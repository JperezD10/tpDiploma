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
        ProfesorBLL gestorProfesor = new ProfesorBLL();
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        Materia materia;
        Materia _materiaDesasignar;
        private Profesor _profesor;
        private List<Materia> MateriasAsignadas;
        private List<Materia> MateriasNoAsignadas;
        AgregarProfesor _FormAgregarProfesor;
        public ProfesorMaterias(AgregarProfesor a, Profesor profesor)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = a.idioma;
            serviceObservable.AddObserver(this);
            _profesor = profesor;
            _FormAgregarProfesor = a;
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
            btnConfirmarProfesor.Text = GetIdioma.buscarTexto(btnConfirmarProfesor.Name, idioma);
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
                    if(MateriasAsignadas.Count >= 3)
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("msbMaximoMateriasProfesor", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MateriasAsignadas.Add(materia);
                        AsignarMateria(materia);
                        materia = null;
                    }
                }
            }
        }

        private void AsignarMateria(Materia materia)
        {
            MateriasNoAsignadas.Remove(materia);
            rellenarGrillas();
        }

        private void rellenarGrillas()
        {
            limpiarGrilla(GrillaMateriasSinAsignar);
            limpiarGrilla(GrillaMateriasAsignadas);
            GrillaMateriasSinAsignar.DataSource = MateriasNoAsignadas;
            GrillaMateriasAsignadas.DataSource = MateriasAsignadas;
            if(MateriasAsignadas.Count > 0)
            {
                hideColumn(GrillaMateriasAsignadas, "ID_Materia");
            }
            if(MateriasNoAsignadas.Count > 0)
            {
                hideColumn(GrillaMateriasSinAsignar, "ID_Materia");
            }
            GrillaMateriasAsignadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GrillaMateriasSinAsignar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void GrillaMateriasSinAsignar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            materia = (Materia)GrillaMateriasSinAsignar.Rows[e.RowIndex].DataBoundItem;
        }

        private void btnConfirmarProfesor_Click(object sender, EventArgs e)
        {
            if (MateriasAsignadas.Count > 0)
            {
                this._profesor.SetMaterias(MateriasAsignadas);
                try
                {
                    gestorProfesor.AgregarProfesor(_profesor);
                    MessageBox.Show(GetIdioma.buscarTexto("msbProfesorAgregado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this._FormAgregarProfesor.limpiarFormulario();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbMateriasNoAsignadas", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GrillaMateriasAsignadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _materiaDesasignar = (Materia)GrillaMateriasAsignadas.Rows[e.RowIndex].DataBoundItem;
        }

        private void btnDesAsignarMateria_Click(object sender, EventArgs e)
        {
            if(_materiaDesasignar != null)
            {
                MateriasAsignadas.Remove(_materiaDesasignar);
                MateriasNoAsignadas.Add(_materiaDesasignar);
                rellenarGrillas();
                _materiaDesasignar = null;
            }
        }
    }
}
