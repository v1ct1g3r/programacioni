namespace SistemaPedidos.Web.ViewModels;

/// <summary>
/// ViewModel para crear productos (físicos o digitales)
/// </summary>
public class CrearProductoVM
{
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Tipo { get; set; } = "Fisico"; // "Fisico" o "Digital"

    // Propiedades específicas para producto físico
    public decimal PesoKg { get; set; }

    // Propiedades específicas para producto digital
    public string UrlDescarga { get; set; } = string.Empty;
}
