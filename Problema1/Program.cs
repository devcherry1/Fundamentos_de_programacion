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
        //Aqui el usuario define el tamaño de la matriz
        Console.WriteLine("Ingrese el numero de empleados:");
        int cantidadEmpleados = numero();

        //Declarar matrices a usar
        string[] nombres = new string[cantidadEmpleados];
        int[] edades = new int[cantidadEmpleados];

        //Recorre las filas de las matrices para ingresar los datos del usuario
         for (int i = 0; i < cantidadEmpleados; i++)
         {
            Console.WriteLine($"Ingrese el nombre del empleado #{i+1}");
            nombres[i] = Console.ReadLine();
            Console.WriteLine($"Ingrese la edad de {nombres[i]}");
            edades[i] = numero();
         }
        
        //Mostrar tabla completa
        Console.WriteLine($"    ICO LTD \nLista de empleados");
        for (int i = 0; i < cantidadEmpleados; i++)
         {
            Console.WriteLine($"Nombre: {nombres[i]} - Edad: {edades[i]}");
         }
        
        //Calcular y mostrar al empleado mas joven
        int indiceEdadMinima = minima(edades);
        Console.WriteLine($"El empleado mas joven es {nombres[indiceEdadMinima]} puesto que tiene {edades[indiceEdadMinima]} años.");

        //Calcular y mostrar al empleado mas catano
        int indiceEdadMaxima = maxima(edades);
        Console.WriteLine($"El empleado mas cerca de pensionarse es {nombres[indiceEdadMaxima]} con {edades[indiceEdadMaxima]} años.");

        //Calcular y mostrar promedio de edad
        double promedioEdad = promedio(edades, cantidadEmpleados);
        Console.WriteLine($"La edad promedio de los empleados es de : {promedioEdad:F1} años.");

        Console.WriteLine(); // Salto de línea al final
    }

    // Funcion sin parametros para validar que la entrada sea un numero entero positivo
    static int numero()
    {
        int cantidad;
        
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.Write("Por favor, ingresa un número entero positivo: ");
        }
        return cantidad;
    }

    //Funcion con parametros y retorno para calcular edad promedio de los empleados
    static double promedio(int[] edades, int cantidadEmpleados)
    {
        int suma = 0;
        for (int i=0; i < cantidadEmpleados; i++)
        {
            suma += edades[i];
        }
        double promedioEdad = (double)suma / cantidadEmpleados;
        return promedioEdad;
    }

    //Funcion con parametros y retorno para calcular la edad minima de los empleados
    static int minima(int[] edades)
    {
        int indiceEdadMinima = 0;
        int edadMinima = edades[0]; // Inicializa con el primer elemento

        for (int i = 1; i < edades.Length; i++)
        {
            if (edades[i] < edadMinima)
            {
                edadMinima = edades[i];
                indiceEdadMinima = i;
            }
        }
        return indiceEdadMinima;
    }
     //Funcion con parametros y retorno para calcular la edad maxima de los empleados
    static int maxima(int[] edades)
    {
        int indiceEdadMaxima = 0;
        int edadMaxima = edades[0]; // Inicializa con el primer elemento

        for (int i = 1; i < edades.Length; i++)
        {
            if (edades[i] > edadMaxima)
            {
                edadMaxima = edades[i];
                indiceEdadMaxima = i;
            }
        }
        return indiceEdadMaxima;
    }
}