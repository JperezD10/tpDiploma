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
    public class NotaBLL
    {
        NotaDAL mapper = new NotaDAL();
        BitacoraBLL servicioBitacora = new BitacoraBLL();
        Encriptacion encriptacion = new Encriptacion();
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        public bool ValidarNotaDisponibleParaTrimestre(Nota nota, int idAlumno, int trimestre)
        {
            return mapper.ValidarNotaDisponibleParaTrimestre(nota, idAlumno, trimestre);
        }

        public void RegistrarNotaPorTrimestre(Nota nota, int id_Alumno, int trimestre)
        {
            mapper.RegistrarNotasPorTrimestre(nota,id_Alumno, trimestre);
            Bitacora b = new Bitacora
            {
                Accion = "Registro de nota",
                Criticidad = "Media",
                Descripcion = encriptacion.encriptar($"Se registró una nota al alumno {nota.Alumno.Nombre} {nota.Alumno.Apellido}"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            servicioBitacora.crearBitacora(b);
        }
    }
}
