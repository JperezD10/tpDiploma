using BE;
using BLL;
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

namespace tpDiploma
{
    public partial class NotasIncripcionAlumno : Form, IObserver<string>
    {
        MateriaBLL gestorMateria = new MateriaBLL();
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        AlumnoBLL gestorAlumno = new AlumnoBLL();
        public string idioma;
        private Alumno _alumno;
        private ABMAlumnos _formPadre;
        CursoBLL gestorCurso;
        List<Curso> cursosDisponibles;
        private Curso _cursoIngreso;
        private Materia _materiaCalificar;
        private List<Materia> _materiasPorCalificar;
        private List<Nota> _notasOtorgadas = new List<Nota>();
        private bool finalizable = false;
        public NotasIncripcionAlumno(ABMAlumnos a, Alumno alumno)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = a.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
            this._alumno = alumno;
            this._formPadre = a;
            gestorCurso = new CursoBLL();
        }

        private void NotasIncripcionAlumno_Load(object sender, EventArgs e)
        {
            llenarGrados();
            _cursoIngreso = null;
            _materiasPorCalificar = null;
            _materiaCalificar = null;
            lblNombreMateria.Visible = false;
        }

        private void llenarGrados()
        {
            cmbGradoCurso.Items.Clear();
            cmbGradoCurso.Items.Add("");
            for (int i = 1; i <= 6; i++)
            {
                cmbGradoCurso.Items.Add(i.ToString());
            }
        }

        private void cmbGradoCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbGradoCurso.SelectedIndex != 0)
            {
                cursosDisponibles = gestorCurso.cursosIngresoAlumno(int.Parse(cmbGradoCurso.Text));
                if(cursosDisponibles.Count > 0)
                {
                    llenarGrillaCursos();
                }
                else
                    MessageBox.Show(GetIdioma.buscarTexto("msbCuposVacios", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void llenarGrillaCursos()
        {
            GrillaCursosDisponibles.DataSource = null;
            GrillaCursosDisponibles.DataSource = cursosDisponibles;
            hideColumn(GrillaCursosDisponibles, "ID_Curso");
            GrillaCursosDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        public void OnNext(string value)
        {
            this.idioma = value;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            lblAñoCursoNuevoAlumno.Text = GetIdioma.buscarTexto(lblAñoCursoNuevoAlumno.Name, idioma);
            lblSubject.Text = GetIdioma.buscarTexto(lblSubject.Name, idioma);
            lblNotaNumerica.Text = GetIdioma.buscarTexto(lblNotaNumerica.Name, idioma);
            btnSaveNota.Text = GetIdioma.buscarTexto(btnSaveNota.Name, idioma);
            lblNotasAsignadas.Text = GetIdioma.buscarTexto(lblNotasAsignadas.Name, idioma);
            btnFinalizarRegistroAlumno.Text = GetIdioma.buscarTexto(btnFinalizarRegistroAlumno.Name, idioma);
        }

        private void GrillaCursosDisponibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _cursoIngreso = (Curso)GrillaCursosDisponibles.Rows[e.RowIndex].DataBoundItem;
                _materiasPorCalificar = gestorMateria.listarMateriasCalificar(_cursoIngreso.AnioSecundaria, _cursoIngreso.Turno);
                if (_materiasPorCalificar.Count == 0)
                {
                    finalizable = true;
                }
                _notasOtorgadas = new List<Nota>();
                ActualizarGrillas();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void llenarGrillaMateriasPorCalificar()
        {
            grillaMateriasPorCalificar.DataSource = null;
            grillaMateriasPorCalificar.DataSource = _materiasPorCalificar;
            hideColumn(grillaMateriasPorCalificar, "ID_Materia");
            grillaMateriasPorCalificar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void llenarGrillaNotasPuestas()
        {
            GrillaNotasPuestas.DataSource = null;
            GrillaNotasPuestas.DataSource = _notasOtorgadas;
            hideColumn(GrillaNotasPuestas, "Alumno");
            hideColumn(GrillaNotasPuestas, "Materia");
            GrillaNotasPuestas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void grillaMateriasPorCalificar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _materiaCalificar = (Materia)grillaMateriasPorCalificar.Rows[e.RowIndex].DataBoundItem;
                lblNombreMateria.Text = _materiaCalificar.Descripcion;
                lblNombreMateria.Visible = true;
            }
            catch (Exception)
            {

            }
            
        }

        private void btnSaveNota_Click(object sender, EventArgs e)
        {
            if(_materiaCalificar != null)
            {
                decimal notaNumerica = validarNota();
                if (notaNumerica >= 1 && notaNumerica <= 10)
                {
                    bool previa = notaNumerica < 7 ? true : false;
                    int cantPrevias = _notasOtorgadas.Count(n => n.Previa == true);
                    if (cantPrevias==2 && previa == true)
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("msbDemasiadasPrevias", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Nota nota = new Nota(_alumno, _materiaCalificar, notaNumerica, previa);
                        _notasOtorgadas.Add(nota);
                        _materiasPorCalificar.Remove(_materiaCalificar);
                        if (_materiasPorCalificar.Count==0)
                        {
                            finalizable = true;
                        }
                        ActualizarGrillas();
                        txtNotaNumerica.Clear();
                    }
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
            string nota = txtNotaNumerica.Text;
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            if (Decimal.TryParse(nota, style, culture, out salida))
                return salida;
            else
                return 0;
        }
        private void ActualizarGrillas()
        {
            _materiaCalificar = null;
            lblNombreMateria.Text = "";
            lblNombreMateria.Visible = false;
            llenarGrillaMateriasPorCalificar();
            llenarGrillaNotasPuestas();
        }

        private void btnFinalizarRegistroAlumno_Click(object sender, EventArgs e)
        {
            if (_materiasPorCalificar==null || finalizable==false)
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbFaltanCalificarMaterias", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string resultado = gestorAlumno.RegistrarAlumno(this._alumno, _notasOtorgadas, _cursoIngreso.ID_Curso, idioma);
                    MessageBox.Show(resultado, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this._formPadre.limpiarFormulario();
                    this.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void GrillaNotasPuestas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
