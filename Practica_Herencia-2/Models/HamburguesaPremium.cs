using System;

namespace Practica_Herencia_2.Models;

public class HamburguesaPremium : Hamburguesa
{
    public HamburguesaPremium(string tipoPan, string carne, decimal precioBase) 
        : base(tipoPan, carne, precioBase)
    {
        // La Hamburguesa Premium automáticamente incluye papitas y bebida (su costo ya se contabliza en el precio base).
        AñadirIngredienteInterno("Papitas Premium", 0m);
        AñadirIngredienteInterno("Bebida Premium", 0m);
    }

    public override void AgregarIngrediente(string nombre, decimal precio)
    {
        Console.WriteLine("[Aviso] La Hamburguesa Premium es un combo cerrado. No se permiten ingredientes adicionales.");
    }
}
