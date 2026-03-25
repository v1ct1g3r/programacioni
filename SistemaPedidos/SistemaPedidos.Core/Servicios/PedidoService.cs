namespace SistemaPedidos.Core.Servicios;

using Models;
using Interfaces;
using Singleton;

/// <summary>
/// Servicio de Pedidos que encapsula la lógica de negocio
/// </summary>
public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;

    public PedidoService(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Pedido>> ObtenerTodosAsync() => _repository.ObtenerTodosAsync();

    public Task<Pedido?> ObtenerPorIdAsync(int id) => _repository.ObtenerPorIdAsync(id);

    public async Task<int> CrearAsync(Pedido pedido)
    {
        if (pedido.Items.Count == 0)
            throw new ArgumentException("El pedido debe contener al menos un producto");

        pedido.CalcularTotal();

        if (pedido.Total <= 0)
            throw new ArgumentException("El total del pedido debe ser mayor a 0");

        var id = await _repository.CrearAsync(pedido);

        // Incrementar el contador global de pedidos
        GestorSistema.Instancia.IncrementarContadorPedidos();

        return id;
    }

    public async Task ActualizarAsync(Pedido pedido)
    {
        if (pedido.Items.Count == 0)
            throw new ArgumentException("El pedido debe contener al menos un producto");

        pedido.CalcularTotal();

        await _repository.ActualizarAsync(pedido);
    }

    public Task EliminarAsync(int id) => _repository.EliminarAsync(id);

    public Task<List<PedidoResumenDTO>> ObtenerResumenAsync() => _repository.ObtenerResumenAsync();
}
