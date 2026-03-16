using System;
using System.Collections.Generic;

namespace ProyectoAvesAbstracto
{
    public abstract class Ave
    {
        public string Nombre { get; set; }

        protected Ave(string nombre)
        {
            Nombre = nombre;
        }

        public abstract void EmitirSonido();

        public virtual void Moverse()
        {
            Console.WriteLine($"{Nombre} está volando de forma estándar.");
        }
    }

    public class Aguila : Ave
    {
        public Aguila(string nombre) : base(nombre) { }

        public override void EmitirSonido()
        {
            Console.WriteLine($"{Nombre} lanza un grito agudo chillón.");
        }

        public override void Moverse()
        {
            Console.WriteLine($"{Nombre} planea a gran altura buscando presas.");
        }
    }

    public class Avestruz : Ave
    {
        public Avestruz(string nombre) : base(nombre) { }

        public override void EmitirSonido()
        {
            Console.WriteLine($"{Nombre} hace un sonido de siseo y ronquido.");
        }

        public override void Moverse()
        {
            Console.WriteLine($"{Nombre} no vuela, pero corre a 70 km/h.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Ave> santuario = new List<Ave>
            {
                new Aguila("Real"),
                new Avestruz("Speedy")
            };

            foreach (var ave in santuario)
            {
                ave.EmitirSonido();
                ave.Moverse();
                Console.WriteLine("---");
            }
        }
    }
}