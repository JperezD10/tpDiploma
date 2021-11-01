using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class CursoBLL
    {
        CursoDAL mapper = new CursoDAL();
        public bool CrearCursoPorAño()
        {
            return mapper.CrearCursosPorAño();
        }

        public List<Curso> CursosDisponiblesParaNuevaMateria()
        {
            return mapper.CurosDisponiblesParaNuevaMateria();
        }
    }
}
