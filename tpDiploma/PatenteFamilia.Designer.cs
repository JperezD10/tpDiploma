
namespace tpDiploma
{
    partial class PatenteFamilia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatenteFamilia));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUsuarioAsignar = new System.Windows.Forms.Label();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.GrillaPermisosNoAsignados = new System.Windows.Forms.DataGridView();
            this.GrillaPermisosAsignados = new System.Windows.Forms.DataGridView();
            this.lblPermisosNoAsignados = new System.Windows.Forms.Label();
            this.lblPermisosAsignados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPermisosNoAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPermisosAsignados)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // lblUsuarioAsignar
            // 
            this.lblUsuarioAsignar.AutoSize = true;
            this.lblUsuarioAsignar.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblUsuarioAsignar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblUsuarioAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUsuarioAsignar.Location = new System.Drawing.Point(172, 36);
            this.lblUsuarioAsignar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioAsignar.Name = "lblUsuarioAsignar";
            this.lblUsuarioAsignar.Size = new System.Drawing.Size(86, 16);
            this.lblUsuarioAsignar.TabIndex = 47;
            this.lblUsuarioAsignar.Text = "Username";
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
            this.cmbUsuarios.Location = new System.Drawing.Point(294, 33);
            this.cmbUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(165, 24);
            this.cmbUsuarios.TabIndex = 56;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            // 
            // GrillaPermisosNoAsignados
            // 
            this.GrillaPermisosNoAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPermisosNoAsignados.Location = new System.Drawing.Point(127, 156);
            this.GrillaPermisosNoAsignados.Name = "GrillaPermisosNoAsignados";
            this.GrillaPermisosNoAsignados.Size = new System.Drawing.Size(288, 212);
            this.GrillaPermisosNoAsignados.TabIndex = 57;
            // 
            // GrillaPermisosAsignados
            // 
            this.GrillaPermisosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPermisosAsignados.Location = new System.Drawing.Point(527, 156);
            this.GrillaPermisosAsignados.Name = "GrillaPermisosAsignados";
            this.GrillaPermisosAsignados.Size = new System.Drawing.Size(288, 212);
            this.GrillaPermisosAsignados.TabIndex = 57;
            // 
            // lblPermisosNoAsignados
            // 
            this.lblPermisosNoAsignados.AutoSize = true;
            this.lblPermisosNoAsignados.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblPermisosNoAsignados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblPermisosNoAsignados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPermisosNoAsignados.Location = new System.Drawing.Point(124, 119);
            this.lblPermisosNoAsignados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPermisosNoAsignados.Name = "lblPermisosNoAsignados";
            this.lblPermisosNoAsignados.Size = new System.Drawing.Size(86, 16);
            this.lblPermisosNoAsignados.TabIndex = 47;
            this.lblPermisosNoAsignados.Text = "Username";
            // 
            // lblPermisosAsignados
            // 
            this.lblPermisosAsignados.AutoSize = true;
            this.lblPermisosAsignados.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblPermisosAsignados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblPermisosAsignados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPermisosAsignados.Location = new System.Drawing.Point(524, 119);
            this.lblPermisosAsignados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPermisosAsignados.Name = "lblPermisosAsignados";
            this.lblPermisosAsignados.Size = new System.Drawing.Size(86, 16);
            this.lblPermisosAsignados.TabIndex = 47;
            this.lblPermisosAsignados.Text = "Username";
            // 
            // PatenteFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(867, 495);
            this.Controls.Add(this.GrillaPermisosAsignados);
            this.Controls.Add(this.GrillaPermisosNoAsignados);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.lblPermisosAsignados);
            this.Controls.Add(this.lblPermisosNoAsignados);
            this.Controls.Add(this.lblUsuarioAsignar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatenteFamilia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AsignarPermisos";
            this.Load += new System.EventHandler(this.AsignarPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPermisosNoAsignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPermisosAsignados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUsuarioAsignar;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.DataGridView GrillaPermisosNoAsignados;
        private System.Windows.Forms.DataGridView GrillaPermisosAsignados;
        private System.Windows.Forms.Label lblPermisosNoAsignados;
        private System.Windows.Forms.Label lblPermisosAsignados;
    }
}