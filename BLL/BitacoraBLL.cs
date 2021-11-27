using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using SEGURIDAD;

namespace BLL
{
    public class BitacoraBLL
    {
        DAL.BitacoraDAL mapper = new DAL.BitacoraDAL();
        DigitoVerificadorBLL digitosVerificadores = new DigitoVerificadorBLL();
        public int crearBitacora(Bitacora b)
        {
            int id = mapper.CrearBitacora(b);
            digitosVerificadores.recalcularDV(id, "Bitacora", true);
            digitosVerificadores.recalcularDVV("Bitacora");
            return id;
        }

        public List<Bitacora> listarBitacora(DateTime fechaDesde, DateTime fechaHasta, string criticidad, string usuario)
        {
            Encriptacion c = new Encriptacion();
            if (usuario != string.Empty) return mapper.listarBitacora(fechaDesde,fechaHasta,criticidad,c.encriptar(usuario));
            else return mapper.listarBitacora(fechaDesde, fechaHasta, criticidad, usuario);
        }
    }
}
