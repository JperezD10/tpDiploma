namespace tpDiploma
{
    partial class MenuPrincipal
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
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnListBitacora = new System.Windows.Forms.Button();
            this.btnRegistrarUsuario = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.baseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarBackUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearFamiliaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelLateral.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.Black;
            this.panelLateral.Controls.Add(this.btnListBitacora);
            this.panelLateral.Controls.Add(this.btnRegistrarUsuario);
            this.panelLateral.Controls.Add(this.btnCerrarSesion);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Margin = new System.Windows.Forms.Padding(2);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(135, 583);
            this.panelLateral.TabIndex = 0;
            this.panelLateral.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnListBitacora
            // 
            this.btnListBitacora.BackColor = System.Drawing.Color.Black;
            this.btnListBitacora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnListBitacora.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnListBitacora.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnListBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListBitacora.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListBitacora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnListBitacora.Location = new System.Drawing.Point(9, 85);
            this.btnListBitacora.Margin = new System.Windows.Forms.Padding(2);
            this.btnListBitacora.Name = "btnListBitacora";
            this.btnListBitacora.Size = new System.Drawing.Size(107, 50);
            this.btnListBitacora.TabIndex = 7;
            this.btnListBitacora.Text = "bitacora";
            this.btnListBitacora.UseVisualStyleBackColor = false;
            this.btnListBitacora.Click += new System.EventHandler(this.btnListBitacora_Click);
            // 
            // btnRegistrarUsuario
            // 
            this.btnRegistrarUsuario.BackColor = System.Drawing.Color.Black;
            this.btnRegistrarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnRegistrarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRegistrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarUsuario.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnRegistrarUsuario.Location = new System.Drawing.Point(9, 12);
            this.btnRegistrarUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            this.btnRegistrarUsuario.Size = new System.Drawing.Size(107, 50);
            this.btnRegistrarUsuario.TabIndex = 7;
            this.btnRegistrarUsuario.Text = "Registrar Usuario";
            this.btnRegistrarUsuario.UseVisualStyleBackColor = false;
            this.btnRegistrarUsuario.Click += new System.EventHandler(this.btnRegistrarUsuario_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnCerrarSesion.Location = new System.Drawing.Point(9, 522);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(107, 50);
            this.btnCerrarSesion.TabIndex = 7;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Maroon;
            this.panelSuperior.Controls.Add(this.menuStrip1);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(135, 0);
            this.panelSuperior.Margin = new System.Windows.Forms.Padding(2);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(959, 28);
            this.panelSuperior.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Maroon;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baseDeDatosToolStripMenuItem,
            this.crearFamiliaToolStripMenuItem,
            this.asignarPermisosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // baseDeDatosToolStripMenuItem
            // 
            this.baseDeDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarBackUpToolStripMenuItem,
            this.generarRestoreToolStripMenuItem});
            this.baseDeDatosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
            this.baseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.baseDeDatosToolStripMenuItem.Text = "Base de datos";
            // 
            // generarBackUpToolStripMenuItem
            // 
            this.generarBackUpToolStripMenuItem.BackColor = System.Drawing.Color.Maroon;
            this.generarBackUpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.generarBackUpToolStripMenuItem.Name = "generarBackUpToolStripMenuItem";
            this.generarBackUpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generarBackUpToolStripMenuItem.Text = "Generar BackUp";
            this.generarBackUpToolStripMenuItem.Click += new System.EventHandler(this.generarBackUpToolStripMenuItem_Click);
            // 
            // generarRestoreToolStripMenuItem
            // 
            this.generarRestoreToolStripMenuItem.BackColor = System.Drawing.Color.Maroon;
            this.generarRestoreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.generarRestoreToolStripMenuItem.Name = "generarRestoreToolStripMenuItem";
            this.generarRestoreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generarRestoreToolStripMenuItem.Text = "Generar Restore";
            this.generarRestoreToolStripMenuItem.Click += new System.EventHandler(this.generarRestoreToolStripMenuItem_Click);
            // 
            // crearFamiliaToolStripMenuItem
            // 
            this.crearFamiliaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.crearFamiliaToolStripMenuItem.Name = "crearFamiliaToolStripMenuItem";
            this.crearFamiliaToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.crearFamiliaToolStripMenuItem.Text = "Administrar Familias";
            this.crearFamiliaToolStripMenuItem.Click += new System.EventHandler(this.crearFamiliaToolStripMenuItem_Click);
            // 
            // asignarPermisosToolStripMenuItem
            // 
            this.asignarPermisosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.asignarPermisosToolStripMenuItem.Name = "asignarPermisosToolStripMenuItem";
            this.asignarPermisosToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.asignarPermisosToolStripMenuItem.Text = "Asignar permisos";
            this.asignarPermisosToolStripMenuItem.Click += new System.EventHandler(this.asignarPermisosToolStripMenuItem_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(135, 28);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(2);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(959, 555);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1094, 583);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelLateral);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panelLateral.ResumeLayout(false);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnRegistrarUsuario;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem baseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarBackUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarRestoreToolStripMenuItem;
        private System.Windows.Forms.Button btnListBitacora;
        private System.Windows.Forms.ToolStripMenuItem crearFamiliaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarPermisosToolStripMenuItem;
    }
}