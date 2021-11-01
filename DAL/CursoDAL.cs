using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CursoDAL
    {
        Acceso acceso = Acceso.Instance;
        public List<Curso> CurosDisponiblesParaNuevaMateria()
        {
            List<Curso> CursosDisponibles = new List<Curso>();
            DataTable dt = acceso.Leer("VerificarMateriasDelCursoParaNuevaMateria", null);

            foreach (DataRow row in dt.Rows)
            {
                Curso CursoDisponible = new Curso((int)row["AñoFecha"], row["AñoSecundaria"].ToString(),(int)row["Cupo"],row["Turno"].ToString());
                CursoDisponible.ID_Curso = (int)row["ID_Curso"];
                CursosDisponibles.Add(CursoDisponible);
            }
            return CursosDisponibles;
        }
        
        public bool CrearCursosPorAño()
        {
            bool salida = false;
            SqlParameter[] parametros =
            {
                new SqlParameter("@añoActual", DateTime.Now.Year),
                new SqlParameter
                {
                    ParameterName = "@returnValue",
                    Direction = ParameterDirection.ReturnValue
                }
            };
            acceso.Escribir("CrearCursosPorAño", parametros);

            if ((int)parametros[1].Value == 1)
                salida = true;
            else 
                salida = false;
            return salida;
        }
    }
}
