using System;
using EjemploHerencia;

Console.WriteLine("--- Ejecutando Pruebas de Herencia ---");

// Uso del Caso 1
Gerente g = new Gerente { Nombre = "Ana", SalarioBase = 3000, Bono = 500 };
g.MostrarSueldo();

// Uso del Caso 5
Circulo c = new Circulo { Radio = 10 };
Console.WriteLine($"Área del círculo: {c.Area():F2}");