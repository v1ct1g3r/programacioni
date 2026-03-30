namespace SistemaPedidos.Core.Models;

public class ProductoFisico : Producto
{
    public decimal PesoKg { get; set; }

    public override string ObtenerDescripcion()
    {
        return $"{Nombre} (Físico) - Peso: {PesoKg} kg - Precio: ${Precio}";
    }
}
