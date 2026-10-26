using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    public class Persona
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
                    codigo = value.ToUpper();
                }
            }
        }
        private string nombreCompleto;

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set
            {
            
                if (value != "")
                {
                    nombreCompleto = value;
                }
            }
        }
        private string numeroTelefono;

        public string NumeroTelefono
        {
            get { return numeroTelefono; }
            set 
            {
                value.Trim();
                if(value.Length==8&&value.All(char.IsDigit))
                {
                    numeroTelefono= value; 
                }
                else
                {
                    throw new ArgumentException("Error: el número de teléfono solo debe contener números");
                }
            }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set 
            {
                value.Trim();
                if(value!=""&&value.Contains("@")&&value.Contains(".com"))
                {
                    correo = value;
                }
                else
                {
                    throw new ArgumentException("Error: correo no válido");
                }
            }
        }
        public Persona(string nombre, string telefono, string correo, string codigo)
        {
            Codigo = codigo;
            NombreCompleto=nombre;
            NumeroTelefono = telefono;
            Correo= correo;
        }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Código: {Codigo}\nNombre: {NombreCompleto}\nNúmero de teléfono: {NumeroTelefono}\nCorreo: {Correo}");
        }

    }
}
