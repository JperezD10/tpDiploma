using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace tpDiploma
{
    public partial class ProfesorMaterias : Form, IObserver<string>
    {
        MateriaBLL gestorMateria = new MateriaBLL();
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        Materia materia;
        private Profesor _profesor;
        private List<Materia> MateriasAsignadas;
        private List<Materia> MateriasNoAsignadas;
        public ProfesorMaterias(AgregarProfesor a, Profesor profesor)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = a.idioma;
            serviceObservable.AddObserver(this);
            _profesor = profesor;
            MateriasAsignadas = new List<Materia>();
            MateriasNoAsignadas = gestorMateria.listarMateriasSinProfesor();
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
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
            lblMateriasSinAsignar.Text = GetIdioma.buscarTexto(lblMateriasSinAsignar.Name, idioma);
            lblMateriasAsignadas.Text = GetIdioma.buscarTexto(lblMateriasAsignadas.Name, idioma);
        }

        private void ProfesorMaterias_Load(object sender, EventArgs e)
        {
            limpiarGrilla(GrillaMateriasAsignadas);
            limpiarGrilla(GrillaMateriasSinAsignar);
            cargarMateriasSinAsignar();
            hideColumn(GrillaMateriasSinAsignar, "ID_Materia");
            GrillaMateriasSinAsignar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }
        private void limpiarGrilla(DataGridView grilla)
        {
            grilla.DataSource = null;
        }
        private void cargarMateriasSinAsignar()
        {
            GrillaMateriasSinAsignar.DataSource = MateriasNoAsignadas;
        }

        private void btnAsignarMateria_Click(object sender, EventArgs e)
        {
            if (materia != null)
            {
                bool HorarioOcupado = MateriasAsignadas.Where(m => materia.Dia == m.Dia && ((materia.HoraInicio < m.HoraInicio && materia.HoraFin > m.HoraInicio) || (materia.HoraInicio < m.HoraFin && materia.HoraFin > m.HoraFin))).Any();
                if (HorarioOcupado)
                {
                    MessageBox.Show(GetIdioma.buscarTexto("msbHorarioProfesorOcupado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MateriasAsignadas.Add(materia);
                    AsignarMateria(materia);
                    materia = null;
                }
            }
        }

        private void AsignarMateria(Materia materia)
        {
            MateriasNoAsignadas.Remove(materia);
            limpiarGrilla(GrillaMateriasSinAsignar);
            limpiarGrilla(GrillaMateriasAsignadas);
            GrillaMateriasSinAsignar.DataSource = MateriasNoAsignadas;
            GrillaMateriasAsignadas.DataSource = MateriasAsignadas;
            hideColumn(GrillaMateriasAsignadas, "ID_Materia");
            GrillaMateriasAsignadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void GrillaMateriasSinAsignar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            materia = (Materia)GrillaMateriasSinAsignar.Rows[e.RowIndex].DataBoundItem;
        }
    }
}
