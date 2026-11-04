using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcionMenu, solicitudesPendientes = 0, opcionAuxiliar, tipo, codigoClientes = 0, codigoRepuestos = 0, codigoTecnicos = 0, codigoEquipo=0;
            string nombre, codigo, telefono, correo, tipoClienteAuxiliar, numeroSerie, marca, modelo, tipoEquipo="", estadoFisico, accesorios, observaciones, diagnostico;
            Cliente propietarioEquipo=null;
            Queue<Solicitud> Urgentes = new Queue<Solicitud>();
            Queue<Solicitud> Normales = new Queue<Solicitud>();
            List<Cliente> Clientes = new List<Cliente>();
            List<Tecnico> Tecnicos = new List<Tecnico>();
            List<Equipo>Equipos=new List<Equipo>();
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
                string value;
                do
                {
                    value = Console.ReadLine();
                    if (value != "")
                    {
                        value = value.Trim();
                        if (value.Length == 8 && value.All(char.IsDigit))
                        {
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Error: el número de teléfono solo debe contener números\nIngrese el número nuevamente: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: debe ingresar un número de telérfono\n Ingrese el número nuevamente: ");
                    }
                } while (true);
                return value;
            }
            string ValidarCorreo()
            {
                string value;
                do
                {
                    value = Console.ReadLine();
                    if (value != "")
                    {
                        value = value.Trim();
                        if (value != "" && value.Contains("@") && value.Contains(".com"))
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
                string value;
                do
                {
                    value = Console.ReadLine();
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
            void MostrarErrorAnimado(string textoError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(textoError);
                Thread.Sleep(1400);
                Console.Write("\r" + new string(' ', textoError.Length) + "\r");
                Console.ResetColor();
            }
            void MostrarExitoAnimado(string mensajeExito)
            {
                Console.ForegroundColor = ConsoleColor.Green;



                Console.Write($" {mensajeExito}");

                Thread.Sleep(2000);

                Console.Write("\r" + new string(' ', mensajeExito.Length + 5) + "\r");

                Console.ResetColor();
            }
            void MostrarAnimacionPuntos()
            {
                Console.Write("Procesando y guardando datos");

                for (int i = 0; i < 5; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(400);
                }
                Console.Clear();
                MostrarExitoAnimado("Registro completado con éxito!");
            }
            void AnimacionContinuar()
            {
                Console.Write("\nRegresando al menú anterior");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(400);
                }
                Console.Clear();
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
                            Console.Clear();
                            Console.WriteLine("---------- GESTIÓN DE CLIENTES ----------");
                            Console.WriteLine("1. Registrar nuevo cliente\n2. Consultar cliente por código\n3. Actualizar información\n4. Volver al menú principal");
                            Console.Write("Ingrese una opción: ");
                            opcionAuxiliar = ValidarEntero();
                            switch (opcionAuxiliar)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.Write("\nIngrese el nombre del cliente: ");
                                    nombre = Console.ReadLine();
                                    Console.Write("\nIngrese el número de teléfono: ");
                                    telefono = ValidarTelefono();
                                    Console.Write("\nIngrese el correo electrónico: ");
                                    correo = ValidarCorreo();
                                    Console.Write("\nIngrese el tipo de cliente: \n1. Normal\n2. Estudiante\n3. Empresa\nIngrese una opción: ");
                                    tipo = ValidarEntero();
                                    tipoClienteAuxiliar = AsignarTipoCliente(tipo);
                                    codigoClientes++;
                                    codigo = "CLIEN-" + codigoClientes.ToString();
                                    Clientes.Add(new Cliente(nombre, codigo, telefono, correo, tipoClienteAuxiliar, 0));
                                    MostrarExitoAnimado("Cliente registrado exitosamente");
                                    Thread.Sleep(1000);
                                    break;
                                case 2:
                                    Console.Clear();
                                    string codigoBusqueda;
                                    bool encontrado = false;
                                    if (Clientes.Count == 0)
                                    {
                                        Console.WriteLine("No hay clientes registrados");
                                    }
                                    else
                                    {
                                        Console.Write("Ingrese el código del cliente: ");
                                        codigoBusqueda = ValidarString();
                                        foreach (Cliente c in Clientes)
                                        {
                                            if (c.Codigo == codigoBusqueda)
                                            {
                                                encontrado = true;
                                                Console.WriteLine("--- INFORMACIÓN DEL CLIENTE ---");
                                                c.MostrarInformacion();
                                                break;
                                            }
                                        }
                                        if (!encontrado)
                                        {
                                            Console.WriteLine($"El código {codigoBusqueda} no existe");
                                        }
                                    }
                                    Thread.Sleep(6000);
                                    AnimacionContinuar();
                                    break;
                                case 3:
                                    Console.Clear();
                                    int opcionActualizar;
                                    encontrado = false;
                                    if (Clientes.Count == 0)
                                    {
                                        Console.WriteLine("No hay clientes registrados");
                                    }
                                    else
                                    {
                                        Console.Write("Ingrese el código del cliente: ");
                                        codigoBusqueda = ValidarString();
                                        foreach (Cliente c in Clientes)
                                        {
                                            if (c.Codigo == codigoBusqueda)
                                            {
                                                encontrado = true;
                                                Console.WriteLine("--- INFORMACIÓN DEL CLIENTE ---");
                                                c.MostrarInformacion();
                                                Console.WriteLine("¿Qué información desea actualizar?\n1. Nombre\n2. Número de teléfono\n3. Correo el ectrónico\n4. Tipo de cliente");
                                                Console.Write("Ingrese una opción: ");
                                                opcionActualizar = ValidarEntero();
                                                switch (opcionActualizar)
                                                {
                                                    case 1:
                                                        Console.Write("Ingrese el nuevo nombre: ");
                                                        nombre = ValidarString();
                                                        c.NombreCompleto = nombre;
                                                        break;
                                                    case 2:
                                                        Console.Write("Ingrese el nuevo número: ");
                                                        telefono = ValidarTelefono();
                                                        c.NumeroTelefono = telefono;
                                                        break;
                                                    case 3:
                                                        Console.Write("Ingrese el nuevo correo: ");
                                                        correo = ValidarCorreo();
                                                        c.Correo = correo;
                                                        break;
                                                    case 4:
                                                        Console.Write("\nIngrese el tipo de cliente: \n1. Normal\n2. Estudiante\n3. Empresa\nIngrese una opción: ");
                                                        tipo = ValidarEntero();
                                                        tipoClienteAuxiliar = AsignarTipoCliente(tipo);
                                                        c.TipoCliente = tipoClienteAuxiliar;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Opción no válida... intente nuevamente\n");
                                                        break;
                                                }
                                                MostrarExitoAnimado("Información actualizada exitosamente");
                                                break;
                                            }
                                        }
                                        if (!encontrado)
                                        {
                                            Console.WriteLine($"El código {codigoBusqueda} no existe");
                                        }
                                    }
                                    AnimacionContinuar();
                                    break;
                                case 4:
                                    Console.Clear();
                                    AnimacionContinuar();
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida... intente nuevamente");
                                    AnimacionContinuar();
                                    break;
                            }
                        } while (opcionAuxiliar != 4);
                        AnimacionContinuar();
                        break;
                    case 2:
                        do{
                            Console.Clear();
                        Console.WriteLine("---------- GESTIÓN DE TÉCNICOS ----------");
                        Console.WriteLine("1. Registrar nuevo técnico\n2. Consultar técnico por código\n3. Actualizar información\n4. Volver al menú principal");
                        Console.Write("Ingrese una opción: ");
                        opcionAuxiliar = ValidarEntero();
                            switch (opcionAuxiliar)
                            {
                                case 1:
                                    Console.Clear();
                                    string especialidad;
                                    int limite;
                                    Console.Write("Ingrese el nombre del técnico: ");
                                    nombre = ValidarString();
                                    Console.Write("Ingrese el número de teléfono: ");
                                    telefono = ValidarTelefono();
                                    Console.Write("Ingrese el correo electrónico: ");
                                    correo = ValidarCorreo();
                                    Console.Write("Ingrese la especialidad: ");
                                    especialidad = ValidarString();
                                    Console.Write("Ingrese el límite de trabajos: ");
                                    limite = ValidarEntero();
                                    codigoTecnicos++;
                                    codigo = "TEC-" + codigoTecnicos.ToString();
                                    Tecnicos.Add(new Tecnico(nombre, codigo, correo, telefono, especialidad, limite));
                                    MostrarExitoAnimado("Técnico registrado con éxito");
                                    break;
                                case 2:
                                    Console.Clear();
                                    string busqueda;
                                    bool encontrado = false;
                                    Console.WriteLine("Ingrese el código del técnico: ");
                                    busqueda = ValidarString();
                                    foreach (Tecnico t in Tecnicos)
                                    {
                                        if (t.Codigo == busqueda)
                                        {
                                            Console.WriteLine("--- INFORMACIÓN DEL TÉCNICO ---");
                                            t.MostrarInformacion();
                                            encontrado = true;
                                            Thread.Sleep(6000);
                                            AnimacionContinuar();
                                            break;
                                        }
                                    }
                                    if (!encontrado)
                                    {
                                        MostrarErrorAnimado("El código del técnico no existe");
                                    }
                                    break;
                                case 3:
                                    Console.Clear();
                                    string buscado;
                                    bool encontrar = false;
                                    int opcionActualizar;
                                    Console.WriteLine("Ingrese el código del técnico: ");
                                    busqueda = ValidarString();
                                    foreach (Tecnico t in Tecnicos)
                                    {
                                        if (t.Codigo == busqueda)
                                        {

                                            encontrado = true;
                                            Console.WriteLine("¿Qué información desea actualizar?\n1. Nombre\n2. Número de teléfono\n3. Correo el ectrónico\n4. Especialidad\n5. Límite de trabajos\n6. Calificación promedio\n7. Actualizar estado");
                                            Console.Write("Ingrese una opción: ");
                                            opcionActualizar = ValidarEntero();
                                            switch (opcionActualizar)
                                            {
                                                case 1:
                                                    Console.Write("Ingrese el nuevo nombre: ");
                                                    nombre = ValidarString();
                                                    t.NombreCompleto = nombre;
                                                    break;
                                                case 2:
                                                    Console.Write("Ingrese el nuevo número: ");
                                                    telefono = ValidarTelefono();
                                                    t.NumeroTelefono = telefono;
                                                    break;
                                                case 3:
                                                    Console.Write("Ingrese el nuevo correo: ");
                                                    correo = ValidarCorreo();
                                                    t.Correo = correo;
                                                    break;
                                                case 4:
                                                    Console.Write("Ingrese la nueva especialidad: ");
                                                    especialidad = ValidarString();
                                                    t.Especialidad = especialidad;
                                                    break;
                                                case 5:
                                                    Console.Write("Ingrese el límite de trabajos: ");
                                                    limite = ValidarEntero();
                                                    t.LimiteTrabajos = limite;
                                                    break;
                                                case 6:
                                                    double promedio = 0;
                                                    if (t.Calificaciones.Length == 0)
                                                    {
                                                        MostrarErrorAnimado("No hay calificaciones registradas");
                                                    }
                                                    else
                                                    {
                                                        t.PromediarCalificaciones();
                                                        Console.WriteLine($"Nuevo promedio de calificaciones: {t.CalificacionPromedio}");
                                                        AnimacionContinuar();
                                                    }
                                                    break;
                                                case 7:
                                                    t.ActualizarEstado();
                                                    break;
                                                default:
                                                    Console.WriteLine("Opción no válida... intente nuevamente\n");
                                                    AnimacionContinuar();
                                                    break;
                                            }
                                            MostrarExitoAnimado("Información actualizada exitosamente");
                                            AnimacionContinuar();
                                            break;
                                        }
                                    }
                                    if (!encontrar)
                                    {
                                        MostrarErrorAnimado("El código del técnico no existe");
                                    }
                                    break;
                                case 4:
                                    Console.Clear();
                                    AnimacionContinuar();
                                    break;
                                default:
                                    MostrarErrorAnimado("Opción no válida");
                                    break;
                            }
                            }while (opcionAuxiliar != 4) ;
                        
                        break;
                    case 3:
                        do
                        {
                            Console.Clear();
                            Console.Write("\n---------- GESTIÓN DE EQUIPOS ----------\n1. Registrar equipo\n2. Buscar equipo por código\n3. Actualizar información\n4. Volver al menú\nIngrese una opción: ");
                            opcionAuxiliar = ValidarEntero();
                            switch (opcionAuxiliar)
                            {
                                case 1:
                                    string codigoPropietario;
                                    bool encontrado = false;
                                    Console.Clear();
                                    Console.WriteLine("---- REGISTRAR EQUIPO ----");
                                    Console.Write("\nIngrese el número de serie del equipo: ");
                                    numeroSerie = ValidarString();
                                    Console.Write("\nIngrese la marca: ");
                                    marca = ValidarString();
                                    Console.Write("\nIngrese el modelo: ");
                                    modelo= ValidarString();
                                    Console.Write("\nIngrese el tipo de equipo: \n1. Computadora\n2. Laptop\n3. Celular\n4. Tablet\n5. Impresora\n6. Otro\nIngrese una opción: ");
                                    int opcionTipo = ValidarEntero();
                                    switch(opcionTipo)
                                    {
                                        case 1:
                                            tipoEquipo = "Computadora";
                                            break;
                                        case 2:
                                            tipoEquipo = "Laptop";
                                            break;
                                        case 3:
                                            tipoEquipo = "Celular";
                                            break;
                                        case 4:
                                            tipoEquipo = "Tablet";
                                            break;
                                        case 5:
                                            tipoEquipo = "Impresora";
                                            break;
                                        case 6:
                                            Console.Write("\nEspecifique: ");
                                            tipoEquipo = ValidarString();
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida");
                                            break;
                                    }
                                    Console.Write("\nIngrese el estado físico del equipo: ");
                                    estadoFisico = ValidarString();
                                    Console.Write("Ingrese los accesorios que entregaron con el equipo: ");
                                    accesorios= ValidarString();
                                    Console.Write("Ingrese observaciones: ");
                                    observaciones= ValidarString();
                                    do
                                    {
                                        encontrado = false;
                                        Console.Write("Ingrese el código del propietario (cliente): ");
                                        codigoPropietario = ValidarString();
                                        foreach (Cliente c in Clientes)
                                        {
                                            if (codigoPropietario == c.Codigo)
                                            {
                                                propietarioEquipo = c;
                                                encontrado = true;
                                                break;
                                                
                                            }
                                        }
                                        if (!encontrado)
                                        {
                                            Console.WriteLine("Cliente no encontrado... intente nuevamente");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    } while (true);
                                    codigo = "EQU-" + codigoEquipo.ToString();
                                    Equipos.Add(new Equipo(codigo, numeroSerie, marca, modelo, propietarioEquipo, tipoEquipo, estadoFisico, accesorios, observaciones, " "));
                                    MostrarExitoAnimado("Equipo registrado exitosamente");
                                    break;
                                case 2:
                                    string codigoBusqueda;
                                    bool encontrar = false;
                                    Console.Clear();
                                    Console.WriteLine("---- BUSCAR EQUIPO ----");
                                    Console.Write("Ingrese el código del equipo que desea buscar: ");
                                    codigoBusqueda = ValidarString();
                                    foreach(Equipo e in Equipos)
                                    {
                                        if (e.Codigo == codigoBusqueda)
                                        {
                                            encontrar = true;
                                            e.MostrarInformacion();
                                            AnimacionContinuar();
                                            break;
                                        }
                                    }
                                    if(!encontrar)
                                    {
                                        MostrarErrorAnimado("No existe un equipo con ese código");
                                    }
                                    break;
                                case 3:
                                    encontrar = false;
                                    string codigoActualizar;
                                    Console.Clear();
                                    Console.WriteLine("---- ACTUALIZAR INFORMACIÓN ----");
                                    Console.Write("Ingrese el código del equipo que desea actualizar: ");
                                    codigoActualizar = ValidarString();
                                    foreach (Equipo e in Equipos)
                                    {
                                        if (e.Codigo == codigoActualizar)
                                        {
                                            encontrar = true;
                                            Console.Write("\n¿Qué información desea actualizar?\n1. Observaciones\n2. Diagnóstico");
                                            int opcionActualizar = ValidarEntero();
                                            switch(opcionAuxiliar)
                                            {
                                                case 1:
                                                    Console.Write("\nIngrese las observaciones: ");
                                                    observaciones = ValidarString();
                                                    e.Observaciones = observaciones;
                                                    break;
                                                case 2:
                                                    Console.Write("\nIngrese el diagnóstico: ");
                                                    diagnostico= ValidarString();
                                                    e.Diagnostico = diagnostico;
                                                    break;
                                                default:
                                                    Console.WriteLine("Opción no válida... intente nuevamente");
                                                    break;
                                            }
                                            AnimacionContinuar();
                                            break;
                                        }
                                    }
                                    if (!encontrar)
                                    {
                                        MostrarErrorAnimado("No existe un equipo con ese código");
                                    }
                                    break;
                                case 4:
                                    Console.Clear();
                                    AnimacionContinuar();
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida... intente nuevamente");
                                    AnimacionContinuar();
                                    break;
                            }
                        } while (opcionAuxiliar != 4);
                        AnimacionContinuar();
                        break;
                    case 4:
                        //Solicitudes
                        break;
                    case 5:
                        do
                        {
                            Console.Clear();
                            Console.Write("\n---------- GESTIÓN DE REPUESTOS ----------\n1. Registrar repuesto\n2. Buscar repuesto por código\n3. Actualizar información\n4. Volver al menú\nIngrese una opción: ");
                            opcionAuxiliar = ValidarEntero();
                            switch (opcionAuxiliar)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("---- REGISTRAR REPUESTO ----");
                                    Console.Write("\nIngrese el número de serie del equipo: ");
                                    numeroSerie = ValidarString();
                                    Console.Write("\nIngrese la marca: ");
                                    marca = ValidarString();
                                    Console.Write("\nIngrese el modelo: ");
                                    modelo = ValidarString();
                                    Console.Write("");
                                    break;
                            }
                        }while(opcionAuxiliar != 5);
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
