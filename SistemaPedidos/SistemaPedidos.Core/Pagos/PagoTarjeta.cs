namespace SistemaPedidos.Core.Pagos;

public class PagoTarjeta : IPago
{
    public bool Procesar(decimal monto, out string mensaje)
    {
        if (monto <= 0)
        {
            mensaje = "El monto debe ser mayor a 0";
            return false;
        }

        if (monto >= 50000)
        {
            mensaje = "El monto excede el límite de transacción por tarjeta (50000)";
            return false;
        }

        mensaje = $"Pago con tarjeta exitoso por ${monto}";
        return true;
    }
}
