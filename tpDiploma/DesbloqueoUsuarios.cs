using BLL;
using BE;
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
    public partial class DesbloqueoUsuarios : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        UsuarioBLL servicioUsuario = new UsuarioBLL();
        private Usuario _usuarioDesbloqueo;
        public string idioma;
        public DesbloqueoUsuarios(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            btnDesbloquearUsuario.Text = GetIdioma.buscarTexto(btnDesbloquearUsuario.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            if (_usuarioDesbloqueo != null)
            {
                servicioUsuario.DesbloquearUsuario(_usuarioDesbloqueo);
                _usuarioDesbloqueo = null;
                LlenarGrillaBloqueados();
                MessageBox.Show(GetIdioma.buscarTexto("msbDesbloqueoExitoso", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(GetIdioma.buscarTexto("msbDesbloqueoSeleccionar", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void GrillaUsuariosBloqueados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _usuarioDesbloqueo = (Usuario)GrillaUsuariosBloqueados.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }
        }
        
        private void LlenarGrillaBloqueados()
        {
            GrillaUsuariosBloqueados.DataSource = null;
            GrillaUsuariosBloqueados.DataSource = servicioUsuario.ObtenerUsuariosBloqueados();

            GrillaUsuariosBloqueados.ScrollBars = ScrollBars.Both;
            hideColumn(GrillaUsuariosBloqueados, "ID_Usuario");
            hideColumn(GrillaUsuariosBloqueados, "Username");
            hideColumn(GrillaUsuariosBloqueados, "Contraseña");
            hideColumn(GrillaUsuariosBloqueados, "IntentosIngreso");
            hideColumn(GrillaUsuariosBloqueados, "Estado");
            GrillaUsuariosBloqueados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        private void DesbloqueoUsuarios_Load(object sender, EventArgs e)
        {
            LlenarGrillaBloqueados();
        }
    }
}
