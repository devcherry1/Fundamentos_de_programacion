using System;
class Program
{
    static void Main()
    {
        //Aqui el usuario define el tamano de la matriz [cantidad de estudiantes]
        Console.WriteLine("Ingrese el numero de estudiantes");
        int cantidadEstudiantes = validarNumero();

        //Declarar matrices a usar
        string [] nombres = new string[cantidadEstudiantes];
        int [] programas = new int [cantidadEstudiantes];
        bool [] pago = new bool [cantidadEstudiantes];
        int[] creditos = new int[cantidadEstudiantes];
        int[] costo = new int[cantidadEstudiantes];
        double[] descuentoPorcentaje = new double[cantidadEstudiantes];
        int[] descuentoTotal = new int[cantidadEstudiantes];
        int[] costoTotal = new int[cantidadEstudiantes];


        //Recorre las filas de las matrices para que el usuario ingrese los datos de los estudiantes y se creen las matrices correspondientes
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            Console.WriteLine($"Ingresa el nombre del estudiante #{i+1}");
            nombres[i] = validarNombre();
            Console.WriteLine($"Por favor, selecciona el programa académico que {nombres[i]} va a cursar, ingresando el número correspondiente:" +
                          $"\n1. Ingeniería de sistemas" +
                          $"\n2. Psicología" +
                          $"\n3. Economía" +
                          $"\n4. Comunicación Social" +
                          $"\n5. Administración de Empresas");
            programas[i] = validarPrograma();
            Console.WriteLine($"{nombres[i]} usara como metodo de pago:"+
                              $"\n1. Efectivo" +
                              $"\n2. Pago en linea" );
            pago[i] = validarPago();
            creditos[i] = creditosPrograma(programas[i]);
            costo[i] = 200000 * creditos[i];
            descuentoPorcentaje[i] = pago[i] ? descuentoPrograma(programas[i]) : 0;
            descuentoTotal[i] = (int)(costo[i] * descuentoPorcentaje[i]);
            costoTotal[i] = (costo[i] - descuentoTotal[i]);
        }
        //Mostrar tabla completa
        Console.WriteLine($"\n ********** LISTA DE ESTUDIANTES ********** ");
        for (int i = 0; i < cantidadEstudiantes; i++)
         {
            Console.WriteLine($"\n Nombre: {nombres[i]}" +
                            $"\n Programa: {programaAcademico(programas[i])}" +
                            $"\n Pago en efectivo: " + (pago[i] ? "Sí" : "No") +
                            $"\n Creditos matriculados: {creditos[i]}" +
                            $"\n Costo neto: ${costo[i]:N0}" +
                            $"\n Descuento: {descuentoPorcentaje[i]*100}%" +
                            $"\n Costo total: ${costoTotal[i]:N0}");
        }
        // Calcular totales
        int totalCreditos = total(creditos);
        int totalSinDescuento = total(costo);
        int totalDescuento = total(descuentoTotal);
        int totalConDescuento = total(costoTotal);

        Console.WriteLine($"\n *** TERCER PERIODO ACADEMICO DEL 2020 ***");
        Console.WriteLine($"\n Total de créditos inscritos: {totalCreditos}" +
                            $"\n Valor total sin descuentos: ${totalSinDescuento:N0}" +
                            $"\n Valor total de descuentos aplicados: ${totalDescuento:N0}" +
                            $"\n Valor neto de las inscripciones: ${totalConDescuento:N0}" +
                            $"\n Promedio pagado por estudiante: ${(totalConDescuento/cantidadEstudiantes):N0}");
    }
    // Funcion sin parametros para validar que la entrada del nombre sea correcta
    static string validarNombre()
    {
        string input = Console.ReadLine();
        while (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("El nombre no puede estar vacío. Ingresa nuevamente el nombre:");
            input = Console.ReadLine();
        }
        return input;
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

    // Funcion sin parametros para validar que la entrada sea un numero entero positivo entre 1 y 5
    static int validarPrograma()
    {
        int cantidad;

        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0 || cantidad >= 6)
        {
            Console.Write("Por favor, ingresa un número entre 1 y 5: ");
        }
        return cantidad;
    }

    //Funcion sin parametros para validar que la entrada sea un numero entero positivo entre 1 y 2
    static bool validarPago()
    {
        int cantidad;
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0 || cantidad >= 3)
        {
            Console.Write("Por favor, ingresa un número entre 1 y 2: ");
        }
        if (cantidad == 1) {
            return true;
        }else{
            return false;
        }
    }

    //Funcion con parametro y retorno para validar el nombre del programa a matricular
    static string programaAcademico(int opcion)
    {
        switch (opcion)
        {
            case 1:
                return "Ingeniería de sistemas";
            case 2:
                return "Psicología";  
            case 3:
                return "Economía";
            case 4:
                return "Comunicación Social";
            case 5:
                return "Administración de Empresas";
            default:
                return "Opcion no válida";  
        }
    }
    //Funcion con parametro y retorno para validar la cantidad de creditos del programa a matricular
    static int creditosPrograma(int opcion)
    {
        switch (opcion)
        {
            case 1:
                return 20;
            case 2:
                return 16; 
            case 3:
                return 18;
            case 4:
                return 18;
            case 5:
                return 20;
            default:
                return 0;  
        }
    }
    //Funcion con parametro y retorno para validara el descuento del programa a matricular cuando aplica
    static double descuentoPrograma(int opcion)
    {
        switch (opcion)
        {
            case 1:
                return 0.18;
            case 2:
                return 0.12;
            case 3:
                return 0.10;
            case 4:
                return 0.05;
            case 5:
                return 0.15;
            default:
                return 0;
        }
    }
    //Funcion con parametro y retorno para recorrer y sumar los elementos de la matriz pasada como parametro y devolver el resultado
    static int total(int[] matriz)
    {
        int suma = 0;
        for (int i = 0; i < matriz.Length; i++)
        { 
            suma += matriz[i];
        }
        return suma;
    }
}
