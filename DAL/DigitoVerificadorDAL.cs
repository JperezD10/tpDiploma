using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DigitoVerificadorDAL
    {
        Acceso db = Acceso.Instance;

        public long recalcularDV(int id, string nombre_tabla, bool guardar, string nombre_id)
        {
            long acumuladorTotalDVH = 0;

            SqlParameter[] sqlParameters = getTablaDVH(nombre_id, nombre_tabla, id);

            DataTable dataTable = db.Leer("DVH_REGISTRO_COMPLETO", sqlParameters);

            Dictionary<int, long> hashId_Dvh = new Dictionary<int, long>();
            foreach (DataRow row in dataTable.Rows)
            {
                long acumuladorDVH = 0;
                foreach (DataColumn column in row.Table.Columns)
                {
                    string columnName = column.ColumnName;
                    if (columnName.ToLower().Equals("dvh"))
                    {
                        continue;
                    }
                    string valorColumna = row[column].ToString();
                    for (int i = 0; i < valorColumna.Length; i++)
                    {
                        int ASCII = getValorASCII(valorColumna[i]);
                        long valorDigitoCaracter = multiplicarPorPeso(ASCII, i + 1);
                        acumuladorDVH += valorDigitoCaracter;
                    }
                }

                //lo agrego al id por si luego tengo que guardar en bbdd
                hashId_Dvh.Add(int.Parse(row[nombre_id].ToString()), acumuladorDVH);
                acumuladorTotalDVH = acumuladorDVH;
            }

            if (!guardar)
            {
                return acumuladorTotalDVH;
            }

            SqlParameter[] sqlParametersDVH = new SqlParameter[4];
            sqlParametersDVH[0] = new SqlParameter("@nombre_tabla", nombre_tabla);
            sqlParametersDVH[1] = new SqlParameter("@nombre_id", nombre_id);

            foreach (int idRegistro in hashId_Dvh.Keys)
            {
                long dvh = hashId_Dvh[idRegistro];
                sqlParametersDVH[2] = new SqlParameter("@id", idRegistro);
                sqlParametersDVH[3] = new SqlParameter("@dvh", dvh);
                db.Escribir("DVH_GUARDAR", sqlParametersDVH);
            }
            return acumuladorTotalDVH;
        }

        public int getValorASCII(char Caracter)
        {
            return (int)Caracter;
        }

        public long multiplicarPorPeso(int ASCII, int i)
        {
            return ASCII * i;
        }

        public SqlParameter[] getTablaDVH(string nombre_id, string nombre_tabla, int id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@nombre_tabla", nombre_tabla);
            sqlParameters[1] = new SqlParameter("@nombre_id", nombre_id);
            sqlParameters[2] = new SqlParameter("@id", id); //si el id es -1 que traiga toda la tabla
            return sqlParameters;
        }

        public long getSumaDVHDeTabla(string nombreTabla)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@nombreTabla", nombreTabla);
            DataTable dataTable = db.Leer("DVH_OBTENER_SUMA_TABLA", sqlParameters);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["DVH"].ToString() == "") return 0;
                return long.Parse(dataRow["DVH"].ToString());
            }
            return 0;
        }

        public string recalcularDVV(string nombreTabla, long acumulador)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@nombreTabla", nombreTabla);
            sqlParameters[1] = new SqlParameter("@dvv", acumulador);
            return db.Escribir("DVV_GUARDAR", sqlParameters);
        }

        public DataTable getTablaDVV()
        {
            return db.Leer("DVV_TABLA_COMPLETA", null);
        }

        public DataTable getTablaDVHCompleta(string nombreTabla)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@nombreTabla", nombreTabla);
            return db.Leer("DVH_TRAER_TABLA_COMPLETA", sqlParameters);
        }

        public DataTable getTablaDVVParticular(string nombreTabla)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@nombreTabla", nombreTabla);
            return db.Leer("DVV_OBTENER_TABLA_PARTICULAR", sqlParameters);
        }

        public long obtenerDVHRegistro(string nombre_tabla, string nombre_id, int id)
        {
            SqlParameter[] sqlParametersRegistro = new SqlParameter[3];
            sqlParametersRegistro[0] = new SqlParameter("@nombreTabla", nombre_tabla);
            sqlParametersRegistro[1] = new SqlParameter("@id", id);
            sqlParametersRegistro[2] = new SqlParameter("@nombreId", nombre_id);
            DataTable dataRegistro = db.Leer("DVH_TRAER_DVH_REGISTRO", sqlParametersRegistro);
            foreach (DataRow dataRow in dataRegistro.Rows)
            {
                return long.Parse(dataRow["DVH"].ToString());
            }
            return 0;
        }
    }
}
