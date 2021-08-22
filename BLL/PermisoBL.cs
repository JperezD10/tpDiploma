using BE;
using SEGURIDAD;
using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermisoBL
    {
        Encriptacion encriptacion = new Encriptacion();
        PermisoDAL permisomapper = new PermisoDAL();
        DigitoVerificadorBLL servicioDigitoVerificador = new DigitoVerificadorBLL();
        BitacoraBLL ServicioBitacora = new BitacoraBLL();
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        public void agregarFamilia(Permiso familia)
        {
            string nombreFamiliaPreCifrado = familia.nombre;
            familia.nombre = encriptacion.encriptar(familia.nombre);
            //int flag = PermisoDAL.comprobarExistenciaFamilia(familia, true);
            //if (flag < 1)
            //{
            int lastID = permisomapper.agregarFamilia(familia);
            servicioDigitoVerificador.recalcularDV(lastID, "Permiso", true);
            Bitacora bitacora = new Bitacora()
            {
                Accion = "Registro de familia",
                Criticidad = "Media",
                Descripcion = encriptacion.encriptar($"Se ha registrado la familia {nombreFamiliaPreCifrado}"),
                Usuario = session_User.Username
            };
            ServicioBitacora.crearBitacora(bitacora);
            //}
            //return ServicioIdioma.ObtenerTexto("mensajeFamiliaYaExiste", idioma);
        }

        public List<Permiso> listarFamiliasTodasOPorUsuario(Usuario user)
        {
            List<Permiso> listaFamilias = new List<Permiso>();
            try
            {
                listaFamilias = permisomapper.listarFamiliasTodasOPorUsuario(user);
                foreach (Permiso p in listaFamilias)
                {
                    p.nombre = encriptacion.desencriptar(p.nombre);
                }
            }
            catch (Exception)
            {

            }
            return listaFamilias;
        }
        public List<Permiso> listarPatentesPorFamiliaODistinta(Permiso familia, string sp)
        {
            familia.nombre = encriptacion.encriptar(familia.nombre);
            List<Permiso> listaPatentes = new List<Permiso>();
            try
            {
                listaPatentes = permisomapper.listarPatentesPorFamiliaODistinta(familia, sp);
                foreach (Permiso p in listaPatentes)
                {
                    p.nombre = encriptacion.desencriptar(p.nombre);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaPatentes;
        }

        public List<Permiso> listarPatentesTodasOPorUsuario(Usuario user)
        {
            List<Permiso> listaPatentes = new List<Permiso>();
            try
            {
                listaPatentes = permisomapper.listarPatentesTodasOPorUsuario(user);
                foreach (Permiso p in listaPatentes)
                {
                    p.nombre = encriptacion.desencriptar(p.nombre);
                }
            }
            catch (Exception)
            {

            }
            return listaPatentes;
        }

        public List<Permiso> obtenerPermisosExluyentesAlUsuario(Usuario user, bool isFamilia)
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            try
            {
                listaPermisos = permisomapper.listarPermisosQuitandoPermisosDeUsuario(user, isFamilia);
                foreach (Permiso p in listaPermisos)
                {
                    p.nombre = encriptacion.desencriptar(p.nombre);
                }
            }
            catch (Exception)
            {

            }
            return listaPermisos;
        }
    }
}
