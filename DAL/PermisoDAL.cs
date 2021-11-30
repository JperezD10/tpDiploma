using BE;
using SEGURIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PermisoDAL
    {
        Acceso Acceso = Acceso.Instance;
        Encriptacion Encriptacion = new Encriptacion();
        private Patente cargarEntidadPatente(DataRow dataRow)
        {
            Patente patente = new Patente();
            if (dataRow != null)
            {
                patente.codigoPermiso = int.Parse(dataRow["ID_Permiso"].ToString());
                patente.DVH = dataRow["DVH"].ToString();
                patente.nombre = dataRow["Permiso"].ToString();
                patente.isFamilia = Boolean.Parse(dataRow["IsFamilia"].ToString());
            }
            return patente;
        }

        private Familia cargarEntidadFamilia(DataRow dataRow)
        {
            Familia familia = new Familia();
            if (dataRow != null)
            {
                familia.codigoPermiso = dataRow["ID_Permiso"] != DBNull.Value ? (int)dataRow["ID_Permiso"] : 0;
                familia.DVH = dataRow["DVH"].ToString();
                familia.nombre = dataRow["Permiso"].ToString();
                familia.isFamilia = dataRow["isFamilia"] != DBNull.Value ? (bool)dataRow["IsFamilia"] : false;
            }
            return familia;
        }

        public List<Permiso> listarPatentesPorFamiliaODistinta(Permiso familia, string sp)
        {
            List<Permiso> listaPatentes = new List<Permiso>();
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@familia", familia.nombre);
                DataTable dataTable = Acceso.Leer(sp, sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    listaPatentes.Add(cargarEntidadPatente(dataRow));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaPatentes;
        }

        private Permiso cargarEntidadPermiso(DataRow dataRow)
        {
            Permiso permiso = null;
            if (dataRow != null)
            {
                bool familia = Boolean.Parse(dataRow["IsFamilia"].ToString());
                if (familia)
                {
                    permiso = new Familia();
                }
                else
                {
                    permiso = new Patente();
                }

                permiso.codigoPermiso = int.Parse(dataRow["ID_Permiso"].ToString());
                permiso.nombre = Encriptacion.desencriptar(dataRow["Permiso"].ToString());
                permiso.isFamilia = familia;

                if (familia)
                {
                    List<Permiso> listaPermisosDeFamilia = obtenerPermisosDeFamilia(permiso);
                    permiso.listaPermisos = listaPermisosDeFamilia;
                }
            }
            return permiso;
        }

        private List<Permiso> obtenerPermisosDeFamilia(Permiso permiso)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@idPermiso", permiso.codigoPermiso);
            DataTable dataTable = Acceso.Leer("OBTENER_PERMISOS_DE_FAMILIA", sqlParameters);
            List<Permiso> listaPermisos = new List<Permiso>();

            if (dataTable.Rows.Count > 0) {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    listaPermisos.Add(cargarEntidadPermiso(dataRow));
                }
            }
            return listaPermisos;
        }
        public List<Patente> listarTodasLasPatentes()
        {

            DataTable dataTable = Acceso.Leer("OBTENER_TODAS_LAS_PATENTES", null);
            List<Patente> listaPatentes = new List<Patente>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var patente = cargarEntidadPatente(dataRow);
                listaPatentes.Add(patente);
            }

            return listaPatentes;
        }
        public List<Familia> listarTodasLasFamilias()
        {

            DataTable dataTable = Acceso.Leer("OBTENER_TODAS_LAS_FAMILIAS", null);
            List<Familia> listaFamilia = new List<Familia>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var familia = cargarEntidadFamilia(dataRow);
                listaFamilia.Add(familia);
            }

            return listaFamilia;
        }
        public List<Permiso> listarTodosLosPermiso()
        {
           
            DataTable dataTable = Acceso.Leer("LISTAR_TODOS_LOS_PERMISOS", null);
            List<Permiso> listaPermisos = new List<Permiso>();
            Dictionary<int, Permiso> dictPermisos = new Dictionary<int, Permiso>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var permiso = cargarEntidadPermiso(dataRow);
                    List<Permiso> lista = extraerPermisosArbol(permiso);
                    foreach (var item in lista)
                    {
                        dictPermisos[item.codigoPermiso] =item;
                    }
                }
            }

            foreach (var item in dictPermisos)
            {
                listaPermisos.Add(item.Value);
            }

            return listaPermisos;
        }

        private List<Permiso> extraerPermisosArbol(Permiso permiso)
        {
            if (!permiso.isFamilia)
            {
                return new List<Permiso> { permiso };
            }
            else
            {
                List<Permiso> lista = new List<Permiso>();
                foreach (var item in permiso.listaPermisos)
                {
                    if (!item.isFamilia) { 
                    lista.Add(item);
                    }
                    else
                    {
                        lista.AddRange(extraerPermisosArbol(item));
                    }
                }
                return lista;
            }
        }

        public List<Familia> listarFamiliasTodasOPorUsuario(Usuario user)
        {
            List<Familia> listaFamilias = new List<Familia>();
            DataTable dataTable = new DataTable();
            if (user != null)
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@isFamilia", true);
                sqlParameters[1] = new SqlParameter("@user", user.Username);
                dataTable = Acceso.Leer("OBTENER_PERMISOS_X_USUARIO", sqlParameters);
            }
            else
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@isFamilia", true);
                dataTable = Acceso.Leer("OBTENER_PERMISOS", sqlParameters);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                listaFamilias.Add(cargarEntidadFamilia(dataRow));
            }
            return listaFamilias;
        }

        public List<Permiso> listarPermisosNoAsignadosUsuario(Usuario user)
        {
            List<Permiso> listaPatentes = new List<Permiso>();
            DataTable dataTable = new DataTable();
            if (user != null)
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@username", user.Username);
                
                
                dataTable = Acceso.Leer("OBTENER_PERMISOS_NO_ASIGNADO_USUARIO", sqlParameters);
            }
            else
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@isFamilia", false);
                dataTable = Acceso.Leer("OBTENER_PERMISOS_GENERAL", sqlParameters);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                listaPatentes.Add(cargarEntidadPermiso(dataRow));
            }
            return listaPatentes;
        }
        public DataTable obtenerPermisosExluyentesAlUsuario(Usuario user, bool isFamilia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@username", user.Username);
                sqlParameters[1] = new SqlParameter("@isFamilia", isFamilia);
                return Acceso.Leer("OBTENER_PERMISOS_EXLUYENTES_AL_USUARIO", sqlParameters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Permiso> listarPermisosPorUsuario(Usuario user)
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@username", user.Username);
             
                DataTable tabla = Acceso.Leer("OBTENER_PERMISOS_POR_USUARIO", sqlParameters);
                

                foreach (DataRow fila in tabla.Rows)
                {
                    var permiso = cargarEntidadPermiso(fila);
                    listaPermisos.Add(permiso);
                }
            }
            catch (Exception)
            {

            }
            return listaPermisos;
        }

            public List<Permiso> listarPermisosQuitandoPermisosDeUsuario(Usuario user, bool isFamilia)
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            DataTable dataTable = obtenerPermisosExluyentesAlUsuario(user, isFamilia);
            if (isFamilia == true)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    listaPermisos.Add(cargarEntidadFamilia(dataRow));
                }
            }
            else
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    listaPermisos.Add(cargarEntidadPatente(dataRow));
                }
            }
            return listaPermisos;
        }

        public int comprobarExistenciaFamilia(Permiso familia, bool isFamilia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@nombrePermiso", familia.nombre);
                sqlParameters[1] = new SqlParameter("@isFamilia", isFamilia);
                DataTable dataTable = Acceso.Leer("PERMISO_COMPROBAR_EXISTENCIA", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return (int)dataRow["Contador"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return -1;
        }

        public int comprobarEliminacionFamilia(Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@familia", familia.nombre);
                DataTable dataTable = Acceso.Leer("SP_FAMILIA_COMPROBAR_ELIMINACION_SIN_FILTRAR_USUARIO", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return (int)dataRow["Contador"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return -1;
        }

        public string eliminarFamilia(Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@familia", familia.nombre);
                return Acceso.Escribir("FAMILIA_ELIMINAR", sqlParameters);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int asignarPermisoAUsuario(Permiso permiso, Usuario usuario, bool isFamilia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[4];
                sqlParameters[0] = new SqlParameter("@nombrePermiso", permiso.nombre);
                sqlParameters[1] = new SqlParameter("@username", usuario.Username);
                sqlParameters[2] = new SqlParameter("@isFamilia", isFamilia);
                sqlParameters[3] = new SqlParameter
                {
                    ParameterName = "@returnValue",
                    Direction = ParameterDirection.ReturnValue
                };
                Acceso.Escribir("ASIGNAR_PERMISO_A_USUARIO", sqlParameters);
                return (int)sqlParameters[3].Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string desasignarPermisoAUsuario(Permiso permiso, Usuario usuario, bool isFamilia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@nombrePermiso", permiso.nombre);
                sqlParameters[1] = new SqlParameter("@username", usuario.Username);
                sqlParameters[2] = new SqlParameter("@isFamilia", isFamilia);
                return Acceso.Escribir("DESASIGNAR_PERMISO_A_USUARIO", sqlParameters);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public int comprobarQuitarPatenteAUsuario(Permiso permiso, Usuario usuario)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@username", usuario.Username);
                sqlParameters[1] = new SqlParameter("@patente", permiso.nombre);
                DataTable dataTable = Acceso.Leer("COMPROBAR_PATENTE_A_QUITAR_USUARIO", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return (int)dataRow["Contador"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return -1;
        }

        public int comprobarQuitarFamiliaAUsuario(Permiso permiso, Usuario usuario)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@familia", permiso.nombre);
                sqlParameters[1] = new SqlParameter("@user", usuario.Username);
                DataTable dataTable = Acceso.Leer("COMPROBAR_FAMILIA_A_QUITAR_USUARIO", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return (int)dataRow["Contador"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return -1;
        }

        public int asignarPatenteAFamilia(Permiso patente, Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@patente", patente.nombre);
                sqlParameters[1] = new SqlParameter("@familia", familia.nombre);
                sqlParameters[2] = new SqlParameter
                {
                    ParameterName = "@returnValue",
                    Direction = ParameterDirection.ReturnValue
                };
                Acceso.Escribir("SP_FAMILIA_AGREGAR_PATENTE", sqlParameters);
                return (int)sqlParameters[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int asignarFamiliaAFamilia(Permiso familiaHija, Permiso familiaPadre)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@familiaHija", familiaHija.nombre);
                sqlParameters[1] = new SqlParameter("@familiaPadre", familiaPadre.nombre);
                sqlParameters[2] = new SqlParameter
                {
                    ParameterName = "@returnValue",
                    Direction = ParameterDirection.ReturnValue
                };
                Acceso.Escribir("ASIGNAR_FAMILIA_A_FAMILIA", sqlParameters);
                return (int)sqlParameters[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int comprobarQuitarPatenteAFamilia(Permiso patente, Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@familia", familia.nombre);
                sqlParameters[1] = new SqlParameter("@patente", patente.nombre);
                DataTable dataTable = Acceso.Leer("SP_PATENTE_COMPROBAR_QUITAR_A_FAMILIA", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return (int)dataRow["Contador"];
                }
            }
            catch (Exception)
            {

            }
            return -1;
        }

        public string desasignarPatenteAFamilia(Permiso patente, Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@patente", patente.nombre);
                sqlParameters[1] = new SqlParameter("@familia", familia.nombre);
                return Acceso.Escribir("SP_PATENTE_DESASIGNAR_A_FAMILIA", sqlParameters);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public int agregarFamilia(Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@familia", familia.nombre);
                sqlParameters[1] = new SqlParameter
                {
                    ParameterName = "@returnValue",
                    Direction = ParameterDirection.ReturnValue
                };
                Acceso.Escribir("AGREGAR_FAMILIA", sqlParameters);
                return (int)sqlParameters[1].Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int agregarPermiso(Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@familia", familia.nombre);
                sqlParameters[1] = new SqlParameter
                {
                    ParameterName = "@returnValue",
                    Direction = ParameterDirection.ReturnValue
                };
                Acceso.Escribir("AGREGAR_PERMISO", sqlParameters);
                return (int)sqlParameters[1].Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int comprobarPatentePorUsuario(Permiso patente, Usuario_Sesion usuario_Sesion)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@patente", patente.nombre);
                sqlParameters[1] = new SqlParameter("@id_usuario", usuario_Sesion.ID_Usuario);
                DataTable dataTable = Acceso.Leer("SP_PATENTE_COMPROBAR_USUARIO", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return (int)dataRow["Contador"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return -1;
        }
    }
}
