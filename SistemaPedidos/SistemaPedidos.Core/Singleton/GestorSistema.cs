using System.Threading;

namespace SistemaPedidos.Core.Singleton;

/// <summary>
/// Class que implementa el patrón Singleton thread-safe con Lazy<T>
/// Gestiona información global del sistema de forma centralizada
/// </summary>
public class GestorSistema
{
    private static readonly Lazy<GestorSistema> _instancia = new(() => new GestorSistema());
    private int _contadorPedidos = 0;

    public string NombreSistema { get; } = "Sistema de Pedidos";
    public string Version { get; } = "1.0.0";
    public DateTime FechaInicio { get; } = DateTime.Now;

    public int ContadorPedidos => _contadorPedidos;

    /// <summary>
    /// Propiedad estática que proporciona acceso a la única instancia de GestorSistema
    /// </summary>
    public static GestorSistema Instancia => _instancia.Value;

    /// <summary>
    /// Constructor privado para evitar instanciación directa
    /// </summary>
    private GestorSistema() { }

    /// <summary>
    /// Incrementa el contador de pedidos de forma thread-safe
    /// </summary>
    public void IncrementarContadorPedidos()
    {
        Interlocked.Increment(ref _contadorPedidos);
    }
}
