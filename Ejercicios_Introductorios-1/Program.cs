using System;

class Program
{
    static void Ejercicio1(int n)
    {
        Console.WriteLine($"La suma de los dígitos de {n} es {n / 10 + n % 10}");
    }
    static void Ejercicio2(int n)
    {
        int[] primos = [11, 13, 17, 19];
        foreach (int primo in primos)
        {
            if (n == primo)
            {
                Console.WriteLine($"{n} es primo");
                return;
            }
        }
        if (n < 0) Console.WriteLine($"{n} es negativo");
    }
    static void Ejercicio3(int n)
    {
        bool primer_digito_primo = false;
        bool segundo_digito_primo = false;
        int[] primos = [2, 3, 5, 7];
        foreach (int primo in primos)
        {
            if (n / 10 == primo)
                primer_digito_primo = true;
            if (n % 10 == primo)
                segundo_digito_primo = true;
        }
        if (primer_digito_primo && segundo_digito_primo)
            Console.WriteLine($"El primer y segundo dígito de {n} son primos");
        else if (primer_digito_primo)
            Console.WriteLine($"El primer dígito de {n} es primo");
        else if (segundo_digito_primo)
            Console.WriteLine($"El segundo dígito de {n} es primo");
        else
            Console.WriteLine($"Ningún dígito de {n} es primo");
    }
    static void Ejercicio4(int n, int m)
    {
        if ((n + m) % 2 == 0)
            Console.WriteLine($"La suma de {n} y {m} origina un número par");
        else
            Console.WriteLine($"La suma de {n} y {m} NO origina un número par");
    }
    static void Ejercicio5(int n)
    {
        int mayor_digito = n % 10, posicion = 2;
        if (n / 10 % 10 > mayor_digito)
        {
            mayor_digito = n / 10 % 10;
            posicion = 1;
        }
        if (n / 100 > mayor_digito)
        {
            mayor_digito = n / 100;
            posicion = 0;
        }
        Console.WriteLine($"El mayor dígito de {n} está en la posición {posicion}");
    }
    static void Ejercicio6(int n)
    {
        int primer_digito = n / 100;
        int segundo_digito = n / 10 % 10;
        int tercer_digito = n % 10;
        if (primer_digito % segundo_digito == 0 && primer_digito % tercer_digito == 0)
            Console.WriteLine($"En {n}, {primer_digito} es múltiplo de {segundo_digito} y {tercer_digito}");
        else if (segundo_digito % primer_digito == 0 && segundo_digito % tercer_digito == 0)
            Console.WriteLine($"En {n}, {segundo_digito} es múltiplo de {primer_digito} y {tercer_digito}");
        else if (tercer_digito % primer_digito == 0 && tercer_digito % segundo_digito == 0)
            Console.WriteLine($"En {n}, {tercer_digito} es múltiplo de {primer_digito} y {segundo_digito}");
        else
            Console.WriteLine($"En {n}, ningún dígito es múltiplo de los otros");
    }
    static void Ejercicio7(int a, int b, int c)
    {
        int n = a, mayor = a;
        n = b;
        if (n > mayor)
            mayor = n;
        n = c;
        if (n > mayor)
            mayor = n;
        Console.WriteLine($"El mayor entre {a}, {b}, y {c} es {mayor}");
    }
    static void Ejercicio8(int n)
    {
        if (n / 10000 == n % 10 && n / 1000 % 10 == n / 10 % 10)
            Console.WriteLine($"{n} es capicúa");
        else
            Console.WriteLine($"{n} NO es capicúa");
    }
    static void Ejercicio9(int n)
    {
        if (n / 100 % 10 == n / 10 % 10)
            Console.WriteLine($"En {n}, el segundo dígito es igual al penúltimo");
        else
            Console.WriteLine($"En {n}, el segundo dígito NO es igual al penúltimo");
    }
    static void Ejercicio10(int a, int b)
    {
        if (Math.Abs(a - b) > 10)
        {
            Console.WriteLine($"Como la diferencia entre {a} y {b} NO es menor o igual que 10, no se muestran los números comprendidos entre ellos");
            return;
        }
        Console.Write($"Como la diferencia entre {a} y {b} es menor o igual que 10, se muestran los números comprendidos entre ellos: ");
        for (int x = Math.Min(a, b); x <= Math.Max(a, b); x++)
            Console.Write($"{x} ");
        Console.WriteLine();
    }
    static void Main()
    {}
}