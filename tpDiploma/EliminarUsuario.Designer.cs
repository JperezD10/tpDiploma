namespace tpDiploma
{
    partial class EliminarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EliminarUsuario));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.lblUsuarioAsignar = new System.Windows.Forms.Label();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Items.AddRange(new object[] {
            "",
            "Baja",
            "Media",
            "Alta"});
            this.cmbUsuarios.Location = new System.Drawing.Point(303, 48);
            this.cmbUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(165, 24);
            this.cmbUsuarios.TabIndex = 58;
            // 
            // lblUsuarioAsignar
            // 
            this.lblUsuarioAsignar.AutoSize = true;
            this.lblUsuarioAsignar.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblUsuarioAsignar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblUsuarioAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUsuarioAsignar.Location = new System.Drawing.Point(181, 51);
            this.lblUsuarioAsignar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioAsignar.Name = "lblUsuarioAsignar";
            this.lblUsuarioAsignar.Size = new System.Drawing.Size(85, 16);
            this.lblUsuarioAsignar.TabIndex = 57;
            this.lblUsuarioAsignar.Text = "Username";
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnEliminarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnEliminarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.btnEliminarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnEliminarUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(507, 48);
            this.btnEliminarUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(117, 24);
            this.btnEliminarUsuario.TabIndex = 59;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // EliminarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(648, 120);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.lblUsuarioAsignar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EliminarUsuario";
            this.Text = "EliminarUsuario";
            this.Load += new System.EventHandler(this.EliminarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Label lblUsuarioAsignar;
        private System.Windows.Forms.Button btnEliminarUsuario;
    }
}