using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ProfesorDAL
    {
        Acceso Acceso = Acceso.Instance;

        public int AgregarProfesor(Profesor profe)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", profe.Nombre),
                new SqlParameter("@apellido", profe.Apellido),
                new SqlParameter("@email", profe.Email),
                new SqlParameter("@DNI", profe.DNI),
                new SqlParameter("@SueldoMateria", profe.SueldoMateria),
                new SqlParameter
                {
                    ParameterName="@returnValue",
                    Direction= ParameterDirection.ReturnValue
                }
            };
            Acceso.Escribir("Agregar_Profesor", parametros);
            return (int)parametros[5].Value;
        }
    }
}
