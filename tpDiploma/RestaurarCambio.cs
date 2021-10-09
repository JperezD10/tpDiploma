using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace tpDiploma
{
    public partial class RestaurarCambio : Form, IObserver<string>
    {
        UsuarioCambiosBLL usuarioCambiosGestor = new UsuarioCambiosBLL();
        IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();
        public string idioma;

        UsuarioCambios _usuarioCambios;
        public RestaurarCambio(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            btnRestaurarInfoUsuario.Text = GetIdioma.buscarTexto(btnRestaurarInfoUsuario.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        public void listarCambios()
        {
            gridCambiosUsuario.DataSource = null;
            try
            {
                List<UsuarioCambios> cambios = UsuarioCambiosBLL.listarCambiosUsuario();
                gridCambiosUsuario.DataSource = cambios;
                gridCambiosUsuario.ScrollBars = ScrollBars.Both;
                hideColumn(gridCambiosUsuario, "idModificador");
                hideColumn(gridCambiosUsuario, "ID_Usuario");
                hideColumn(gridCambiosUsuario, "Username");
                hideColumn(gridCambiosUsuario, "Contraseña");
                hideColumn(gridCambiosUsuario, "IntentosIngreso");
                hideColumn(gridCambiosUsuario, "Estado");
                gridCambiosUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        private void RestaurarCambio_Load(object sender, EventArgs e)
        {
            listarCambios();
        }

        private void gridCambiosUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _usuarioCambios = (UsuarioCambios)gridCambiosUsuario.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }

        }

        private void btnRestaurarInfoUsuario_Click(object sender, EventArgs e)
        {
            if (_usuarioCambios != null)
            {
                UsuarioBLL gestor = new UsuarioBLL();
                try
                {
                    gestor.ModificarUsuario(_usuarioCambios);
                    listarCambios();
                    MessageBox.Show(GetIdioma.buscarTexto("msbReestaurarInfoUsuario", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbReestaurarInfoUsuarioSeleccionar", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
