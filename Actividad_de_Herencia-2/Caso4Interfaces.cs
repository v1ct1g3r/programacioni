// Herencia Múltiple con Interfaces
namespace EjemploHerencia;

public interface IImprimible { void Imprimir(); }
public interface IEscaneable { void Escanear(); }

public class MultiFuncional : IImprimible, IEscaneable {
    public void Imprimir() => Console.WriteLine("Imprimiendo...");
    public void Escanear() => Console.WriteLine("Escaneando...");
}