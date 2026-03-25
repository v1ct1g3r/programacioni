namespace SistemaPedidos.Web.ViewModels;

/// <summary>
/// ViewModel para crear pedidos
/// </summary>
public class CrearPedidoVM
{
    public List<int> ProductosSeleccionados { get; set; } = new();
    public Dictionary<int, int> Cantidades { get; set; } = new();
    public string TipoPago { get; set; } = "tarjeta"; // "tarjeta" o "efectivo"
}
