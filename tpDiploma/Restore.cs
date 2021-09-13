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
    public partial class Restore : Form, IObserver<string>
    {
        BLL.IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();
        BLL.ServicioBackupRestore servicioBackupRestore = new BLL.ServicioBackupRestore();
        public string idioma;
        public Restore(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        private void Restore_Load(object sender, EventArgs e)
        {

        }

        public void OnCompleted()
        {
            lblRutaRestore.Text = GetIdioma.buscarTexto(lblRutaRestore.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            realizarRestore();
        }

        private void btnPathRestore_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }
        private void openFileDialog()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "bak files (*.bak)|*.bak";
                if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    txtRutaRestore.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void realizarRestore()
        {
            if (txtRutaRestore.Text != "")
            {
                string result = servicioBackupRestore.realizarRestore(txtRutaRestore.Text);
                if (result != "")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    txtRutaRestore.Clear();
                    MessageBox.Show(GetIdioma.buscarTexto("mensajeRestoreExitoso", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
