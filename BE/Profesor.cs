using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Profesor: Persona
    {
        public Profesor(string nombre, string apellido, string email, string DNI,float sueldoMateria) : base(nombre,apellido, email, DNI)
        {
            SueldoMateria = sueldoMateria;
        }

        public float SueldoMateria { get; set; }
        List<Materia> Materias;

        public void SetMaterias(List<Materia> materias) => this.Materias = materias;

        public List<Materia> GetMaterias() => Materias;
    }
}
