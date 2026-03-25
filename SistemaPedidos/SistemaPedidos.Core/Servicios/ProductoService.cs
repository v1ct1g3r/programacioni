namespace SistemaPedidos.Core.Servicios;

using Models;
using Interfaces;

/// <summary>
/// Servicio de Productos que encapsula la lógica de negocio
/// </summary>
public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Producto>> ObtenerTodosAsync() => _repository.ObtenerTodosAsync();

    public Task<Producto?> ObtenerPorIdAsync(int id) => _repository.ObtenerPorIdAsync(id);

    public Task<int> CrearAsync(Producto producto)
    {
        if (string.IsNullOrWhiteSpace(producto.Nombre))
            throw new ArgumentException("El nombre del producto es requerido");

        if (producto.Precio <= 0)
            throw new ArgumentException("El precio debe ser mayor a 0");

        if (producto.Stock < 0)
            throw new ArgumentException("El stock no puede ser negativo");

        return _repository.CrearAsync(producto);
    }

    public async Task ActualizarAsync(Producto producto)
    {
        if (string.IsNullOrWhiteSpace(producto.Nombre))
            throw new ArgumentException("El nombre del producto es requerido");

        if (producto.Precio <= 0)
            throw new ArgumentException("El precio debe ser mayor a 0");

        if (producto.Stock < 0)
            throw new ArgumentException("El stock no puede ser negativo");

        await _repository.ActualizarAsync(producto);
    }

    public Task EliminarAsync(int id) => _repository.EliminarAsync(id);
}
