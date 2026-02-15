using System;
using System.Collections.Generic;

class Program
{
    static bool esPrimo(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int d = 3; d * d <= n; d += 2)
            if (n % d == 0) return false;
        return true;
    }
    static void Ejercicio1(int[] arr)
    {
        int max = -1, pos = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                pos = i;
            }
        }
        Console.WriteLine($"El mayor número leído está en la posición {pos}");
    }
    static void Ejercicio2(int[] arr)
    {
        int max = -1, pos = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max && arr[i] % 2 == 0)
            {
                max = arr[i];
                pos = i;
            }
        }
        Console.WriteLine($"El mayor número par leído está en la posición {pos}");
    }
    static void Ejercicio3(int[] arr)
    {
        int max = -1, pos = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (esPrimo(arr[i]) && arr[i] > max)
            {
                max = arr[i];
                pos = i;
            }
        }
        Console.WriteLine($"El mayor número primo leído está en la posición {pos}");
    }
    static void Ejercicio4(int[] arr)
    {
        int total = 0;
        foreach (int num in arr)
        {
            string s = num.ToString();
            if (esPrimo(s[0] - '0')) total++;
        }
        Console.WriteLine($"El arreglo contiene {total} elementos que comienzan en dígito primo");
    }
    static void Ejercicio5(int[] arr)
    {
        int max_digitos_pares = -1, pos = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (esPrimo(arr[i]))
            {
                int a = arr[i], digitos_pares = 0;
                while (a > 0)
                {
                    if (a % 10 % 2 == 0) digitos_pares++;
                    a /= 10;
                }
                if (digitos_pares > max_digitos_pares)
                {
                    max_digitos_pares = digitos_pares;
                    pos = i;
                }
            }
        }
        Console.WriteLine($"El número primo con mayor cantidad de dígitos pares se encuentra en la posición {pos}");
    }
    static void Ejercicio6(int[] arr)
    {
        List<int> posiciones = new List<int>();
        for (int i = 0; i < arr.Length; i++)
            if (arr[i].ToString().Length > 3)
                posiciones.Add(i);
        Console.WriteLine($"Los números con más de tres dígitos están en las posiciones {string.Join(", ", posiciones)}");
    }
    static void Ejercicio7(int[] arr)
    {
        int promedio = 0;
        foreach (int num in arr)
            promedio += num;
        promedio /= arr.Length;
        Console.WriteLine($"El promedio entero de los datos del arreglo es {promedio}");
    }
    static void Ejercicio8(int[] arr)
    {
        int negativos = 0;
        foreach (int num in arr)
            if (num < 0) negativos++;
        Console.WriteLine($"En el arreglo hay {negativos} números negativos");
    }
    static void Ejercicio9(int[] arr)
    {
        int[] factoriales = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            int factorial = arr[i];
            for (int f = arr[i] - 1; f >= 1; f--)
                factorial *= f;
            factoriales[i] = factorial;
        }
        Console.WriteLine($"Los factoriales de los números en el arreglo son {string.Join(", ", factoriales)}");
    }
    static void Ejercicio10(int[] arr)
    {
        int num = int.Parse(Console.ReadLine());
        int divisores = 0;
        foreach (int div in arr)
            if (num % div == 0) divisores++;
        Console.WriteLine($"{num} tiene {divisores} divisores exactos en el arreglo");
    }
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Ejercicio1(arr);
        Ejercicio2(arr);
        Ejercicio3(arr);
        Ejercicio4(arr);
        Ejercicio5(arr);
        Ejercicio6(arr);
        Ejercicio7(arr);
        Ejercicio8(arr);
        Ejercicio9(arr);
        Ejercicio10(arr);
    }
}