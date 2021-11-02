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
    public class AlumnoDAL
    {
        Acceso acceso = Acceso.Instance;

        public List<Alumno> ObtenerAlumnos(string nombre, string apellido, string dni)
        {
            List<Alumno> alumnos = new List<Alumno>();
            SqlParameter[] parametro =
            {
                new SqlParameter("@nombre", nombre=="" ? (object)DBNull.Value : nombre),
                new SqlParameter("@apellido", apellido=="" ? (object)DBNull.Value : apellido),
                new SqlParameter("@dni", dni=="" ? (object)DBNull.Value : dni),
            };
            DataTable dt = acceso.Leer("BuscarAlumnos", parametro);

            foreach (DataRow fila in dt.Rows)
            {
                Alumno alumno = new Alumno(fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Email"].ToString(), fila["DNI"].ToString(), (bool)fila["Activo"]);
                alumno.ID_Alumno = (int)fila["ID_Alumno"];
                alumnos.Add(alumno);
            }
            return alumnos;
        }

        public Alumno VerificarExistenciaAlumno(string dni)
        {
            Alumno alumno = null;
            SqlParameter[] parametro =
            {
                new SqlParameter("@dni", dni),
            };
            DataTable dt = acceso.Leer("VerificarExistenciaAlumno", parametro);

            foreach (DataRow fila in dt.Rows)
            {
                alumno = new Alumno(fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Email"].ToString(), fila["DNI"].ToString(), (bool)fila["Activo"]);
                alumno.ID_Alumno = (int)fila["ID_Alumno"];
            }
            return alumno;
        }

        public int RegistrarAlumno(Alumno alumno)
        {
            SqlParameter[] parametro =
            {
                new SqlParameter("@nombre", alumno.Nombre),
                new SqlParameter("@apellido", alumno.Apellido),
                new SqlParameter("@Email", alumno.Email),
                new SqlParameter("@dni", alumno.DNI),
                new SqlParameter
                {
                    ParameterName = "@returnValue",
                    Direction = ParameterDirection.ReturnValue
                }
            };
            acceso.Escribir("RegistrarAlumno", parametro);
            return (int)parametro[4].Value;
        }

        public void AsignarAlumnoACurso(int id_Alumno, int id_Curso)
        {
            SqlParameter[] parametro =
            {
                new SqlParameter("@idAlumno", id_Alumno),
                new SqlParameter("@idCurso", id_Curso),
            };
            acceso.Escribir("AsignarAlumnoACurso", parametro);
        }

        public void BajaAlumno(int ID_Alumno)
        {
            SqlParameter[] parametro =
            {
                new SqlParameter("@idAlumno", ID_Alumno),
            };

            acceso.Escribir("BajaAlumno", parametro);
        }
    }
}
