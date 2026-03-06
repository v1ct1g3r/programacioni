namespace PracticaPOO
{
    public class Motor
    {
        private int litros_de_aceite, potencia;
        public Motor(int potencia)
        {
            this.potencia = potencia;
            litros_de_aceite = 0;
        }
        public int Litros_de_aceite
        {
            get { return litros_de_aceite; }
            set { litros_de_aceite = value; }
        }
        public int Potencia
        {
            get { return potencia; }
            set { potencia = value; }
        }
    }

    public class Coche
    {
        private Motor motor;
        private string marca, modelo;
        private double precio_de_averias;
        public Coche(string marca, string modelo)
        {
            Random rnd = new();
            motor = new(rnd.Next());
            this.marca = marca;
            this.modelo = modelo;
            precio_de_averias = 0;
        }
        public Motor Motor { get { return motor; } }
        public string Marca { get { return marca; } }
        public string Modelo { get { return modelo; } }
        public double Precio_de_averias { get { return precio_de_averias; } }
        public void AcumularAveria(double importe)
        {
            precio_de_averias += importe;
        }
    }

    public class Garaje
    {
        private Coche? coche;
        private string? averia_asociada;
        private int coches_atendiendose = 0;
        public string? Averia_asociada { get { return averia_asociada; } }
        public bool AceptarCoche(Coche coche, string averia_asociada)
        {
            if (coches_atendiendose > 0) return false;
            this.coche = coche;
            this.averia_asociada = averia_asociada;
            coches_atendiendose++;
            return true;
        }
        public void DevolverCoche()
        {
            coches_atendiendose--;
        }
    }

    public class PracticaPOO
    {
        public static void Main()
        {
            Garaje garaje = new();
            Coche coche1 = new("Bugatti", "Chiron");
            Coche coche2 = new("Lamborghini", "Aventador");
            Random rnd = new();
            for (int i = 0; i < 2; i++)
            {
                if (garaje.AceptarCoche(coche1, "aceite"))
                {
                    coche1.AcumularAveria(rnd.NextDouble());
                    if (garaje.Averia_asociada == "aceite")
                        coche1.Motor.Litros_de_aceite += 10;
                    garaje.DevolverCoche();
                }
                if (garaje.AceptarCoche(coche2, "goma"))
                {
                    coche2.AcumularAveria(rnd.NextDouble());
                    if (garaje.Averia_asociada == "aceite")
                        coche2.Motor.Litros_de_aceite += 10;
                    garaje.DevolverCoche();
                }
            }
            Console.WriteLine("============= Información de los coches =============");
            Console.WriteLine($"Coche 1: {coche1.Marca} {coche1.Modelo}");
            Console.WriteLine($"Precio de averías: {coche1.Precio_de_averias}");
            Console.WriteLine($"Coche 2: {coche2.Marca} {coche2.Modelo}");
            Console.WriteLine($"Precio de averías: {coche2.Precio_de_averias}");
        }
    }
}