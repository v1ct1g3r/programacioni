using System;
using System.Text;
using Practica_Herencia_2.Models;

namespace Practica_Herencia_2;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.WriteLine("======================================================");
        Console.WriteLine("  Bienvenido a Chimi MiBarriga del Sr. Billy Navaja   ");
        Console.WriteLine("======================================================");

        // 1. Hamburguesa Clásica
        Hamburguesa clasica = new Hamburguesa("Pan de Ajonjolí", "Res Premium", 150m);
        clasica.AgregarIngrediente("Lechuga", 15m);
        clasica.AgregarIngrediente("Tomate", 10m);
        clasica.AgregarIngrediente("Queso Cheddar", 25m);
        clasica.AgregarIngrediente("Bacon", 30m);
        
        // Intentar agregar uno más (no debería permitirlo)
        clasica.AgregarIngrediente("Pepinillos", 15m);
        
        clasica.MostrarPrecio();

        Console.WriteLine("\n");

        // 2. Hamburguesa Saludable
        HamburguesaSaludable saludable = new HamburguesaSaludable("Pollo a la Plancha", 180m);
        
        // Primeros 4 normales (Heredados de clase base)
        saludable.AgregarIngrediente("Aguacate", 40m);
        saludable.AgregarIngrediente("Espinaca", 15m);
        saludable.AgregarIngrediente("Cebolla Morada", 10m);
        saludable.AgregarIngrediente("Queso Panela", 35m);
        
        // Procesamiento de los 2 adicionales saludables (Propios de la clase)
        saludable.AgregarIngredienteSaludable("Semillas de Girasol", 20m);
        saludable.AgregarIngredienteSaludable("Aceite de Oliva", 15m);
        
        // Intentar agregar un tercer ingrediente saludable (no debería permitirlo)
        saludable.AgregarIngredienteSaludable("Champiñones", 25m);
        
        saludable.MostrarPrecio();

        Console.WriteLine("\n");

        // 3. Hamburguesa Premium
        HamburguesaPremium premium = new HamburguesaPremium("Pan Brioche", "Carne Angus", 350m);
        
        // Intentar agregar ingredientes (no debería permitirlo)
        premium.AgregarIngrediente("Huevo frito", 25m);
        
        premium.MostrarPrecio();

        Console.WriteLine("\n======================================================");
        Console.WriteLine("        ¡Gracias por su visita a Chimi MiBarriga!     ");
        Console.WriteLine("======================================================");
    }
}
