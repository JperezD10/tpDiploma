using BE;
using BLL;
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
    public partial class RestoreCorrupto : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        PermisoBL servicioPermiso = new PermisoBL();
        Usuario_Sesion usuario_Sesion = Usuario_Sesion.Instance;
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        ServicioBackupRestore servicioBackupRestore = new ServicioBackupRestore();
        public string idioma;
        LogIn login;
        public RestoreCorrupto(LogIn l)
        {
            InitializeComponent();
            login = l;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
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
            if (comprobarPatentePorUsuario("Realistar restore"))
            {
                if (txtRutaRestore.Text != "")
                {
                    string result = servicioBackupRestore.realizarRestore(txtRutaRestore.Text);
                    if (result != "")
                    {
                        MessageBox.Show(result);
                        this.Close();
                        this.login.Show();
                    }
                    else
                    {
                        txtRutaRestore.Clear();
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeRestoreExitoso", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                showPermisoInsuficiente();
            }
        }
        private bool comprobarPatentePorUsuario(string nombrePatente)
        {
            Permiso patente = new Patente();
            patente.nombre = nombrePatente;
            return servicioPermiso.comprobarPatentePorUsuario(patente, usuario_Sesion);
        }
        private void showPermisoInsuficiente()
        {
            MessageBox.Show(GetIdioma.buscarTexto("mensajePermisoInsuficiente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
