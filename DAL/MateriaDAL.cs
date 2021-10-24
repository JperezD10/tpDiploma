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
    public class MateriaDAL
    {
        Acceso acceso = Acceso.Instance;

        public List<Materia> listarMateriasSinProfesor()
        {
            List<Materia> materias = new List<Materia>();
            DataTable dt = acceso.Leer("listarMateriasSinProfesor", null);

            foreach (DataRow row in dt.Rows)
            {
                Materia materia = new Materia(row["Año"].ToString(), row["Descripcion"].ToString(), row["Dia"].ToString(), (int)row["HoraInicio"], (int)row["HoraFin"]);
                materia.ID_Materia = (int)row["ID_Materia"];
                materias.Add(materia);
            }
            return materias;
        }

        public void AsignarProfesorAMateria(List<Materia> materias, int ID_Profesor)
        {
            foreach (var materia in materias)
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@id_materia", materia.ID_Materia),
                    new SqlParameter("@id_profesor", ID_Profesor),
                };
                acceso.Escribir("AsignarProfesorAMateria", parametros);
            }
        }
    }
}
