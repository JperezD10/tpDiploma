using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SEGURIDAD;
using BE;

namespace BLL
{
    public class MateriaBLL
    {
        MateriaDAL mapper = new MateriaDAL();
        Encriptacion encriptacion = new Encriptacion();
        BitacoraBLL servicioBitacora = new BitacoraBLL();
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        public List<Materia> listarMateriasSinProfesor()
        {
            return mapper.listarMateriasSinProfesor();
        }

        public bool ValidarHorarioNuevaMateria(Materia materia)
        {
            return mapper.ValidarHorarioNuevaMateria(materia);
        }

        public void CrearMateria(Materia materia, int IDCurso)
        {
            materia.HoraFin = materia.HoraInicio + 2;
            mapper.CrearMateria(materia, IDCurso);
            Bitacora b = new Bitacora
            {
                Accion = "Registro de materia",
                Criticidad = "Media",
                Descripcion = encriptacion.encriptar($"Se regitros la materia {materia.Descripcion}"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            servicioBitacora.crearBitacora(b);
        }
        public List<Materia> listarMateriasCalificar(int cursoGrado, string turno)
        {
            return mapper.ListarMateriasParaIngresoAlumno(cursoGrado, turno);
        }
    }
}
