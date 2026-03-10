// Herencia Simple
namespace EjemploHerencia;

// Clase Base
public class Empleado {
    public string? Nombre { get; set; }
    public decimal SalarioBase { get; set; }
}

// Clase Derivada
public class Gerente : Empleado {
    public decimal Bono { get; set; }
    public void MostrarSueldo() => Console.WriteLine($"{Nombre} gana: {SalarioBase + Bono:C}");
}