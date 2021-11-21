using System;
using System.Collections.Generic;
using System.Data;
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
        public void RegistrarNotasPorTrimestre(Nota nota, int id_Alumno, int trimestre)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@idAlumno",id_Alumno),
                new SqlParameter("@idMateria",nota.Materia.ID_Materia),
                new SqlParameter("@notaNumerica",nota.NotaNumerica),
                new SqlParameter("@trimestre",trimestre)
            };
            acceso.Escribir("PonerNotaTrimestral", parametros);
        }

        public bool ValidarNotaDisponibleParaTrimestre(Nota nota, int id_Alumno, int trimestre)
        {
            bool salida = true;
            SqlParameter[] parametros =
            {
                new SqlParameter("@idAlumno",id_Alumno),
                new SqlParameter("@idMateria",nota.Materia.ID_Materia),
                new SqlParameter("@trimestre",trimestre)
            };
            DataTable resultado = acceso.Leer("ValidarNotaDisponibleParaTrimestre", parametros);
            if (resultado.Rows.Count>0)
            {
                salida = false;
            }
            else
            {
                salida = true;
            }
            return salida;
        }
    }
}
