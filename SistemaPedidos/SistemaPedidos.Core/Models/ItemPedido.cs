namespace SistemaPedidos.Core.Models;

/// <summary>
/// Clase que representa un ítem dentro de un pedido
/// Es la relación muchos-a-muchos entre Pedido y Producto
/// </summary>
public class ItemPedido
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    // Propiedades de navegación
    public Pedido? Pedido { get; set; }
    public Producto? Producto { get; set; }
}
