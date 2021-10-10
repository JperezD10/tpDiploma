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
        Usuario_Sesion usuario_Sesion = Usuario_Sesion.Instance;
        public string idioma;
        Permiso patenteOtorgada;
        Permiso patenteSinOtorgar;
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
            lblPatentesDeLaFamilia.Text = GetIdioma.buscarTexto(lblPatentesDeLaFamilia.Name, idioma);
            lblPatentesSinOtorgar.Text = GetIdioma.buscarTexto(lblPatentesSinOtorgar.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }
        private void limpiarGrilla( DataGridView grilla)
        {
            grilla.DataSource = null;
        }

        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreFamilia.Text))
            {
                Permiso familia = new Familia()
                {
                    nombre = txtNombreFamilia.Text
                };
                string result = servicioPermiso.agregarFamilia(familia, idioma);
                if (result != "")
                {
                    MessageBox.Show(result, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtNombreFamilia.Clear();
                limpiarGrilla(GrillaPatenteFamilia);
                limpiarGrilla(GrillaPatentesSinOtorgar);
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

        private void btnDesasignarPermiso_Click(object sender, EventArgs e)
        {
            desasignarPatenteAFamilia();
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            asignarPatenteAFamilia();
        }

        private void asignarPatenteAFamilia()
        {
            try
            {
                if (comprobarPatentePorUsuario("Asignar patente a familia").Equals(true))
                {
                    if (patenteSinOtorgar != null && cmbFamilias.SelectedIndex != -1)
                    {
                        Permiso familia = new Familia()
                        {
                            nombre = cmbFamilias.SelectedItem.ToString()
                        };
                        servicioPermiso.asignarPatenteAFamilia(patenteSinOtorgar, familia, idioma);
                        listarPatentesPorFamilia();
                        listarPatentesQueNoSeanDeLaFamilia();
                        patenteSinOtorgar = null;
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeSeleccionarFamiliaOPatente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    showPermisoInsuficiente();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void desasignarPatenteAFamilia()
        {
            try
            {
                if (comprobarPatentePorUsuario("Asignar patente a familia"))
                {
                    if (patenteOtorgada != null && cmbFamilias.SelectedIndex != -1)
                    {
                        Permiso familia = new Familia()
                        {
                            nombre = cmbFamilias.SelectedItem.ToString()
                        };
                        string result = servicioPermiso.desasignarPatenteAFamilia(patenteOtorgada, familia, idioma);
                        if (result != "")
                        {
                            MessageBox.Show(result);
                        }
                        listarPatentesPorFamilia();
                        listarPatentesQueNoSeanDeLaFamilia();
                        patenteOtorgada = null;
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeSeleccionarFamiliaOPatente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    showPermisoInsuficiente();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GrillaPatenteFamilia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                patenteOtorgada = (Patente)GrillaPatenteFamilia.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GrillaPatentesSinOtorgar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                patenteSinOtorgar = (Patente)GrillaPatentesSinOtorgar.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            eliminarFamilia();
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
        private void eliminarFamilia()
        {
            try
            {
                if (comprobarPatentePorUsuario("Eliminar familia"))
                {
                    if (txtNombreFamilia.Text != "")
                    {
                        Permiso familia = new Familia
                        {
                            nombre = txtNombreFamilia.Text
                        };
                        string result = servicioPermiso.eliminarFamilia(familia, true, idioma);
                        if (result != "")
                        {
                            MessageBox.Show(result, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        txtNombreFamilia.Clear();
                        limpiarGrilla(GrillaPatenteFamilia);
                        limpiarGrilla(GrillaPatentesSinOtorgar);
                        cargarFamilias();
                    }
                    else
                    {

                    }
                }
                else
                {
                    showPermisoInsuficiente();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
