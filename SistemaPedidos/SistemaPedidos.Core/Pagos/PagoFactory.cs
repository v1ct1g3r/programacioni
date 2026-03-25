namespace SistemaPedidos.Core.Pagos;

/// <summary>
/// Factory que crea instancias de IPago según el tipo especificado
/// Implementa el patrón Factory Method
/// </summary>
public static class PagoFactory
{
    /// <summary>
    /// Crea una implementación de IPago según el tipo especificado
    /// </summary>
    /// <param name="tipo">Tipo de pago: "tarjeta" o "efectivo"</param>
    /// <returns>Instancia de IPago correspondiente</returns>
    /// <exception cref="ArgumentException">Si el tipo no es reconocido</exception>
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
