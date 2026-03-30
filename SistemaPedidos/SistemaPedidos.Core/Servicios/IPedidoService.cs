namespace SistemaPedidos.Core.Servicios;

using Models;
using Interfaces;

public interface IPedidoService
{
    Task<List<Pedido>> ObtenerTodosAsync();
    Task<Pedido?> ObtenerPorIdAsync(int id);
    Task<int> CrearAsync(Pedido pedido);
    Task ActualizarAsync(Pedido pedido);
    Task EliminarAsync(int id);
    Task<List<PedidoResumenDTO>> ObtenerResumenAsync();
}
