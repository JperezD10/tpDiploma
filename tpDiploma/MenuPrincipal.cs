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
    public partial class MenuPrincipal : Form, IObserver<string>
    {
        LogIn login = new LogIn();
        IdiomaBLL gestoriIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        CursoBLL gestorCurso = new CursoBLL();
        Usuario_Sesion Usuario_Sesion = Usuario_Sesion.Instance;
        
        public string idioma;
        public MenuPrincipal(LogIn l)
        {
            InitializeComponent();
            this.login = l;
            Properties.Settings.Default.Idioma = l.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            login.ListarIdiomas();
            login.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count>0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new CrearUsuario(this, null));
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

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
            btnRegistrarUsuario.Text = gestoriIdioma.buscarTexto(btnRegistrarUsuario.Name, idioma);
            btnCerrarSesion.Text = gestoriIdioma.buscarTexto(btnCerrarSesion.Name, idioma);
            btnListBitacora.Text = gestoriIdioma.buscarTexto(btnListBitacora.Name, idioma);
            baseDeDatosToolStripMenuItem.Text = gestoriIdioma.buscarTexto(baseDeDatosToolStripMenuItem.Name, idioma);
            crearFamiliaToolStripMenuItem.Text = gestoriIdioma.buscarTexto(crearFamiliaToolStripMenuItem.Name, idioma);
            crearFamiliaToolStripMenuItem.Text = gestoriIdioma.buscarTexto(crearFamiliaToolStripMenuItem.Name, idioma);
            generarBackUpToolStripMenuItem.Text = gestoriIdioma.buscarTexto(generarBackUpToolStripMenuItem.Name, idioma);
            generarRestoreToolStripMenuItem.Text = gestoriIdioma.buscarTexto(generarRestoreToolStripMenuItem.Name, idioma);
            asignarPermisosToolStripMenuItem.Text = gestoriIdioma.buscarTexto(asignarPermisosToolStripMenuItem.Name, idioma);
            lblSaludoUsername.Text = $"{gestoriIdioma.buscarTexto(lblSaludoUsername.Name, idioma)} {Usuario_Sesion.Username}";
            editarPerfilToolStripMenuItem.Text = gestoriIdioma.buscarTexto(editarPerfilToolStripMenuItem.Name, idioma);
            restaurarInformacionToolStripMenuItem.Text = gestoriIdioma.buscarTexto(restaurarInformacionToolStripMenuItem.Name, idioma);
            btnRegistrarProfesor.Text = gestoriIdioma.buscarTexto(btnRegistrarProfesor.Name, idioma);
            btnCrearCursoPorAño.Text = gestoriIdioma.buscarTexto(btnCrearCursoPorAño.Name, idioma);
            btnRegistrarMaterias.Text = gestoriIdioma.buscarTexto(btnRegistrarMaterias.Name, idioma);
            btnRegistrarAlumno.Text = gestoriIdioma.buscarTexto(btnRegistrarAlumno.Name, idioma);
            btnRegistrarNota.Text = gestoriIdioma.buscarTexto(btnRegistrarNota.Name, idioma);
            btnBajaAlumno.Text = gestoriIdioma.buscarTexto(btnBajaAlumno.Name, idioma);
            idiomaToolStripMenuItem.Text = gestoriIdioma.buscarTexto(idiomaToolStripMenuItem.Name, idioma);
            nuevoIdiomaToolStripMenuItem.Text = gestoriIdioma.buscarTexto(nuevoIdiomaToolStripMenuItem.Name, idioma);
            completarIdiomaToolStripMenuItem.Text = gestoriIdioma.buscarTexto(completarIdiomaToolStripMenuItem.Name, idioma);
        }

        private void btnListBitacora_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListBitacora(this));
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void crearFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ABMFamilia(this));
        }

        private void asignarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new PatenteFamilia(this));
        }

        private void generarBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new BackUp(this));
        }

        private void generarRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Restore(this));
        }

        private void editarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new CrearUsuario(this, Usuario_Sesion));
        }

        private void restaurarInformacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new RestaurarCambio(this));
        }

        private void btnRegistrarProfesor_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new AgregarProfesor(this));
        }

        private void btnCrearCursoPorAño_Click(object sender, EventArgs e)
        {
            bool salida = gestorCurso.CrearCursoPorAño();
            if (!salida)
                MessageBox.Show(gestoriIdioma.buscarTexto("msbCrearCursoPronto", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show(gestoriIdioma.buscarTexto("msbCrearCursoExito", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegistrarMaterias_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Materias(this));
        }

        private void btnRegistrarAlumno_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ABMAlumnos(this));
        }

        private void completarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new CompletarIdioma(this));
        }

        private void nuevoIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new AgregarIdioma(this));
        }

        private void btnBajaAlumno_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new BajaAlumno(this));
        }

        private void btnRegistrarNota_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new RegistrarNotaTrimestral(this));
        }
    }
}
