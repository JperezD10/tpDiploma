using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Persona
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Email { get; set; }
        public string DNI { get; set; }

        public Persona(string nombre, string apellido, string email, string DNI)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.DNI = DNI;
        }
    }
}
