using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class NotaDAL
    {
        Acceso acceso = Acceso.Instance;

        public void RegistrarNotasHistoricas(List<Nota> notas, int id_Alumno)
        {
            foreach (var nota in notas)
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@idAlumno",id_Alumno),
                    new SqlParameter("@idMateria",nota.Materia.ID_Materia),
                    new SqlParameter("@notaNumerica",nota.NotaNumerica),
                    new SqlParameter("@previa",nota.Previa)
                };
                acceso.Escribir("RegistrarNotasHistoricas", parametros);
            }
        }
    }
}
