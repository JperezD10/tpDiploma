
namespace tpDiploma
{
    partial class Materias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materias));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNombreMateria = new System.Windows.Forms.Label();
            this.lblDiaMateria = new System.Windows.Forms.Label();
            this.lblHoraInicioMateria = new System.Windows.Forms.Label();
            this.txtNombreMateria = new System.Windows.Forms.TextBox();
            this.cmbDiaMateria = new System.Windows.Forms.ComboBox();
            this.txtHoraInicioMateria = new System.Windows.Forms.TextBox();
            this.grillaCursosDisponibles = new System.Windows.Forms.DataGridView();
            this.btnSaveMateria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCursosDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // lblNombreMateria
            // 
            this.lblNombreMateria.AutoSize = true;
            this.lblNombreMateria.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblNombreMateria.Location = new System.Drawing.Point(169, 35);
            this.lblNombreMateria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreMateria.Name = "lblNombreMateria";
            this.lblNombreMateria.Size = new System.Drawing.Size(136, 16);
            this.lblNombreMateria.TabIndex = 51;
            this.lblNombreMateria.Text = "Nombre MAteria";
            this.lblNombreMateria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiaMateria
            // 
            this.lblDiaMateria.AutoSize = true;
            this.lblDiaMateria.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblDiaMateria.Location = new System.Drawing.Point(169, 88);
            this.lblDiaMateria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiaMateria.Name = "lblDiaMateria";
            this.lblDiaMateria.Size = new System.Drawing.Size(34, 16);
            this.lblDiaMateria.TabIndex = 52;
            this.lblDiaMateria.Text = "Dia";
            this.lblDiaMateria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHoraInicioMateria
            // 
            this.lblHoraInicioMateria.AutoSize = true;
            this.lblHoraInicioMateria.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraInicioMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblHoraInicioMateria.Location = new System.Drawing.Point(169, 144);
            this.lblHoraInicioMateria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoraInicioMateria.Name = "lblHoraInicioMateria";
            this.lblHoraInicioMateria.Size = new System.Drawing.Size(123, 16);
            this.lblHoraInicioMateria.TabIndex = 52;
            this.lblHoraInicioMateria.Text = "Hora de Inicio";
            this.lblHoraInicioMateria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombreMateria
            // 
            this.txtNombreMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtNombreMateria.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNombreMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtNombreMateria.Location = new System.Drawing.Point(400, 32);
            this.txtNombreMateria.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreMateria.Name = "txtNombreMateria";
            this.txtNombreMateria.Size = new System.Drawing.Size(126, 23);
            this.txtNombreMateria.TabIndex = 53;
            // 
            // cmbDiaMateria
            // 
            this.cmbDiaMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbDiaMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaMateria.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbDiaMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbDiaMateria.FormattingEnabled = true;
            this.cmbDiaMateria.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes"});
            this.cmbDiaMateria.Location = new System.Drawing.Point(400, 85);
            this.cmbDiaMateria.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDiaMateria.Name = "cmbDiaMateria";
            this.cmbDiaMateria.Size = new System.Drawing.Size(126, 24);
            this.cmbDiaMateria.TabIndex = 55;
            // 
            // txtHoraInicioMateria
            // 
            this.txtHoraInicioMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtHoraInicioMateria.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtHoraInicioMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtHoraInicioMateria.Location = new System.Drawing.Point(400, 141);
            this.txtHoraInicioMateria.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoraInicioMateria.Name = "txtHoraInicioMateria";
            this.txtHoraInicioMateria.Size = new System.Drawing.Size(126, 23);
            this.txtHoraInicioMateria.TabIndex = 53;
            // 
            // grillaCursosDisponibles
            // 
            this.grillaCursosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaCursosDisponibles.Location = new System.Drawing.Point(156, 213);
            this.grillaCursosDisponibles.Name = "grillaCursosDisponibles";
            this.grillaCursosDisponibles.Size = new System.Drawing.Size(426, 165);
            this.grillaCursosDisponibles.TabIndex = 56;
            this.grillaCursosDisponibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaCursosDisponibles_CellClick);
            // 
            // btnSaveMateria
            // 
            this.btnSaveMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnSaveMateria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveMateria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnSaveMateria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSaveMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMateria.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnSaveMateria.Location = new System.Drawing.Point(293, 396);
            this.btnSaveMateria.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveMateria.Name = "btnSaveMateria";
            this.btnSaveMateria.Size = new System.Drawing.Size(170, 55);
            this.btnSaveMateria.TabIndex = 57;
            this.btnSaveMateria.Text = "Crear";
            this.btnSaveMateria.UseVisualStyleBackColor = false;
            this.btnSaveMateria.Click += new System.EventHandler(this.btnSaveMateria_Click);
            // 
            // Materias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(678, 503);
            this.Controls.Add(this.btnSaveMateria);
            this.Controls.Add(this.grillaCursosDisponibles);
            this.Controls.Add(this.cmbDiaMateria);
            this.Controls.Add(this.txtHoraInicioMateria);
            this.Controls.Add(this.txtNombreMateria);
            this.Controls.Add(this.lblNombreMateria);
            this.Controls.Add(this.lblHoraInicioMateria);
            this.Controls.Add(this.lblDiaMateria);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Materias";
            this.Text = "Materias";
            this.Load += new System.EventHandler(this.Materias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCursosDisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombreMateria;
        private System.Windows.Forms.Label lblDiaMateria;
        private System.Windows.Forms.Label lblHoraInicioMateria;
        private System.Windows.Forms.TextBox txtNombreMateria;
        private System.Windows.Forms.ComboBox cmbDiaMateria;
        private System.Windows.Forms.TextBox txtHoraInicioMateria;
        private System.Windows.Forms.DataGridView grillaCursosDisponibles;
        private System.Windows.Forms.Button btnSaveMateria;
    }
}