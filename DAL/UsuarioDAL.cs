using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SEGURIDAD;

namespace DAL
{
    public class UsuarioDAL
    {
        Acceso acceso = Acceso.Instance;
        Encriptacion encriptado = new Encriptacion();

        public bool VerificarExistenciaUsuario(string Username)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@USERNAME", Username);
            DataTable dataTable = acceso.Leer("VerificarUsuario", parametro);
            if (dataTable.Rows.Count > 0) return true;
            else return false;
        }
        public void SumarIntentosLog(string Username)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@Username", Username);
            acceso.Escribir("SumarIntentoDeLog", parametro);
        }
        public void BloquearUsuario(string Username)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@Username", Username);
            acceso.Escribir("BloquearUsuario", parametro);
            BitacoraDAL accesoBitacora = new BitacoraDAL();
            BE.Usuario_Sesion usuario_Sesion = BE.Usuario_Sesion.Instance;
            BE.Bitacora bitacora = new BE.Bitacora()
            {
                Accion = "Bloqueo de usuario",
                Criticidad = "Media",
                Descripcion = encriptado.encriptar($"El usuario {encriptado.desencriptar(usuario_Sesion.Username)} ha sido bloqueado"),
                Usuario = usuario_Sesion.Username
            };
            accesoBitacora.CrearBitacora(bitacora);
        }
        public int MostrarIntentosRestantes(string Username)
        {
            int intentosRestantes = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@Username", Username);
            DataTable dataTable = acceso.Leer("MostrarIntentoLog", parametro);
            foreach (DataRow item in dataTable.Rows)
            {
                intentosRestantes = (int)item["IntentosIngreso"];
            }
            return intentosRestantes;
        }
        private void ReestablecerContadorLog(string Username)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@username", Username);
            acceso.Escribir("ReestablecerInicioSesion", parametro);
        }
        public bool IniciarSesion(string Username, string contraseña)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@username", Username);
            parametro[1] = new SqlParameter("@password", contraseña);
            DataTable dataTable = acceso.Leer("IniciarSesion", parametro);
            if (dataTable.Rows.Count > 0)
            {
                BE.Usuario_Sesion usuario_Sesion = BE.Usuario_Sesion.Instance;
                usuario_Sesion.Username = Username;
                usuario_Sesion.Contraseña = contraseña;
                ReestablecerContadorLog(Username);
                BitacoraDAL accesoBitacora = new BitacoraDAL();
                BE.Bitacora bitacora = new BE.Bitacora()
                {
                    Accion = "Inicio de sesión",
                    Criticidad = "Baja",
                    Descripcion = encriptado.encriptar($"El usuario {encriptado.desencriptar(usuario_Sesion.Username)} ha iniciado sesion"),
                    Usuario = usuario_Sesion.Username
                };
                accesoBitacora.CrearBitacora(bitacora);
                return true;
            }
            else return false;
        }

        public string CrearUsuario(BE.Usuario newUser)
        {
            SqlParameter[] parametro = new SqlParameter[8];
            parametro[0] = new SqlParameter("@Nombre", newUser.Nombre);
            parametro[1] = new SqlParameter("@Apellido", newUser.Apellido);
            parametro[2] = new SqlParameter("@Dni", newUser.DNI);
            parametro[3] = new SqlParameter("@Username", newUser.Username);
            parametro[4] = new SqlParameter("@Contraseña", newUser.Contraseña);
            parametro[5] = new SqlParameter("@Email", newUser.Email);
            parametro[6] = new SqlParameter("@FechaNacimiento", newUser.FechaNacimiento);
            parametro[7] = new SqlParameter("@Direccion", newUser.Direccion);
            return acceso.Escribir("CrearUsuario",parametro);
        }
        
        
    }
}
