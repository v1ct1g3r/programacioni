using System;
using System.Collections.Generic;

namespace Practica_Herencia_2.Models;

public class Hamburguesa
{
    public string TipoPan { get; private set; }
    public string Carne { get; private set; }
    public decimal PrecioBase { get; private set; }

    private readonly List<Ingrediente> _ingredientesAdicionales;
    private const int MAX_INGREDIENTES = 4;

    public Hamburguesa(string tipoPan, string carne, decimal precioBase)
    {
        TipoPan = tipoPan;
        Carne = carne;
        PrecioBase = precioBase;
        _ingredientesAdicionales = new List<Ingrediente>();
    }

    protected void AñadirIngredienteInterno(string nombre, decimal precio)
    {
        _ingredientesAdicionales.Add(new Ingrediente(nombre, precio));
    }

    public virtual void AgregarIngrediente(string nombre, decimal precio)
    {
        if (_ingredientesAdicionales.Count >= MAX_INGREDIENTES)
        {
            Console.WriteLine($"[Aviso] No se pueden agregar más de {MAX_INGREDIENTES} ingredientes a la {FormatearNombreClase()}.");
            return;
        }

        AñadirIngredienteInterno(nombre, precio);
    }

    public void MostrarPrecio()
    {
        Console.WriteLine($"\n--- Detalle de {FormatearNombreClase()} ---");
        Console.WriteLine($"- Precio Base ({TipoPan}, {Carne}): {PrecioBase:C}");
        
        decimal total = PrecioBase;
        total += MostrarIngredientes();

        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"Total a pagar: {total:C}");
    }

    protected virtual decimal MostrarIngredientes()
    {
        decimal subtotal = 0;
        foreach (var ingrediente in _ingredientesAdicionales)
        {
            Console.WriteLine($"- Adicional: {ingrediente.Nombre} -> {ingrediente.Precio:C}");
            subtotal += ingrediente.Precio;
        }
        return subtotal;
    }

    private string FormatearNombreClase()
    {
        string nombreReal = this.GetType().Name;
        if (nombreReal.Contains("Saludable")) return "Hamburguesa Saludable";
        if (nombreReal.Contains("Premium")) return "Hamburguesa Premium";
        return "Hamburguesa Clásica";
    }
}
