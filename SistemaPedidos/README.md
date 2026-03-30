# Sistema de Pedidos

Aplicación ASP.NET Core MVC que demuestra la implementación de cinco patrones fundamentales de diseño: Singleton, Factory, Strategy, Herencia y Encapsulamiento.

## Tecnologías Utilizadas

- **.NET 8** / **C# 12**
- **ASP.NET Core MVC** con Razor Views
- **Entity Framework Core 8** (ORM con migraciones)
- **Dapper** (para consultas SQL optimizadas)
- **SQL Server** (Base de datos)
- **Bootstrap 5** (Estilos UI)

## Patrones de Diseño

### 1. **SINGLETON** - `GestorSistema.cs`
- Implementación thread-safe con `Lazy<T>`
- Gestor centralizado del sistema
- Contador de pedidos con `Interlocked.Increment`
- Propiedades de solo lectura: `NombreSistema`, `Version`, `FechaInicio`

### 2. **FACTORY** - `PagoFactory.cs`
- Patrón Factory Method para crear estrategias de pago
- Método estático `Crear(string tipo)` que retorna `IPago`
- Soporta: "tarjeta" y "efectivo"

### 3. **STRATEGY** - `IPago`, `PagoTarjeta`, `PagoEfectivo`
- Interfaz `IPago` define el contrato
- Múltiples estrategias de procesamiento de pagos
- Cada estrategia con lógica de validación específica

### 4. **HERENCIA** - `Producto`, `ProductoFisico`, `ProductoDigital`
- Clase abstracta `Producto` con método abstracto `ObtenerDescripcion()`
- Dos implementaciones concretas
- Usa herencia TPH (Table Per Hierarchy) en EF Core

### 5. **ENCAPSULAMIENTO** - `Pedido.cs`
- Campo privado `_estado` con propiedad de solo lectura `Estado`
- Lista privada `_items` expuesta como `IReadOnlyList<ItemPedido>`
- Métodos de validación: `SetEstado()`, `AgregarItem()`, `CalcularTotal()`
- Validaciones de transición de estado

## Estructura de Base de Datos

La aplicación crea automáticamente 4 tablas vía migraciones EF Core:

```sql
-- Tabla de Productos (TPH inheritance)
Productos
├── Id (PK)
├── Nombre
├── Precio
├── Stock
├── TipoProducto (enum discriminator)
├── PesoKg (nullable - ProductoFisico)
└── UrlDescarga (nullable - ProductoDigital)

-- Tabla de Pedidos
Pedidos
├── Id (PK)
├── FechaPedido
├── Estado (enum)
├── Total
└── TipoPago

-- Tabla Pivote (relación M2M)
ItemsPedidos
├── Id (PK)
├── PedidoId (FK)
├── ProductoId (FK)
├── Cantidad
└── PrecioUnitario

-- Tabla de Pagos (histórico)
Pagos
├── Id (PK)
├── TipoPago
├── Monto
├── FechaPago
└── Estado
```

## Instalación

### **Paso 1: Configurar la Cadena de Conexión**

Editar `SistemaPedidos.Web/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=SistemaPedidosDb;Trusted_Connection=true;"
  }
}
```

**Opciones de servidor:**
- **SQL Server Local**: `(localdb)\mssqllocaldb`
- **SQL Server Express**: `.\SQLEXPRESS`
- **SQL Server remoto**: `server.instance.net`

### **Paso 2: Instalar Entity Framework Tools**

```bash
dotnet tool install --global dotnet-ef
```

### **Paso 3: Crear y Aplicar Migraciones**

Navegar a la carpeta `SistemaPedidos.Web`:

```bash
cd SistemaPedidos.Web

# Crear migración inicial
dotnet ef migrations add InitialCreate --project ../SistemaPedidos.Data

# Aplicar migración a la BD
dotnet ef database update --project ../SistemaPedidos.Data
```

### **Paso 4: Restaurar Dependencias y Compilar**

```bash
dotnet restore
dotnet build
```

### **Paso 5: Ejecutar la Aplicación**

```bash
dotnet run --project SistemaPedidos.Web
```

