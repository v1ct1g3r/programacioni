using System;

class Program
{
    static void Main()
    {
        Console.Write("INGRESE UN AÑO: ");
        int year = int.Parse(Console.ReadLine());
        if (esBisiesto(year))
        {
            Console.WriteLine($"{year} ES BISIESTO");
        }
        else
        {
            Console.WriteLine($"{year} NO ES BISIESTO");
        }
    }
    static bool esBisiesto(int year)
    {
        if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
        {
            return true;
        }
        return false;
    }
}