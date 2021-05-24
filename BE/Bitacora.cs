using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int ID_Bitacora { get; set; }
        public string Accion { get; set; }
        public string Criticidad { get; set; }
        public string Descripcion { get; set; }
        public string DVH { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
