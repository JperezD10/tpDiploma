namespace tpDiploma
{
    partial class CompletarIdioma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompletarIdioma));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbCompletarIdioma = new System.Windows.Forms.ComboBox();
            this.lblLenguajeLogin = new System.Windows.Forms.Label();
            this.GrillaATraducir = new System.Windows.Forms.DataGridView();
            this.lblTraduccion = new System.Windows.Forms.Label();
            this.lblControlATraducir = new System.Windows.Forms.Label();
            this.txtTraduccion = new System.Windows.Forms.TextBox();
            this.btnGuardarTraduccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaATraducir)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // cmbCompletarIdioma
            // 
            this.cmbCompletarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbCompletarIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompletarIdioma.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbCompletarIdioma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbCompletarIdioma.FormattingEnabled = true;
            this.cmbCompletarIdioma.Items.AddRange(new object[] {
            "",
            "Baja",
            "Media",
            "Alta"});
            this.cmbCompletarIdioma.Location = new System.Drawing.Point(695, 37);
            this.cmbCompletarIdioma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCompletarIdioma.Name = "cmbCompletarIdioma";
            this.cmbCompletarIdioma.Size = new System.Drawing.Size(149, 27);
            this.cmbCompletarIdioma.TabIndex = 57;
            this.cmbCompletarIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbCompletarIdioma_SelectedIndexChanged);
            // 
            // lblLenguajeLogin
            // 
            this.lblLenguajeLogin.AutoSize = true;
            this.lblLenguajeLogin.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblLenguajeLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblLenguajeLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLenguajeLogin.Location = new System.Drawing.Point(479, 41);
            this.lblLenguajeLogin.Name = "lblLenguajeLogin";
            this.lblLenguajeLogin.Size = new System.Drawing.Size(104, 20);
            this.lblLenguajeLogin.TabIndex = 58;
            this.lblLenguajeLogin.Text = "Language";
            // 
            // GrillaATraducir
            // 
            this.GrillaATraducir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaATraducir.Location = new System.Drawing.Point(181, 124);
            this.GrillaATraducir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrillaATraducir.Name = "GrillaATraducir";
            this.GrillaATraducir.RowHeadersWidth = 51;
            this.GrillaATraducir.Size = new System.Drawing.Size(395, 325);
            this.GrillaATraducir.TabIndex = 59;
            this.GrillaATraducir.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaATraducir_CellClick);
            // 
            // lblTraduccion
            // 
            this.lblTraduccion.AutoSize = true;
            this.lblTraduccion.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblTraduccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblTraduccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTraduccion.Location = new System.Drawing.Point(691, 282);
            this.lblTraduccion.Name = "lblTraduccion";
            this.lblTraduccion.Size = new System.Drawing.Size(129, 20);
            this.lblTraduccion.TabIndex = 58;
            this.lblTraduccion.Text = "Traduccion";
            this.lblTraduccion.Click += new System.EventHandler(this.lblTraduccion_Click);
            // 
            // lblControlATraducir
            // 
            this.lblControlATraducir.AutoSize = true;
            this.lblControlATraducir.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblControlATraducir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblControlATraducir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblControlATraducir.Location = new System.Drawing.Point(691, 170);
            this.lblControlATraducir.Name = "lblControlATraducir";
            this.lblControlATraducir.Size = new System.Drawing.Size(118, 20);
            this.lblControlATraducir.TabIndex = 58;
            this.lblControlATraducir.Text = "a traducir";
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtTraduccion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTraduccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtTraduccion.Location = new System.Drawing.Point(969, 278);
            this.txtTraduccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(204, 27);
            this.txtTraduccion.TabIndex = 60;
            this.txtTraduccion.TextChanged += new System.EventHandler(this.txtTraduccion_TextChanged);
            // 
            // btnGuardarTraduccion
            // 
            this.btnGuardarTraduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnGuardarTraduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardarTraduccion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnGuardarTraduccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnGuardarTraduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTraduccion.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTraduccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnGuardarTraduccion.Location = new System.Drawing.Point(816, 354);
            this.btnGuardarTraduccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarTraduccion.Name = "btnGuardarTraduccion";
            this.btnGuardarTraduccion.Size = new System.Drawing.Size(209, 43);
            this.btnGuardarTraduccion.TabIndex = 61;
            this.btnGuardarTraduccion.Text = "Guardar";
            this.btnGuardarTraduccion.UseVisualStyleBackColor = false;
            this.btnGuardarTraduccion.Click += new System.EventHandler(this.btnGuardarTraduccion_Click);
            // 
            // CompletarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1312, 580);
            this.Controls.Add(this.btnGuardarTraduccion);
            this.Controls.Add(this.txtTraduccion);
            this.Controls.Add(this.GrillaATraducir);
            this.Controls.Add(this.lblControlATraducir);
            this.Controls.Add(this.lblTraduccion);
            this.Controls.Add(this.lblLenguajeLogin);
            this.Controls.Add(this.cmbCompletarIdioma);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CompletarIdioma";
            this.Text = "CompletarIdioma";
            this.Load += new System.EventHandler(this.CompletarIdioma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaATraducir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbCompletarIdioma;
        private System.Windows.Forms.Label lblLenguajeLogin;
        private System.Windows.Forms.DataGridView GrillaATraducir;
        private System.Windows.Forms.Label lblTraduccion;
        private System.Windows.Forms.Label lblControlATraducir;
        private System.Windows.Forms.TextBox txtTraduccion;
        private System.Windows.Forms.Button btnGuardarTraduccion;
    }
}