using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
    public class IdiomaDAL
    {
        Acceso acceso = Acceso.Instance;

        public List<string> CargarIdiomas()
        {
            List<string> idiomas = new List<string>();
            DataTable dataTable = acceso.Leer("ListarIdiomas", null);
            foreach (DataRow item in dataTable.Rows)
            {
                idiomas.Add(item["Idioma"].ToString());
            }
            return idiomas;
        }
        public String obtenerTexto(string mensaje, string idioma)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@idioma", idioma);
            sqlParameters[1] = new SqlParameter("@nombreControl", mensaje);
            DataTable dataTable = acceso.Leer("BuscarTexto", sqlParameters);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                return dataRow["Traduccion"].ToString();
            }
            return "";
        }
    }
}
