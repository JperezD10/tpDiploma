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
    public class UsuarioCambiosDAL
    {
        Acceso acceso = Acceso.Instance;
        Encriptacion encriptado = new Encriptacion();
        Usuario_Sesion Usuario_Sesion = Usuario_Sesion.Instance;
        public List<UsuarioCambios> listarUsuarioCambios()
        {
            List<UsuarioCambios> listaUsuariosAuditoria = new List<UsuarioCambios>();
            DataTable dataTable = new DataTable();
            try
            {
                SqlParameter[] parametro = new SqlParameter[1];
                parametro[0] = new SqlParameter("@ID_USUARIO", Usuario_Sesion.ID_Usuario);
                dataTable = acceso.Leer("OBTENER_AUDITORIA_USUARIO", parametro);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    UsuarioCambios usuario = new UsuarioCambios();
                    usuario.Nombre = dataRow["Nombre"].ToString();
                    usuario.Apellido = dataRow["Apellido"].ToString();
                    usuario.Email = dataRow["Email"].ToString();
                    usuario.DNI = dataRow["DNI"].ToString();
                    usuario.FechaNacimiento = (DateTime)dataRow["FechaNacimiento"];
                    usuario.Direccion = dataRow["Direccion"].ToString();
                    usuario.Fecha = (DateTime)dataRow["Fecha"];
                    usuario.Modificador = dataRow["Username"].ToString();
                    usuario.ID_Usuario = (int)dataRow["ID_Usuario"];
                    listaUsuariosAuditoria.Add(usuario);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaUsuariosAuditoria;
        }

        public int CrearUsuarioAuditoria(Usuario cambiosUsuario)
        {
            SqlParameter[] parametro = new SqlParameter[8];
            parametro[0] = new SqlParameter("@Nombre", cambiosUsuario.Nombre);
            parametro[1] = new SqlParameter("@Apellido", cambiosUsuario.Apellido);
            parametro[2] = new SqlParameter("@Dni", cambiosUsuario.DNI);
            parametro[3] = new SqlParameter("@Email", cambiosUsuario.Email);
            parametro[4] = new SqlParameter("@FechaNacimiento", cambiosUsuario.FechaNacimiento);
            parametro[5] = new SqlParameter("@Direccion", cambiosUsuario.Direccion);
            parametro[6] = new SqlParameter("@idUsuario", cambiosUsuario.ID_Usuario);
            parametro[7] = new SqlParameter("@idModificador", Usuario_Sesion.ID_Usuario);
            acceso.Escribir("CrearAuditoriaUsuario", parametro);
            return Usuario_Sesion.ID_Usuario;
        }
    }
}
