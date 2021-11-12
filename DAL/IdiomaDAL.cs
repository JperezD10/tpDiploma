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

        public void GuardarTraduccion(IdiomaControl idiomaControl, string idioma)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@traduccion", idiomaControl.Traduccion);
            sqlParameters[1] = new SqlParameter("@idioma", idioma);
            sqlParameters[2] = new SqlParameter("@NombreControl", idiomaControl.NombreControl);
            acceso.Escribir("GuardarTraduccion", sqlParameters);
        }

        public List<IdiomaControl> ObtenerControlesPendientesATraducir(string idioma)
        {
            List<IdiomaControl> controles = new List<IdiomaControl>();
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@idioma", idioma)
            };
            DataTable tabla = acceso.Leer("ControlesATraducir", sqlParameters);
            foreach (DataRow fila in tabla.Rows)
            {
                IdiomaControl control = new IdiomaControl()
                {
                    NombreControl = fila["nombreControl"].ToString()
                };
                controles.Add(control);
            }
            return controles;
        }

        public bool ValidarIdiomaDisponible(string idioma)
        {
            bool libre = true;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@idioma", idioma);
            DataTable dataTable = acceso.Leer("ValidarNuevoIdioma", sqlParameters);
            if (dataTable.Rows.Count > 0)
                libre = false;
            else
                libre = true;
            return libre;
        }
        public void GuardarIdioma(string idioma)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@idioma", idioma);
            acceso.Escribir("GuardarIdioma", sqlParameters);
        }
    }
}
