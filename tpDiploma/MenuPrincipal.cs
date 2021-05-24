using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpDiploma
{
    public partial class MenuPrincipal : Form, IObserver<string>
    {
        LogIn login = new LogIn();
        BLL.IdiomaBLL gestoriIdioma = new BLL.IdiomaBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();

        public string idioma;
        public MenuPrincipal(LogIn l)
        {
            InitializeComponent();
            this.login = l;
            Properties.Settings.Default.Idioma = l.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count>0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new CrearUsuario(this));
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            btnRegistrarUsuario.Text = gestoriIdioma.buscarTexto(btnRegistrarUsuario.Name, idioma);
            btnCerrarSesion.Text = gestoriIdioma.buscarTexto(btnCerrarSesion.Name, idioma);
            baseDeDatosToolStripMenuItem.Text = gestoriIdioma.buscarTexto(baseDeDatosToolStripMenuItem.Name, idioma);
            generarBackUpToolStripMenuItem.Text = gestoriIdioma.buscarTexto(generarBackUpToolStripMenuItem.Name, idioma);
            generarRestoreToolStripMenuItem.Text = gestoriIdioma.buscarTexto(generarRestoreToolStripMenuItem.Name, idioma);
        }

        private void btnListBitacora_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListBitacora(this));
        }
    }
}
