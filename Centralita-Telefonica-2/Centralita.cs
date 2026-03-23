namespace Centralita;

public class Centralita
{
    private int cont;
    private double acum;

    public Centralita()
    {
        cont = 0;
        acum = 0.0;
    }

    public int getTotalLLamadas()
    {
        return cont;
    }

    public double getTotalFacturado()
    {
        return acum;
    }

    public void registrarLLamada(LLamada param)
    {
        Console.WriteLine(param.ToString());

        cont = cont + 1;
        acum = acum + param.calcularPrecio();
    }
}
