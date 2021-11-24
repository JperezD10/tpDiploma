using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using SEGURIDAD;

namespace BLL
{
    public class AlumnoBLL
    {
        AlumnoDAL mapper = new AlumnoDAL();
        NotaDAL mapperNota = new NotaDAL();
        BitacoraBLL servicioBitacora = new BitacoraBLL();
        Encriptacion encriptacion = new Encriptacion();
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        IdiomaBLL GetIdioma = new IdiomaBLL();

        public string RegistrarAlumno(Alumno alumno, List<Nota> notas, int ID_cursoIngreso, string idioma)
        {
            string result = "";
            Alumno verficiacionAlumno = mapper.VerificarExistenciaAlumno(alumno.DNI);
            if (verficiacionAlumno != null)
            {
                mapper.ReactivarAlumno(verficiacionAlumno.ID_Alumno);
                mapper.AsignarAlumnoACurso(verficiacionAlumno.ID_Alumno, ID_cursoIngreso);
                mapperNota.RegistrarNotasHistoricas(notas, verficiacionAlumno.ID_Alumno);
                Bitacora b = new Bitacora
                {
                    Accion = "Reactivacion de alumno",
                    Criticidad = "Media",
                    Descripcion = encriptacion.encriptar($"Se reactivo al alumno {alumno.Nombre}"),
                    Usuario = encriptacion.encriptar(session_User.Username)
                };
                servicioBitacora.crearBitacora(b);
                result = GetIdioma.buscarTexto("msbAlumnoReactivado", idioma);
            }
            else
            {
                int id_Alumno = mapper.RegistrarAlumno(alumno);
                mapper.AsignarAlumnoACurso(id_Alumno, ID_cursoIngreso);
                mapperNota.RegistrarNotasHistoricas(notas, id_Alumno);
                Bitacora b = new Bitacora
                {
                    Accion = "Registro de alumno",
                    Criticidad = "Media",
                    Descripcion = encriptacion.encriptar($"Se registro al alumno {alumno.Nombre}"),
                    Usuario = encriptacion.encriptar(session_User.Username)
                };
                servicioBitacora.crearBitacora(b);
                result = GetIdioma.buscarTexto("msbAlumnoRegistrado", idioma);
            }
            return result;
        }

        public List<Alumno> ObtenerAlumnos(string nombre, string apellido, string dni)
        {
            return mapper.ObtenerAlumnos(nombre, apellido, dni);
        }

        public void BajaAlumno(Alumno alumno)
        {
            mapper.BajaAlumno(alumno.ID_Alumno);
            Bitacora b = new Bitacora
            {
                Accion = "Baja de alumno",
                Criticidad = "Media",
                Descripcion = encriptacion.encriptar($"Se dio de baja al alumno {alumno.Nombre} {alumno.Apellido}"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            servicioBitacora.crearBitacora(b);
        }

        public bool AlumnoDisponible(string DNI)
        {
            bool salida = true;
            Alumno alumno = mapper.VerificarExistenciaAlumno(DNI);
            if (alumno == null || alumno.Activo == false)
            {
                salida = true;
            }
            else
                salida = false;
            return salida;
        }

        public List<Alumno> buscarAlumnosPorCurso(int grado, string turno)
        {
            return mapper.BuscarAlumnosPorCurso(grado, turno);
        }
    }
}
