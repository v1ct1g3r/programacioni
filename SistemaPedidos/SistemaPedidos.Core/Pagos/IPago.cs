namespace SistemaPedidos.Core.Pagos;

public interface IPago
{
    bool Procesar(decimal monto, out string mensaje);
}
