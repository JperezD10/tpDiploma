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
    public partial class BajaAlumno : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        AlumnoBLL gestorAlumno = new AlumnoBLL();
        private IEnumerable<Alumno> _alumnos;
        private Alumno _AlumnoEliminar;
        public string idioma;
        public BajaAlumno(MenuPrincipal m)
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
            btnBajaAlumno.Text = GetIdioma.buscarTexto(btnBajaAlumno.Name, idioma);
            btnBuscarAlumnos.Text = GetIdioma.buscarTexto(btnBuscarAlumnos.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            this.idioma = value;
        }

        private void btnBajaAlumno_Click(object sender, EventArgs e)
        {
            if (_AlumnoEliminar != null)
            {
                gestorAlumno.BajaAlumno(_AlumnoEliminar);
                MessageBox.Show(GetIdioma.buscarTexto("msbAlumnoEliminado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _alumnos = gestorAlumno.ObtenerAlumnos(txtNombre.Text, txtApellido.Text, txtDNI.Text);
                CargarGrilla();
            }
            else
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbSeleccionarAlumnoAEliminar", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarGrilla()
        {
            GrillaAlumnos.DataSource = null;
            GrillaAlumnos.DataSource = _alumnos;
            hideColumn(GrillaAlumnos, "ID_Alumno");
            hideColumn(GrillaAlumnos, "activo");
            GrillaAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        private void GrillaAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _AlumnoEliminar = (Alumno)GrillaAlumnos.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }
        }

        private void btnBuscarAlumnos_Click(object sender, EventArgs e)
        {
            _alumnos = gestorAlumno.ObtenerAlumnos(txtNombre.Text, txtApellido.Text, txtDNI.Text);
            CargarGrilla();
        }

    }
}
