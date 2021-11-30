using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso
    {
        public int codigoPermiso { get; set; }
        public string DVH { get; set; }
        public string nombre { get; set; }
        public Boolean isFamilia { get; set; }

        public List<Permiso> listaPermisos = new List<Permiso>();

        public void addPermiso(Permiso permiso)
        {
            if (!listaPermisos.Contains(permiso)){
                listaPermisos.Add(permiso);
            }
          
        }

        public  void removePermiso(Permiso permiso)
        {
            listaPermisos.Remove(permiso);
        }

    }
}
