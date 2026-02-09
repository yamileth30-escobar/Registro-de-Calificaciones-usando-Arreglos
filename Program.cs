//Registrar 3 notas por cada estudiante y calcular el promedio de cada uno.

using System;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {
        int cantidadEstudiantes = 5;
        int notasPorEstudiante = 3;

        //Creamos un Arreglo bidimensional para almacenar las notas de cada estudiante.
        double[,] notas = new double[cantidadEstudiantes, notasPorEstudiante];

        //Arreglo para los promedios de cada estudiante.
        double[] promedio = new double[cantidadEstudiantes];

        //Ingresamos las notas de cada estudiante.
        for (int i = 0; i < cantidadEstudiantes; i++) //i es para recorrer cada estudiante.
        {
            Console.WriteLine($"\nIngrese las notas del estudiante {i + 1}:"); //n es para crear una nueva linea antes de cada estudiante.

            for (int j = 0; j < notasPorEstudiante; j++) //j++ es para recorrer cada nota de cada estudiante.
            {
                Console.WriteLine($"Nota {j + 1}: ");
                notas[i, j] = double.Parse(Console.ReadLine()); //parse convierte el valor ingresado por el usuario a un tipo de dato double y lo almacena.
            }
        }

        //Calculamos el promedio de cada estudiante.
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            double suma = 0; //Variable para almacenar la suma de las notas de cada estudiante.

            for (int j = 0; j < notasPorEstudiante; j++)
            {
                suma += notas[i, j]; //Sumamos las notas de cada estudiante.
            }
            promedio[i] = suma / notasPorEstudiante; //Calculamos el promedio dividiendo la suma entre la cantidad de notas por estudiante.
        }

        //Mostraremos los resultados de cada estudiante.
        Console.WriteLine("\n Resultados Finales");

        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            Console.Write($"Estudiante {i + 1} - Notas: ");

            for (int j = 0; j < notasPorEstudiante; j++) //Recorremos las notas de cada estudiante.
            {
                Console.Write(notas[i, j] + " "); //Mostramos las notas de cada estudiante en la misma linea, separadas por un espacio.
            }

            Console.WriteLine($"| Promedio: {promedio[i]: 0.00}"); //Mostramos el promedio con dos decimales utilizando el formato ": 0.00".
        }

        Console.ReadKey(); //Esperamos a que el usuario presione una tecla para cerrar la consola.

    }

}
