﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SEGURIDAD;
using System.Net;
using System.Net.Mail;
using BE;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL mapper = new UsuarioDAL();
        Encriptacion encriptado = new Encriptacion();
        DigitoVerificadorBLL digitosVerificadores = new DigitoVerificadorBLL();
        BitacoraBLL servicioBitacora = new BitacoraBLL();
        Usuario_Sesion session_User = Usuario_Sesion.Instance;
        public bool VerificarUsuario(string username)
        {
            username = encriptado.encriptar(username);
            return mapper.VerificarExistenciaUsuario(username);
        }
        public void SumarIntentosLog(string username)
        {
            username = encriptado.encriptar(username);
            mapper.SumarIntentosLog(username);
        }
        public void BloquearUsuario(string username)
        {
            username = encriptado.encriptar(username);
            mapper.BloquearUsuario(username);
        }
        public int MostrarIntentosLog(string username)
        {
            username = encriptado.encriptar(username);
            return mapper.MostrarIntentosRestantes(username);
        }

        public bool IniciarSesion(string username,string contraseña)
        {
            username = encriptado.encriptar(username);
            contraseña = encriptado.generarSHA256(contraseña);
            bool inicio = mapper.IniciarSesion(username, contraseña);
            BitacoraBLL servicioBitacora = new BitacoraBLL();
            BE.Bitacora bitacora = new BE.Bitacora()
            {
                Accion = "Inicio de sesión",
                Criticidad = "Baja",
                Descripcion = encriptado.encriptar($"El usuario {encriptado.desencriptar(username)} ha iniciado sesion"),
                Usuario = username
            };
            servicioBitacora.crearBitacora(bitacora);
            return inicio;
        }
        public int crearUsuario(BE.Usuario newUser)
        {
            string contraseñaRandom = newUser.Contraseña;
            newUser.Username = encriptado.encriptar(newUser.Username);
            newUser.Direccion = encriptado.encriptar(newUser.Direccion);
            newUser.Contraseña = encriptado.generarSHA256(newUser.Contraseña);
            int idNuevoUsuario= mapper.CrearUsuario(newUser);
            digitosVerificadores.recalcularDV(idNuevoUsuario,"Usuario", true);
            digitosVerificadores.recalcularDVV("Usuario");
            EnviarMail(newUser.Email, newUser.Nombre + " " + newUser.Apellido, encriptado.desencriptar(newUser.Username), contraseñaRandom);
            Bitacora bitacora = new Bitacora()
            {
                Accion = "Registro de usuario",
                Criticidad = "Media",
                Descripcion = encriptado.encriptar($"Se ha registrado a {newUser.Nombre} {newUser.Apellido}"),
                Usuario = session_User.Username
            };
            int idBitacora = servicioBitacora.crearBitacora(bitacora);
            digitosVerificadores.recalcularDV(idBitacora, "Bitacora", true);
            digitosVerificadores.recalcularDVV("Bitacora");
            return idNuevoUsuario;
        }
        private Random _random = new Random();
        public string GenerarContraseña()
        {
            bool lowerCase = false;
            var builder = new StringBuilder(40);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < 40; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public void EnviarMail(string email, string Nombre, string username, string password)
        {
            var fromAddress = new MailAddress("liceoperezdemonty@gmail.com", "Liceo Perez Demonty");
            var toAddress = new MailAddress(email, Nombre);
            string fromPassword = "Freya2205";
            string subject = "Bienvenido/a al Liceo";
            string body = "Bienvenido al liceo sr/sra " + Nombre + ". \nAqui se encuentran sus credenciales para ingresar al sistema: \nNombre de usuario: " + username + "\nContraseña: " + password + "\nLe deseamos mucha suerte!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
