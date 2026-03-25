namespace SistemaPedidos.Core.Servicios;

using Models;

/// <summary>
/// Interfaz que define el contrato para el servicio de Productos
/// </summary>
public interface IProductoService
{
    Task<List<Producto>> ObtenerTodosAsync();
    Task<Producto?> ObtenerPorIdAsync(int id);
    Task<int> CrearAsync(Producto producto);
    Task ActualizarAsync(Producto producto);
    Task EliminarAsync(int id);
}
