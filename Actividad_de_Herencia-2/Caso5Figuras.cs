// Herencia Simple con Abstracción
namespace EjemploHerencia;

public abstract class Figura { public abstract double Area(); }

public class Circulo : Figura {
    public double Radio { get; set; }
    public override double Area() => Math.PI * Math.Pow(Radio, 2);
}