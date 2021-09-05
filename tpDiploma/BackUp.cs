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
    public partial class BackUp : Form, IObserver<string>
    {
        BLL.IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();
        BLL.ServicioBackupRestore servicioBackupRestore = new BLL.ServicioBackupRestore();
        public string idioma;
        public BackUp(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            lblRutaBackUp.Text = GetIdioma.buscarTexto(lblRutaBackUp.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void BackUp_Load(object sender, EventArgs e)
        {

        }

        private void btnPathBackUp_Click(object sender, EventArgs e)
        {
            openFolderDialog();
        }

        private void openFolderDialog()
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    txtRutaBackUp.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void realizarBackup()
        {
            if (txtRutaBackUp.Text != "")
            {
                string result = servicioBackupRestore.realizarBackup(txtRutaBackUp.Text);
                if (result != "")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    txtRutaBackUp.Clear();
                    MessageBox.Show(GetIdioma.buscarTexto("mensajeBackupExitoso", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            realizarBackup();
        }
    }
}
