namespace SistemaPedidos.Core.Pagos;

/// <summary>
/// Implementación de IPago para pagos en efectivo
/// Estrategia de pago que siempre es exitosa
/// </summary>
public class PagoEfectivo : IPago
{
    public bool Procesar(decimal monto, out string mensaje)
    {
        if (monto <= 0)
        {
            mensaje = "El monto debe ser mayor a 0";
            return false;
        }

        mensaje = $"Pago en efectivo exitoso por ${monto}";
        return true;
    }
}
