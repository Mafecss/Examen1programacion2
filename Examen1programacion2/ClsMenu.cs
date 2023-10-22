using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen1Programacion
{
    internal class ClsMenu
    {
        static int opcion;
        static public void Menu()
        {

            opcion = 0; 

            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Inicializar");
                Console.WriteLine("2. Agregar");
                Console.WriteLine("3. Consultar");
                Console.WriteLine("4. Modificar");
                Console.WriteLine("5. Borrar");
                Console.WriteLine("6. Generar reportes");
                Console.WriteLine("7. Salir");
                Console.Write("Ingrese su opción (1-7): ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Por favor, ingrese un número del 1 al 7.");
                    continue;
                
            }

                switch (opcion)
                {
                    case 1: ClsEmpleados.InicializarArreglos(); break; 

                    case 2: ClsEmpleados.Agregar(); break;

                    case 3: ClsEmpleados.Consultar(); break;

                    case 4: ClsEmpleados.Modificar(); break;

                    case 5: ClsEmpleados.Borrar(); break;

                    case 6: ClsEmpleados.MenuReportes(); break;

                    case 7: Console.WriteLine("Saliendo del programa."); break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 7.");
                        break;
                }
            } while (opcion != 7);
        }

    }
}

