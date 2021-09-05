using BE;
using SEGURIDAD;
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
    public partial class PatenteFamilia : Form, IObserver<string>
    {
        BLL.PermisoBL servicioPermiso = new BLL.PermisoBL();
        BLL.IdiomaBLL GetIdioma = new BLL.IdiomaBLL();
        BLL.UsuarioBLL servicioUsuario = new BLL.UsuarioBLL();
        BLL.IdiomaObservableBLL serviceObservable = new BLL.IdiomaObservableBLL();
        public string idioma;
        Permiso familiaOtorgada;
        Permiso familiaSinOtorgar;

        public PatenteFamilia(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        public void OnCompleted()
        {
            lblUsuarioAsignar.Text = GetIdioma.buscarTexto(lblUsuarioAsignar.Name, idioma);
            lblPermisosNoAsignados.Text = GetIdioma.buscarTexto(lblPermisosNoAsignados.Name, idioma);
            lblPermisosAsignados.Text = GetIdioma.buscarTexto(lblPermisosAsignados.Name, idioma);
            lblFamiliasNoAsignadas.Text = GetIdioma.buscarTexto(lblFamiliasNoAsignadas.Name, idioma);
            lblFamiliasAsignadas.Text = GetIdioma.buscarTexto(lblFamiliasAsignadas.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            idioma = value;
        }

        private void AsignarPermisos_Load(object sender, EventArgs e)
        {
            llenarUsuarios();
        }

        private void llenarUsuarios()
        {
            cmbUsuarios.Items.Clear();
            List<Usuario> listaUsuarios = servicioUsuario.listarUsuario();
            foreach (Usuario usuario in listaUsuarios)
            {
                cmbUsuarios.Items.Add(usuario.Username);
            }
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPatentesPorUsuario();
            listarFamiliasPorUsuario();
            obtenerPermisosExluyentesAlUsuario(false, GrillaPermisosNoAsignados);
            obtenerPermisosExluyentesAlUsuario(true, GrillaFamiliasNoAsignadas);
        }

        private void listarPatentesPorUsuario()
        {
            Encriptacion encriptado = new Encriptacion();
            Usuario usuarioPatente = new Usuario
            {
                Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
            };
            List<Permiso> listaPatentesUsuario = servicioPermiso.listarPatentesTodasOPorUsuario(usuarioPatente);
            setDataGridPermisos(listaPatentesUsuario, GrillaPermisosAsignados);
        }
        private void listarFamiliasPorUsuario()
        {
            Encriptacion encriptado = new Encriptacion();
            Usuario usuarioFamilia = new Usuario
            {
                Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
            };
            List<Permiso> listaFamiliasUsuario = servicioPermiso.listarFamiliasTodasOPorUsuario(usuarioFamilia);
            setDataGridPermisos(listaFamiliasUsuario, GrillaFamiliasAsignadas);
        }
        private void obtenerPermisosExluyentesAlUsuario(bool isFamilia, DataGridView dataGridView)
        {
            Encriptacion encriptado = new Encriptacion();
            Usuario usuario = new Usuario
            {
                Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
            };
            List<Permiso> listaPermisos = servicioPermiso.obtenerPermisosExluyentesAlUsuario(usuario, isFamilia);
            setDataGridPermisos(listaPermisos, dataGridView);
        }

        private void setDataGridPermisos(List<Permiso> listaPermisos, DataGridView dataGridView)
        {
            dataGridView.DataSource = listaPermisos;
            dataGridView.ClearSelection();
            hideColumn(dataGridView, "codigoPermiso");
            hideColumn(dataGridView, "DVH");
            hideColumn(dataGridView, "isFamilia");
            changeHeaderText(dataGridView, "nombre", "Permiso");
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void hideColumn(DataGridView dataGridView, string column)
        {
            dataGridView.Columns[column].Visible = false;
        }
        private void changeHeaderText(DataGridView dataGridView, string column, string name)
        {
            dataGridView.Columns[column].HeaderText = name;
        }

        private void btnAsignarFamilia_Click(object sender, EventArgs e)
        {
            asignarFamilia();
        }

        private void asignarFamilia()
        {
            try
            {
                //if (comprobarPatentePorUsuario("Asignar familia a usuario").Equals(true))
                //{
                if (familiaSinOtorgar != null && cmbUsuarios.SelectedIndex != -1)
                {
                    if (familiaSinOtorgar is Familia)
                    {
                        Encriptacion encriptacion = new Encriptacion();
                        Usuario usuario = new Usuario()
                        {
                            Username = encriptacion.encriptar(cmbUsuarios.SelectedItem.ToString())
                        };
                        servicioPermiso.asignarPermisoAUsuario(familiaSinOtorgar, usuario, true);
                        listarFamiliasPorUsuario();
                        obtenerPermisosExluyentesAlUsuario(true, GrillaFamiliasNoAsignadas);
                        familiaSinOtorgar = null;
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeEstaSeleccionadaPatente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(GetIdioma.buscarTexto("mensajeDebeSeleccionarUsuarioOFamilia", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //}
                //else
                //{
                //    showPermisoInsuficiente();
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GrillaFamiliasNoAsignadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                familiaSinOtorgar = (Familia)GrillaFamiliasNoAsignadas.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }
        }

        private void btnDesasignarFamilia_Click(object sender, EventArgs e)
        {
            desasignarFamiliaAUsuario();
        }

        private void desasignarFamiliaAUsuario()
        {
            try
            {
                //if (comprobarPatentePorUsuario("Asignar familia a usuario").Equals(true))
                //{
                if (familiaOtorgada != null && cmbUsuarios.SelectedIndex != -1)
                {
                    if (familiaOtorgada is Familia)
                    {
                        Encriptacion encriptado = new Encriptacion();
                        Usuario usuario = new Usuario()
                        {
                            Username = encriptado.encriptar(cmbUsuarios.SelectedItem.ToString())
                        };
                        string result = servicioPermiso.desasignarPermisoAUsuario(familiaOtorgada, usuario, true, idioma);
                        if (result != "")
                        {
                            MessageBox.Show(result);
                        }
                        listarFamiliasPorUsuario();
                        obtenerPermisosExluyentesAlUsuario(true, GrillaFamiliasNoAsignadas);
                        familiaOtorgada = null;
                    }
                    else
                    {
                        MessageBox.Show(GetIdioma.buscarTexto("mensajeEstaSeleccionadaPatente", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(GetIdioma.buscarTexto("mensajeDebeSeleccionarUsuarioOFamilia", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //}
                //else
                //{
                //    showPermisoInsuficiente();
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GrillaFamiliasAsignadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                familiaOtorgada = (Familia)GrillaFamiliasAsignadas.Rows[e.RowIndex].DataBoundItem;
            }
            catch (Exception)
            {

            }
        }
    }
}
