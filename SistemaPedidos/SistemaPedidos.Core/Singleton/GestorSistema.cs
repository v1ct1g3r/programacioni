using System.Threading;

namespace SistemaPedidos.Core.Singleton;

public class GestorSistema
{
    private static readonly Lazy<GestorSistema> _instancia = new(() => new GestorSistema());
    private int _contadorPedidos = 0;

    public string NombreSistema { get; } = "Sistema de Pedidos";
    public string Version { get; } = "1.5.0";
    public DateTime FechaInicio { get; } = DateTime.Now;

    public int ContadorPedidos => _contadorPedidos;

    public static GestorSistema Instancia => _instancia.Value;

    private GestorSistema() { }

    public void IncrementarContadorPedidos()
    {
        Interlocked.Increment(ref _contadorPedidos);
    }
}
