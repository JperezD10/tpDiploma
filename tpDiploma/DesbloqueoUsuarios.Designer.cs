namespace tpDiploma
{
    partial class DesbloqueoUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesbloqueoUsuarios));
            this.btnDesbloquearUsuario = new System.Windows.Forms.Button();
            this.GrillaUsuariosBloqueados = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaUsuariosBloqueados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDesbloquearUsuario
            // 
            this.btnDesbloquearUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnDesbloquearUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesbloquearUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesbloquearUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnDesbloquearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesbloquearUsuario.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesbloquearUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnDesbloquearUsuario.Location = new System.Drawing.Point(354, 400);
            this.btnDesbloquearUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesbloquearUsuario.Name = "btnDesbloquearUsuario";
            this.btnDesbloquearUsuario.Size = new System.Drawing.Size(157, 35);
            this.btnDesbloquearUsuario.TabIndex = 65;
            this.btnDesbloquearUsuario.Text = "Guardar";
            this.btnDesbloquearUsuario.UseVisualStyleBackColor = false;
            this.btnDesbloquearUsuario.Click += new System.EventHandler(this.btnDesbloquearUsuario_Click);
            // 
            // GrillaUsuariosBloqueados
            // 
            this.GrillaUsuariosBloqueados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaUsuariosBloqueados.Location = new System.Drawing.Point(213, 75);
            this.GrillaUsuariosBloqueados.Name = "GrillaUsuariosBloqueados";
            this.GrillaUsuariosBloqueados.RowHeadersWidth = 51;
            this.GrillaUsuariosBloqueados.Size = new System.Drawing.Size(453, 279);
            this.GrillaUsuariosBloqueados.TabIndex = 63;
            this.GrillaUsuariosBloqueados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaUsuariosBloqueados_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // DesbloqueoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(803, 456);
            this.Controls.Add(this.btnDesbloquearUsuario);
            this.Controls.Add(this.GrillaUsuariosBloqueados);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DesbloqueoUsuarios";
            this.Text = "DesbloqueoUsuarios";
            this.Load += new System.EventHandler(this.DesbloqueoUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrillaUsuariosBloqueados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDesbloquearUsuario;
        private System.Windows.Forms.DataGridView GrillaUsuariosBloqueados;
    }
}