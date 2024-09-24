using System;

class Program
{
    static void Main() //Crea tres jugadores y determina cuál tiene el puntaje más alto, imprimiendo el ganador.
    {
        // Crear tres objetos de la clase Jugador
        Jugador jugador1 = CrearJugador();
        Jugador jugador2 = CrearJugador();
        Jugador jugador3 = CrearJugador();
  
        //Validar numero mayor e imprime el resultado
        if (jugador1.Puntaje>jugador2.Puntaje)
        {
          if (jugador1.Puntaje>jugador3.Puntaje)
          {
            Console.WriteLine($"El ganador es {jugador1.Nombre} puesto que obtuvo {jugador1.Puntaje}");
          }
          else
          {
            Console.WriteLine($"El ganador es {jugador3.Nombre} puesto que obtuvo {jugador3.Puntaje}");
          }
        }
        else
        {
          if (jugador2.Puntaje>jugador3.Puntaje)
          {
            Console.WriteLine($"El ganador es {jugador2.Nombre} puesto que obtuvo {jugador2.Puntaje}");
          }
          else
          {
            Console.WriteLine($"El ganador es {jugador3.Nombre} puesto que obtuvo {jugador3.Puntaje}");
          }
        }
    }
    static Jugador CrearJugador() 
    //Solicita el nombre y puntaje de un jugador, asegurándose de que el puntaje esté en el rango permitido.
    {
        Console.Write("Ingrese el nombre del participante: ");
        string nombre = Console.ReadLine(); // Solicitar el nombre al usuario

        int puntaje = SolicitarNumero($"Ingrese el puntaje para '{nombre}' (1-6): ");
        return new Jugador(nombre, puntaje);
    }
    static int SolicitarNumero(string mensaje) 
    /*Metodo para validar que el numero sea entero y que se encuentre entre 1 y 6 
    porque los dados comunes solo tienen 6 caras :V
    Al final devolvera el valor al objeto jugador#.puntaje
    */
    {
        int numero;
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out numero))
            {
                if (numero >= 1 && numero <= 6)
                {
                    return numero;
                }
                else
                {
                    Console.WriteLine("El puntaje debe estar entre 1 y 6. Intente nuevamente.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
            }
        }
    }
}
class Jugador 
//Clase jugador, define la estructura para almacenar el nombre y puntaje de un jugador.
//debe estar afuera de la clase program por organizacion y para poder reutilizarla
{
    public string Nombre { get; set; }
    public int Puntaje { get; set; }
    public Jugador(string nombre, int puntaje)
    {
        Nombre = nombre;
        Puntaje = puntaje;
    }
}