using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

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
        public List<IdiomaControl> ObtenerControlesPendientesATraducir(string idioma)
        {
            return mapper.ObtenerControlesPendientesATraducir(idioma);
        }
        public bool validarIdiomaDisponible(string idioma)
        {
            return mapper.ValidarIdiomaDisponible(idioma);
        }
        public void GuardarTraduccion(IdiomaControl control, string idioma)
        {
            mapper.GuardarTraduccion(control, idioma);
        }
        public void GuardarIdioma(string idioma)
        {
            mapper.GuardarIdioma(idioma);
        }
    }
}
