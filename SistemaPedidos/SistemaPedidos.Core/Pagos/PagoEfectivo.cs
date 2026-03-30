namespace SistemaPedidos.Core.Pagos;

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
