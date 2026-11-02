using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcionMenu, solicitudesPendientes = 0, opcionAuxiliar, tipo;
            string nombre, codigo, telefono, correo, tipoClienteAuxiliar;
            Queue<Solicitud> Urgentes = new Queue<Solicitud>();
            Queue<Solicitud> Normales = new Queue<Solicitud>();
            List<Cliente> Clientes = new List<Cliente>();
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
            string ValidarTelefono()
            {
                string value = Console.ReadLine();
                do
                {
                    if (value != "")
                    {
                        value = value.Trim();
                        if (value.Length == 8 && value.All(char.IsDigit))
                        {
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Error: el número de teléfono solo debe contener números");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: debe ingresar un número de telérfono");
                    }
                } while (true);
                return value;
            }
            string ValidarCorreo()
            {
                string value = Console.ReadLine();
                do
                {
                    if (value != "")
                    {
                        value = value.Trim();
                        if(value!="" && value.Contains("@")&& value.Contains(".com"))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: el correo no es válido");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: debe ingresar un correo");
                    }
                } while (true);
                return value;
            }
            string ValidarString()
            {
                string value = Console.ReadLine();
                do
                {
                    if (value.Trim() != "")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: debe ingresar un dato");
                    }
                } while (true);
                return value;
            }
            string AsignarTipoCliente(int opcion)
            {
                string value;
            if (opcion == 1)
            {
                value = "Normal";
            }
            else if (opcion == 2)
            {
                value = "Estudiante";
            }
            else if (opcion == 3)
            {
                value = "Empresa";
            }
            else
            {
                    value = "Otro";
            }
                return value;
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
                                    Console.Write("\nIngrese el nombre del cliente: ");
                                    nombre = Console.ReadLine();
                                    Console.Write("\nIngrese el número de teléfono: ");
                                    telefono = ValidarTelefono();
                                    Console.Write("\nIngrese el correo electrónico: ");
                                    correo= ValidarCorreo();
                                    Console.Write("\nIngrese el tipo de cliente: \n1. Normal\n2. Estudiante\n3. Empresa\nIngrese una opción: ");
                                    tipo = ValidarEntero();
                                    tipoClienteAuxiliar=AsignarTipoCliente(tipo);
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
