using System;
using System.Globalization;

namespace RegistroCalificaciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cantidad de estudiantes
            int estudiantes = 5;

            // Cantidad de notas por cada estudiante
            int notasPorEstudiante = 3;

            // Arreglo bidimensional para almacenar las notas
            // Filas -> estudiantes
            // Columnas -> notas
            double[,] notas = new double[estudiantes, notasPorEstudiante];

            // Arreglo para almacenar el promedio de cada estudiante
            double[] promedios = new double[estudiantes];

            // ===============================
            // INGRESO DE NOTAS CON VALIDACIÓN
            // ===============================
            for (int i = 0; i < estudiantes; i++)
            {
                Console.WriteLine($"Estudiante {i + 1}");

                for (int j = 0; j < notasPorEstudiante; j++)
                {
                    // Leer nota validada en rango 0-10
                    double nota = ReadDoubleInRange($"Ingrese la nota {j + 1} (0 - 10): ", 0, 10);

                    // Guardar nota válida
                    notas[i, j] = nota;
                }

                Console.WriteLine();
            }

            // ===============================
            // CÁLCULO DE PROMEDIOS
            // ===============================
            for (int i = 0; i < estudiantes; i++)
            {
                double suma = 0;

                for (int j = 0; j < notasPorEstudiante; j++)
                {
                    suma += notas[i, j];
                }

                promedios[i] = suma / notasPorEstudiante;
            }

            // ===============================
            // MOSTRAR RESULTADOS
            // ===============================
            Console.WriteLine("📊 RESULTADOS FINALES");

            for (int i = 0; i < estudiantes; i++)
            {
                Console.Write($"Estudiante {i + 1} - Notas: ");

                for (int j = 0; j < notasPorEstudiante; j++)
                {
                    Console.Write(notas[i, j] + " ");
                }

                // Promedio con 2 decimales
                Console.WriteLine($"| Promedio: {promedios[i]:F2}");
            }

            // Pausa final
            Console.ReadLine();
        }

        // Lee y valida un double dentro de un rango. Acepta tanto separador de la cultura actual
        // como el separador invariante ('.') para mayor tolerancia en la entrada.
        private static double ReadDoubleInRange(string prompt, double min, double max)
        {
            double result;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Entrada no disponible. Intente nuevamente.");
                    continue;
                }

                input = input.Trim();

                // Intentar con la cultura actual
                if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out result))
                {
                    if (result < min || result > max)
                    {
                        Console.WriteLine("❌ Nota inválida. Intente nuevamente.");
                        continue;
                    }

                    return result;
                }

                // Intentar con la cultura invariante (acepta '.' como separador)
                if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
                {
                    if (result < min || result > max)
                    {
                        Console.WriteLine("❌ Nota inválida. Intente nuevamente.");
                        continue;
                    }

                    return result;
                }

                Console.WriteLine("❌ Entrada no numérica. Use un número (p.ej. 7,5 o 7.5) y vuelva a intentarlo.");
            }
        }
    }
}
