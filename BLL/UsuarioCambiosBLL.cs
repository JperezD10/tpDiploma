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
    public class UsuarioCambiosBLL
    {
        
        public static void crearUsuarioCambios(Usuario usuario)
        {
            UsuarioCambiosDAL mapper = new UsuarioCambiosDAL();
            mapper.CrearUsuarioAuditoria(usuario);
        }

        public static List<UsuarioCambios> listarCambiosUsuario()
        {
            UsuarioCambiosDAL mapper = new UsuarioCambiosDAL();
            Encriptacion encriptacion = new Encriptacion();
            List<UsuarioCambios> cambios = mapper.listarUsuarioCambios();
            foreach (var cambio in cambios)
            {
                cambio.Modificador = encriptacion.desencriptar(cambio.Modificador);
            }
            return cambios;
        }

        
    }
}
