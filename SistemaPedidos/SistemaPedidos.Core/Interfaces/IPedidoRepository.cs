namespace SistemaPedidos.Core.Interfaces;

using Models;

/// <summary>
/// DTO para resumen de pedidos obtenido mediante Dapper
/// </summary>
public class PedidoResumenDTO
{
    public int PedidoId { get; set; }
    public DateTime FechaPedido { get; set; }
    public decimal Total { get; set; }
    public int CantidadProductos { get; set; }
    public string TipoPago { get; set; } = string.Empty;
}

/// <summary>
/// Interfaz que define el contrato para el repositorio de Pedidos
/// </summary>
public interface IPedidoRepository
{
    Task<List<Pedido>> ObtenerTodosAsync();
    Task<Pedido?> ObtenerPorIdAsync(int id);
    Task<int> CrearAsync(Pedido pedido);
    Task ActualizarAsync(Pedido pedido);
    Task EliminarAsync(int id);
    Task<List<PedidoResumenDTO>> ObtenerResumenAsync();
}
