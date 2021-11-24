using BE;
using BLL;
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
    public partial class EliminarUsuario : Form, IObserver<string>
    {
        PermisoBL servicioPermiso = new PermisoBL();
        IdiomaBLL GetIdioma = new IdiomaBLL();
        UsuarioBLL servicioUsuario = new UsuarioBLL();
        Usuario_Sesion Usuario_Sesion = Usuario_Sesion.Instance;
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        List<Usuario> _listaUsuarios;
        public string idioma;
        public EliminarUsuario(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }
        public void OnCompleted()
        {
            lblUsuarioAsignar.Text = GetIdioma.buscarTexto(lblUsuarioAsignar.Name, idioma);
            btnEliminarUsuario.Text = GetIdioma.buscarTexto(btnEliminarUsuario.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void EliminarUsuario_Load(object sender, EventArgs e)
        {
            llenarUsuarios();
        }
        private void llenarUsuarios()
        {
            cmbUsuarios.Items.Clear();
            _listaUsuarios = servicioUsuario.listarUsuario();
            foreach (Usuario usuario in _listaUsuarios)
            {
                if (Usuario_Sesion.ID_Usuario != usuario.ID_Usuario)
                {
                    cmbUsuarios.Items.Add(usuario.Username);
                }
            }
        }

        private bool comprobarPatentePorUsuario(string nombrePatente)
        {
            Permiso patente = new Patente();
            patente.nombre = nombrePatente;
            return servicioPermiso.comprobarPatentePorUsuario(patente, Usuario_Sesion);
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.Text=="")
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbSeleccioneUsuarioEliminar", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (comprobarPatentePorUsuario("Eliminar Usuario"))
                {
                    int idUsuario = _listaUsuarios.Find(u => u.Username == cmbUsuarios.Text).ID_Usuario;
                    servicioUsuario.EliminarUsuario(idUsuario);
                    MessageBox.Show(GetIdioma.buscarTexto("msbUsuarioEliminado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(GetIdioma.buscarTexto("mensajePermisoInsuficiente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
