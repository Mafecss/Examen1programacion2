using System;
using System.Collections.Generic;
using System.Linq;


namespace Examen1Programacion
{
    public class ClsEmpleado
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public double Salario { get; set; }
    }

    public static class ClsEmpleados
    {
        private static ClsEmpleado[] empleados = new ClsEmpleado[10];
        private static int indice = 0;

        public static void InicializarArreglos()
        {
            Array.Clear(empleados, 0, empleados.Length);
            Console.WriteLine("Arreglos inicializados.");
        }

        public static void Agregar()
        {
            Console.Write("Digite la cédula: ");
            string cedula = Console.ReadLine();
            Console.Write("Digite el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Digite la dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Digite el teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Digite el salario: ");
            if (double.TryParse(Console.ReadLine(), out double salario))
            {
                ClsEmpleado nuevoEmpleado = new ClsEmpleado
                {
                    Cedula = cedula,
                    Nombre = nombre,
                    Direccion = direccion,
                    Telefono = telefono,
                    Salario = salario
                };
                empleados[indice] = nuevoEmpleado;
                Console.WriteLine("Empleado agregado correctamente.");
                indice++;
            }
            else
            {
                Console.WriteLine("Salario inválido. No se pudo agregar el empleado.");
            }
        }

        public static void Consultar()
        {
            Console.Write("Ingrese la cédula del empleado a consultar: ");
            string cedula = Console.ReadLine();
            ClsEmpleado empleado = empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Empleado encontrado:");
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public static void Modificar()
        {
            Console.Write("Ingrese la cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();
            ClsEmpleado empleado = empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Empleado encontrado. Ingrese los nuevos datos:");
                Console.Write("Nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Salario: ");
                if (double.TryParse(Console.ReadLine(), out double salario))
                {
                    empleado.Salario = salario;
                    Console.WriteLine("Empleado modificado correctamente.");
                }
                else
                {
                    Console.WriteLine("Salario inválido. No se pudo modificar el empleado.");
                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado. No se pudo modificar.");
            }
        }

        public static void Borrar()
        {
            Console.Write("Ingrese la cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();
            ClsEmpleado empleado = empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);
            if (empleado != null)
            {
                Array.Clear(empleados, Array.IndexOf(empleados, empleado), 1);
                Console.WriteLine("Empleado borrado correctamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado. No se pudo borrar.");
            }
        }

        public static void MenuReportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú de Reportes");
                Console.WriteLine("1. Consultar empleado por cédula");
                Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
                Console.WriteLine("3. Calcular y mostrar el promedio de salarios");
                Console.WriteLine("4. Calcular y mostrar el salario más alto y más bajo");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Ingrese su opción (1-5): ");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Consultar();
                            break;
                        case 2:
                            ListarPorNombre();
                            break;
                        case 3:
                            CalcularPromedioSalarios();
                            break;
                        case 4:
                            SalarioMasAltoYBajo();
                            break;
                        case 5:
                            Console.WriteLine("Volviendo al menú principal.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, ingrese un número del 1 al 5.");
                }
            } while (opcion != 5);
        }

        public static void ListarPorNombre()
        {
            var empleadosOrdenados = empleados.Where(e => e != null).OrderBy(e => e.Nombre).ToList();
            Console.WriteLine("Empleados ordenados por nombre:");
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
            }
        }

        public static void CalcularPromedioSalarios()
        {
            if (empleados.Count(e => e != null) > 0)
            {
                double sumaSalarios = empleados.Where(e => e != null).Sum(e => e.Salario);
                double promedioSalarios = sumaSalarios / empleados.Count(e => e != null);
                Console.WriteLine($"El promedio de salarios es: {promedioSalarios}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
            }
        }

        public static void SalarioMasAltoYBajo()
        {
            if (empleados.Count(e => e != null) > 0)
            {
                double salarioMasAlto = empleados.Where(e => e != null).Max(e => e.Salario);
                double salarioMasBajo = empleados.Where(e => e != null).Min(e => e.Salario);
                Console.WriteLine($"Salario más alto: {salarioMasAlto}");
                Console.WriteLine($"Salario más bajo: {salarioMasBajo}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular los salarios más alto y más bajo.");
            }
        }
    }
}