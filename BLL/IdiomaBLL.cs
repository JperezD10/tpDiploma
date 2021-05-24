using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class IdiomaBLL
    {
        IdiomaDAL mapper = new IdiomaDAL();
        public List<string> CargarIdiomas()
        {
            return mapper.CargarIdiomas();
        }
        public string buscarTexto(string elemento, string idioma)
        {
            return mapper.obtenerTexto(elemento, idioma);
        }
    }
}
