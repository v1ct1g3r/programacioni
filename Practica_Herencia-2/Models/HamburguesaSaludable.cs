using System;
using System.Collections.Generic;

namespace Practica_Herencia_2.Models;

public class HamburguesaSaludable : Hamburguesa
{
    private readonly List<Ingrediente> _ingredientesSaludablesExtras;
    private const int MAX_INGREDIENTES_SALUDABLES = 2;

    public HamburguesaSaludable(string carne, decimal precioBase) 
        : base("Pan Integral", carne, precioBase)
    {
        _ingredientesSaludablesExtras = new List<Ingrediente>();
    }

    public void AgregarIngredienteSaludable(string nombre, decimal precio)
    {
        if (_ingredientesSaludablesExtras.Count >= MAX_INGREDIENTES_SALUDABLES)
        {
            Console.WriteLine($"[Aviso] No se pueden agregar más de {MAX_INGREDIENTES_SALUDABLES} ingredientes saludables extras.");
            return;
        }

        _ingredientesSaludablesExtras.Add(new Ingrediente(nombre, precio));
    }

    protected override decimal MostrarIngredientes()
    {
        // Mustra los ingredientes base y acumula el costo
        decimal subtotal = base.MostrarIngredientes();

        // Muestra los ingredientes limitados a saludables y acumula el costo
        foreach (var ingrediente in _ingredientesSaludablesExtras)
        {
            Console.WriteLine($"- Adicional Saludable: {ingrediente.Nombre} -> {ingrediente.Precio:C}");
            subtotal += ingrediente.Precio;
        }

        return subtotal;
    }
}
