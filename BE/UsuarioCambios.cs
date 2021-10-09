using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioCambios: Usuario
    {
        public int idModificador { get; set; }
        public string Modificador { get; set; }
        public DateTime Fecha { get; set; }
    }
}
