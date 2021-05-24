using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BitacoraBLL
    {
        DAL.BitacoraDAL mapper = new DAL.BitacoraDAL();

        public void crearBitacora(BE.Bitacora b)
        {
            mapper.CrearBitacora(b);
        }

        public List<BE.Bitacora> listarBitacora(DateTime fechaDesde, DateTime fechaHasta, string criticidad, string usuario)
        {
            return mapper.listarBitacora(fechaDesde,fechaHasta,criticidad,usuario);
        }
    }
}
