using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario_Sesion: Usuario
    {
        private static Usuario_Sesion _instance = null;
        public static Usuario_Sesion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Usuario_Sesion();
                }

                return _instance;
            }
        }
    }
}
