
namespace tpDiploma
{
    partial class NotasIncripcionAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotasIncripcionAlumno));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GrillaCursosDisponibles = new System.Windows.Forms.DataGridView();
            this.lblAñoCursoNuevoAlumno = new System.Windows.Forms.Label();
            this.cmbGradoCurso = new System.Windows.Forms.ComboBox();
            this.grillaMateriasPorCalificar = new System.Windows.Forms.DataGridView();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtNotaNumerica = new System.Windows.Forms.TextBox();
            this.lblNotaNumerica = new System.Windows.Forms.Label();
            this.lblNombreMateria = new System.Windows.Forms.Label();
            this.btnSaveNota = new System.Windows.Forms.Button();
            this.GrillaNotasPuestas = new System.Windows.Forms.DataGridView();
            this.lblNotasAsignadas = new System.Windows.Forms.Label();
            this.btnFinalizarRegistroAlumno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCursosDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriasPorCalificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaNotasPuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // GrillaCursosDisponibles
            // 
            this.GrillaCursosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaCursosDisponibles.Location = new System.Drawing.Point(197, 108);
            this.GrillaCursosDisponibles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GrillaCursosDisponibles.Name = "GrillaCursosDisponibles";
            this.GrillaCursosDisponibles.ReadOnly = true;
            this.GrillaCursosDisponibles.RowHeadersWidth = 51;
            this.GrillaCursosDisponibles.RowTemplate.Height = 24;
            this.GrillaCursosDisponibles.Size = new System.Drawing.Size(719, 113);
            this.GrillaCursosDisponibles.TabIndex = 68;
            this.GrillaCursosDisponibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaCursosDisponibles_CellClick);
            // 
            // lblAñoCursoNuevoAlumno
            // 
            this.lblAñoCursoNuevoAlumno.AutoSize = true;
            this.lblAñoCursoNuevoAlumno.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblAñoCursoNuevoAlumno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblAñoCursoNuevoAlumno.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAñoCursoNuevoAlumno.Location = new System.Drawing.Point(353, 42);
            this.lblAñoCursoNuevoAlumno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAñoCursoNuevoAlumno.Name = "lblAñoCursoNuevoAlumno";
            this.lblAñoCursoNuevoAlumno.Size = new System.Drawing.Size(149, 16);
            this.lblAñoCursoNuevoAlumno.TabIndex = 69;
            this.lblAñoCursoNuevoAlumno.Text = "seleccione curso";
            // 
            // cmbGradoCurso
            // 
            this.cmbGradoCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbGradoCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradoCurso.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbGradoCurso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbGradoCurso.FormattingEnabled = true;
            this.cmbGradoCurso.Location = new System.Drawing.Point(548, 41);
            this.cmbGradoCurso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbGradoCurso.Name = "cmbGradoCurso";
            this.cmbGradoCurso.Size = new System.Drawing.Size(126, 24);
            this.cmbGradoCurso.TabIndex = 70;
            this.cmbGradoCurso.SelectedIndexChanged += new System.EventHandler(this.cmbGradoCurso_SelectedIndexChanged);
            // 
            // grillaMateriasPorCalificar
            // 
            this.grillaMateriasPorCalificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaMateriasPorCalificar.Location = new System.Drawing.Point(36, 325);
            this.grillaMateriasPorCalificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grillaMateriasPorCalificar.Name = "grillaMateriasPorCalificar";
            this.grillaMateriasPorCalificar.ReadOnly = true;
            this.grillaMateriasPorCalificar.RowHeadersWidth = 51;
            this.grillaMateriasPorCalificar.RowTemplate.Height = 24;
            this.grillaMateriasPorCalificar.Size = new System.Drawing.Size(359, 216);
            this.grillaMateriasPorCalificar.TabIndex = 71;
            this.grillaMateriasPorCalificar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaMateriasPorCalificar_CellClick);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblSubject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubject.Location = new System.Drawing.Point(110, 277);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(149, 16);
            this.lblSubject.TabIndex = 69;
            this.lblSubject.Text = "seleccione curso";
            // 
            // txtNotaNumerica
            // 
            this.txtNotaNumerica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtNotaNumerica.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNotaNumerica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtNotaNumerica.Location = new System.Drawing.Point(548, 377);
            this.txtNotaNumerica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNotaNumerica.Name = "txtNotaNumerica";
            this.txtNotaNumerica.Size = new System.Drawing.Size(126, 23);
            this.txtNotaNumerica.TabIndex = 72;
            // 
            // lblNotaNumerica
            // 
            this.lblNotaNumerica.AutoSize = true;
            this.lblNotaNumerica.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblNotaNumerica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblNotaNumerica.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNotaNumerica.Location = new System.Drawing.Point(442, 379);
            this.lblNotaNumerica.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotaNumerica.Name = "lblNotaNumerica";
            this.lblNotaNumerica.Size = new System.Drawing.Size(47, 16);
            this.lblNotaNumerica.TabIndex = 69;
            this.lblNotaNumerica.Text = "nota";
            // 
            // lblNombreMateria
            // 
            this.lblNombreMateria.AutoSize = true;
            this.lblNombreMateria.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblNombreMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblNombreMateria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreMateria.Location = new System.Drawing.Point(544, 325);
            this.lblNombreMateria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreMateria.Name = "lblNombreMateria";
            this.lblNombreMateria.Size = new System.Drawing.Size(68, 16);
            this.lblNombreMateria.TabIndex = 69;
            this.lblNombreMateria.Text = "nombre";
            // 
            // btnSaveNota
            // 
            this.btnSaveNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnSaveNota.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveNota.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnSaveNota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSaveNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveNota.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnSaveNota.Location = new System.Drawing.Point(496, 446);
            this.btnSaveNota.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveNota.Name = "btnSaveNota";
            this.btnSaveNota.Size = new System.Drawing.Size(112, 29);
            this.btnSaveNota.TabIndex = 73;
            this.btnSaveNota.Text = "Crear";
            this.btnSaveNota.UseVisualStyleBackColor = false;
            this.btnSaveNota.Click += new System.EventHandler(this.btnSaveNota_Click);
            // 
            // GrillaNotasPuestas
            // 
            this.GrillaNotasPuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaNotasPuestas.Location = new System.Drawing.Point(700, 325);
            this.GrillaNotasPuestas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GrillaNotasPuestas.Name = "GrillaNotasPuestas";
            this.GrillaNotasPuestas.ReadOnly = true;
            this.GrillaNotasPuestas.RowHeadersWidth = 51;
            this.GrillaNotasPuestas.RowTemplate.Height = 24;
            this.GrillaNotasPuestas.Size = new System.Drawing.Size(359, 216);
            this.GrillaNotasPuestas.TabIndex = 71;
            this.GrillaNotasPuestas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaNotasPuestas_CellClick);
            // 
            // lblNotasAsignadas
            // 
            this.lblNotasAsignadas.AutoSize = true;
            this.lblNotasAsignadas.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblNotasAsignadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblNotasAsignadas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNotasAsignadas.Location = new System.Drawing.Point(825, 277);
            this.lblNotasAsignadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotasAsignadas.Name = "lblNotasAsignadas";
            this.lblNotasAsignadas.Size = new System.Drawing.Size(149, 16);
            this.lblNotasAsignadas.TabIndex = 69;
            this.lblNotasAsignadas.Text = "seleccione curso";
            // 
            // btnFinalizarRegistroAlumno
            // 
            this.btnFinalizarRegistroAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnFinalizarRegistroAlumno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFinalizarRegistroAlumno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnFinalizarRegistroAlumno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnFinalizarRegistroAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarRegistroAlumno.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarRegistroAlumno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnFinalizarRegistroAlumno.Location = new System.Drawing.Point(445, 556);
            this.btnFinalizarRegistroAlumno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinalizarRegistroAlumno.Name = "btnFinalizarRegistroAlumno";
            this.btnFinalizarRegistroAlumno.Size = new System.Drawing.Size(199, 34);
            this.btnFinalizarRegistroAlumno.TabIndex = 74;
            this.btnFinalizarRegistroAlumno.Text = "Finalizar";
            this.btnFinalizarRegistroAlumno.UseVisualStyleBackColor = false;
            this.btnFinalizarRegistroAlumno.Click += new System.EventHandler(this.btnFinalizarRegistroAlumno_Click);
            // 
            // NotasIncripcionAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1090, 609);
            this.Controls.Add(this.btnFinalizarRegistroAlumno);
            this.Controls.Add(this.btnSaveNota);
            this.Controls.Add(this.txtNotaNumerica);
            this.Controls.Add(this.GrillaNotasPuestas);
            this.Controls.Add(this.grillaMateriasPorCalificar);
            this.Controls.Add(this.cmbGradoCurso);
            this.Controls.Add(this.lblNombreMateria);
            this.Controls.Add(this.lblNotaNumerica);
            this.Controls.Add(this.lblNotasAsignadas);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblAñoCursoNuevoAlumno);
            this.Controls.Add(this.GrillaCursosDisponibles);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "NotasIncripcionAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotasIncripcionAlumno";
            this.Load += new System.EventHandler(this.NotasIncripcionAlumno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCursosDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriasPorCalificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaNotasPuestas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView GrillaCursosDisponibles;
        private System.Windows.Forms.Label lblAñoCursoNuevoAlumno;
        private System.Windows.Forms.ComboBox cmbGradoCurso;
        private System.Windows.Forms.DataGridView grillaMateriasPorCalificar;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtNotaNumerica;
        private System.Windows.Forms.Label lblNotaNumerica;
        private System.Windows.Forms.Label lblNombreMateria;
        private System.Windows.Forms.Button btnSaveNota;
        private System.Windows.Forms.DataGridView GrillaNotasPuestas;
        private System.Windows.Forms.Label lblNotasAsignadas;
        private System.Windows.Forms.Button btnFinalizarRegistroAlumno;
    }
}