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
        IdiomaBLL servicioIdioma = new IdiomaBLL();
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        public string agregarFamilia(Permiso familia, string idioma)
        {
            string nombreFamiliaPreCifrado = familia.nombre;
            familia.nombre = encriptacion.encriptar(familia.nombre);
            int flag = permisomapper.comprobarExistenciaFamilia(familia, true);
            if (flag < 1)
            {
                int lastID = permisomapper.agregarFamilia(familia);
                servicioDigitoVerificador.recalcularDV(lastID, "Permiso", true);
                Bitacora bitacora = new Bitacora()
                {
                    Accion = "Registro de familia",
                    Criticidad = "Media",
                    Descripcion = encriptacion.encriptar($"Se ha registrado la familia {nombreFamiliaPreCifrado}"),
                    Usuario = encriptacion.encriptar(session_User.Username)
                };
                ServicioBitacora.crearBitacora(bitacora);
                return servicioIdioma.buscarTexto("mensajeFamiliaCreada", idioma);
            }
            return servicioIdioma.buscarTexto("mensajeFamiliaYaExiste", idioma);
        }

        //public void agregarPermiso(Permiso permiso)
        //{
        //    int id = permisomapper.agregarPermiso(permiso);
        //    servicioDigitoVerificador.recalcularDV(id, "Permiso", true);
        //    servicioDigitoVerificador.recalcularDVV("UsuarioPermiso");
        //    servicioDigitoVerificador.recalcularDVV("Compuesto");
        //    servicioDigitoVerificador.recalcularDVV("Permiso");
        //}
        public string eliminarFamilia(Permiso familia, bool isFamilia, string idioma)
        {
            familia.nombre = encriptacion.encriptar(familia.nombre);
            int flagExistencia = permisomapper.comprobarExistenciaFamilia(familia, true);
            if (flagExistencia >= 0)
            {
                if (flagExistencia > 0)
                {
                    int flag = permisomapper.comprobarEliminacionFamilia(familia);
                    if (flag >= 0)
                    {
                        if (flag > 0)
                        {
                            permisomapper.eliminarFamilia(familia);
                            servicioDigitoVerificador.recalcularDVV("UsuarioPermiso");
                            servicioDigitoVerificador.recalcularDVV("Compuesto");
                            servicioDigitoVerificador.recalcularDVV("Permiso");
                            Bitacora bitacora = new Bitacora()
                            {
                                Accion = "Eliminación de familia",
                                Criticidad = "Alta",
                                Descripcion = encriptacion.encriptar($"La familia {encriptacion.desencriptar(familia.nombre)} ha sido eliminada"),
                                Usuario = encriptacion.encriptar(session_User.Username)
                            };
                            ServicioBitacora.crearBitacora(bitacora);
                            return servicioIdioma.buscarTexto("mensajeFamiliaEliminada", idioma);
                        }
                        else
                        {
                            return servicioIdioma.buscarTexto("mensajeNoSePuedeEliminarFamilia", idioma);
                        }
                    }
                    else
                    {
                        return "Failed comprobacion eliminacion";
                    }
                }
                else
                {
                    return servicioIdioma.buscarTexto("mensajeNoExisteFamilia", idioma);
                }
            }
            else
            {
                return "Failed comprobacion existencia";
            }
        }

        public List<Permiso> listarPermisosPorUsuario(Usuario usuario)
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            listaPermisos = permisomapper.listarPermisosPorUsuario(usuario);
            return listaPermisos;
        }

        public List<Familia> listarFamiliasTodasOPorUsuario(Usuario user)
        {
            List<Familia> listaFamilias = new List<Familia>();
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
        public List<Permiso> listarFamiliasconPatentes()
        {
            List<Permiso> listaFamilias = permisomapper.listarTodasLasFamiliasConPatentes();
            return listaFamilias;
        }

        public List<Familia> listarTodasLasFamilias()
        {
            List<Familia> Familias = permisomapper.listarTodasLasFamilias();
            foreach (Familia familia in Familias)
            {
                familia.nombre = encriptacion.desencriptar(familia.nombre);
            }
            return Familias;
        }
        public List<Patente> listarTodasLasPatentes()
        {
            List<Patente> patentes = permisomapper.listarTodasLasPatentes();
            foreach (Patente patente in patentes)
            {
                patente.nombre = encriptacion.desencriptar(patente.nombre);
            }
            return patentes;
        }
        public List<Permiso> listarTodosLosPermiso()
        {
            return permisomapper.listarTodosLosPermiso();
        }
        public List<Permiso> obtenerFamiliaDelPermiso(Permiso permiso)
        {
            return permisomapper.obtenerFamiliaDelPermiso(permiso);
        }
        public List<Permiso> ListarPermisosDeFamilia(Permiso permiso)
        {
            return permisomapper.obtenerPermisosDeFamilia(permiso);
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

        public bool comprobarPatentePorUsuario(Permiso patente, Usuario_Sesion usuario)
        {
            patente.nombre = encriptacion.encriptar(patente.nombre);
            int flag = permisomapper.comprobarPatentePorUsuario(patente, usuario);
            bool result = false;
            if (flag > 0)
            {
                result = true;
            }
            return result;
        }
        public void asignarPermisoAUsuario(Permiso permiso, Usuario usuario, bool isFamilia)
        {
            permiso.nombre = encriptacion.encriptar(permiso.nombre);
            int lastID = permisomapper.asignarPermisoAUsuario(permiso, usuario, isFamilia);
            servicioDigitoVerificador.recalcularDV(lastID, "UsuarioPermiso", true);
            Bitacora b = new Bitacora
            {
                Accion = "Asignación de permiso",
                Criticidad = "Alta",
                Descripcion = encriptacion.encriptar($"El permiso {encriptacion.desencriptar(permiso.nombre)}  ha sido asignado al usuario {encriptacion.desencriptar(usuario.Username)}"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            ServicioBitacora.crearBitacora(b);
        }

        public void AsignarFamiliaAFamilia(Familia familiaHija, Familia FamiliaPadre)
        {
            familiaHija.nombre = encriptacion.encriptar(familiaHija.nombre);
            FamiliaPadre.nombre = encriptacion.encriptar(FamiliaPadre.nombre);
            int lastID = permisomapper.asignarFamiliaAFamilia(familiaHija, FamiliaPadre);
            servicioDigitoVerificador.recalcularDV(lastID, "Compuesto", true);
            Bitacora b = new Bitacora
            {
                Accion = "Asignación de permiso",
                Criticidad = "Alta",
                Descripcion = encriptacion.encriptar($"El permiso {encriptacion.desencriptar(familiaHija.nombre)} fue asignado"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            ServicioBitacora.crearBitacora(b);
        }

        public string desasignarPermisoAUsuario(Permiso permiso, Usuario usuario, bool isFamilia, string idioma)
        {
            permiso.nombre = encriptacion.encriptar(permiso.nombre);
            int flag = -2;
            if (permiso is Patente)
            {
                flag = permisomapper.comprobarQuitarPatenteAUsuario(permiso, usuario);
            }
            else
            {
                flag = permisomapper.comprobarQuitarFamiliaAUsuario(permiso, usuario);
            }
            return desasignarPermisoAUsuarioPasoFinal(permiso, usuario, isFamilia, flag, idioma);
        }
        public void DesasignarFamiliaDeFamilia(Permiso FamiliaPadre, Permiso FamiliaHija)
        {
            permisomapper.DesasignarFamiliaDeFamilia(FamiliaPadre, FamiliaHija);
            servicioDigitoVerificador.recalcularDVV("Compuesto");
            Bitacora b = new Bitacora
            {
                Accion = "Desasignación de permiso",
                Criticidad = "Alta",
                Descripcion = encriptacion.encriptar($"El permiso {FamiliaHija.nombre}  ha sido desasignado"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            ServicioBitacora.crearBitacora(b);
        }
        public string desasignarPermisoAUsuarioPasoFinal(Permiso permiso, Usuario usuario, bool isFamilia, int flag, string idioma)
        {
            //if (flag >= 0)
            //{
            //    if (flag > 0)
            //    {
                    permisomapper.desasignarPermisoAUsuario(permiso, usuario, isFamilia);
                    servicioDigitoVerificador.recalcularDVV("UsuarioPermiso");
                    Bitacora b = new Bitacora
                    {
                        Accion = "Desasignación de permiso",
                        Criticidad = "Alta",
                        Descripcion = encriptacion.encriptar($"El permiso {encriptacion.desencriptar(permiso.nombre)}  ha sido desasignado del usuario {encriptacion.desencriptar(usuario.Username)}"),
                        Usuario = encriptacion.encriptar(session_User.Username)
                    };
                    ServicioBitacora.crearBitacora(b);
                    return "";
                //}
                //else
                //{
                //    BLL.IdiomaBLL servicioIdioma = new IdiomaBLL();
                //    return servicioIdioma.buscarTexto("mensajeNoSePuedeDesasignar", idioma);
                //}
            //}
        }

        public string asignarPatenteAFamilia(Permiso patente, Permiso familia, string idioma)
        {
            patente.nombre = encriptacion.encriptar(patente.nombre);
            familia.nombre = encriptacion.encriptar(familia.nombre);
            int lastID = permisomapper.asignarPatenteAFamilia(patente, familia);
            servicioDigitoVerificador.recalcularDV(lastID, "Compuesto", true);
            Bitacora b = new Bitacora
            {
                Accion = "Asignación de patente",
                Criticidad = "Alta",
                Descripcion = encriptacion.encriptar($"El permiso {encriptacion.desencriptar(patente.nombre)}  ha sido asignada a la familia {encriptacion.desencriptar(familia.nombre)}"),
                Usuario = encriptacion.encriptar(session_User.Username)
            };
            ServicioBitacora.crearBitacora(b);
            return "";
        }

        public string desasignarPatenteAFamilia(Permiso patente, Permiso familia, string idioma)
        {
            patente.nombre = encriptacion.encriptar(patente.nombre);
            familia.nombre = encriptacion.encriptar(familia.nombre);
            int flag = permisomapper.comprobarQuitarPatenteAFamilia(patente, familia);
            if (flag >= 0)
            {
                if (flag > 0)
                {
                    permisomapper.desasignarPatenteAFamilia(patente, familia);
                    servicioDigitoVerificador.recalcularDVV("Compuesto");
                    Bitacora b = new Bitacora
                    {
                        Accion = "Desasignación de patente",
                        Criticidad = "Media",
                        Descripcion = encriptacion.encriptar($"El permiso {encriptacion.desencriptar(patente.nombre)}  ha sido asignada a la familia {encriptacion.desencriptar(familia.nombre)}"),
                        Usuario = encriptacion.encriptar(session_User.Username)
                    };
                    ServicioBitacora.crearBitacora(b);
                    return "";
                }
                else
                {
                    return servicioIdioma.buscarTexto("mensajeNoSePuedeDesasignar", idioma);
                }
            }
            else
            {
                return "Failed comprobacion";
            }

        }
    }
}
