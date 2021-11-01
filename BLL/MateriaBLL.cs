using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class MateriaBLL
    {
        MateriaDAL mapper = new MateriaDAL();
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
        }
    }
}
