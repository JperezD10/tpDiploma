using BE;
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

        private Permiso cargarEntidadPatente(DataRow dataRow)
        {
            Permiso patente = new Patente();
            if (dataRow != null)
            {
                patente.codigoPermiso = int.Parse(dataRow["ID_Permiso"].ToString());
                patente.DVH = dataRow["DVH"].ToString();
                patente.nombre = dataRow["Permiso"].ToString();
                patente.isFamilia = Boolean.Parse(dataRow["IsFamilia"].ToString());
            }
            return patente;
        }

        private Permiso cargarEntidadFamilia(DataRow dataRow)
        {
            Permiso familia = new Familia();
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
            catch (Exception)
            {

            }
            return listaPatentes;
        }

        public List<Permiso> listarFamiliasTodasOPorUsuario(Usuario user)
        {
            List<Permiso> listaFamilias = new List<Permiso>();
            DataTable dataTable = new DataTable();
            if (user != null)
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@isFamilia", true);
                sqlParameters[1] = new SqlParameter("@user", user.Username);
                dataTable = Acceso.Leer("OBTENER_PERMISO_X_USUARIO", sqlParameters);
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

        public List<Permiso> listarPatentesTodasOPorUsuario(Usuario user)
        {
            List<Permiso> listaPatentes = new List<Permiso>();
            DataTable dataTable = new DataTable();
            if (user != null)
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@isFamilia", false);
                sqlParameters[1] = new SqlParameter("@user", user.Username);
                dataTable = Acceso.Leer("SP_PERMISO_GET_X_USER", sqlParameters);
            }
            else
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@isFamilia", false);
                dataTable = Acceso.Leer("SP_PERMISO_GET_ALL", sqlParameters);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                listaPatentes.Add(cargarEntidadPatente(dataRow));
            }
            return listaPatentes;
        }

        public DataTable getPermisosQuitandoPermisosUsuario(Usuario user, bool isFamilia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@username", user.Username);
                sqlParameters[1] = new SqlParameter("@isFamilia", isFamilia);
                return Acceso.Leer("SP_PERMISO_GET_ALL_QUITANDO_PERMISOS_USER", sqlParameters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Permiso> listarPermisosQuitandoPermisosDeUsuario(Usuario user, bool isFamilia)
        {
            List<Permiso> listaPermisos = new List<Permiso>();
            DataTable dataTable = getPermisosQuitandoPermisosUsuario(user, isFamilia);
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
                DataTable dataTable = Acceso.Leer("SP_PERMISO_COMPROBAR_EXISTENCIA", sqlParameters);
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
            catch (Exception)
            {

            }
            return -1;
        }

        public string eliminarFamilia(Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@familia", familia.nombre);
                return Acceso.Escribir("SP_FAMILIA_ELIMINAR", sqlParameters);
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
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@nombrePermiso", permiso.nombre);
                sqlParameters[1] = new SqlParameter("@username", usuario.Username);
                sqlParameters[2] = new SqlParameter("@isFamilia", isFamilia);
                DataTable dataTable = Acceso.Leer("SP_PERMISO_ASIGNAR_A_USUARIO", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return int.Parse(dataRow["ID_Usuario_Permiso"].ToString());
                }
            }
            catch (Exception)
            {

            }
            return -1;
        }

        public string desasignarPermisoAUsuario(Permiso permiso, Usuario usuario, bool isFamilia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@nombrePermiso", permiso.nombre);
                sqlParameters[1] = new SqlParameter("@username", usuario.Username);
                sqlParameters[2] = new SqlParameter("@isFamilia", isFamilia);
                return Acceso.Escribir("SP_PERMISO_DESASIGNAR_A_USUARIO", sqlParameters);
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
                DataTable dataTable = Acceso.Leer("SP_PATENTE_COMPROBAR_QUITAR_A_USUARIO", sqlParameters);
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

        public int comprobarQuitarFamiliaAUsuario(Permiso permiso, Usuario usuario)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@familia", permiso.nombre);
                sqlParameters[1] = new SqlParameter("@user", usuario.Username);
                DataTable dataTable = Acceso.Leer("SP_USUARIO_COMPROBAR_QUITAR_FAMILIA", sqlParameters);
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

        public int asignarPatenteAFamilia(Permiso patente, Permiso familia)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@patente", patente.nombre);
                sqlParameters[1] = new SqlParameter("@familia", familia.nombre);
                DataTable dataTable = Acceso.Leer("SP_FAMILIA_AGREGAR_PATENTE", sqlParameters);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    return int.Parse(dataRow["ID_Compuesto"].ToString());
                }
            }
            catch (Exception)
            {

            }
            return -1;
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

        public int comprobarPatentePorUsuario(Permiso patente, Usuario_Sesion usuario_Sesion)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@patente", patente.nombre);
                sqlParameters[1] = new SqlParameter("@username", usuario_Sesion.Username);
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
