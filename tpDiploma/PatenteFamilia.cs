using BE;
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
        BLL.PermisoBL servicioPermiso = new BLL.PermisoBL();
        BLL.IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        BLL.UsuarioBLL servicioUsuario = new BLL.UsuarioBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();
        public string idioma;

        public PatenteFamilia(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            lblUsuarioAsignar.Text = GetIdioma.buscarTexto(lblUsuarioAsignar.Name, idioma);
            lblPermisosNoAsignados.Text = GetIdioma.buscarTexto(lblPermisosNoAsignados.Name, idioma);
            lblPermisosAsignados.Text = GetIdioma.buscarTexto(lblPermisosAsignados.Name, idioma);
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

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPatentesPorUsuario();
            obtenerPermisosExluyentesAlUsuario(false, GrillaPermisosNoAsignados);
        }

        private void listarPatentesPorUsuario()
        {
            Encriptacion encriptado = new Encriptacion();
            Usuario usuarioPatente = new Usuario
            {
                Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
            };
            List<Permiso> listaPatentesUsuario = servicioPermiso.listarPatentesTodasOPorUsuario(usuarioPatente);
            setDataGridPermisos(listaPatentesUsuario, GrillaPermisosAsignados);
        }
        private void obtenerPermisosExluyentesAlUsuario(bool isFamilia, DataGridView dataGridView)
        {
            Encriptacion encriptado = new Encriptacion();
            Usuario usuario = new Usuario
            {
                Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
            };
            List<Permiso> listaPermisos = servicioPermiso.obtenerPermisosExluyentesAlUsuario(usuario, isFamilia);
            setDataGridPermisos(listaPermisos, dataGridView);
        }

        private void setDataGridPermisos(List<Permiso> listaPermisos, DataGridView dataGridView)
        {
            dataGridView.DataSource = listaPermisos;
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
