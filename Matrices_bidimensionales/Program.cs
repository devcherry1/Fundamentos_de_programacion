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
        // Declarar matrices a usar
        double[,] matrizTiempos = new double[6, 6];
        double[] matrizPromedios = new double[6];
        double[] matrizTiemposMin = new double[6];

        // Recorrer filas y columnas para que el usuario añada datos a la matriz de tiempos
        for (int i = 0; i < 6; i++)
        {
            string nombre = ObtenerNombre(i);
            Console.WriteLine($"Ingrese el tiempo para '{nombre}'\n El valor debe estar entre 10.1 y 10.5 segundos:");

            for (int j = 0; j < 6; j++)
            {
                Console.Write($"Tiempo #{j + 1}: ");
                matrizTiempos[i, j] = SolicitarNumero();
            }
            Console.WriteLine();
        }

        // Recorrer filas y columnas de matrizTiempos para calcular promedios y añadir los resultados a la matriz de promedios
        for (int i = 0; i < 6; i++)
        {
            double suma = 0;
            for (int j = 0; j < 6; j++)
            {
                suma += matrizTiempos[i, j];
            }
            matrizPromedios[i] = suma / 6;
        }

        // Determinar quien tiene el mejor promedio sin tiempos excediendo 10.4 segundos
        int indiceMejorPromedio = -1; // Inicializa como -1 para indicar que no se ha encontrado
        for (int i = 0; i < 6; i++)
        {
            bool todosBajos = true;
            for (int j = 0; j < 6; j++)
            {
                if (matrizTiempos[i, j] > 10.4)
                {
                    todosBajos = false; // Si algun tiempo es mayor a 10.4, lo marcamos
                    break; // Salimos del bucle
                }
            }

            // Verificamos si todos los tiempos son validos y si es el mejor promedio
            if (todosBajos && (indiceMejorPromedio == -1 || matrizPromedios[i] < matrizPromedios[indiceMejorPromedio]))
            {
                indiceMejorPromedio = i; // Actualizamos el índice del mejor promedio
            }
        }

        // Mostrar por pantalla el corredor con el mejor promedio
        if (indiceMejorPromedio != -1)
        {
            string mejorPromedioGanador = ObtenerNombre(indiceMejorPromedio);
            Console.WriteLine($"El corredor con el mejor promedio sin tiempos excediendo 10.4 segundos es {mejorPromedioGanador} con un promedio de {matrizPromedios[indiceMejorPromedio]:F1} segundos.");
        }
        else
        {
            Console.WriteLine("No hay corredores que cumplan con la condición de promedios válidos.");
        }

        // Calcular tiempos mínimos
        for (int i = 0; i < 6; i++)
        {
            double tiempoMinimo = matrizTiempos[i, 0]; // Inicializar con el primer tiempo de la fila
            for (int j = 1; j < 6; j++)
            {
                if (matrizTiempos[i, j] < tiempoMinimo)
                {
                    tiempoMinimo = matrizTiempos[i, j]; // Actualizar el tiempo mínimo
                }
            }
            matrizTiemposMin[i] = tiempoMinimo; // Almacenar el tiempo mínimo
        }

        // Determinar quién tiene el tiempo más bajo
        int indiceMinimoTiempo = 0;
        for (int i = 1; i < 6; i++)
        {
            if (matrizTiemposMin[i] < matrizTiemposMin[indiceMinimoTiempo])
            {
                indiceMinimoTiempo = i;
            }
        }

        // Mostrar por pantalla el corredor con el tiempo más bajo
        string tiempoGanador = ObtenerNombre(indiceMinimoTiempo);
        Console.WriteLine($"El corredor con el tiempo más bajo es {tiempoGanador} con un tiempo de {matrizTiemposMin[indiceMinimoTiempo]:F1} segundos.");
    }

    static string ObtenerNombre(int i)
    {
        switch (i)
        {
            case 0: return "Juan";
            case 1: return "Carlos";
            case 2: return "Pedro";
            case 3: return "Roberto";
            case 4: return "Raúl";
            case 5: return "David";
            default: return "Valor inválido";
        }
    }

    static double SolicitarNumero()
    {
        double numero;
        while (true)
        {
            string entrada = Console.ReadLine();

            if (double.TryParse(entrada, out numero))
            {
                if (numero >= 10.1 && numero <= 10.5)
                {
                    return numero;
                }
                else
                {
                    Console.WriteLine("El tiempo debe estar entre 10.1 y 10.5 segundos. Intente nuevamente.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un valor numérico.");
            }
        }
    }
}