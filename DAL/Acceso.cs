using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL
{
    public class Acceso
    {
        private static Acceso _instance = null;

        public static Acceso Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Acceso();
                }

                return _instance;
            }
        }

        SqlConnection sqlConnection = new SqlConnection();
        SqlTransaction sqlTransaction;

        public void openConnection()
        {
            try
            {
                //String strAppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //String strFilePath = Path.Combine(strAppPath, "SalaEnsayo");
                //String strFullFilename = Path.Combine(strFilePath, "SalaEnsayo.mdf");
                //sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + strFullFilename + ";Integrated Security=True");
                sqlConnection.ConnectionString = @"Data Source=MSI;Initial Catalog=DIPLOMA;Integrated Security=True";
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlConnection getConnnection()
        {
            try
            {
                //String strAppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //String strFilePath = Path.Combine(strAppPath, "SalaEnsayo");
                //String strFullFilename = Path.Combine(strFilePath, "SalaEnsayo.mdf");
                //sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + strFullFilename + ";Integrated Security=True");
                sqlConnection.ConnectionString = @"Data Source=DESKTOP-TLDQ719\MSSQLSERVER19;Initial Catalog=SalaEnsayo;Integrated Security=True";
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void closeConnection()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception)
            {

            }
        }

        public DataTable Leer(String st, SqlParameter[] parameters)
        {
            closeConnection();
            openConnection();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand();
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.CommandText = st;
            if (parameters != null)
            {
                sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters);
            }
            sqlDataAdapter.SelectCommand.Connection = sqlConnection;
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            closeConnection();
            return dataTable;
        }
        public String Escribir(String st, SqlParameter[] parameters)
        {
            openConnection();
            sqlTransaction = sqlConnection.BeginTransaction();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = st;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.AddRange(parameters);
            try
            {
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                return ex.Message;
            }
            closeConnection();
            return "";
        }
    }
}
