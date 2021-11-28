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
        List<Permiso> PatentesOtorgadas;
        List<Permiso> PatentesSinOtorgar;
        Permiso patenteOtorgada;
        Permiso patenteSinOtorgar;
        TreeNode SelectedNode;
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
            btnEliminarFamilia.Text = GetIdioma.buscarTexto(btnEliminarFamilia.Name, idioma);
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
                limpiarGrilla(GrillaPatentesSinOtorgar);
                llenarTreeView();
            }
            else
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbNombreFamiliaInvalido", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ABMFamilia_Load(object sender, EventArgs e)
        {
            llenarTreeView();
            SelectedNode = null;
            txtNombreFamilia.Clear();
        }

        void llenarTreeView()
        {
            int nodoActual = -1;
            treeViewFamilias.Nodes.Clear();
            treeViewFamilias.ExpandAll();
            List<Permiso> familias = servicioPermiso.listarFamiliasTodasOPorUsuario(null);
            foreach (Familia familia in familias)
            {
                nodoActual++;
                treeViewFamilias.Nodes.Add(familia.nombre);
                treeViewFamilias.SelectedNode = treeViewFamilias.Nodes[nodoActual];
                List<Permiso> listaPatentes = servicioPermiso.listarPatentesPorFamiliaODistinta(familia, "OBTENER_PATENTE_X_FAMILIA");
                foreach (Permiso patente in listaPatentes)
                {
                    treeViewFamilias.SelectedNode.Nodes.Add(patente.nombre);
                }
            }
            GrillaPatentesSinOtorgar.DataSource = null;
        }

        private void listarPatentesPorFamilia()
        {
            if (SelectedNode != null)
            {
                Permiso familia = new Familia();
                familia.nombre = SelectedNode.Text;
                PatentesOtorgadas = servicioPermiso.listarPatentesPorFamiliaODistinta(familia, "OBTENER_PATENTE_X_FAMILIA");
            }
        }
        private void listarPatentesQueNoSeanDeLaFamilia()
        {
            if (SelectedNode !=null)
            {
                Permiso familia = new Familia();
                familia.nombre = SelectedNode.Text;
                PatentesSinOtorgar = servicioPermiso.listarPatentesPorFamiliaODistinta(familia, "OBTENER_PATENTSE_QUITANDO_PATENTES_FAMILIA");
                setDataGridPatentes(PatentesSinOtorgar, GrillaPatentesSinOtorgar);
            }
            
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
                    if (patenteSinOtorgar != null && SelectedNode!= null)
                    {
                        Permiso familia = new Familia()
                        {
                            nombre = SelectedNode.Text
                        };
                        servicioPermiso.asignarPatenteAFamilia(patenteSinOtorgar, familia, idioma);
                        listarPatentesPorFamilia();
                        listarPatentesQueNoSeanDeLaFamilia();
                        llenarTreeView();
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
                    if (patenteOtorgada != null && SelectedNode != null)
                    {
                        Permiso familia = new Familia()
                        {
                            nombre = SelectedNode.Text
                        };
                        string result = servicioPermiso.desasignarPatenteAFamilia(patenteOtorgada, familia, idioma);
                        if (result != "")
                        {
                            MessageBox.Show(result);
                        }
                        listarPatentesPorFamilia();
                        listarPatentesQueNoSeanDeLaFamilia();
                        llenarTreeView();
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
                        limpiarGrilla(GrillaPatentesSinOtorgar);
                        llenarTreeView();
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

        private void treeViewFamilias_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                SelectedNode = e.Node;
                listarPatentesPorFamilia();
                listarPatentesQueNoSeanDeLaFamilia();
                txtNombreFamilia.Text = e.Node.Text;
            }
            else if (e.Node.Level == 1)
            {
                patenteOtorgada = PatentesOtorgadas.Find(p => p.nombre == e.Node.Text);
            }
        }
    }
}
