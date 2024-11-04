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
        //Aqui el usuario define la medida de cada lado del cuadrado
        Console.WriteLine("Cuanto mide cada lado del cuadrado (en centimetros)?:");
        int lado = validarNumero();

        medidas(lado);

        Console.WriteLine(); // Salto de línea al final
    }
    
    // Funcion sin parametros para validar que la entrada sea un numero entero positivo
    static int validarNumero()
    {
        int cantidad;
        
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.Write("Por favor, ingresa un número entero positivo: ");
        }
        return cantidad;
    }
    
    // Funcion con parametros sin retorno para mostrar area y perimetro del cuadrado
    static void medidas(int lado)
    {
        int area = lado * lado;
        int perimetro = lado * 4;
        Console.WriteLine($"Teniendo en cuenta que cada lado de tu cuadrado mide {lado} centímetros:" +
                          $"\nEl área del cuadrado es de {area} centimetros cuadrados." +
                          $"\nMientras que el perímetro del cuadrado es de {perimetro} centímetros.");
    }
}