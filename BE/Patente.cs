using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patente: Permiso
    {
        public string nombre
        {
            get => base.nombre;
            set => base.nombre = value;
        }
    }
}
