using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class AlumnoBLL
    {
        AlumnoDAL mapper = new AlumnoDAL();
        NotaDAL mapperNota = new NotaDAL();
        public void RegistrarAlumno(Alumno alumno, List<Nota> notas, int ID_cursoIngreso)
        {
            int id_Alumno = mapper.RegistrarAlumno(alumno);
            mapper.AsignarAlumnoACurso(id_Alumno, ID_cursoIngreso);
            mapperNota.RegistrarNotasHistoricas(notas, id_Alumno);
        }
    }
}
