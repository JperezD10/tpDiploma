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
    public partial class AgregarIdioma : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        public AgregarIdioma(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
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
            lblNuevoIdioma.Text = GetIdioma.buscarTexto(lblNuevoIdioma.Name, idioma);
            btnGuardarNuevoIdioma.Text = GetIdioma.buscarTexto(btnGuardarNuevoIdioma.Name, idioma);
        }

        private void btnGuardarNuevoIdioma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNuevoIdioma.Text))
            {
                MessageBox.Show(GetIdioma.buscarTexto("msbNuevoIdiomaVacio", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (GetIdioma.validarIdiomaDisponible(txtNuevoIdioma.Text))
                {
                    GetIdioma.GuardarIdioma(txtNuevoIdioma.Text);
                    MessageBox.Show(GetIdioma.buscarTexto("msbNuevoIdiomaExitoso", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(GetIdioma.buscarTexto("msbNuevoIdiomaOcupado", idioma), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txtNuevoIdioma.Clear();
            }
        }
    }
}
