
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCursosDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriasPorCalificar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // GrillaCursosDisponibles
            // 
            this.GrillaCursosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaCursosDisponibles.Location = new System.Drawing.Point(151, 133);
            this.GrillaCursosDisponibles.Name = "GrillaCursosDisponibles";
            this.GrillaCursosDisponibles.RowHeadersWidth = 51;
            this.GrillaCursosDisponibles.RowTemplate.Height = 24;
            this.GrillaCursosDisponibles.Size = new System.Drawing.Size(959, 139);
            this.GrillaCursosDisponibles.TabIndex = 68;
            this.GrillaCursosDisponibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaCursosDisponibles_CellClick);
            // 
            // lblAñoCursoNuevoAlumno
            // 
            this.lblAñoCursoNuevoAlumno.AutoSize = true;
            this.lblAñoCursoNuevoAlumno.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblAñoCursoNuevoAlumno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblAñoCursoNuevoAlumno.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAñoCursoNuevoAlumno.Location = new System.Drawing.Point(250, 50);
            this.lblAñoCursoNuevoAlumno.Name = "lblAñoCursoNuevoAlumno";
            this.lblAñoCursoNuevoAlumno.Size = new System.Drawing.Size(177, 20);
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
            this.cmbGradoCurso.Location = new System.Drawing.Point(730, 50);
            this.cmbGradoCurso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbGradoCurso.Name = "cmbGradoCurso";
            this.cmbGradoCurso.Size = new System.Drawing.Size(167, 27);
            this.cmbGradoCurso.TabIndex = 70;
            this.cmbGradoCurso.SelectedIndexChanged += new System.EventHandler(this.cmbGradoCurso_SelectedIndexChanged);
            // 
            // grillaMateriasPorCalificar
            // 
            this.grillaMateriasPorCalificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaMateriasPorCalificar.Location = new System.Drawing.Point(151, 405);
            this.grillaMateriasPorCalificar.Name = "grillaMateriasPorCalificar";
            this.grillaMateriasPorCalificar.RowHeadersWidth = 51;
            this.grillaMateriasPorCalificar.RowTemplate.Height = 24;
            this.grillaMateriasPorCalificar.Size = new System.Drawing.Size(479, 266);
            this.grillaMateriasPorCalificar.TabIndex = 71;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblSubject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubject.Location = new System.Drawing.Point(250, 346);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(177, 20);
            this.lblSubject.TabIndex = 69;
            this.lblSubject.Text = "seleccione curso";
            // 
            // NotasIncripcionAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1272, 750);
            this.Controls.Add(this.grillaMateriasPorCalificar);
            this.Controls.Add(this.cmbGradoCurso);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblAñoCursoNuevoAlumno);
            this.Controls.Add(this.GrillaCursosDisponibles);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NotasIncripcionAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotasIncripcionAlumno";
            this.Load += new System.EventHandler(this.NotasIncripcionAlumno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaCursosDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriasPorCalificar)).EndInit();
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
    }
}