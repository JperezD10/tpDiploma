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
    public partial class CompletarIdioma : Form, IObserver<string>
    {
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        private IdiomaControl _idiomaControl;
        public string idioma;
        public CompletarIdioma(MenuPrincipal m)
        {
            InitializeComponent();
            Properties.Settings.Default.Idioma = m.idioma;
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
            _idiomaControl = null;
        }

        public void OnCompleted()
        {
            lblLenguajeLogin.Text = GetIdioma.buscarTexto(lblLenguajeLogin.Name, idioma);
            lblTraduccion.Text = GetIdioma.buscarTexto(lblTraduccion.Name, idioma);
            btnGuardarTraduccion.Text = GetIdioma.buscarTexto(btnGuardarTraduccion.Name, idioma);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            this.idioma = value;
        }

        private void CompletarIdioma_Load(object sender, EventArgs e)
        {
            cmbCompletarIdioma.Items.Clear();
            cmbCompletarIdioma.DataSource = GetIdioma.CargarIdiomas();
        }
    }
}
