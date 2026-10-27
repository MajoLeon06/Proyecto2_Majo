using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcionMenu, solicitudesPendientes = 0, opcionAuxiliar;
            string nombre, codigo;
            Queue<Solicitud> Urgentes = new Queue<Solicitud>();
            Queue<Solicitud> Normales = new Queue<Solicitud>();

            int ValidarEntero()
            {
                int dato;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out dato))
                    {
                        Console.WriteLine();
                        Console.Write("Error: el dato debe ser numérico...\nIngrese el dato nuevamente: ");
                    }
                    else
                    {
                        if (dato < 0)
                        {
                            Console.WriteLine();
                            Console.Write("Error: el número debe ser positivo\nIngrese nuevamente el dato:");
                        }
                        else
                        {
                            break;
                        }
                    }
                } while (true);
                return dato;
            }
            do
            {
                Console.WriteLine("================ XELATECH SOPORTE ================");
                Console.WriteLine("1. Gestión de clientes\n2. Gestión de técnicos\n3. Gestión de equipos\n4. Gestión de solicitudes\n5. Gestión de repuestos\n6. Atención de pedidos pendientes\n7. Información ordenada\n8. Métodos de búsqueda\n9. Reportes del sistema\n10. Salir");
                Console.Write("Ingrese una opción: ");
                opcionMenu = ValidarEntero();
                switch (opcionMenu)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("---------- GESTIÓN DE CLIENTES ----------");
                            Console.WriteLine("1. Registrar nuevo cliente\n2. Consultar cliente por código\n3. Actualizar información\n4. Volver al menú principal");
                            Console.Write("Ingrese una opción: ");
                            opcionAuxiliar = ValidarEntero();
                            switch (opcionAuxiliar)
                            {
                                case 1:

                                    break;
                            }
                        } while (opcionAuxiliar != 4);
                        break;
                    case 2:
                        //Tecnicos
                        break;
                    case 3:
                        //Equipos
                        break;
                    case 4:
                        //Solicitudes
                        break;
                    case 5:
                        //Repuestos
                        break;
                    case 6:
                        //Pedidos pendientes
                        break;
                    case 7:
                        //Información ordenada
                        break;
                    case 8:
                        //Búsqueda
                        break;
                    case 9:
                        //Reportes
                        break;
                    case 10:
                        Console.WriteLine("Gracias por utilizar los servicios de XELATECH SOPORTE...");
                        break;
                    default:
                        Console.WriteLine("Error: opción no válida... intente nuevamente");
                        break;
                }
            } while (opcionMenu != 10);
        }
    }
}
