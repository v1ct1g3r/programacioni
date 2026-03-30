using System;

class BusRoute
{
    public string BusName { get; }
    public int Capacity { get; }
    public decimal TicketPrice { get; }
    public int Passengers { get; private set; }

    public BusRoute(string busName, int capacity, decimal ticketPrice)
    {
        BusName = busName;
        Capacity = capacity;
        TicketPrice = ticketPrice;
    }

    public void RegisterPassengers(int count)
    {
        if (Passengers + count <= Capacity)
        {
            Passengers += count;
        }
    }

    public string GetSummary()
    {
        var sales = Math.Round(Passengers * TicketPrice);
        var availableSeats = Capacity - Passengers;
        return $"Auto Bus {BusName} {Passengers} Pasajeros Ventas {sales:N0} quedan {availableSeats} asientos disponibles";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var route1 = new BusRoute("Plantinum", 22, 1000m);
        route1.RegisterPassengers(5);

        var route2 = new BusRoute("Gold", 15, 1333.3333333333333333m);
        route2.RegisterPassengers(3);

        Console.WriteLine(route1.GetSummary());
        Console.WriteLine(route2.GetSummary());
    }
}