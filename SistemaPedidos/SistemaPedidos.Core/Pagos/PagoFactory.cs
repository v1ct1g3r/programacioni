namespace SistemaPedidos.Core.Pagos;

public static class PagoFactory
{
    public static IPago Crear(string tipo)
    {
        return tipo.ToLower() switch
        {
            "tarjeta" => new PagoTarjeta(),
            "efectivo" => new PagoEfectivo(),
            _ => throw new ArgumentException($"Tipo de pago no reconocido: {tipo}. Use 'tarjeta' o 'efectivo'")
        };
    }
}
