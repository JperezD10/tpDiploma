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

namespace tpDiploma
{
    public partial class CrearUsuario : Form, IObserver<string>
    {
        BLL.UsuarioBLL gestor = new BLL.UsuarioBLL();
        BLL.IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();
        private Usuario _usuario;
        public string idioma;
        public CrearUsuario(MenuPrincipal m, Usuario usuario)
        {
            this._usuario = usuario;
            InitializeComponent();
            bindForm(usuario);
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        private void bindForm(Usuario usuario)
        {
            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDireccion.Text = usuario.Direccion;
                txtDNI.Text = usuario.DNI;
                txtEmail.Text = usuario.Email;
                txtFechaNacimiento.Value = usuario.FechaNacimiento;
            }
        }

        public void OnCompleted()
        {
            lblApellidoRegistrarUsuario.Text = GetIdioma.buscarTexto(lblApellidoRegistrarUsuario.Name, idioma);
            lblDireccionRegistroUsuario.Text = GetIdioma.buscarTexto(lblDireccionRegistroUsuario.Name, idioma);
            lblFechaNacimientoRegistrarUsuario.Text = GetIdioma.buscarTexto(lblFechaNacimientoRegistrarUsuario.Name, idioma);
            lblNombreRegistrarUsuario.Text = GetIdioma.buscarTexto(lblNombreRegistrarUsuario.Name, idioma);
            btnGuardarUsuario.Text = GetIdioma.buscarTexto(btnGuardarUsuario.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void btnIngresar_Click(object sender, EventArgs e)//crear o modificar
        {
            if(_usuario == null)
            {
                RegistrarNuevoUsuario();
            }
            else
            {
                EditarUsuarioSession();
            }
            
        }

        private void RegistrarNuevoUsuario()
        {
            BE.Usuario newUser = new BE.Usuario()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Username = txtNombre.Text.ToLower()[0] + txtApellido.Text.ToLower().Replace(" ", "").Trim(),
                Contraseña = gestor.GenerarContraseña(),
                Email = txtEmail.Text,
                FechaNacimiento = txtFechaNacimiento.Value,
                Direccion = txtDireccion.Text
            };
            try
            {
                gestor.crearUsuario(newUser);
                MessageBox.Show(GetIdioma.buscarTexto("msbUsuarioCreado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarUsuarioSession()
        {
            _usuario.Nombre = txtNombre.Text;
            _usuario.Apellido = txtApellido.Text;
            _usuario.DNI = txtDNI.Text;
            _usuario.Email = txtEmail.Text;
            _usuario.FechaNacimiento = txtFechaNacimiento.Value;
            _usuario.Direccion = txtDireccion.Text;
            try
            {
                gestor.ModificarUsuario(_usuario);
                MessageBox.Show(GetIdioma.buscarTexto("msbUsuarioModificado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
