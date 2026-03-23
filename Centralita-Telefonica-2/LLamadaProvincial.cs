namespace Centralita;

public class LLamadaProvincial : LLamada
{

    private double precio1;
    private double precio2;
    private double precio3;
    private int franja;

    public LLamadaProvincial(string param1, string param2, int param3, int param4)
        : base(param1, param2, param3)
    {
        precio1 = 0.20;
        precio2 = 0.25;
        precio3 = 0.30;
        franja  = param4;
    }

    public override double calcularPrecio()
    {
        double precioSegundo;

        if (franja == 1)
        {
            precioSegundo = precio1;
        }
        else if (franja == 2)
        {
            precioSegundo = precio2;
        }
        else
        {
            precioSegundo = precio3;
        }

        return precioSegundo * getDuracion();
    }

    public override string ToString()
    {
        return "LLamada PROVINCIAL | Origen: " + getNumOrigen()
             + " -> Destino: "   + getNumDestino()
             + " | Duracion: "   + getDuracion()  + "s"
             + " | Franja: "     + franja
             + " | Precio: "     + calcularPrecio().ToString("F2") + " eur";
    }
}
