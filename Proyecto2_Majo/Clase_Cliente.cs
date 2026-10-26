using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    public class Cliente : Persona
    {
        private string tipoCliente;

        public string TipoCliente
        {
            get { return tipoCliente; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    tipoCliente = value;
                }
            }
        }
        private int cantidadSolicitudes;

        public int CantidadSolicitudes
        {
            get { return cantidadSolicitudes; }
            set
            {
                if (value > 0)
                {
                    cantidadSolicitudes = value;
                }
                else
                {
                    throw new ArgumentException("Error: la cantidad de solicitudes debe ser positiva");
                }
            }
        }
        public Cliente(string nombre, string codigo, string telefono, string correo, string tipo, int solicitudes) : base(nombre, telefono, correo, codigo)
        {
            TipoCliente = tipo;
            CantidadSolicitudes = solicitudes;
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo de cliente: {TipoCliente}\nCantidad de solicitudes: {CantidadSolicitudes}");
        }
        public void ActualizarSolicitudes(int nuevasSolicitudes)
        {
            if(nuevasSolicitudes>CantidadSolicitudes)
            {
            CantidadSolicitudes=nuevasSolicitudes;
            }
        }
    }   
}
