/*
Nombre: Juan Pablo Garcia Carrillo
Grupo: 213022_727
Programa: Ingenieria de sistemas
Codigo fuente: Autoria Propia
*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingresa un número entero positivo mayor que 1: ");
        int cantidad;

        // Validar que la entrada sea un numero entero positivo mayor que 1
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 1)
        {
            Console.Write("Por favor, ingresa un número entero positivo mayor que 1: ");
        }

        int a = 1;

        Console.WriteLine($"Estos son los primeros {cantidad} numeros de la serie Fibonacci:");
        for (int i = 0; i < cantidad; i++)
        {
            Console.Write(a + "  ");
            int siguiente = a + a;
            a = siguiente;
        }
        Console.WriteLine(); // Salto de línea al final
    }
}