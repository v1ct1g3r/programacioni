# 🚀 GUÍA RÁPIDA - Sistema de Pedidos

## Inicio Rápido (5 Pasos)

### 1️⃣ Abrir la Solución
```bash
# En Visual Studio
File → Open → SistemaPedidos.sln
```

### 2️⃣ Configurar Base de Datos (appsettings.json)
Editar archivo: `SistemaPedidos.Web/appsettings.json`

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SistemaPedidosDb;Trusted_Connection=true;"
}
```

### 3️⃣ Crear Migraciones e Inicializar BD
```bash
cd SistemaPedidos.Web

# Instalar Entity Framework CLI (si no está)
dotnet tool install --global dotnet-ef

# Crear migración
dotnet ef migrations add InitialCreate --project ../SistemaPedidos.Data

# Ejecutar migración
dotnet ef database update --project ../SistemaPedidos.Data
```

### 4️⃣ Restaurar y Compilar
```bash
dotnet restore
dotnet build
```

### 5️⃣ Ejecutar Aplicación
```bash
dotnet run
```

Accede a: **http://localhost:5000**

---

## 📚 Patrones de Diseño Implementados

### 🔹 **SINGLETON** - Gestor Central
- **Ubicación**: `SistemaPedidos.Core/Singleton/GestorSistema.cs`
- **Características**:
  - Thread-safe con `Lazy<T>`
  - Contador de pedidos con `Interlocked.Increment`
  - Acceso: `GestorSistema.Instancia`

### 🔸 **FACTORY** - Creación de Pagos
- **Ubicación**: `SistemaPedidos.Core/Pagos/PagoFactory.cs`
- **Uso**:
  ```csharp
  var pago = PagoFactory.Crear("tarjeta");
  pago.Procesar(100.00m, out var mensaje);
  ```

### 🔻 **STRATEGY** - Estrategias de Pago
- **Ubicación**: `SistemaPedidos.Core/Pagos/`
  - `PagoTarjeta`: Límite de $50,000
  - `PagoEfectivo`: Sin límite
- **Interfaz**: `IPago.Procesar(decimal monto, out string mensaje)`

### 🔺 **HERENCIA** - Jerarquía de Productos
- **Ubicación**: `SistemaPedidos.Core/Models/`
  - `Producto` (abstracta): Base común
  - `ProductoFisico`: Con peso
  - `ProductoDigital`: Con URL de descarga

### ◆ **ENCAPSULAMIENTO** - Validaciones de Pedido
- **Ubicación**: `SistemaPedidos.Core/Models/Pedido.cs`
- **Características**:
  - Estado privado `_estado`, expuesto como `Estado` (solo lectura)
  - Lista privada `_items`, expuesta como `IReadOnlyList<ItemPedido>`
  - Validaciones en `SetEstado()` y `AgregarItem()`

---

## 🗂️ Estructura de Archivos Clave

```
SistemaPedidos/
├── SistemaPedidos.Core/        ← Lógica de Negocio
│   ├── Models/                 (Entidades + Enums)
│   ├── Pagos/                  (Strategy + Factory)
│   ├── Servicios/              (Lógica de negocio)
│   ├── Interfaces/             (Contratos)
│   └── Singleton/              (GestorSistema)
│
├── SistemaPedidos.Data/        ← Acceso a Datos
│   ├── AppDbContext.cs         (EF Core)
│   └── Repositories/           (CRUD + Dapper)
│
└── SistemaPedidos.Web/         ← Presentación
    ├── Program.cs              (Configuración DI)
    ├── Controllers/            (Lógica de rutas)
    ├── ViewModels/             (DTOs para vistas)
    └── Views/                  (Razor templates)
```

---

## 🧪 Casos de Prueba

### ✅ Crear Producto Físico
```
1. Ir a /Productos
2. Clic en "+ Nuevo Producto"
3. Seleccionar "Físico"
4. Ingresar datos:
   - Nombre: "Monitor Samsung 4K"
   - Precio: 450.00
   - Stock: 15
   - Peso: 3.2 kg
5. Crear → Debe aparecer en la lista
```

### ✅ Crear Pedido
```
1. Ir a /Pedidos/Crear
2. Seleccionar 2+ productos
3. Ingresar cantidades
4. Elegir método de pago ("tarjeta" o "efectivo")
5. Procesar → Redirige a Detalle
```

### ✅ Validar Límites de Pago
```
Tarjeta:
  - Rechaza: $0 o $50,000+
  - Acepta: $0.01 - $49,999.99

Efectivo:
  - Siempre acepta (excepto $0)
```

---

## 🔧 Comandos Útiles

```bash
# Crear nueva migración
dotnet ef migrations add NombreMigracion --project ../SistemaPedidos.Data

# Revertir última migración
dotnet ef database update [NombreMigracionAnterior] --project ../SistemaPedidos.Data

# Eliminar última migración no aplicada
dotnet ef migrations remove --project ../SistemaPedidos.Data

# Ver script SQL de migraciones
dotnet ef migrations script --project ../SistemaPedidos.Data

# Compilar solo un proyecto
dotnet build SistemaPedidos.Core/

# Ejecutar modo watch (recompila al cambiar archivos)
dotnet watch run
```

---

## ⚠️ Problemas Comunes

### "dotnet: command not found"
- Instalar .NET 8 SDK desde https://dotnet.microsoft.com/download

### "Connection timeout"
- Verificar que SQL Server está corriendo
- Validar connection string en appsettings.json

### "Migration not found"
- Verificar que se creó la migración: `dotnet ef migrations list`
- Volver a crear: `dotnet ef migrations add InitialCreate`

### Errores de validación en vista
- Revisar `ModelState.IsValid` en Controller
- Verificar atributos `[Required]` en ViewModels

---

## 📖 Documentación Completa

Ver **README.md** para:
- Descripción detallada de cada patrón
- Estructura de base de datos
- Flujo completo de la aplicación
- Referencias y recursos

---

## 🎯 Próximos Pasos

1. **Explorar el código**: Revisar cada patrón de diseño
2. **Modificar datos semilla**: Editar `AppDbContext.OnModelCreating()`
3. **Agregar validaciones**: Mejorar lógica de negocio en Servicios
4. **Autenticación**: Implementar Identity en `Program.cs`
5. **Tests**: Crear proyecto `SistemaPedidos.Tests` con xUnit

---

Para dudas o problemas, revisar el README.md completo.
