namespace SistemaPedidos.Core.Models;

/// <summary>
/// Clase abstracta base que implementa el patrón de herencia
/// Define propiedades comunes para todos los productos
/// </summary>
public abstract class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    /// <summary>
    /// Método abstracto que deve ser implementado por las clases derivadas
    /// </summary>
    public abstract string ObtenerDescripcion();
}
