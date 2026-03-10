// Herencia Jerárquica
namespace EjemploHerencia;

// Clase Base
public class Animal { public string? Nombre { get; set; } }

// Clase Derivada 1
public class Perro : Animal { public void Ladrar() => Console.WriteLine($"{Nombre} dice: ¡Guau!"); }

// Clase Derivada 2
public class Gato : Animal { public void Maullar() => Console.WriteLine($"{Nombre} dice: ¡Miau!"); }