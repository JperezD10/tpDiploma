using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Alumno: Persona
    {
        public int ID_Alumno { get; set; }
        public List<Nota> Notas { get; set; }
        public bool Activo { get; set; }

        public Alumno(string nombre, string apellido, string email, string DNI, bool activo) : base(nombre, apellido, email, DNI)
        {
            this.Activo = activo;
        }

        public void SetNotas(List<Nota> notas) => this.Notas = notas;
    }
}
