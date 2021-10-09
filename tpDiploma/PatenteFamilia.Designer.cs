
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
            this.lblFamiliasNoAsignadas = new System.Windows.Forms.Label();
            this.GrillaFamiliasNoAsignadas = new System.Windows.Forms.DataGridView();
            this.lblFamiliasAsignadas = new System.Windows.Forms.Label();
            this.GrillaFamiliasAsignadas = new System.Windows.Forms.DataGridView();
            this.btnAsignarPermiso = new System.Windows.Forms.Button();
            this.btnDesasignarPermiso = new System.Windows.Forms.Button();
            this.btnAsignarFamilia = new System.Windows.Forms.Button();
            this.btnDesasignarFamilia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPermisosNoAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPermisosAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFamiliasNoAsignadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFamiliasAsignadas)).BeginInit();
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
            this.GrillaPermisosNoAsignados.Location = new System.Drawing.Point(127, 124);
            this.GrillaPermisosNoAsignados.Name = "GrillaPermisosNoAsignados";
            this.GrillaPermisosNoAsignados.ReadOnly = true;
            this.GrillaPermisosNoAsignados.Size = new System.Drawing.Size(288, 157);
            this.GrillaPermisosNoAsignados.TabIndex = 57;
            // 
            // GrillaPermisosAsignados
            // 
            this.GrillaPermisosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPermisosAsignados.Location = new System.Drawing.Point(527, 124);
            this.GrillaPermisosAsignados.Name = "GrillaPermisosAsignados";
            this.GrillaPermisosAsignados.ReadOnly = true;
            this.GrillaPermisosAsignados.Size = new System.Drawing.Size(288, 157);
            this.GrillaPermisosAsignados.TabIndex = 57;
            // 
            // lblPermisosNoAsignados
            // 
            this.lblPermisosNoAsignados.AutoSize = true;
            this.lblPermisosNoAsignados.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblPermisosNoAsignados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblPermisosNoAsignados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPermisosNoAsignados.Location = new System.Drawing.Point(124, 87);
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
            this.lblPermisosAsignados.Location = new System.Drawing.Point(524, 87);
            this.lblPermisosAsignados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPermisosAsignados.Name = "lblPermisosAsignados";
            this.lblPermisosAsignados.Size = new System.Drawing.Size(86, 16);
            this.lblPermisosAsignados.TabIndex = 47;
            this.lblPermisosAsignados.Text = "Username";
            // 
            // lblFamiliasNoAsignadas
            // 
            this.lblFamiliasNoAsignadas.AutoSize = true;
            this.lblFamiliasNoAsignadas.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblFamiliasNoAsignadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblFamiliasNoAsignadas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFamiliasNoAsignadas.Location = new System.Drawing.Point(124, 306);
            this.lblFamiliasNoAsignadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFamiliasNoAsignadas.Name = "lblFamiliasNoAsignadas";
            this.lblFamiliasNoAsignadas.Size = new System.Drawing.Size(86, 16);
            this.lblFamiliasNoAsignadas.TabIndex = 47;
            this.lblFamiliasNoAsignadas.Text = "Username";
            // 
            // GrillaFamiliasNoAsignadas
            // 
            this.GrillaFamiliasNoAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaFamiliasNoAsignadas.Location = new System.Drawing.Point(127, 343);
            this.GrillaFamiliasNoAsignadas.Name = "GrillaFamiliasNoAsignadas";
            this.GrillaFamiliasNoAsignadas.ReadOnly = true;
            this.GrillaFamiliasNoAsignadas.Size = new System.Drawing.Size(288, 158);
            this.GrillaFamiliasNoAsignadas.TabIndex = 57;
            this.GrillaFamiliasNoAsignadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaFamiliasNoAsignadas_CellClick);
            // 
            // lblFamiliasAsignadas
            // 
            this.lblFamiliasAsignadas.AutoSize = true;
            this.lblFamiliasAsignadas.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblFamiliasAsignadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblFamiliasAsignadas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFamiliasAsignadas.Location = new System.Drawing.Point(524, 306);
            this.lblFamiliasAsignadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFamiliasAsignadas.Name = "lblFamiliasAsignadas";
            this.lblFamiliasAsignadas.Size = new System.Drawing.Size(86, 16);
            this.lblFamiliasAsignadas.TabIndex = 47;
            this.lblFamiliasAsignadas.Text = "Username";
            // 
            // GrillaFamiliasAsignadas
            // 
            this.GrillaFamiliasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaFamiliasAsignadas.Location = new System.Drawing.Point(527, 343);
            this.GrillaFamiliasAsignadas.Name = "GrillaFamiliasAsignadas";
            this.GrillaFamiliasAsignadas.ReadOnly = true;
            this.GrillaFamiliasAsignadas.Size = new System.Drawing.Size(288, 158);
            this.GrillaFamiliasAsignadas.TabIndex = 57;
            this.GrillaFamiliasAsignadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaFamiliasAsignadas_CellClick);
            // 
            // btnAsignarPermiso
            // 
            this.btnAsignarPermiso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnAsignarPermiso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsignarPermiso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnAsignarPermiso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnAsignarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarPermiso.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.btnAsignarPermiso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnAsignarPermiso.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAsignarPermiso.Location = new System.Drawing.Point(441, 141);
            this.btnAsignarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarPermiso.Name = "btnAsignarPermiso";
            this.btnAsignarPermiso.Size = new System.Drawing.Size(52, 45);
            this.btnAsignarPermiso.TabIndex = 58;
            this.btnAsignarPermiso.Text = "=>";
            this.btnAsignarPermiso.UseVisualStyleBackColor = false;
            this.btnAsignarPermiso.Click += new System.EventHandler(this.btnAsignarPermiso_Click);
            // 
            // btnDesasignarPermiso
            // 
            this.btnDesasignarPermiso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnDesasignarPermiso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesasignarPermiso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesasignarPermiso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnDesasignarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesasignarPermiso.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.btnDesasignarPermiso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesasignarPermiso.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDesasignarPermiso.Location = new System.Drawing.Point(441, 216);
            this.btnDesasignarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesasignarPermiso.Name = "btnDesasignarPermiso";
            this.btnDesasignarPermiso.Size = new System.Drawing.Size(52, 48);
            this.btnDesasignarPermiso.TabIndex = 58;
            this.btnDesasignarPermiso.Text = "<=";
            this.btnDesasignarPermiso.UseVisualStyleBackColor = false;
            this.btnDesasignarPermiso.Click += new System.EventHandler(this.btnDesasignarPermiso_Click);
            // 
            // btnAsignarFamilia
            // 
            this.btnAsignarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnAsignarFamilia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsignarFamilia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnAsignarFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnAsignarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarFamilia.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.btnAsignarFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnAsignarFamilia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAsignarFamilia.Location = new System.Drawing.Point(441, 361);
            this.btnAsignarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarFamilia.Name = "btnAsignarFamilia";
            this.btnAsignarFamilia.Size = new System.Drawing.Size(52, 45);
            this.btnAsignarFamilia.TabIndex = 58;
            this.btnAsignarFamilia.Text = "=>";
            this.btnAsignarFamilia.UseVisualStyleBackColor = false;
            this.btnAsignarFamilia.Click += new System.EventHandler(this.btnAsignarFamilia_Click);
            // 
            // btnDesasignarFamilia
            // 
            this.btnDesasignarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnDesasignarFamilia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesasignarFamilia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesasignarFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnDesasignarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesasignarFamilia.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.btnDesasignarFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesasignarFamilia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDesasignarFamilia.Location = new System.Drawing.Point(441, 436);
            this.btnDesasignarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesasignarFamilia.Name = "btnDesasignarFamilia";
            this.btnDesasignarFamilia.Size = new System.Drawing.Size(52, 48);
            this.btnDesasignarFamilia.TabIndex = 58;
            this.btnDesasignarFamilia.Text = "<=";
            this.btnDesasignarFamilia.UseVisualStyleBackColor = false;
            this.btnDesasignarFamilia.Click += new System.EventHandler(this.btnDesasignarFamilia_Click);
            // 
            // PatenteFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(876, 518);
            this.Controls.Add(this.btnDesasignarFamilia);
            this.Controls.Add(this.btnDesasignarPermiso);
            this.Controls.Add(this.btnAsignarFamilia);
            this.Controls.Add(this.btnAsignarPermiso);
            this.Controls.Add(this.GrillaPermisosAsignados);
            this.Controls.Add(this.GrillaFamiliasAsignadas);
            this.Controls.Add(this.GrillaFamiliasNoAsignadas);
            this.Controls.Add(this.GrillaPermisosNoAsignados);
            this.Controls.Add(this.lblFamiliasAsignadas);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.lblFamiliasNoAsignadas);
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
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFamiliasNoAsignadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFamiliasAsignadas)).EndInit();
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
        private System.Windows.Forms.Label lblFamiliasNoAsignadas;
        private System.Windows.Forms.DataGridView GrillaFamiliasNoAsignadas;
        private System.Windows.Forms.Label lblFamiliasAsignadas;
        private System.Windows.Forms.DataGridView GrillaFamiliasAsignadas;
        private System.Windows.Forms.Button btnAsignarPermiso;
        private System.Windows.Forms.Button btnDesasignarPermiso;
        private System.Windows.Forms.Button btnAsignarFamilia;
        private System.Windows.Forms.Button btnDesasignarFamilia;
    }
}