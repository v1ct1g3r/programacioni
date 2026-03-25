namespace SistemaPedidos.Core.Models;

/// <summary>
/// Clase que representa un producto digital
/// Hereda de Producto e agrega propiedades específicas para productos digitales
/// </summary>
public class ProductoDigital : Producto
{
    public string UrlDescarga { get; set; } = string.Empty;

    public override string ObtenerDescripcion()
    {
        return $"{Nombre} (Digital) - Descarga en: {UrlDescarga} - Precio: ${Precio}";
    }
}
