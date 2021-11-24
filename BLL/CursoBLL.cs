using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using SEGURIDAD;

namespace BLL
{
    public class CursoBLL
    {
        CursoDAL mapper = new CursoDAL();
        BitacoraBLL servicioBitacora = new BitacoraBLL();
        Encriptacion encriptacion = new Encriptacion();
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        public bool CrearCursoPorAño()
        {
            bool salida = mapper.CrearCursosPorAño();
            Bitacora b = new Bitacora
            {
                Accion = "Creacion de cursos",
                Criticidad = "Media",
                Descripcion = encriptacion.encriptar($"Se crearon cursos para el año {DateTime.Now.Year}"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            servicioBitacora.crearBitacora(b);
            return salida;
        }

        public List<Curso> CursosDisponiblesParaNuevaMateria()
        {
            return mapper.CurosDisponiblesParaNuevaMateria();
        }

        public List<Curso> cursosIngresoAlumno(int grado)
        {
            return mapper.cursosDisponiblesParaAlumnos(grado);
        }
    }
}
