namespace SistemaPedidos.Core.Pagos;

/// <summary>
/// Interfaz que define el contrato para procesamiento de pagos
/// Implementa el patrón Strategy
/// </summary>
public interface IPago
{
    /// <summary>
    /// Procesa un pago del monto especificado
    /// </summary>
    /// <param name="monto">Monto a procesar</param>
    /// <param name="mensaje">Mensaje de resultado del procesamiento</param>
    /// <returns>True si el pago fue exitoso, false en caso contrario</returns>
    bool Procesar(decimal monto, out string mensaje);
}