La aplicación estará disponible en:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:7000`

## Estructura de Carpetas

```
SistemaPedidos/
├── SistemaPedidos.sln                  (Archivo de solución)
│
├── SistemaPedidos.Core/                (Capa de Lógica de Negocio)
│   ├── Models/
│   │   ├── Producto.cs                 (Clase abstracta)
│   │   ├── ProductoFisico.cs           (Herencia)
│   │   ├── ProductoDigital.cs          (Herencia)
│   │   ├── Pedido.cs                   (Encapsulamiento real)
│   │   ├── ItemPedido.cs
│   │   ├── EstadoPedido.cs
│   │   └── TipoProducto.cs
│   │
│   ├── Pagos/                          (Patrones Strategy + Factory)
│   │   ├── IPago.cs
│   │   ├── PagoTarjeta.cs
│   │   ├── PagoEfectivo.cs
│   │   └── PagoFactory.cs
│   │
│   ├── Servicios/
│   │   ├── IProductoService.cs
│   │   ├── ProductoService.cs
│   │   ├── IPedidoService.cs
│   │   └── PedidoService.cs
│   │
│   ├── Interfaces/
│   │   ├── IProductoRepository.cs
│   │   └── IPedidoRepository.cs
│   │
│   └── Singleton/
│       └── GestorSistema.cs            (Thread-safe con Lazy<T>)
│
├── SistemaPedidos.Data/                (Capa de Acceso a Datos)
│   ├── AppDbContext.cs                 (DbContext de EF Core)
│   ├── Repositories/
│   │   ├── ProductoRepository.cs       (Patrón Repository)
│   │   └── PedidoRepository.cs         (Con Dapper)
│   └── Migrations/                     (Generadas automáticamente)
│
└── SistemaPedidos.Web/                 (Capa de Presentación)
    ├── Program.cs                      (Configuración DI)
    ├── appsettings.json
    ├── Controllers/
    │   ├── ProductosController.cs
    │   └── PedidosController.cs
    ├── Views/
    │   ├── Shared/
    │   │   └── _Layout.cshtml
    │   ├── Productos/
    │   │   ├── Index.cshtml
    │   │   └── Crear.cshtml
    │   └── Pedidos/
    │       ├── Index.cshtml
    │       ├── Crear.cshtml
    │       └── Detalle.cshtml
    ├── ViewModels/
    │   ├── CrearProductoVM.cs
    │   └── CrearPedidoVM.cs
    └── Properties/
        └── launchSettings.json
```

## Flujo de la Aplicación

1. **Visualizar Productos** → `/Productos`
   - Lista de todos los productos (físicos y digitales)
   - Opción para crear nuevos

2. **Crear Producto** → `/Productos/Crear`
   - Formulario dinámico (campos condicionales según tipo)
   - Validaciones en lado cliente y servidor

3. **Crear Pedido** → `/Pedidos/Crear`
   - Seleccionar productos con cantidades
   - Elegir método de pago
   - Validación de stock

4. **Procesar Pago**
   - `PagoFactory.Crear()` instancia la estrategia
   - `IPago.Procesar()` valida el monto

5. **Cambiar Estado**
   - `Pedido.SetEstado()` valida transiciones
   - Pendiente → Procesado/Cancelado

6. **Ver Resumen** → `/Pedidos`
   - Query Dapper con JOIN
   - Información agregada de pedidos

7. **Detalle del Pedido** → `/Pedidos/Detalle/{id}`
   - Información completa con items

## Datos de Prueba

La BD se inicializa automáticamente con 3 productos:

1. **Laptop Dell XPS** (Físico)
   - Precio: $1,200
   - Stock: 5 unidades
   - Peso: 2.5 kg

2. **Mouse Logitech** (Físico)
   - Precio: $30
   - Stock: 50 unidades
   - Peso: 0.1 kg

3. **Visual Studio Professional** (Digital)
   - Precio: $499.99
   - Stock: 999 unidades
   - URL: https://download.microsoft.com/vspr

## Inyección de Dependencias

```csharp
// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repositorios
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// Servicios
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

// GestorSistema NO se registra (Singleton propio)
```

## Ejemplos de Uso

### Crear un Producto Físico
```
POST /Productos/Crear
Nombre: Teclado Mecánico
Precio: 150.00
Stock: 10
Tipo: Físico
PesoKg: 1.2
```

### Crear un Pedido
```
POST /Pedidos/Crear
ProductosSeleccionados: [1, 2]
Cantidades[1]: 2
Cantidades[2]: 5
TipoPago: tarjeta
```

### Validaciones de Pago
- **Tarjeta**: Monto debe estar entre $0.01 y $49,999.99
- **Efectivo**: Siempre acepta montos válidos > $0

## Manejo de Errores

La aplicación incluye:
- Validaciones en modelos (Data Annotations)
- Validaciones en servicios
- Manejo de excepciones en Controllers
- Mensajes de error en `TempData`
- Retroalimentación al usuario vía Bootstrap alerts

## Documentación del Código

Todas las clases que implementan patrones incluyen comentarios XML (///) para:
- Documentación automática
- IntelliSense en Visual Studio
- Generación de documentación

## Consideraciones de Seguridad

- Usar migraciones en entornos de producción
- Encriptar connection strings
- Validar entrada de usuario
- Implementar autenticación/autorización según sea necesario

## Referencias

- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core/)
- [ASP.NET Core MVC](https://docs.microsoft.com/aspnet/core/mvc/)
- [C# Design Patterns](https://refactoring.guru/design-patterns/csharp)
- [Dapper Documentation](https://github.com/DapperLib/Dapper)

---

**Autor**: Víctor Olmo  
**Versión**: 1.5  
**Última actualización**: 2026
