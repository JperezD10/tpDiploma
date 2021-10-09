
namespace tpDiploma
{
    partial class RestaurarCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestaurarCambio));
            this.gridCambiosUsuario = new System.Windows.Forms.DataGridView();
            this.btnRestaurarInfoUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridCambiosUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCambiosUsuario
            // 
            this.gridCambiosUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCambiosUsuario.Location = new System.Drawing.Point(124, 11);
            this.gridCambiosUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.gridCambiosUsuario.Name = "gridCambiosUsuario";
            this.gridCambiosUsuario.ReadOnly = true;
            this.gridCambiosUsuario.RowHeadersWidth = 51;
            this.gridCambiosUsuario.RowTemplate.Height = 24;
            this.gridCambiosUsuario.Size = new System.Drawing.Size(832, 312);
            this.gridCambiosUsuario.TabIndex = 64;
            this.gridCambiosUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCambiosUsuario_CellClick);
            // 
            // btnRestaurarInfoUsuario
            // 
            this.btnRestaurarInfoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnRestaurarInfoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestaurarInfoUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnRestaurarInfoUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRestaurarInfoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarInfoUsuario.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurarInfoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnRestaurarInfoUsuario.Location = new System.Drawing.Point(326, 347);
            this.btnRestaurarInfoUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurarInfoUsuario.Name = "btnRestaurarInfoUsuario";
            this.btnRestaurarInfoUsuario.Size = new System.Drawing.Size(345, 39);
            this.btnRestaurarInfoUsuario.TabIndex = 63;
            this.btnRestaurarInfoUsuario.Text = "Restore";
            this.btnRestaurarInfoUsuario.UseVisualStyleBackColor = false;
            this.btnRestaurarInfoUsuario.Click += new System.EventHandler(this.btnRestaurarInfoUsuario_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-6, -15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // RestaurarCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(967, 452);
            this.Controls.Add(this.gridCambiosUsuario);
            this.Controls.Add(this.btnRestaurarInfoUsuario);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RestaurarCambio";
            this.Text = "RestaurarCambio";
            this.Load += new System.EventHandler(this.RestaurarCambio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCambiosUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridCambiosUsuario;
        private System.Windows.Forms.Button btnRestaurarInfoUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}