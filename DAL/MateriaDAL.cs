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
                Materia materia = new Materia((int)row["Año"], row["Descripcion"].ToString(), row["Dia"].ToString(), (int)row["HoraInicio"], (int)row["HoraFin"]);
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

        public bool ValidarHorarioNuevaMateria(Materia materia)
        {
            bool salida = false;
            SqlParameter[] parametro =
            {
                new SqlParameter("@anio", materia.Anio),
                new SqlParameter("@dia", materia.Dia),
                new SqlParameter("@horaInicio", materia.HoraInicio),
                new SqlParameter("@horaFin", materia.HoraFin),
            };
            DataTable tabla = acceso.Leer("ValidadHorarioNuevaMateria", parametro);
            if (tabla.Rows.Count > 0)
            {
                salida = false;
            }
            else
            {
                salida = true;
            }
            return salida;
        }
        public void CrearMateria(Materia materia, int IDCurso)
        {
            SqlParameter[] parametro =
            {
                new SqlParameter("@Año", materia.Anio),
                new SqlParameter("@descripcion", materia.Descripcion),
                new SqlParameter("@dia", materia.Dia),
                new SqlParameter("@horaInicio", materia.HoraInicio),
                new SqlParameter("@horaFin", materia.HoraFin),
                new SqlParameter("@idCurso", IDCurso)
            };
            acceso.Escribir("CrearMateria", parametro);
        }

        public List<Materia> ListarMateriasParaIngresoAlumno(int cursoGrado, string turno)
        {
            List<Materia> materias = new List<Materia>();
            SqlParameter[] parametros =
            {
                new SqlParameter("@curso",cursoGrado),
                new SqlParameter("@turno",turno)
            };

            DataTable tabla = acceso.Leer("ListarMateriasParaIngresoAlumno", parametros);
            foreach (DataRow fila in tabla.Rows)
            {
                Materia materia = new Materia((int)fila["Año"], fila["Descripcion"].ToString(), fila["Dia"].ToString(), (int)fila["HoraInicio"], (int)fila["HoraFin"]);
                materia.ID_Materia = (int)fila["ID_Materia"];
                materias.Add(materia);
            }
            return materias;
        }

        public List<Materia> BuscarMateriasPorCurso(int grado, string turno)
        {
            List<Materia> materias = new List<Materia>();
            SqlParameter[] parametro =
            {
                new SqlParameter("@Grado", grado),
                new SqlParameter("@turno", turno),
            };
            DataTable dt = acceso.Leer("BuscarMateriasPorCurso", parametro);

            foreach (DataRow fila in dt.Rows)
            {
                Materia materia = new Materia((int)fila["Año"], fila["Descripcion"].ToString(), fila["Dia"].ToString(), (int)fila["HoraInicio"], (int)fila["HoraFin"]);
                materia.ID_Materia = (int)fila["ID_Materia"];
                materias.Add(materia);
            }
            return materias;
        }
    }
}
