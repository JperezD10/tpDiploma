using BE;
using DAL;
using SEGURIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioBackupRestore
    {
        BackUpRestore backup_Restore;
        BackUpRestoreDAL Backup_RestoreDAL = new BackUpRestoreDAL();
        BitacoraBLL ServicioBitacora = new BitacoraBLL();
        Usuario_Sesion Usuario_Sesion = Usuario_Sesion.Instance;
        Encriptacion encriptacion = new Encriptacion();

        public string realizarBackup(string ruta)
        {
            try
            {
                backup_Restore = new BackUpRestore();
                String rutaSinComilla = ruta.Replace("\\\\", "\\");
                backup_Restore.ruta = rutaSinComilla;
                Backup_RestoreDAL.realizarBackup(backup_Restore);
                Bitacora bitacora = new Bitacora()
                {
                    Accion = "Backup",
                    Criticidad = "Alta",
                    Descripcion = encriptacion.encriptar("Se ha realizado un backup de la base de datos"),
                    Usuario = encriptacion.encriptar(Usuario_Sesion.Username)
                };
                ServicioBitacora.crearBitacora(bitacora);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string realizarRestore(string ruta)
        {
            try
            {
                backup_Restore = new BackUpRestore();
                backup_Restore.ruta = ruta;
                if (Backup_RestoreDAL.realizarRestore(backup_Restore).Equals(true))
                {
                    Bitacora bitacora = new Bitacora()
                    {
                        Accion = "Restore",
                        Criticidad = "Alta",
                        Descripcion = encriptacion.encriptar("Se ha realizado un restore de la base de datos"),
                        Usuario = encriptacion.encriptar(Usuario_Sesion.Username)
                    };
                    ServicioBitacora.crearBitacora(bitacora);
                    return "";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
