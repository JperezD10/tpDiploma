namespace tpDiploma
{
    partial class BajaAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BajaAlumno));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApellidoRegistrarProfesor = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblNombreRegistrarProfesor = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.GrillaAlumnos = new System.Windows.Forms.DataGridView();
            this.btnBajaAlumno = new System.Windows.Forms.Button();
            this.btnBuscarAlumnos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // lblApellidoRegistrarProfesor
            // 
            this.lblApellidoRegistrarProfesor.AutoSize = true;
            this.lblApellidoRegistrarProfesor.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoRegistrarProfesor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblApellidoRegistrarProfesor.Location = new System.Drawing.Point(229, 91);
            this.lblApellidoRegistrarProfesor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApellidoRegistrarProfesor.Name = "lblApellidoRegistrarProfesor";
            this.lblApellidoRegistrarProfesor.Size = new System.Drawing.Size(75, 16);
            this.lblApellidoRegistrarProfesor.TabIndex = 76;
            this.lblApellidoRegistrarProfesor.Text = "Apellido";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblDNI.Location = new System.Drawing.Point(229, 149);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(34, 16);
            this.lblDNI.TabIndex = 77;
            this.lblDNI.Text = "DNI";
            // 
            // lblNombreRegistrarProfesor
            // 
            this.lblNombreRegistrarProfesor.AutoSize = true;
            this.lblNombreRegistrarProfesor.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreRegistrarProfesor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblNombreRegistrarProfesor.Location = new System.Drawing.Point(229, 46);
            this.lblNombreRegistrarProfesor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreRegistrarProfesor.Name = "lblNombreRegistrarProfesor";
            this.lblNombreRegistrarProfesor.Size = new System.Drawing.Size(68, 16);
            this.lblNombreRegistrarProfesor.TabIndex = 78;
            this.lblNombreRegistrarProfesor.Text = "Nombre";
            // 
            // txtDNI
            // 
            this.txtDNI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtDNI.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtDNI.Location = new System.Drawing.Point(415, 147);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(154, 23);
            this.txtDNI.TabIndex = 75;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtApellido.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtApellido.Location = new System.Drawing.Point(415, 89);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(154, 23);
            this.txtApellido.TabIndex = 74;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtNombre.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtNombre.Location = new System.Drawing.Point(415, 45);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(154, 23);
            this.txtNombre.TabIndex = 73;
            // 
            // GrillaAlumnos
            // 
            this.GrillaAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaAlumnos.Location = new System.Drawing.Point(146, 212);
            this.GrillaAlumnos.Name = "GrillaAlumnos";
            this.GrillaAlumnos.Size = new System.Drawing.Size(528, 162);
            this.GrillaAlumnos.TabIndex = 79;
            this.GrillaAlumnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaAlumnos_CellClick);
            // 
            // btnBajaAlumno
            // 
            this.btnBajaAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnBajaAlumno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBajaAlumno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnBajaAlumno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnBajaAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaAlumno.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajaAlumno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnBajaAlumno.Location = new System.Drawing.Point(305, 403);
            this.btnBajaAlumno.Margin = new System.Windows.Forms.Padding(2);
            this.btnBajaAlumno.Name = "btnBajaAlumno";
            this.btnBajaAlumno.Size = new System.Drawing.Size(154, 45);
            this.btnBajaAlumno.TabIndex = 80;
            this.btnBajaAlumno.Text = "Baja";
            this.btnBajaAlumno.UseVisualStyleBackColor = false;
            this.btnBajaAlumno.Click += new System.EventHandler(this.btnBajaAlumno_Click);
            // 
            // btnBuscarAlumnos
            // 
            this.btnBuscarAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnBuscarAlumnos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarAlumnos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnBuscarAlumnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnBuscarAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAlumnos.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAlumnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnBuscarAlumnos.Location = new System.Drawing.Point(632, 85);
            this.btnBuscarAlumnos.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarAlumnos.Name = "btnBuscarAlumnos";
            this.btnBuscarAlumnos.Size = new System.Drawing.Size(120, 29);
            this.btnBuscarAlumnos.TabIndex = 80;
            this.btnBuscarAlumnos.Text = "Baja";
            this.btnBuscarAlumnos.UseVisualStyleBackColor = false;
            this.btnBuscarAlumnos.Click += new System.EventHandler(this.btnBuscarAlumnos_Click);
            // 
            // BajaAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(810, 502);
            this.Controls.Add(this.btnBuscarAlumnos);
            this.Controls.Add(this.btnBajaAlumno);
            this.Controls.Add(this.GrillaAlumnos);
            this.Controls.Add(this.lblApellidoRegistrarProfesor);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblNombreRegistrarProfesor);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BajaAlumno";
            this.Text = "BajaAlumno";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApellidoRegistrarProfesor;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblNombreRegistrarProfesor;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView GrillaAlumnos;
        private System.Windows.Forms.Button btnBajaAlumno;
        private System.Windows.Forms.Button btnBuscarAlumnos;
    }
}