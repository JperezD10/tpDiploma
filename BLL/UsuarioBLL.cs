using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SEGURIDAD;
using System.Net;
using System.Net.Mail;


namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL mapper = new UsuarioDAL();
        Encriptacion encriptado = new Encriptacion();

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
            return mapper.IniciarSesion(username, contraseña);
        }
        public string crearUsuario(BE.Usuario newUser)
        {
            EnviarMail(newUser.Email, newUser.Nombre + " " + newUser.Apellido, newUser.Username, newUser.Contraseña);
            newUser.Username = encriptado.encriptar(newUser.Username);
            newUser.Direccion = encriptado.encriptar(newUser.Direccion);
            newUser.Contraseña = encriptado.generarSHA256(newUser.Contraseña);
            return mapper.CrearUsuario(newUser);
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
