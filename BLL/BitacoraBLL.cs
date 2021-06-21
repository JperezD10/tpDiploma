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
        DigitoVerificadorBLL digitosVerificadores = new DigitoVerificadorBLL();
        public int crearBitacora(BE.Bitacora b)
        {
            int id = mapper.CrearBitacora(b);
            digitosVerificadores.recalcularDV(id, "Bitacora", true);
            digitosVerificadores.recalcularDVV("Bitacora");
            return id;
        }

        public List<BE.Bitacora> listarBitacora(DateTime fechaDesde, DateTime fechaHasta, string criticidad, string usuario)
        {
            SEGURIDAD.Encriptacion c = new SEGURIDAD.Encriptacion();
            if (usuario != string.Empty) return mapper.listarBitacora(fechaDesde,fechaHasta,criticidad,c.encriptar(usuario));
            else return mapper.listarBitacora(fechaDesde, fechaHasta, criticidad, usuario);
        }
    }
}
