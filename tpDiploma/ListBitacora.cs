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
    public partial class ListBitacora : Form, IObserver<string>
    {
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        ReporteBLL servicioReporte = new ReporteBLL();
        PermisoBL servicioPermiso = new PermisoBL();
        Usuario_Sesion usuario_Sesion = Usuario_Sesion.Instance;
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();

        public string idioma;
        List<Bitacora> _listaBitacora;
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
                if (comprobarPatentePorUsuario("Listar bitacora").Equals(true))
                {
                    _listaBitacora = gestorBitacora.listarBitacora(txtFechaDesde.Value, txtFechaHasta.Value, cmbCriticidad.Text, txtUsername.Text);
                    gridBitacora.DataSource = _listaBitacora;
                    gridBitacora.ScrollBars = ScrollBars.Both;
                    hideColumn(gridBitacora, "ID_Bitacora");
                    hideColumn(gridBitacora, "DVH");
                    gridBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    showPermisoInsuficiente();
                }
            }
            catch (Exception)
            {
                throw;
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
            MessageBox.Show(GetIdioma.buscarTexto("mensajePermisoInsuficiente", idioma));
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (_listaBitacora != null)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        List<DataGridView> listaTablas = new List<DataGridView>();
                        listaTablas.Add(gridBitacora);
                        servicioReporte.reportePDF(listaTablas, sfd, idioma);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
