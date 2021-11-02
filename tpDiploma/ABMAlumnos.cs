using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpDiploma
{
    public partial class ABMAlumnos : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        public ABMAlumnos(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            lblApellidoRegistrarProfesor.Text = GetIdioma.buscarTexto(lblApellidoRegistrarProfesor.Name, idioma);
            lblNombreRegistrarProfesor.Text = GetIdioma.buscarTexto(lblNombreRegistrarProfesor.Name, idioma);
            btnGuardarAlumno.Text = GetIdioma.buscarTexto(btnGuardarAlumno.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            this.idioma = value;
        }
        private bool validarCampos(string nombre, string apellido, string DNI, string Email)
        {
            string _patronDNI = @"\d{7,8}";
            Regex regexDNI = new Regex(_patronDNI);
            MatchCollection matchDNI = regexDNI.Matches(DNI);
            bool result = true;

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
            if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbEmailVacio", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }

            return result;
        }

        private void btnGuardarAlumno_Click(object sender, EventArgs e)
        {
            bool salida = validarCampos(txtNombre.Text, txtApellido.Text, txtDNI.Text, txtEmail.Text);
            if (salida)
            {
                Alumno alumno = new Alumno(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtDNI.Text, true);
                NotasIncripcionAlumno notas = new NotasIncripcionAlumno(this,alumno);
                notas.ShowDialog();
            }
        }

        public void limpiarFormulario()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
        }

        private void ABMAlumnos_Load(object sender, EventArgs e)
        {
            limpiarFormulario();
        }
    }
}
