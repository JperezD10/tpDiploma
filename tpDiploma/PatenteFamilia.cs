using BE;
using BLL;
using SEGURIDAD;
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
    public partial class PatenteFamilia : Form, IObserver<string>
    {
        PermisoBL servicioPermiso = new PermisoBL();
        IdiomaBLL GetIdioma = new IdiomaBLL();
        UsuarioBLL servicioUsuario = new UsuarioBLL();
        Encriptacion Encriptacion = new Encriptacion();
        Usuario_Sesion Usuario_Sesion = Usuario_Sesion.Instance;
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        Permiso permisoSinOtorgar;
        Familia _FamiliaPadreArbol;
        Patente _PatenteArbol;
        TreeNode SelectedNode;
        List<Permiso> _listaPermisos;
        List<Patente> _listaTodasPatente;
        List<Familia> _listaTodasFamilias;
        public PatenteFamilia(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
            _FamiliaPadreArbol = null;
            SelectedNode = null;
        }

        public void OnCompleted()
        {
            lblUsuarioAsignar.Text = GetIdioma.buscarTexto(lblUsuarioAsignar.Name, idioma);
            lblPermisosNoAsignados.Text = GetIdioma.buscarTexto(lblPermisosNoAsignados.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void AsignarPermisos_Load(object sender, EventArgs e)
        {
            llenarUsuarios();
            SelectedNode = null;
            _listaTodasPatente = null;
            _listaTodasFamilias = null;
            _listaTodasPatente = servicioPermiso.listarTodasLasPatentes();
            _listaTodasFamilias = servicioPermiso.listarTodasLasFamilias();
        }

        private void llenarUsuarios()
        {
            cmbUsuarios.Items.Clear();
            List<Usuario> listaUsuarios = servicioUsuario.listarUsuario();
            foreach (Usuario usuario in listaUsuarios)
            {
                cmbUsuarios.Items.Add(usuario.Username);
            }
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

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarPermisos();
        }
        private void llenarPermisos()
        {
            List<Permiso> todosLosPermisos = servicioPermiso.listarTodosLosPermiso();

            var usuario = getUser();

            _listaPermisos = obtenerPermisosPorUsuario(usuario);
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
                if (!dictPermisos.ContainsKey(permiso.codigoPermiso))
                {
                    permisosNoAsignados.Add(permiso);
                }
            }
            setDataGridPermisos(permisosNoAsignados, GrillaPermisosNoAsignados);
            TreeViewPermisosUsuario.Nodes.Clear();
            List<TreeNode> listaTreeNodes = crearArbolFromPermisos(_listaPermisos);
            foreach (var treeNode in listaTreeNodes)
            {
                TreeViewPermisosUsuario.Nodes.Add(treeNode);
            }
            TreeViewPermisosUsuario.ExpandAll();
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

        private List<Permiso> obtenerPermisosPorUsuario(Usuario usuario)
        {
            List<Permiso> listaPermisos = servicioPermiso.listarPermisosPorUsuario(usuario);
            return listaPermisos;
        }

        public Usuario getUser()
        {
            Encriptacion encriptado = new Encriptacion();
            Usuario usuarioPatente = new Usuario
            {
                Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
            };
            return usuarioPatente;
        }


        private void setDataGridPermisos(List<Permiso> listaPermisos, DataGridView dataGridView)
        {
            dataGridView.DataSource = listaPermisos;
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

        private void asignarFamilia()
        {
            try
            {
                if (comprobarPatentePorUsuario("Asignar familia a usuario").Equals(true))
                {
                    if (permisoSinOtorgar != null && cmbUsuarios.SelectedIndex != -1)
                    {
                        if (permisoSinOtorgar is Familia)
                        {
                            Encriptacion encriptacion = new Encriptacion();
                            Usuario usuario = new Usuario()
                            {
                                Username = encriptacion.encriptar(cmbUsuarios.SelectedItem.ToString())
                            };
                            servicioPermiso.asignarPermisoAUsuario(permisoSinOtorgar, usuario, true);
                            SelectedNode = null;
                            permisoSinOtorgar = null;
                            llenarPermisos();
                        }
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeDebeSeleccionarUsuarioOFamilia", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool comprobarPatentePorUsuario(string nombrePatente)
        {
            Permiso patente = new Patente();
            patente.nombre = nombrePatente;
            return servicioPermiso.comprobarPatentePorUsuario(patente, Usuario_Sesion);
        }
        private void desasignarFamiliaAUsuario()
        {
            try
            {
                if (comprobarPatentePorUsuario("Asignar familia a usuario").Equals(true))
                {
                    if (_FamiliaPadreArbol != null && cmbUsuarios.SelectedIndex != -1)
                    {
                        Encriptacion encriptado = new Encriptacion();
                        Usuario usuario = new Usuario()
                        {
                            Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
                        };
                        string result = servicioPermiso.desasignarPermisoAUsuario(_FamiliaPadreArbol, usuario, true, idioma);
                        if (result != "")
                        {
                            MessageBox.Show(result, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _PatenteArbol = null;
                        SelectedNode = null;
                        llenarPermisos();
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeDebeSeleccionarUsuarioOFamilia", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void showPermisoInsuficiente()
        {
            MessageBox.Show(GetIdioma.buscarTexto("mensajePermisoInsuficiente", idioma));
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            if (permisoSinOtorgar is Familia)
            {
                asignarFamilia();
            }
            else
            {
                asignarPermisoAUsuario();
            }
            _listaTodasPatente = servicioPermiso.listarTodasLasPatentes();
            _listaTodasFamilias = servicioPermiso.listarTodasLasFamilias();
        }

        private void asignarPermisoAUsuario()
        {
            try
            {
                if (comprobarPatentePorUsuario("Asignar patente a usuario").Equals(true))
                {
                    if (permisoSinOtorgar != null && cmbUsuarios.SelectedIndex != -1)
                    {
                        if (_FamiliaPadreArbol == null)
                        {
                            Usuario usuario = new Usuario()
                            {
                                Username = Encriptacion.encriptar(cmbUsuarios.SelectedItem.ToString())
                            };
                            servicioPermiso.asignarPermisoAUsuario(permisoSinOtorgar, usuario, false);
                        }
                        else
                        {
                            servicioPermiso.asignarPatenteAFamilia(permisoSinOtorgar, _FamiliaPadreArbol, idioma);
                        }
                        permisoSinOtorgar = null;
                        llenarPermisos();
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeDebeSeleccionarUsuarioOPatente",idioma),"", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnDesasignarPermiso_Click(object sender, EventArgs e)
        {
            if (_PatenteArbol != null)
            {
                desasignarPermisoAUsuario();
            }
            else
            {
                desasignarFamiliaAUsuario();
            }
            _listaTodasPatente = servicioPermiso.listarTodasLasPatentes();
            _listaTodasFamilias = servicioPermiso.listarTodasLasFamilias();
        }

        private void desasignarPermisoAUsuario()
        {
            try
            {
                if (comprobarPatentePorUsuario("Asignar patente a usuario").Equals(true))
                {
                    if (cmbUsuarios.SelectedIndex != -1)
                    {
                        if (_PatenteArbol != null)
                        {
                            Usuario usuario = new Usuario()
                            {
                                Username = Encriptacion.encriptar(cmbUsuarios.SelectedItem.ToString())
                            };
                            string result = servicioPermiso.desasignarPermisoAUsuario(_PatenteArbol, usuario, false, idioma);
                            if (result != "")
                            {
                                MessageBox.Show(result);
                            }
                            _PatenteArbol = null;
                            _FamiliaPadreArbol = null;
                        }
                        llenarPermisos();
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeDebeSeleccionarUsuarioOPatente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void GrillaPermisosNoAsignados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                permisoSinOtorgar = (Permiso)GrillaPermisosNoAsignados.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }
        }

        private void TreeViewPermisosUsuario_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = e.Node;
            var FamiliaEncontrada = _listaTodasFamilias.Find(f => f.nombre == SelectedNode.Text);
            if (FamiliaEncontrada != null)
            {
                if (SelectedNode.Parent == null)
                {
                    _FamiliaPadreArbol = FamiliaEncontrada;
                }
                _PatenteArbol = null;
            }
            else
            {
                var patente = _listaTodasPatente.Find(f => f.nombre == SelectedNode.Text);
                _PatenteArbol = patente;
                _FamiliaPadreArbol = null;
            }
        }
    }
}
