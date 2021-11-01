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

        public Dictionary<Materia, decimal> NotaHistorica { get; set; }

        public Nota(Alumno alumno, Dictionary<Materia, decimal> notasMaterias)
        {
            this.Alumno = alumno;
            this.NotaHistorica = notasMaterias;
        }
    }
}
