using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nota
    {
        public Alumno Alumno { get; set; }
        public Materia Materia { get; set; }
        public string materia
        {
            get
            {
                return this.Materia.Descripcion;
            }
        }
        public decimal NotaNumerica { get; set; }
        public bool Previa { get; set; }
        

        public Nota(Alumno alumno, Materia materia, decimal nota,bool previa)
        {
            this.Alumno = alumno;
            this.Materia = materia;
            this.NotaNumerica = nota;
            this.Previa = previa;
        }
    }
}
