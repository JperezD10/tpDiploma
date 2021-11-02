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
using BE;
using BLL;

namespace tpDiploma
{
    public partial class Materias : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        CursoBLL gestorCurso = new CursoBLL();
        MateriaBLL gestorMateria = new MateriaBLL();
        Curso _Curso;
        public Materias(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            lblDiaMateria.Text = GetIdioma.buscarTexto(lblDiaMateria.Name, idioma);
            lblHoraInicioMateria.Text = GetIdioma.buscarTexto(lblHoraInicioMateria.Name, idioma);
            lblNombreMateria.Text = GetIdioma.buscarTexto(lblNombreMateria.Name, idioma);
            btnSaveMateria.Text = GetIdioma.buscarTexto(btnSaveMateria.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            _Curso = null;
            listarDias();
            listarCursosDisponibles();
        }

        private void listarDias()
        {
            cmbDiaMateria.Items.Clear();
            cmbDiaMateria.Items.Add("Lunes");
            cmbDiaMateria.Items.Add("Martes");
            cmbDiaMateria.Items.Add("Miercoles");
            cmbDiaMateria.Items.Add("Jueves");
            cmbDiaMateria.Items.Add("Viernes");
            cmbDiaMateria.SelectedIndex = 0;
        }
        private void listarCursosDisponibles()
        {
            grillaCursosDisponibles.DataSource = null;
            grillaCursosDisponibles.DataSource = gestorCurso.CursosDisponiblesParaNuevaMateria();
            hideColumn(grillaCursosDisponibles, "ID_Curso");
            grillaCursosDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }

        private void grillaCursosDisponibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Curso = (Curso)grillaCursosDisponibles.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSaveMateria_Click(object sender, EventArgs e)
        {
            bool validacion = ValidarCampos();
            if (validacion)
            {
                Materia materia = new Materia(_Curso.AnioSecundaria, txtNombreMateria.Text, cmbDiaMateria.Text, int.Parse(txtHoraInicioMateria.Text));
                if (gestorMateria.ValidarHorarioNuevaMateria(materia))
                {
                    gestorMateria.CrearMateria(materia, _Curso.ID_Curso);
                    MessageBox.Show(GetIdioma.buscarTexto("msbMateriaCreada", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(GetIdioma.buscarTexto("msbMateriaHorarioOcupado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LimpiarTxt(txtNombreMateria);
            LimpiarTxt(txtHoraInicioMateria);
            _Curso = null;
        }
        
        private void LimpiarTxt(TextBox text)
        {
            text.Clear();
        }
        private bool ValidarCampos()
        {
            bool salida = true;
            string _patronHora = @"\d{1,2}";
            Regex regex = new Regex(_patronHora);
            MatchCollection matchHora = regex.Matches(txtHoraInicioMateria.Text);
            if (string.IsNullOrEmpty(txtNombreMateria.Text))
            {
                salida = false;
                MessageBox.Show(GetIdioma.buscarTexto("msbNombreMateriaError", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (matchHora.Count < 1)
            {
                salida = false;
                MessageBox.Show(GetIdioma.buscarTexto("msbHoraInicioIncorrecta", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (_Curso != null)
            {
                int horario = int.Parse(txtHoraInicioMateria.Text);
                if((_Curso.Turno == "Mañana" && (horario < 8 || horario > 14)) || (_Curso.Turno == "Tarde" && (horario < 16 || horario > 22)))
                {
                    salida = false;
                    MessageBox.Show(GetIdioma.buscarTexto("msbHoraFueraDeTurno", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return salida;
        }
    }
}
