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
    public partial class ListBitacora : Form, IObserver<string>
    {
        BLL.BitacoraBLL gestorBitacora = new BLL.BitacoraBLL();
        BLL.IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();

        public string idioma;
        public ListBitacora(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }
        public ListBitacora()
        {
            InitializeComponent();
        }

        public void OnCompleted()
        {
            lblCriticidadBitacora.Text = GetIdioma.buscarTexto(lblCriticidadBitacora.Name,idioma);
            lblFechaDesdeBitacora.Text = GetIdioma.buscarTexto(lblFechaDesdeBitacora.Name,idioma);
            lblFechaHastaBitacora.Text = GetIdioma.buscarTexto(lblFechaHastaBitacora.Name,idioma);
            lblUsernameBitacora.Text = GetIdioma.buscarTexto(lblUsernameBitacora.Name,idioma);
            btnListarBitacora.Text = GetIdioma.buscarTexto(btnListarBitacora.Name,idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void ListBitacora_Load(object sender, EventArgs e)
        {
            
        }

        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        private void btnListarBitacora_Click(object sender, EventArgs e)
        {
            gridBitacora.DataSource = null;
            try
            {
                var bitacora = gestorBitacora.listarBitacora(txtFechaDesde.Value, txtFechaHasta.Value, cmbCriticidad.Text, txtUsername.Text);
                gridBitacora.DataSource = bitacora;
                gridBitacora.ScrollBars = ScrollBars.Both;
                hideColumn(gridBitacora, "ID_Bitacora");
                hideColumn(gridBitacora, "DVH");
                gridBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
