namespace Centralita;

public abstract class LLamada
{
    private string numOrigen;
    private string numDestino;
    private double duracion;

    public LLamada(string param1, string param2, double param3)
    {
        numOrigen  = param1;
        numDestino = param2;
        duracion   = param3;
    }

    public string getNumOrigen()
    {
        return numOrigen;
    }

    public string getNumDestino()
    {
        return numDestino;
    }

    public double getDuracion()
    {
        return duracion;
    }

    public abstract double calcularPrecio();
}
