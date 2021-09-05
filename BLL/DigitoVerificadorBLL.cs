using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using SEGURIDAD;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        DigitoVerificadorDAL DigitoVerificadorDAL = new DigitoVerificadorDAL();
        Encriptacion servicioEncriptacion = new Encriptacion();

        public long recalcularDV(int id, string nombre_tabla, Boolean guardar)
        {
            string nombreID = "ID_" + nombre_tabla;
            long DVH = DigitoVerificadorDAL.recalcularDV(id, nombre_tabla, guardar, nombreID);
            if (guardar)
            {
                recalcularDVV(nombre_tabla);
                return 0;
            }
            return DVH;
        }

        public long obtenerDVHRegistro(string nombreTabla, string nombreId, int id)
        {
            string nombreID = "ID_" + nombreId;
            return DigitoVerificadorDAL.obtenerDVHRegistro(nombreTabla, nombreID, id);
        }

        public void recalcularDVV(string nombreTabla)
        {
            string tablaEncriptada = servicioEncriptacion.encriptar(nombreTabla);
            long dvhAcumulado = DigitoVerificadorDAL.getSumaDVHDeTabla(nombreTabla);
            DigitoVerificadorDAL.recalcularDVV(tablaEncriptada, dvhAcumulado);
        }

        public List<Bitacora> validarDV()
        {
            List<Bitacora> listaBitacora = new List<Bitacora>();
            try
            {
                DataTable tablaDVV = DigitoVerificadorDAL.getTablaDVV();
                foreach (DataRow dataRow in tablaDVV.Rows)
                {
                    long acumuladorDVHTabla = 0;
                    string nombreTabla = servicioEncriptacion.desencriptar(dataRow["Tabla"].ToString());
                    DataTable tablaDVH = DigitoVerificadorDAL.getTablaDVHCompleta(nombreTabla);
                    foreach (DataRow dataRowDVH in tablaDVH.Rows)
                    {
                        if (dataRowDVH != null)
                        {
                            int id = (int)dataRowDVH[0];
                            long dvhGuardado = DigitoVerificadorDAL.obtenerDVHRegistro(nombreTabla, "ID_" + nombreTabla, id);
                            long dvhRecalculado = DigitoVerificadorDAL.recalcularDV(id, nombreTabla, false, "ID_" + nombreTabla);
                            acumuladorDVHTabla += dvhRecalculado;
                            if (dvhGuardado != dvhRecalculado)
                            {
                                Bitacora bitacora = new Bitacora
                                {
                                    Accion = "Registro alterado",
                                    Descripcion = "El registro con el ID: " + id + " en la tabla: " + nombreTabla + " ha sido alterado",
                                };
                                listaBitacora.Add(bitacora);
                            }
                        }
                    }
                    if (acumuladorDVHTabla != long.Parse(dataRow["DVV"].ToString()))
                    {
                        Bitacora bitacora = new Bitacora
                        {
                            Accion = "Registro eliminado o agregado",
                            Descripcion = "Un registro en la tabla: " + nombreTabla + " ha sido agregado o eliminado",
                        };
                        listaBitacora.Add(bitacora);
                    }
                }
                return listaBitacora;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void recalcularDVTotal()
        {
            DataTable tablaDVV = DigitoVerificadorDAL.getTablaDVV();
            foreach (DataRow dataRow in tablaDVV.Rows)
            {
                long acumuladorDVHTabla = 0;
                string nombreTabla = servicioEncriptacion.desencriptar(dataRow["Tabla"].ToString());
                DataTable tablaDVH = DigitoVerificadorDAL.getTablaDVHCompleta(nombreTabla);
                foreach (DataRow dataRowDVH in tablaDVH.Rows)
                {
                    if (dataRowDVH != null)
                    {
                        int id = (int)dataRowDVH[0];
                        long dvhRecalculado = DigitoVerificadorDAL.recalcularDV(id, nombreTabla, true, "ID_" + nombreTabla);
                        acumuladorDVHTabla += dvhRecalculado;
                    }
                }
                DigitoVerificadorDAL.recalcularDVV(dataRow["Tabla"].ToString(), acumuladorDVHTabla);
            }

        }
    }
}
