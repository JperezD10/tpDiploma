
namespace tpDiploma
{
    partial class ProfesorMaterias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfesorMaterias));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDesAsignarMateria = new System.Windows.Forms.Button();
            this.btnAsignarMateria = new System.Windows.Forms.Button();
            this.lblMateriasAsignadas = new System.Windows.Forms.Label();
            this.lblMateriasSinAsignar = new System.Windows.Forms.Label();
            this.GrillaMateriasAsignadas = new System.Windows.Forms.DataGridView();
            this.GrillaMateriasSinAsignar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMateriasAsignadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMateriasSinAsignar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, -25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // btnDesAsignarMateria
            // 
            this.btnDesAsignarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnDesAsignarMateria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesAsignarMateria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesAsignarMateria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnDesAsignarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesAsignarMateria.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.btnDesAsignarMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesAsignarMateria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDesAsignarMateria.Location = new System.Drawing.Point(527, 261);
            this.btnDesAsignarMateria.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesAsignarMateria.Name = "btnDesAsignarMateria";
            this.btnDesAsignarMateria.Size = new System.Drawing.Size(52, 48);
            this.btnDesAsignarMateria.TabIndex = 66;
            this.btnDesAsignarMateria.Text = "<=";
            this.btnDesAsignarMateria.UseVisualStyleBackColor = false;
            // 
            // btnAsignarMateria
            // 
            this.btnAsignarMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnAsignarMateria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsignarMateria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnAsignarMateria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnAsignarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarMateria.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.btnAsignarMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnAsignarMateria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAsignarMateria.Location = new System.Drawing.Point(527, 173);
            this.btnAsignarMateria.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarMateria.Name = "btnAsignarMateria";
            this.btnAsignarMateria.Size = new System.Drawing.Size(52, 45);
            this.btnAsignarMateria.TabIndex = 65;
            this.btnAsignarMateria.Text = "=>";
            this.btnAsignarMateria.UseVisualStyleBackColor = false;
            this.btnAsignarMateria.Click += new System.EventHandler(this.btnAsignarMateria_Click);
            // 
            // lblMateriasAsignadas
            // 
            this.lblMateriasAsignadas.AutoSize = true;
            this.lblMateriasAsignadas.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblMateriasAsignadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblMateriasAsignadas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMateriasAsignadas.Location = new System.Drawing.Point(780, 77);
            this.lblMateriasAsignadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMateriasAsignadas.Name = "lblMateriasAsignadas";
            this.lblMateriasAsignadas.Size = new System.Drawing.Size(164, 16);
            this.lblMateriasAsignadas.TabIndex = 63;
            this.lblMateriasAsignadas.Text = "Materias asignadas";
            // 
            // lblMateriasSinAsignar
            // 
            this.lblMateriasSinAsignar.AutoSize = true;
            this.lblMateriasSinAsignar.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblMateriasSinAsignar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblMateriasSinAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMateriasSinAsignar.Location = new System.Drawing.Point(136, 77);
            this.lblMateriasSinAsignar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMateriasSinAsignar.Name = "lblMateriasSinAsignar";
            this.lblMateriasSinAsignar.Size = new System.Drawing.Size(172, 16);
            this.lblMateriasSinAsignar.TabIndex = 64;
            this.lblMateriasSinAsignar.Text = "materias sin asignar";
            // 
            // GrillaMateriasAsignadas
            // 
            this.GrillaMateriasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaMateriasAsignadas.Location = new System.Drawing.Point(633, 112);
            this.GrillaMateriasAsignadas.Name = "GrillaMateriasAsignadas";
            this.GrillaMateriasAsignadas.ReadOnly = true;
            this.GrillaMateriasAsignadas.Size = new System.Drawing.Size(433, 288);
            this.GrillaMateriasAsignadas.TabIndex = 61;
            // 
            // GrillaMateriasSinAsignar
            // 
            this.GrillaMateriasSinAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaMateriasSinAsignar.Location = new System.Drawing.Point(26, 112);
            this.GrillaMateriasSinAsignar.Name = "GrillaMateriasSinAsignar";
            this.GrillaMateriasSinAsignar.ReadOnly = true;
            this.GrillaMateriasSinAsignar.Size = new System.Drawing.Size(445, 288);
            this.GrillaMateriasSinAsignar.TabIndex = 62;
            this.GrillaMateriasSinAsignar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaMateriasSinAsignar_CellClick);
            // 
            // ProfesorMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1109, 473);
            this.Controls.Add(this.btnDesAsignarMateria);
            this.Controls.Add(this.btnAsignarMateria);
            this.Controls.Add(this.lblMateriasAsignadas);
            this.Controls.Add(this.lblMateriasSinAsignar);
            this.Controls.Add(this.GrillaMateriasAsignadas);
            this.Controls.Add(this.GrillaMateriasSinAsignar);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "ProfesorMaterias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfesorMaterias";
            this.Load += new System.EventHandler(this.ProfesorMaterias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMateriasAsignadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaMateriasSinAsignar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDesAsignarMateria;
        private System.Windows.Forms.Button btnAsignarMateria;
        private System.Windows.Forms.Label lblMateriasAsignadas;
        private System.Windows.Forms.Label lblMateriasSinAsignar;
        private System.Windows.Forms.DataGridView GrillaMateriasAsignadas;
        private System.Windows.Forms.DataGridView GrillaMateriasSinAsignar;
    }
}