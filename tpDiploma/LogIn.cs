﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using SEGURIDAD;

namespace tpDiploma
{
    public partial class LogIn : Form, IObserver<string>
    {
        UsuarioBLL gestor = new UsuarioBLL();
        Encriptacion seguridad = new Encriptacion();
        IdiomaBLL GetIdioma = new IdiomaBLL();
        IdiomaObservableBLL serviceObservable = new IdiomaObservableBLL();
        public string idioma;
        private string contraIncorrecta, avisoInexistente, AvisoBloqueo = "";
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            cmbIdioma.DataSource = GetIdioma.CargarIdiomas();
            cmbIdioma.DisplayMember = "Idioma";
            cmbIdioma.SelectedIndex = 0;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            iniciarSesion();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //gestion de idioma
        {
            Properties.Settings.Default.Idioma = cmbIdioma.SelectedItem.ToString();
            serviceObservable.AddObserver(this);
            serviceObservable.Notify(Properties.Settings.Default.Idioma);
        }

        private void iniciarSesion()
        {
            if (gestor.VerificarUsuario(txtNombreUsuario.Text))
            {
                if (gestor.IniciarSesion(txtNombreUsuario.Text, txtPassword.Text))
                {
                    MenuPrincipal m = new MenuPrincipal(this);
                    m.Show();
                    this.Hide();
                    txtNombreUsuario.Text = txtPassword.Text = "";
                }
                else
                {
                    gestor.SumarIntentosLog(txtNombreUsuario.Text);
                    int ingresoNumero = gestor.MostrarIntentosLog(txtNombreUsuario.Text);
                    if (ingresoNumero == 0)
                    {
                        gestor.BloquearUsuario(txtNombreUsuario.Text);
                        MessageBox.Show(AvisoBloqueo, "", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }
                    else MessageBox.Show(contraIncorrecta + ingresoNumero, "", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
            }
            else MessageBox.Show(avisoInexistente, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciarSesion();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciarSesion();
            }
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
            lblContraseñaLogin.Text = GetIdioma.buscarTexto(lblContraseñaLogin.Name, idioma);
            lblUsuarioLogin.Text = GetIdioma.buscarTexto(lblUsuarioLogin.Name, idioma);
            btnIngresar.Text = GetIdioma.buscarTexto(btnIngresar.Name, idioma);
            lblLenguajeLogin.Text = GetIdioma.buscarTexto(lblLenguajeLogin.Name, idioma);
            AvisoBloqueo = GetIdioma.buscarTexto("msbContraseñaBlock", idioma);
            avisoInexistente = GetIdioma.buscarTexto("msbUsuarioInexistente", idioma);
            contraIncorrecta = GetIdioma.buscarTexto("msbContraseñaIncorrecta", idioma);
        }
    }
}
