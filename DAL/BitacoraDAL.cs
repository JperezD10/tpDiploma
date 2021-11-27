using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class BitacoraDAL
    {
        Acceso acceso = Acceso.Instance;
        SEGURIDAD.Encriptacion seguridad = new SEGURIDAD.Encriptacion();
        public int CrearBitacora(Bitacora bitacora)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Accion", bitacora.Accion),
                    new SqlParameter("@Descripcion", bitacora.Descripcion),
                    new SqlParameter("@Criticidad", bitacora.Criticidad),
                    new SqlParameter("@usuario", bitacora.Usuario),
                    new SqlParameter
                    {
                        ParameterName="@returnValue",
                        Direction= ParameterDirection.ReturnValue
                    }
                };
                acceso.Escribir("RegistrarBitacora", parametros);
                return (int)parametros[4].Value;
            }
            catch (Exception ex)
            {
                acceso.Serialize(ex);
                throw ex;
            }
        }

        public List<Bitacora> listarBitacora(DateTime fechaDesde, DateTime fechaHasta, string criticidad, string usuario)
        {
            List<Bitacora> resultado = new List<Bitacora>();
            DataTable dt = new DataTable();
            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaDesde",fechaDesde==DateTime.MinValue ? (object)DBNull.Value : fechaDesde),
                new SqlParameter("@fechaHasta",fechaHasta==DateTime.MinValue ? (object)DBNull.Value : fechaHasta),
                new SqlParameter("@criticidad",criticidad == "" ? (object)DBNull.Value : criticidad),
                new SqlParameter("@usuario",usuario == "" ? (object)DBNull.Value : usuario),
            };

            dt = acceso.Leer("ListarBitacora", parametros);

            foreach (DataRow row in dt.Rows)
            {
                Bitacora b = new Bitacora()
                {
                    Accion = row["Accion"].ToString(),
                    Descripcion = seguridad.desencriptar(row["Descripcion"].ToString()),
                    Fecha = (DateTime)row["Fecha"],
                    Usuario = seguridad.desencriptar(row["Username"].ToString()),
                    Criticidad = row["Criticidad"].ToString()
                };
                resultado.Add(b);
            }
            return resultado;
        }
    }
}
