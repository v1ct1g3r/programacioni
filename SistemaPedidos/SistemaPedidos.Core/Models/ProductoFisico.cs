namespace SistemaPedidos.Core.Models;

/// <summary>
/// Clase que representa un producto físico
/// Hereda de Producto e agrega propiedades específicas para productos físicos
/// </summary>
public class ProductoFisico : Producto
{
    public decimal PesoKg { get; set; }

    public override string ObtenerDescripcion()
    {
        return $"{Nombre} (Físico) - Peso: {PesoKg} kg - Precio: ${Precio}";
    }
}
