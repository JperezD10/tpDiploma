using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class NotaBLL
    {
        NotaDAL mapper = new NotaDAL();
        public bool ValidarNotaDisponibleParaTrimestre(Nota nota, int idAlumno, int trimestre)
        {
            return mapper.ValidarNotaDisponibleParaTrimestre(nota, idAlumno, trimestre);
        }

        public void RegistrarNotaPorTrimestre(Nota nota, int id_Alumno, int trimestre)
        {
            mapper.RegistrarNotasPorTrimestre(nota,id_Alumno, trimestre);
        }
    }
}
