
namespace tpDiploma
{
    partial class ABMFamilia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMFamilia));
            this.btnCrearFamilia = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.lblNombreFamiliaCrear = new System.Windows.Forms.Label();
            this.btnEliminarFamilia = new System.Windows.Forms.Button();
            this.lblFamiliaListar = new System.Windows.Forms.Label();
            this.cmbFamilias = new System.Windows.Forms.ComboBox();
            this.GrillaPatenteFamilia = new System.Windows.Forms.DataGridView();
            this.GrillaPatentesSinOtorgar = new System.Windows.Forms.DataGridView();
            this.lblPatentesDeLaFamilia = new System.Windows.Forms.Label();
            this.lblPatentesSinOtorgar = new System.Windows.Forms.Label();
            this.btnDesasignarPermiso = new System.Windows.Forms.Button();
            this.btnAsignarPermiso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPatenteFamilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPatentesSinOtorgar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearFamilia
            // 
            this.btnCrearFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnCrearFamilia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearFamilia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnCrearFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnCrearFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearFamilia.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnCrearFamilia.Location = new System.Drawing.Point(546, 115);
            this.btnCrearFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrearFamilia.Name = "btnCrearFamilia";
            this.btnCrearFamilia.Size = new System.Drawing.Size(147, 26);
            this.btnCrearFamilia.TabIndex = 7;
            this.btnCrearFamilia.Text = "CREAR FAMILIA";
            this.btnCrearFamilia.UseVisualStyleBackColor = false;
            this.btnCrearFamilia.Click += new System.EventHandler(this.btnCrearFamilia_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-8, -22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtNombreFamilia.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNombreFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtNombreFamilia.Location = new System.Drawing.Point(713, 60);
            this.txtNombreFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(154, 23);
            this.txtNombreFamilia.TabIndex = 46;
            // 
            // lblNombreFamiliaCrear
            // 
            this.lblNombreFamiliaCrear.AutoSize = true;
            this.lblNombreFamiliaCrear.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreFamiliaCrear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblNombreFamiliaCrear.Location = new System.Drawing.Point(543, 63);
            this.lblNombreFamiliaCrear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreFamiliaCrear.Name = "lblNombreFamiliaCrear";
            this.lblNombreFamiliaCrear.Size = new System.Drawing.Size(128, 16);
            this.lblNombreFamiliaCrear.TabIndex = 48;
            this.lblNombreFamiliaCrear.Text = "NOMBRE FAMILIA";
            // 
            // btnEliminarFamilia
            // 
            this.btnEliminarFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnEliminarFamilia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarFamilia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnEliminarFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnEliminarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFamilia.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnEliminarFamilia.Location = new System.Drawing.Point(720, 115);
            this.btnEliminarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarFamilia.Name = "btnEliminarFamilia";
            this.btnEliminarFamilia.Size = new System.Drawing.Size(147, 26);
            this.btnEliminarFamilia.TabIndex = 7;
            this.btnEliminarFamilia.Text = "Eliminar familia";
            this.btnEliminarFamilia.UseVisualStyleBackColor = false;
            this.btnEliminarFamilia.Click += new System.EventHandler(this.btnEliminarFamilia_Click);
            // 
            // lblFamiliaListar
            // 
            this.lblFamiliaListar.AutoSize = true;
            this.lblFamiliaListar.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamiliaListar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblFamiliaListar.Location = new System.Drawing.Point(135, 60);
            this.lblFamiliaListar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFamiliaListar.Name = "lblFamiliaListar";
            this.lblFamiliaListar.Size = new System.Drawing.Size(128, 16);
            this.lblFamiliaListar.TabIndex = 48;
            this.lblFamiliaListar.Text = "NOMBRE FAMILIA";
            // 
            // cmbFamilias
            // 
            this.cmbFamilias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.cmbFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFamilias.Font = new System.Drawing.Font("Arial", 10.2F);
            this.cmbFamilias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.cmbFamilias.FormattingEnabled = true;
            this.cmbFamilias.Items.AddRange(new object[] {
            "",
            "Baja",
            "Media",
            "Alta"});
            this.cmbFamilias.Location = new System.Drawing.Point(289, 57);
            this.cmbFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFamilias.Name = "cmbFamilias";
            this.cmbFamilias.Size = new System.Drawing.Size(113, 24);
            this.cmbFamilias.TabIndex = 55;
            this.cmbFamilias.SelectedIndexChanged += new System.EventHandler(this.cmbFamilias_SelectedIndexChanged);
            // 
            // GrillaPatenteFamilia
            // 
            this.GrillaPatenteFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPatenteFamilia.Location = new System.Drawing.Point(138, 224);
            this.GrillaPatenteFamilia.Name = "GrillaPatenteFamilia";
            this.GrillaPatenteFamilia.ReadOnly = true;
            this.GrillaPatenteFamilia.Size = new System.Drawing.Size(288, 222);
            this.GrillaPatenteFamilia.TabIndex = 56;
            this.GrillaPatenteFamilia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaPatenteFamilia_CellClick);
            // 
            // GrillaPatentesSinOtorgar
            // 
            this.GrillaPatentesSinOtorgar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaPatentesSinOtorgar.Location = new System.Drawing.Point(589, 224);
            this.GrillaPatentesSinOtorgar.Name = "GrillaPatentesSinOtorgar";
            this.GrillaPatentesSinOtorgar.ReadOnly = true;
            this.GrillaPatentesSinOtorgar.Size = new System.Drawing.Size(278, 222);
            this.GrillaPatentesSinOtorgar.TabIndex = 56;
            this.GrillaPatentesSinOtorgar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrillaPatentesSinOtorgar_CellClick);
            // 
            // lblPatentesDeLaFamilia
            // 
            this.lblPatentesDeLaFamilia.AutoSize = true;
            this.lblPatentesDeLaFamilia.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblPatentesDeLaFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblPatentesDeLaFamilia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPatentesDeLaFamilia.Location = new System.Drawing.Point(181, 189);
            this.lblPatentesDeLaFamilia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPatentesDeLaFamilia.Name = "lblPatentesDeLaFamilia";
            this.lblPatentesDeLaFamilia.Size = new System.Drawing.Size(180, 16);
            this.lblPatentesDeLaFamilia.TabIndex = 57;
            this.lblPatentesDeLaFamilia.Text = "patentes de la familia";
            // 
            // lblPatentesSinOtorgar
            // 
            this.lblPatentesSinOtorgar.AutoSize = true;
            this.lblPatentesSinOtorgar.Font = new System.Drawing.Font("Felix Titling", 10.2F);
            this.lblPatentesSinOtorgar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblPatentesSinOtorgar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPatentesSinOtorgar.Location = new System.Drawing.Point(640, 189);
            this.lblPatentesSinOtorgar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPatentesSinOtorgar.Name = "lblPatentesSinOtorgar";
            this.lblPatentesSinOtorgar.Size = new System.Drawing.Size(178, 16);
            this.lblPatentesSinOtorgar.TabIndex = 57;
            this.lblPatentesSinOtorgar.Text = "patentes sin otorgar";
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
            this.btnDesasignarPermiso.Location = new System.Drawing.Point(482, 264);
            this.btnDesasignarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesasignarPermiso.Name = "btnDesasignarPermiso";
            this.btnDesasignarPermiso.Size = new System.Drawing.Size(52, 45);
            this.btnDesasignarPermiso.TabIndex = 59;
            this.btnDesasignarPermiso.Text = "=>";
            this.btnDesasignarPermiso.UseVisualStyleBackColor = false;
            this.btnDesasignarPermiso.Click += new System.EventHandler(this.btnDesasignarPermiso_Click);
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
            this.btnAsignarPermiso.Location = new System.Drawing.Point(482, 347);
            this.btnAsignarPermiso.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarPermiso.Name = "btnAsignarPermiso";
            this.btnAsignarPermiso.Size = new System.Drawing.Size(52, 48);
            this.btnAsignarPermiso.TabIndex = 60;
            this.btnAsignarPermiso.Text = "<=";
            this.btnAsignarPermiso.UseVisualStyleBackColor = false;
            this.btnAsignarPermiso.Click += new System.EventHandler(this.btnAsignarPermiso_Click);
            // 
            // ABMFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1025, 540);
            this.Controls.Add(this.btnAsignarPermiso);
            this.Controls.Add(this.btnDesasignarPermiso);
            this.Controls.Add(this.lblPatentesSinOtorgar);
            this.Controls.Add(this.lblPatentesDeLaFamilia);
            this.Controls.Add(this.GrillaPatentesSinOtorgar);
            this.Controls.Add(this.GrillaPatenteFamilia);
            this.Controls.Add(this.cmbFamilias);
            this.Controls.Add(this.lblFamiliaListar);
            this.Controls.Add(this.lblNombreFamiliaCrear);
            this.Controls.Add(this.txtNombreFamilia);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEliminarFamilia);
            this.Controls.Add(this.btnCrearFamilia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "ABMFamilia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearFamilia";
            this.Load += new System.EventHandler(this.ABMFamilia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPatenteFamilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaPatentesSinOtorgar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearFamilia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label lblNombreFamiliaCrear;
        private System.Windows.Forms.Button btnEliminarFamilia;
        private System.Windows.Forms.Label lblFamiliaListar;
        private System.Windows.Forms.ComboBox cmbFamilias;
        private System.Windows.Forms.DataGridView GrillaPatenteFamilia;
        private System.Windows.Forms.DataGridView GrillaPatentesSinOtorgar;
        private System.Windows.Forms.Label lblPatentesDeLaFamilia;
        private System.Windows.Forms.Label lblPatentesSinOtorgar;
        private System.Windows.Forms.Button btnDesasignarPermiso;
        private System.Windows.Forms.Button btnAsignarPermiso;
    }
}