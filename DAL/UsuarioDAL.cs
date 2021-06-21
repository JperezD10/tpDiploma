﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BE;
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
                ObtenerUsuarioLogin(Username);
                ReestablecerContadorLog(Username);
                
                return true;
            }
            else return false;
        }

        private void ObtenerUsuarioLogin(string username)
        {
            Usuario_Sesion usuario = Usuario_Sesion.Instance;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@username", username);
            DataTable tabla = acceso.Leer("ObtenerUsuarioLogin", parametros);
            foreach(DataRow fila in tabla.Rows)
            {
                usuario.ID_Usuario = (int)fila["ID_Usuario"];
                usuario.Nombre = fila["Nombre"].ToString();
                usuario.Apellido = fila["Apellido"].ToString();
                usuario.Email = fila["Email"].ToString();
                usuario.DNI = fila["DNI"].ToString();
                usuario.Username = fila["Username"].ToString();
            }
        }

        public int CrearUsuario(BE.Usuario newUser)
        {
            SqlParameter[] parametro = new SqlParameter[9];
            parametro[0] = new SqlParameter("@Nombre", newUser.Nombre);
            parametro[1] = new SqlParameter("@Apellido", newUser.Apellido);
            parametro[2] = new SqlParameter("@Dni", newUser.DNI);
            parametro[3] = new SqlParameter("@Username", newUser.Username);
            parametro[4] = new SqlParameter("@Contraseña", newUser.Contraseña);
            parametro[5] = new SqlParameter("@Email", newUser.Email);
            parametro[6] = new SqlParameter("@FechaNacimiento", newUser.FechaNacimiento);
            parametro[7] = new SqlParameter("@Direccion", newUser.Direccion);
            parametro[8] = new SqlParameter
            {
                ParameterName = "@returnValue",
                Direction = ParameterDirection.ReturnValue
            };
            acceso.Escribir("CrearUsuario",parametro);
            return (int)parametro[8].Value;
        }
        
        
    }
}
