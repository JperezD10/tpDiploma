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
        List<Patente> _listaTodasPatente;
        List<Familia> _listaTodasFamilias;
        List<Permiso> _listaPermisos;
        Permiso permisoOtorgado;
        Permiso permisoSinOtorgar;
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
                llenarTreeView(servicioPermiso.listarFamiliasconPatentes());
            }
            else
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbNombreFamiliaInvalido", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ABMFamilia_Load(object sender, EventArgs e)
        {
            GrillaPatentesSinOtorgar.DataSource = null;
            SelectedNode = null;
            txtNombreFamilia.Clear();
            _listaTodasPatente = null;
            _listaTodasFamilias = null;
            _listaTodasPatente = servicioPermiso.listarTodasLasPatentes();
            _listaTodasFamilias = servicioPermiso.listarTodasLasFamilias();
            llenarTreeView(servicioPermiso.listarFamiliasconPatentes());
        }

        void llenarTreeView(List<Permiso> listaPermisos)
        {
            List<Permiso> listaPatentes = servicioPermiso.listarFamiliasconPatentes();
            treeViewFamilias.Nodes.Clear();
            List<TreeNode> listaTreeNodes = crearArbolFromPermisos(listaPermisos);
            foreach (var treeNode in listaTreeNodes)
            {
                treeViewFamilias.Nodes.Add(treeNode);
            }
            treeViewFamilias.ExpandAll();
        }
        private List<Permiso> extraerPermisosArbol(Permiso permiso)
        {
            if (!permiso.isFamilia)
            {
                return new List<Permiso> { permiso };
            }
            else
            {
                List<Permiso> lista = new List<Permiso>();
                lista.Add(permiso);
                foreach (var item in permiso.listaPermisos)
                {
                    if (!item.isFamilia)
                    {
                        lista.Add(item);
                    }
                    else
                    {
                        lista.AddRange(extraerPermisosArbol(item));
                    }
                }
                return lista;
            }
        }
        private void setDataGridPatentes(List<Permiso> listaPatentes, DataGridView dataGridView)
        {
            dataGridView.DataSource = listaPatentes;
            dataGridView.ClearSelection();
            hideColumn(dataGridView, "codigoPermiso");
            hideColumn(dataGridView, "DVH");
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
                    if (permisoSinOtorgar != null && SelectedNode!= null)
                    {
                        //si encuentra esto es porque se selecciono una familia
                        if (permisoSinOtorgar.isFamilia && permisoOtorgado.isFamilia)
                        {
                            servicioPermiso.AsignarFamiliaAFamilia((Familia)permisoSinOtorgar, (Familia)permisoOtorgado);
                        }
                        else if(permisoSinOtorgar.isFamilia == false && permisoOtorgado.isFamilia && SelectedNode.Parent == null)
                        {
                            servicioPermiso.asignarPatenteAFamilia(permisoSinOtorgar, permisoOtorgado, idioma);
                        }
                        _listaTodasPatente = servicioPermiso.listarTodasLasPatentes();
                        _listaTodasFamilias = servicioPermiso.listarTodasLasFamilias();
                        llenarPermisos();
                        llenarTreeView(servicioPermiso.listarFamiliasconPatentes());
                        permisoSinOtorgar = null;
                        SelectedNode = null;
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
                    if (permisoOtorgado != null && SelectedNode != null)
                    {
                        //si es una familia asignada a otra familia
                        if (permisoOtorgado.isFamilia && SelectedNode.Parent != null)
                        {
                            var familiaPadre = _listaTodasFamilias.Find(f => f.nombre == SelectedNode.Parent.Text);
                            servicioPermiso.DesasignarFamiliaDeFamilia(familiaPadre,permisoOtorgado);
                        }
                        //si es una patente asignada a la familia principal, no al compuesto.
                        else if(permisoOtorgado.isFamilia == false && SelectedNode.Level == 1)
                        {
                            var familiaPadre = _listaTodasFamilias.Find(f => f.nombre == SelectedNode.Parent.Text);
                            servicioPermiso.desasignarPatenteAFamilia(permisoOtorgado, familiaPadre, idioma);
                        }
                        _listaTodasPatente = servicioPermiso.listarTodasLasPatentes();
                        _listaTodasFamilias = servicioPermiso.listarTodasLasFamilias();
                        llenarPermisos();
                        llenarTreeView(servicioPermiso.listarFamiliasconPatentes());
                        permisoOtorgado = null;
                        SelectedNode = null;
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
                permisoSinOtorgar = (Permiso)GrillaPatentesSinOtorgar.Rows[e.RowIndex].DataBoundItem;
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
                        llenarTreeView(servicioPermiso.listarFamiliasconPatentes());
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
        List<Permiso> obtenerPermisosDeFamilia(Familia Familia)
        {
            List<Permiso> listaPermisos = servicioPermiso.ListarPermisosDeFamilia(Familia);
            return listaPermisos;
        }
        void llenarPermisos()
        {
            List<Permiso> todosLosPermisos = servicioPermiso.listarTodosLosPermiso();

            var familiaEncontrada = _listaTodasFamilias.Find(f => f.nombre == SelectedNode.Text);
            if (familiaEncontrada == null)
            {
                familiaEncontrada = _listaTodasFamilias.Find(f => f.nombre == SelectedNode.Parent.Text);
            }
            _listaPermisos = obtenerPermisosDeFamilia(familiaEncontrada);
            Dictionary<int, Permiso> dictPermisos = new Dictionary<int, Permiso>();

            foreach (var permiso in _listaPermisos)
            {

                List<Permiso> lista = extraerPermisosArbol(permiso);
                foreach (var item in lista)
                {
                    dictPermisos[item.codigoPermiso] = item;
                }
            }

            List<Permiso> permisosNoAsignados = new List<Permiso>();

            foreach (var permiso in todosLosPermisos)
            {
                if (!dictPermisos.ContainsKey(permiso.codigoPermiso) && permiso.nombre != familiaEncontrada.nombre)
                {
                    if (SelectedNode.Parent != null)
                    {
                        if (permiso.nombre != SelectedNode.Parent.Text)
                        {
                            permisosNoAsignados.Add(permiso);
                        }
                    }
                    else
                    {
                        permisosNoAsignados.Add(permiso);
                    }
                }
            }
            if (permisoOtorgado != null)
            {
                List<Permiso> permisosPadre = servicioPermiso.obtenerFamiliaDelPermiso(permisoOtorgado);
                foreach (var item in permisosPadre)
                {
                    var permisoPadreNoMostrar = permisosNoAsignados.Find(p => p.nombre == item.nombre);
                    if(permisoPadreNoMostrar != null)
                        permisosNoAsignados.Remove(permisoPadreNoMostrar);
                }
            }
            setDataGridPatentes(permisosNoAsignados, GrillaPatentesSinOtorgar);
            llenarTreeView(servicioPermiso.listarFamiliasconPatentes());
        }
        private List<TreeNode> crearArbolFromPermisos(List<Permiso> listaPermisos)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            foreach (var permiso in listaPermisos)
            {
                TreeNode tree = new TreeNode(permiso.nombre);
                tree.Tag = permiso;
                if (permiso.isFamilia)
                {
                    var listaTreeNodes = crearArbolFromPermisos(permiso.listaPermisos);
                    foreach (var item in listaTreeNodes)
                    {
                        tree.Nodes.Add((TreeNode)item);
                    }
                }
                nodeList.Add(tree);
            }
            return nodeList;
        }
        private void treeViewFamilias_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = e.Node;
            var familiaEncontrada = _listaTodasFamilias.Find(f => f.nombre == SelectedNode.Text);
            if (familiaEncontrada != null)
            {
                permisoOtorgado = familiaEncontrada;
                if (SelectedNode.Parent == null)
                {
                    txtNombreFamilia.Text = familiaEncontrada.nombre;
                }
                llenarPermisos();
            }
            else
            {
                var patenteEncontrado = _listaTodasPatente.Find(f => f.nombre == SelectedNode.Text);
                permisoOtorgado = patenteEncontrado;
                txtNombreFamilia.Clear();
            }
        }
    }
}
