using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Alumno: Persona
    {
        public bool Activo { get; set; }

        public Alumno(string nombre, string apellido, string email, string DNI, bool activo) : base(nombre, apellido, email, DNI)
        {
            this.Activo = activo;
        }
    }
}
