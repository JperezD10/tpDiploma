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
    public class IdiomaBLL
    {
        IdiomaDAL mapper = new IdiomaDAL();
        Encriptacion encriptacion = new Encriptacion();
        BitacoraBLL ServicioBitacora = new BitacoraBLL();
        Usuario_Sesion Usuario_Sesion = Usuario_Sesion.Instance;
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
            Bitacora bitacora = new Bitacora()
            {
                Accion = "Nueva traduccion",
                Criticidad = "Medio",
                Descripcion = encriptacion.encriptar($"Se ha traducido el control {control.NombreControl}"),
                Usuario = encriptacion.encriptar(Usuario_Sesion.Username)
            };
            ServicioBitacora.crearBitacora(bitacora);
            mapper.GuardarTraduccion(control, idioma);
        }
        public void GuardarIdioma(string idioma)
        {
            mapper.GuardarIdioma(idioma);
            Bitacora bitacora = new Bitacora()
            {
                Accion = "Nuevo idioma",
                Criticidad = "Alta",
                Descripcion = encriptacion.encriptar("Se ha registrado un nuevo idioma"),
                Usuario = encriptacion.encriptar(Usuario_Sesion.Username)
            };
            ServicioBitacora.crearBitacora(bitacora);
        }
    }
}
