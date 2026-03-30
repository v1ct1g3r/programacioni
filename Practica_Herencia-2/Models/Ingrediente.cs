using System;

namespace Practica_Herencia_2.Models;

public class Ingrediente
{
    public string Nombre { get; }
    public decimal Precio { get; }

    public Ingrediente(string nombre, decimal precio)
    {
        Nombre = nombre;
        Precio = precio;
    }
}
