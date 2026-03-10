// Herencia Multinivel
namespace EjemploHerencia;

// Nivel 1: Clase Base
public class Vehiculo { public void Arrancar() => Console.WriteLine("Vehículo encendido."); }

// Nivel 2: Clase Derivada de Vehículo
public class Automovil : Vehiculo { public int Puertas { get; set; } }

// Nivel 3: Clase Derivada de Automóvil
public class VehiculoElectrico : Automovil { public void Cargar() => Console.WriteLine("Cargando..."); }