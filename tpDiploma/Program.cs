using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpDiploma
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //LogIn l = new LogIn();
            //l.idioma = "Español";
            //MenuPrincipal m = new MenuPrincipal(l);
            Application.Run(new LogIn());
        }
    }
}
