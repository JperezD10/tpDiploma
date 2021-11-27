using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia : Permiso
    {
        public List<Permiso> listaPermisos { get; set; }

        public string nombre
        {
            get => base.nombre;
            set => base.nombre = value;
        }
    }
}
