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
    public partial class CompletarIdioma : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        private IdiomaControl _idiomaControl;
        private List<IdiomaControl> _controlesATraducir;
        public string idioma;
        MenuPrincipal menu;
        public CompletarIdioma(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            menu = m;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
            _idiomaControl = null;
        }

        public void OnCompleted()
        {
            lblLenguajeLogin.Text = GetIdioma.buscarTexto(lblLenguajeLogin.Name, idioma);
            lblTraduccion.Text = GetIdioma.buscarTexto(lblTraduccion.Name, idioma);
            btnGuardarTraduccion.Text = GetIdioma.buscarTexto(btnGuardarTraduccion.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            this.idioma = value;
        }

        private void CompletarIdioma_Load(object sender, EventArgs e)
        {
            cmbCompletarIdioma.Items.Clear();
            cmbCompletarIdioma.DataSource = GetIdioma.CargarIdiomas();
            LlenarGrillaATraducir();
            lblControlATraducir.Text = "";
        }

        public void LlenarGrillaATraducir()
        {
            string idiomaATraducir = cmbCompletarIdioma.Text;
            GrillaATraducir.DataSource = null;
            _controlesATraducir = new List<IdiomaControl>();
            _controlesATraducir = GetIdioma.ObtenerControlesPendientesATraducir(idiomaATraducir);
            GrillaATraducir.DataSource = _controlesATraducir;
            hideColumn(GrillaATraducir, "ID_IdiomaControl");
            hideColumn(GrillaATraducir, "Traduccion");
            GrillaATraducir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        private void cmbCompletarIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGrillaATraducir();
        }

        private void GrillaATraducir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _idiomaControl = (IdiomaControl)GrillaATraducir.Rows[e.RowIndex].DataBoundItem;
                lblControlATraducir.Text = _idiomaControl.NombreControl;
            }
            catch (Exception)
            {

            }
        }

        private void btnGuardarTraduccion_Click(object sender, EventArgs e)
        {
            if (_idiomaControl==null)
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbIdiomaControlVacio", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtTraduccion.Text))
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbTraduccionVacia", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _idiomaControl.Traduccion = txtTraduccion.Text;
                GetIdioma.GuardarTraduccion(_idiomaControl, cmbCompletarIdioma.Text);
                serviceObservable.Notify(Properties.Settings.Default.Idioma);
                menu.OnCompleted();
                MessageBox.Show(GetIdioma.buscarTexto("msbTraduccionExitosa", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _controlesATraducir.Remove(_idiomaControl);
                txtTraduccion.Clear();
                LlenarGrillaATraducir();
            }
            _idiomaControl = null;
            lblControlATraducir.Text = "";
        }

        private void txtTraduccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTraduccion_Click(object sender, EventArgs e)
        {

        }
    }
}
