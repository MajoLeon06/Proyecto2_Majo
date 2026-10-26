using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    public class Tecnicos : Persona
    {
        private string especialidad;

        public string Especialidad
        {
            get { return especialidad; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    especialidad = value;
                }
                else
                {
                    throw new ArgumentException("Error: debe agregar una especialidad");
                }
            }
        }
        private int limiteTrabajos;

        public int LimiteTrabajos
        {
            get { return limiteTrabajos; }
            set
            {
                if (value > 0)
                {
                    limiteTrabajos = value;
                }
                else
                { throw new ArgumentException("Error: la cantidad debe ser mayor a 0"); }
            }
        }
        private int trabajosActivos;

        public int TrabajosActivos
        {
            get { return trabajosActivos; }
            set
            {
                if (value < LimiteTrabajos)
                {
                    trabajosActivos = value;
                }
                else
                {
                    throw new ArgumentException("Error: la cantidad de trabajos supera el límite del técnico");
                }
            }
        }
        private string disponibilidad;

        public string Disponibilidad
        {
            get { return disponibilidad; }
            set
            {
                if (value != "")
                {
                    disponibilidad = value;
                }
            }
        }
        private int trabajosTerminados;

        public int TrabajosTerminados
        {
            get { return trabajosTerminados; }
            set
            {
                if (value >= 0)
                {
                    trabajosTerminados = value;
                }
            }
        }
        private double calificacionPromedio;

        public double CalificacionPromedio
        {
            get { return calificacionPromedio; }
            set
            {
                if (value >= 0)
                {
                    calificacionPromedio = value;
                }
            }
        }
        private double[] calificaciones;

        public double[]Calificaciones
        {
            get { return calificaciones; }
            set { calificaciones = value; }
        }

        public Tecnicos(string nombre, string codigo, string correo, string telefono, string disponibilidad, string especialidad, int limite, int activos, int terminados, double calificacion, double[]calificaciones) : base(nombre, telefono, correo, codigo)
        {
            Especialidad = especialidad;
            LimiteTrabajos = limite;
            TrabajosActivos = activos;
            TrabajosTerminados = terminados;
            CalificacionPromedio = calificacion;
            Calificaciones = calificaciones;
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Especialidad: {Especialidad}\nDisponibilidad: {Disponibilidad}\nLímite de trabajos: {LimiteTrabajos}\nTrabajos activos: {TrabajosActivos}\nTrabajos finalizados: {TrabajosTerminados}\nCalificación promedio: {CalificacionPromedio}");
        }
        public void ActualizarEstado()
        {
            if (TrabajosActivos < LimiteTrabajos)
            {
                Disponibilidad = "Disponible";
            }
            else if (TrabajosActivos == LimiteTrabajos)
            {
                Disponibilidad = "Ocupado";
            }
        }
        public void PromediarCalificaciones()
        {
            double suma = 0;
            foreach (double n in Calificaciones)
            {
                suma += n;
            }
            CalificacionPromedio = suma / Calificaciones.Length;
        }
    }
}
