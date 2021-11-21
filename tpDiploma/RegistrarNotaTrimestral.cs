using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace tpDiploma
{
    public partial class RegistrarNotaTrimestral : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        AlumnoBLL gestorAlumno = new AlumnoBLL();
        MateriaBLL gestorMateria = new MateriaBLL();
        NotaBLL gestorNota = new NotaBLL();
        IEnumerable<Alumno> _alumnos;
        IEnumerable<Materia> _materias;
        private Materia _materiaCalificar;
        private Alumno _alumnoCalificar;
        public string idioma;
        public RegistrarNotaTrimestral(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            lblCurso.Text = GetIdioma.buscarTexto(lblCurso.Name, idioma);
            lblTurno.Text = GetIdioma.buscarTexto(lblTurno.Name, idioma);
            lblAlumnosRegistrarNota.Text = GetIdioma.buscarTexto(lblAlumnosRegistrarNota.Name, idioma);
            lblMateriaRegistrarNota.Text = GetIdioma.buscarTexto(lblMateriaRegistrarNota.Name, idioma);
            lblTrimestre.Text = GetIdioma.buscarTexto(lblTrimestre.Name, idioma);
            lblNotaNumerica.Text = GetIdioma.buscarTexto(lblNotaNumerica.Name, idioma);
            btnGuardarNotaTrimestral.Text = GetIdioma.buscarTexto(btnGuardarNotaTrimestral.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void cargarCombos()
        {
            cmbCurso.Items.Clear();
            cmbTrimestre.Items.Clear();
            cmbTurno.Items.Clear();

            cmbCurso.Items.Add("");
            for (int i = 1; i <= 6; i++)
            {
                cmbCurso.Items.Add(i.ToString());
            }
            cmbCurso.SelectedIndex = 0;

            cmbTurno.Items.Add("");
            cmbTurno.Items.Add("Mañana");
            cmbTurno.Items.Add("Tarde");
            cmbTurno.SelectedIndex = 0;

            cmbTrimestre.Items.Add("");
            cmbTrimestre.Items.Add("1");
            cmbTrimestre.Items.Add("2");
            cmbTrimestre.Items.Add("3");
            cmbTrimestre.SelectedIndex = 0;
        }

        private void RegistrarNotaTrimestral_Load(object sender, EventArgs e)
        {
            cargarCombos();
        }

        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTurno.SelectedIndex != 0 && cmbCurso.SelectedIndex != 0)
            {
                try
                {
                    _alumnos = gestorAlumno.buscarAlumnosPorCurso(int.Parse(cmbCurso.Text), cmbTurno.Text);
                    _materias = gestorMateria.buscarMateriasPorCurso(int.Parse(cmbCurso.Text), cmbTurno.Text);
                    llenarGrillas();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void llenarGrillas()
        {
            GrillaAlumnos.DataSource = null;
            GrillaAlumnos.DataSource = _alumnos;
            hideColumn(GrillaAlumnos, "ID_Alumno");
            hideColumn(GrillaAlumnos, "Activo");

            GrillaMaterias.DataSource = null;
            GrillaMaterias.DataSource = _materias;
            hideColumn(GrillaMaterias, "ID_Materia");

            GrillaAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GrillaMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        private void btnGuardarNotaTrimestral_Click(object sender, EventArgs e)
        {
            if (cmbTrimestre.SelectedIndex==0)
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbSeleccioneTrimestre", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(_materiaCalificar == null || _alumnoCalificar == null)
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbSeleccioneAlumnoYMateria", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                decimal notaNumerica = validarNota();
                if (notaNumerica >= 1 && notaNumerica <= 10)
                {
                    Nota nota = new Nota(_alumnoCalificar, _materiaCalificar, notaNumerica, false);
                    bool calificable = gestorNota.ValidarNotaDisponibleParaTrimestre(nota, _alumnoCalificar.ID_Alumno, int.Parse(cmbTrimestre.Text));
                    if (calificable)
                    {
                        gestorNota.RegistrarNotaPorTrimestre(nota, _alumnoCalificar.ID_Alumno, int.Parse(cmbTrimestre.Text));
                        MessageBox.Show(GetIdioma.buscarTexto("msbCalificadoTrimestreExito", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(GetIdioma.buscarTexto("msbNotaYaExistente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(GetIdioma.buscarTexto("msbFormatoNotaInvalido", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private decimal validarNota()
        {
            decimal salida = 0;
            string nota = txtNotaTrimestral.Text;
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (Decimal.TryParse(nota, style, culture, out salida))
                return salida;
            else
                return 0;
        }
        private void GrillaAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _alumnoCalificar = (Alumno)GrillaAlumnos.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }
        }

        private void GrillaMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _materiaCalificar = (Materia)GrillaMaterias.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }
        }
    }
}
