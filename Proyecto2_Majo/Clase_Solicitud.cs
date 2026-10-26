using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    internal class Solicitud
    {
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    codigo = value;
                }
            }
        }
        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private Equipo equipo;

        public Equipo Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }
        private Tecnicos tecnico;

        public Tecnicos Tecnico
        {
            get { return tecnico; }
            set { tecnico = value; }
        }
        private string descripcionProblema;

        public string DescripcionProblema
        {
            get { return descripcionProblema; }
            set { descripcionProblema = value; }
        }
        private DateTime fechaIngreso;

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        private string prioridad;

        public string Prioridad
        {
            get { return prioridad; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    prioridad = value;
                }
            }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value != "")
                {
                    estado = value;
                }
            }
        }
        private string diagnostico;

        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }
        private List<Repuesto> repuestosUsados;

        public List<Repuesto> RepuestosUsados
        {
            get { return repuestosUsados; }
            set { repuestosUsados = value; }
        }
        private double costoManoObra;

        public double CostoManoObra
        {
            get { return costoManoObra; }
            set
            {
                if (value > 0)
                {
                    costoManoObra = value;
                }
            }
        }
        private double costoRepuestos;

        public double CostoRepuestos
        {
            get { return costoRepuestos; }
            set
            {
                if (value > 0)
                {
                    costoRepuestos = value;
                }
            }
        }
        private double costoTotal;

        public double CostoTotal
        {
            get { return costoTotal; }
            set
            {
                costoTotal = CostoManoObra + CostoRepuestos + 20;
            }
        }
        public Solicitud(string codigo, Cliente cliente, Equipo equipo, string problema, DateTime fecha, string prioridad, string diagnostico, double mano, double crepuestos, double total)
        {
            Codigo = codigo;
            Cliente = cliente;
            Equipo = equipo;
            DescripcionProblema = problema;
            FechaIngreso = fecha;
            Prioridad = prioridad;
            Estado = "Recibida";
            Diagnostico = diagnostico;
            RepuestosUsados = new List<Repuesto>();
            CostoManoObra = mano;
            CostoRepuestos = crepuestos;
            CostoTotal = total;
            Historial = new Stack<string>();
        }
        private Stack<string> historial;

        public Stack<string> Historial
        {
            get { return historial; }
            set { historial = value; }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("---------- INFORMACIÓN DE SOLICITUD ----------");
            Console.WriteLine($"Código: {Codigo}\nCliente: {Cliente}\nEquipo: {Equipo}\nProblema: {DescripcionProblema}\nFecha de ingreso: {FechaIngreso}\nPrioridad: {Prioridad}\nEstado: {Estado}\nTécnico: {Tecnico}\n");
        }
        public void ActualizarEstado(int opcion)
        {
            if (opcion == 1)
            {
                Estado = "Recibida";
            }
            else if (opcion == 2 && Estado=="Recibida")
            {
                Estado = "En espera";
            }
            else if(opcion==3&&  Estado=="Recibida")
            {
                Estado = "Asignada";
            }
            else if( opcion==4&& Estado=="Asignada")
            {
                Estado = "En diagnóstico";
            }
            else if(opcion == 5&& Estado=="En diagnóstico")
            {
                Estado = "En reparación";
            }
            else if(opcion == 6&& Estado=="En reparacion")
            {
                Estado = "Finalizado";
            }
            else if(opcion==7&& Estado=="Finalizado")
            {
                Estado = "Entregada";
            }
            else if(opcion==8)
            {
                Estado = "Cancelada";
            }
        }
    }
}