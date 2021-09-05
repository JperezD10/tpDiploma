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
    public partial class ABMFamilia : Form, IObserver<string>
    {
        BLL.PermisoBL servicioPermiso = new BLL.PermisoBL();
        BLL.IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();
        public string idioma;
        public ABMFamilia(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            btnCrearFamilia.Text = GetIdioma.buscarTexto(btnCrearFamilia.Name, idioma);
            lblNombreFamiliaCrear.Text = GetIdioma.buscarTexto(lblNombreFamiliaCrear.Name, idioma);
            lblFamiliaListar.Text = GetIdioma.buscarTexto(lblFamiliaListar.Name, idioma);
            btnEliminarFamilia.Text = GetIdioma.buscarTexto(btnEliminarFamilia.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreFamilia.Text))
            {
                Permiso familia = new Familia()
                {
                    nombre = txtNombreFamilia.Text
                };
                servicioPermiso.agregarFamilia(familia);
                MessageBox.Show(GetIdioma.buscarTexto("msbFamiliaAgregada", idioma),"",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cargarFamilias();
            }
            else
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbNombreFamiliaInvalido", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ABMFamilia_Load(object sender, EventArgs e)
        {
            cargarFamilias();
        }

        void cargarFamilias()
        {
            cmbFamilias.Items.Clear();
            List<Permiso> familias = servicioPermiso.listarFamiliasTodasOPorUsuario(null);
            foreach (Familia familia in familias)
            {
                cmbFamilias.Items.Add(familia.nombre);
            }
        }

        private void cmbFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPatentesPorFamilia();
            listarPatentesQueNoSeanDeLaFamilia();
        }

        private void listarPatentesPorFamilia()
        {
            Permiso familia = new Familia();
            familia.nombre = cmbFamilias.SelectedItem.ToString();
            List<Permiso> listaPatentes = servicioPermiso.listarPatentesPorFamiliaODistinta(familia, "OBTENER_PATENTE_X_FAMILIA");
            setDataGridPatentes(listaPatentes, GrillaPatenteFamilia);
        }
        private void listarPatentesQueNoSeanDeLaFamilia()
        {
            Permiso familia = new Familia();
            familia.nombre = cmbFamilias.SelectedItem.ToString();
            List<Permiso> listaPatentes = servicioPermiso.listarPatentesPorFamiliaODistinta(familia, "OBTENER_PATENTSE_QUITANDO_PATENTES_FAMILIA");
            setDataGridPatentes(listaPatentes, GrillaPatentesSinOtorgar);
        }
        private void setDataGridPatentes(List<Permiso> listaPatentes, DataGridView dataGridView)
        {
            dataGridView.DataSource = listaPatentes;
            dataGridView.ClearSelection();
            hideColumn(dataGridView, "codigoPermiso");
            hideColumn(dataGridView, "DVH");
            hideColumn(dataGridView, "isFamilia");
            changeHeaderText(dataGridView, "nombre", "Permiso");
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }
        private void changeHeaderText(DataGridView dataGridView, string column, string name)
        {
            dataGridView.Columns[column].HeaderText = name;
        }
    }
}
