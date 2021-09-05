using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BE;
using System.Threading.Tasks;

namespace DAL
{
    public class BackUpRestoreDAL
    {
        Acceso Acceso = Acceso.Instance;

        public string realizarBackup(BackUpRestore backup_Restore)
        {
            try
            {
                DateTime fechaBackup = DateTime.Now.Date;
                backup_Restore.ruta = backup_Restore.ruta + "\\Escuela_" + fechaBackup.ToShortDateString().Replace('/', '-') + ".BAK";
                var conexion = Acceso.getConnnection();
                var sqlConStrBuilder = new SqlConnectionStringBuilder(conexion.ConnectionString);
                var query = String.Format("BACKUP DATABASE DIPLOMA TO DISK='{0}'", backup_Restore.ruta);
                var cmd1 = new SqlCommand(query, conexion);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Acceso.closeConnection();
            }
            return "";
        }

        public bool realizarRestore(BackUpRestore backup_Restore)
        {
            String database = "DIPLOMA";
            String filePath = backup_Restore.ruta;
            bool exito = false;
            try
            {
                SqlConnection connection = Acceso.getConnnection();
                connection.Close();
                connection.Open();

                SqlCommand cmd1 =
                new SqlCommand("alter database [" + database + "] set offline with rollback immediate",
                connection);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 =
                new SqlCommand("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ",
                connection);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 =
                new SqlCommand(
                "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + filePath + "' WITH REPLACE",
                connection);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("ALTER DATABASE [" + database + "] SET MULTI_USER", connection);
                cmd4.ExecuteNonQuery();
                SqlCommand cmd5 =
                new SqlCommand("alter database [" + database + "] set online",
                connection);
                cmd5.ExecuteNonQuery();
                connection.Close();
                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
                throw ex;
            }

            return exito;
        }
    }
}
