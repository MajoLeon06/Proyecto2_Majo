using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    internal class Equipo
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
        private string numeroSerie;

        public string NumeroSerie
        {
            get { return numeroSerie; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    numeroSerie = value;
                }
            }
        }
        private string marca;

        public string Marca
        {
            get { return marca; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    marca = value;
                }
            }
        }
        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    modelo = value;
                }
            }
        }
        private Cliente propietario;

        public Cliente Propietario
        {
            get { return propietario; }
            set { propietario = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    tipo = value;
                }
            }
        }
        private string estadoFisico;

        public string EstadoFisico
        {
            get { return estadoFisico; }
            set
            {
                if (value != "")
                {
                    estadoFisico = value;
                }
            }
        }
        private string accesorios;

        public string Accesorios
        {
            get { return accesorios; }
            set
            {
                if (value != "")
                {
                    accesorios = value;
                }
            }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set
            {
                if (value != "")
                {
                    observaciones = value;
                }
                else
                {
                    observaciones = "Ninguna";
                }
            }
        }
        private string diagnostico;

        public string Diagnostico
        {
            get { return diagnostico; }
            set
            {
                if (value != "")
                {
                    diagnostico = value;
                }
                else
                {
                    diagnostico = "Pendiente";
                }
            }
        }
        public Equipo(string codigo, string serie, string marca, string modelo, Cliente propietario, string tipo, string estado, string accesorios, string observaciones, string diagnostico)
        {
            Codigo=codigo;
            NumeroSerie=serie;
            Marca=marca;
            Modelo=modelo;
            Propietario=propietario;
            Tipo=tipo;
            EstadoFisico=estado;
            Accesorios=accesorios;
            Observaciones=observaciones;
            Diagnostico=diagnostico;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine("---------- INFORMACIÓN DEL EQUIPO ----------");
            Console.WriteLine($"Código: {Codigo}\nNúmero de serie: {NumeroSerie}\nMarca: {Marca}\nModelo: {Modelo}\nPropietario: {Propietario}\nTipo: {Tipo}\nEstado físico recibido: {EstadoFisico}\nAccesorios: {Accesorios}\nObservaciones: {Observaciones}\nDiagnóstico: {Diagnostico}");
        }
    }
}
