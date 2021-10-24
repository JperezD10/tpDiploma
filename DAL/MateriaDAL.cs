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
                materias.Add(materia);
            }
            return materias;
        }
    }
}
