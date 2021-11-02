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
    public partial class NotasIncripcionAlumno : Form, IObserver<string>
    {
        MateriaBLL gestorMateria = new MateriaBLL();
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        private Alumno _alumno;
        private ABMAlumnos _formPadre;
        CursoBLL gestorCurso;
        List<Curso> cursosDisponibles;
        private Curso _cursoIngreso;
        private List<Materia> _materiasPorCalificar;
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
        }

        private void GrillaCursosDisponibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _cursoIngreso = (Curso)GrillaCursosDisponibles.Rows[e.RowIndex].DataBoundItem;
            _materiasPorCalificar = gestorMateria.listarMateriasCalificar(_cursoIngreso.AnioSecundaria, _cursoIngreso.Turno);
            llenarGrillaMateriasPorCalificar();
        }

        private void llenarGrillaMateriasPorCalificar()
        {
            grillaMateriasPorCalificar.DataSource = null;
            grillaMateriasPorCalificar.DataSource = _materiasPorCalificar;
            hideColumn(grillaMateriasPorCalificar, "ID_Materia");
            grillaMateriasPorCalificar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
