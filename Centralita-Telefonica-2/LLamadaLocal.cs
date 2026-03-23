namespace Centralita;

public class LLamadaLocal : LLamada
{
    private double precio;

    public LLamadaLocal(string param1, string param2, int param3)
        : base(param1, param2, param3)
    {
        precio = 0.15;
    }

    public override double calcularPrecio()
    {
        return precio * getDuracion();
    }

    public override string ToString()
    {
        return "LLamada LOCAL    | Origen: " + getNumOrigen()
             + " -> Destino: "  + getNumDestino()
             + " | Duracion: "  + getDuracion()  + "s"
             + " | Precio: "    + calcularPrecio().ToString("F2") + " eur";
    }
}
