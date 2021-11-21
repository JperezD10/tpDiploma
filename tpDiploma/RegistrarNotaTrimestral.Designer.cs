namespace tpDiploma
{
    partial class RegistrarNotaTrimestral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarNotaTrimestral));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.txtNotaTrimestral = new System.Windows.Forms.TextBox();
            this.lblNotaNumerica = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.GrillaAlumnos = new System.Windows.Forms.DataGridView();
            this.GrillaMaterias = new System.Windows.Forms.DataGridView();
            this.lblAlumnosRegistrarNota = new System.Windows.Forms.Label();
            this.lblMateriaRegistrarNota = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.btnGuardarNotaTrimestral = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // cmbCurso
            // 
            this.cmbCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurso.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes"});
            this.cmbCurso.Location = new System.Drawing.Point(502, 39);
            this.cmbCurso.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(126, 24);
            this.cmbCurso.TabIndex = 61;
            // 
            // txtNotaTrimestral
            // 
            this.txtNotaTrimestral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtNotaTrimestral.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNotaTrimestral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtNotaTrimestral.Location = new System.Drawing.Point(516, 528);
            this.txtNotaTrimestral.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotaTrimestral.Name = "txtNotaTrimestral";
            this.txtNotaTrimestral.Size = new System.Drawing.Size(126, 23);
            this.txtNotaTrimestral.TabIndex = 60;
            // 
            // lblNotaNumerica
            // 
            this.lblNotaNumerica.AutoSize = true;
            this.lblNotaNumerica.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaNumerica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblNotaNumerica.Location = new System.Drawing.Point(285, 531);
            this.lblNotaNumerica.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotaNumerica.Name = "lblNotaNumerica";
            this.lblNotaNumerica.Size = new System.Drawing.Size(47, 16);
            this.lblNotaNumerica.TabIndex = 58;
            this.lblNotaNumerica.Text = "Nota";
            this.lblNotaNumerica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblCurso.Location = new System.Drawing.Point(271, 42);
            this.lblCurso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(58, 16);
            this.lblCurso.TabIndex = 59;
            this.lblCurso.Text = "Curso";
            this.lblCurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GrillaAlumnos
            // 
            this.GrillaAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaAlumnos.Location = new System.Drawing.Point(143, 220);
            this.GrillaAlumnos.Name = "GrillaAlumnos";
            this.GrillaAlumnos.Size = new System.Drawing.Size(310, 192);
            this.GrillaAlumnos.TabIndex = 62;
            this.GrillaAlumnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaAlumnos_CellClick);
            // 
            // GrillaMaterias
            // 
            this.GrillaMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaMaterias.Location = new System.Drawing.Point(537, 220);
            this.GrillaMaterias.Name = "GrillaMaterias";
            this.GrillaMaterias.Size = new System.Drawing.Size(310, 192);
            this.GrillaMaterias.TabIndex = 62;
            this.GrillaMaterias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaMaterias_CellClick);
            // 
            // lblAlumnosRegistrarNota
            // 
            this.lblAlumnosRegistrarNota.AutoSize = true;
            this.lblAlumnosRegistrarNota.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnosRegistrarNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblAlumnosRegistrarNota.Location = new System.Drawing.Point(244, 169);
            this.lblAlumnosRegistrarNota.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlumnosRegistrarNota.Name = "lblAlumnosRegistrarNota";
            this.lblAlumnosRegistrarNota.Size = new System.Drawing.Size(77, 16);
            this.lblAlumnosRegistrarNota.TabIndex = 59;
            this.lblAlumnosRegistrarNota.Text = "Alumnos";
            this.lblAlumnosRegistrarNota.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMateriaRegistrarNota
            // 
            this.lblMateriaRegistrarNota.AutoSize = true;
            this.lblMateriaRegistrarNota.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateriaRegistrarNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblMateriaRegistrarNota.Location = new System.Drawing.Point(665, 169);
            this.lblMateriaRegistrarNota.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMateriaRegistrarNota.Name = "lblMateriaRegistrarNota";
            this.lblMateriaRegistrarNota.Size = new System.Drawing.Size(70, 16);
            this.lblMateriaRegistrarNota.TabIndex = 59;
            this.lblMateriaRegistrarNota.Text = "Materia";
            this.lblMateriaRegistrarNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblTurno.Location = new System.Drawing.Point(271, 95);
            this.lblTurno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(59, 16);
            this.lblTurno.TabIndex = 59;
            this.lblTurno.Text = "Turno";
            this.lblTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTurno
            // 
            this.cmbTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurno.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes"});
            this.cmbTurno.Location = new System.Drawing.Point(502, 92);
            this.cmbTurno.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(126, 24);
            this.cmbTurno.TabIndex = 61;
            this.cmbTurno.SelectedIndexChanged += new System.EventHandler(this.cmbTurno_SelectedIndexChanged);
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.AutoSize = true;
            this.lblTrimestre.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrimestre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblTrimestre.Location = new System.Drawing.Point(285, 464);
            this.lblTrimestre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(59, 16);
            this.lblTrimestre.TabIndex = 59;
            this.lblTrimestre.Text = "Turno";
            this.lblTrimestre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrimestre.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbTrimestre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes"});
            this.cmbTrimestre.Location = new System.Drawing.Point(516, 461);
            this.cmbTrimestre.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(126, 24);
            this.cmbTrimestre.TabIndex = 61;
            // 
            // btnGuardarNotaTrimestral
            // 
            this.btnGuardarNotaTrimestral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnGuardarNotaTrimestral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardarNotaTrimestral.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnGuardarNotaTrimestral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnGuardarNotaTrimestral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarNotaTrimestral.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarNotaTrimestral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnGuardarNotaTrimestral.Location = new System.Drawing.Point(385, 585);
            this.btnGuardarNotaTrimestral.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarNotaTrimestral.Name = "btnGuardarNotaTrimestral";
            this.btnGuardarNotaTrimestral.Size = new System.Drawing.Size(159, 38);
            this.btnGuardarNotaTrimestral.TabIndex = 81;
            this.btnGuardarNotaTrimestral.Text = "Calificar";
            this.btnGuardarNotaTrimestral.UseVisualStyleBackColor = false;
            this.btnGuardarNotaTrimestral.Click += new System.EventHandler(this.btnGuardarNotaTrimestral_Click);
            // 
            // RegistrarNotaTrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(938, 664);
            this.Controls.Add(this.btnGuardarNotaTrimestral);
            this.Controls.Add(this.GrillaMaterias);
            this.Controls.Add(this.GrillaAlumnos);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.cmbTurno);
            this.Controls.Add(this.cmbCurso);
            this.Controls.Add(this.txtNotaTrimestral);
            this.Controls.Add(this.lblNotaNumerica);
            this.Controls.Add(this.lblMateriaRegistrarNota);
            this.Controls.Add(this.lblAlumnosRegistrarNota);
            this.Controls.Add(this.lblTrimestre);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrarNotaTrimestral";
            this.Text = "RegistrarNotaTrimestral";
            this.Load += new System.EventHandler(this.RegistrarNotaTrimestral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAlumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMaterias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.TextBox txtNotaTrimestral;
        private System.Windows.Forms.Label lblNotaNumerica;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.DataGridView GrillaAlumnos;
        private System.Windows.Forms.DataGridView GrillaMaterias;
        private System.Windows.Forms.Label lblAlumnosRegistrarNota;
        private System.Windows.Forms.Label lblMateriaRegistrarNota;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Button btnGuardarNotaTrimestral;
    }
}