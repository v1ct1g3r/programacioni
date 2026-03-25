namespace SistemaPedidos.Core.Interfaces;

using Models;

/// <summary>
/// Interfaz que define el contrato para el repositorio de Productos
/// </summary>
public interface IProductoRepository
{
    Task<List<Producto>> ObtenerTodosAsync();
    Task<Producto?> ObtenerPorIdAsync(int id);
    Task<int> CrearAsync(Producto producto);
    Task ActualizarAsync(Producto producto);
    Task EliminarAsync(int id);
}
