
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
            this.lblPermisosNoAsignados = new System.Windows.Forms.Label();
            this.btnAsignarPermiso = new System.Windows.Forms.Button();
            this.btnDesasignarPermiso = new System.Windows.Forms.Button();
            this.TreeViewPermisosUsuario = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPermisosNoAsignados)).BeginInit();
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
            this.lblUsuarioAsignar.Location = new System.Drawing.Point(243, 36);
            this.lblUsuarioAsignar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioAsignar.Name = "lblUsuarioAsignar";
            this.lblUsuarioAsignar.Size = new System.Drawing.Size(85, 16);
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
            this.cmbUsuarios.Location = new System.Drawing.Point(365, 33);
            this.cmbUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(165, 24);
            this.cmbUsuarios.TabIndex = 56;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            // 
            // GrillaPermisosNoAsignados
            // 
            this.GrillaPermisosNoAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPermisosNoAsignados.Location = new System.Drawing.Point(48, 124);
            this.GrillaPermisosNoAsignados.Name = "GrillaPermisosNoAsignados";
            this.GrillaPermisosNoAsignados.ReadOnly = true;
            this.GrillaPermisosNoAsignados.Size = new System.Drawing.Size(330, 374);
            this.GrillaPermisosNoAsignados.TabIndex = 57;
            this.GrillaPermisosNoAsignados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaPermisosNoAsignados_CellClick);
            // 
            // lblPermisosNoAsignados
            // 
            this.lblPermisosNoAsignados.AutoSize = true;
            this.lblPermisosNoAsignados.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblPermisosNoAsignados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblPermisosNoAsignados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPermisosNoAsignados.Location = new System.Drawing.Point(107, 86);
            this.lblPermisosNoAsignados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPermisosNoAsignados.Name = "lblPermisosNoAsignados";
            this.lblPermisosNoAsignados.Size = new System.Drawing.Size(187, 16);
            this.lblPermisosNoAsignados.TabIndex = 47;
            this.lblPermisosNoAsignados.Text = "Permisos no asignados";
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
            this.btnAsignarPermiso.Location = new System.Drawing.Point(448, 232);
            this.btnAsignarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarPermiso.Name = "btnAsignarPermiso";
            this.btnAsignarPermiso.Size = new System.Drawing.Size(52, 49);
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
            this.btnDesasignarPermiso.Location = new System.Drawing.Point(448, 307);
            this.btnDesasignarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesasignarPermiso.Name = "btnDesasignarPermiso";
            this.btnDesasignarPermiso.Size = new System.Drawing.Size(52, 52);
            this.btnDesasignarPermiso.TabIndex = 58;
            this.btnDesasignarPermiso.Text = "<=";
            this.btnDesasignarPermiso.UseVisualStyleBackColor = false;
            this.btnDesasignarPermiso.Click += new System.EventHandler(this.btnDesasignarPermiso_Click);
            // 
            // TreeViewPermisosUsuario
            // 
            this.TreeViewPermisosUsuario.Location = new System.Drawing.Point(562, 124);
            this.TreeViewPermisosUsuario.Name = "TreeViewPermisosUsuario";
            this.TreeViewPermisosUsuario.Size = new System.Drawing.Size(326, 374);
            this.TreeViewPermisosUsuario.TabIndex = 59;
            this.TreeViewPermisosUsuario.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewPermisosUsuario_NodeMouseClick);
            // 
            // PatenteFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(919, 522);
            this.Controls.Add(this.TreeViewPermisosUsuario);
            this.Controls.Add(this.btnDesasignarPermiso);
            this.Controls.Add(this.btnAsignarPermiso);
            this.Controls.Add(this.GrillaPermisosNoAsignados);
            this.Controls.Add(this.cmbUsuarios);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUsuarioAsignar;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.DataGridView GrillaPermisosNoAsignados;
        private System.Windows.Forms.Label lblPermisosNoAsignados;
        private System.Windows.Forms.Button btnAsignarPermiso;
        private System.Windows.Forms.Button btnDesasignarPermiso;
        private System.Windows.Forms.TreeView TreeViewPermisosUsuario;
    }
}