using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BE;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace tpDiploma
{
    public partial class AgregarProfesor : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        public AgregarProfesor(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        private void btnGuardarProfesor_Click(object sender, EventArgs e)
        {
            bool estadoFormulario = validarCampos(txtNombre.Text, txtApellido.Text, txtDNI.Text, txtEmail.Text);
            if( estadoFormulario)
            {
                Profesor profesor = new Profesor(txtNombre.Text, txtApellido.Text, txtDNI.Text, txtEmail.Text);
                ProfesorMaterias pm = new ProfesorMaterias(this, profesor);
                pm.ShowDialog();
            }
        }

        private void AgregarProfesor_Load(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        public void limpiarFormulario()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
        }

        private bool validarCampos(string nombre, string apellido, string DNI, string Email)
        {
            string _patronDNI = @"^\d{7,8}$";
            Regex regexDNI = new Regex(_patronDNI);
            MatchCollection matchDNI = regexDNI.Matches(DNI);
            bool result = true;
            try
            {
                var addr = new MailAddress(Email);
                result = addr.Address == Email;
            }
            catch
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbEmailVacio", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbNombreVacio", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbApellidoVacio", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            if (matchDNI.Count < 1)
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbDNIVacio", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }

            return result;
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            lblApellidoRegistrarProfesor.Text = GetIdioma.buscarTexto(lblApellidoRegistrarProfesor.Name, idioma);
            lblNombreRegistrarProfesor.Text = GetIdioma.buscarTexto(lblNombreRegistrarProfesor.Name, idioma);
            btnGuardarProfesor.Text = GetIdioma.buscarTexto(btnGuardarProfesor.Name, idioma);
        }
    }
}
