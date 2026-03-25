namespace SistemaPedidos.Core.Models;

/// <summary>
/// Clase que representa un Pedido en el sistema
/// Implementa encapsulamiento real con campos privados y validaciones
/// </summary>
public class Pedido
{
    private EstadoPedido _estado = EstadoPedido.Pendiente;
    private List<ItemPedido> _items = new();

    public int Id { get; set; }
    public DateTime FechaPedido { get; set; } = DateTime.Now;
    public string TipoPago { get; set; } = string.Empty;
    public decimal Total { get; set; }

    public EstadoPedido Estado => _estado;

    public IReadOnlyList<ItemPedido> Items => _items.AsReadOnly();

    /// <summary>
    /// Propiedad de navegación para EF Core — no usar en lógica de negocio
    /// </summary>
    public List<ItemPedido> ItemsNavigation
    {
        get => _items;
        set => _items = value;
    }

    public void SetEstado(EstadoPedido nuevoEstado)
    {
        if (_estado == EstadoPedido.Pendiente && (nuevoEstado == EstadoPedido.Procesado || nuevoEstado == EstadoPedido.Cancelado))
        {
            _estado = nuevoEstado;
        }
        else if (_estado != EstadoPedido.Pendiente)
        {
            throw new InvalidOperationException($"No se puede cambiar el estado de {_estado} a {nuevoEstado}");
        }
    }

    public void AgregarItem(Producto producto, int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a 0");

        if (producto.Stock < cantidad)
            throw new InvalidOperationException($"Stock insuficiente para {producto.Nombre}. Disponible: {producto.Stock}");

        var itemExistente = _items.FirstOrDefault(i => i.ProductoId == producto.Id);
        if (itemExistente != null)
        {
            itemExistente.Cantidad += cantidad;
        }
        else
        {
            _items.Add(new ItemPedido
            {
                ProductoId = producto.Id,
                Producto = producto,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio
            });
        }
    }

    public void CalcularTotal()
    {
        Total = _items.Sum(item => item.Cantidad * item.PrecioUnitario);
    }
}