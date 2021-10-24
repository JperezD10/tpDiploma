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
    }
}
