
namespace tpDiploma
{
    partial class BackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUp));
            this.txtRutaBackUp = new System.Windows.Forms.TextBox();
            this.lblRutaBackUp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnPathBackUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRutaBackUp
            // 
            this.txtRutaBackUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.txtRutaBackUp.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtRutaBackUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.txtRutaBackUp.Location = new System.Drawing.Point(294, 72);
            this.txtRutaBackUp.Margin = new System.Windows.Forms.Padding(2);
            this.txtRutaBackUp.Name = "txtRutaBackUp";
            this.txtRutaBackUp.Size = new System.Drawing.Size(296, 23);
            this.txtRutaBackUp.TabIndex = 47;
            // 
            // lblRutaBackUp
            // 
            this.lblRutaBackUp.AutoSize = true;
            this.lblRutaBackUp.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaBackUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.lblRutaBackUp.Location = new System.Drawing.Point(124, 75);
            this.lblRutaBackUp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRutaBackUp.Name = "lblRutaBackUp";
            this.lblRutaBackUp.Size = new System.Drawing.Size(128, 16);
            this.lblRutaBackUp.TabIndex = 49;
            this.lblRutaBackUp.Text = "NOMBRE FAMILIA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-6, -24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // btnBackUp
            // 
            this.btnBackUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnBackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnBackUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackUp.Font = new System.Drawing.Font("Felix Titling", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnBackUp.Location = new System.Drawing.Point(679, 64);
            this.btnBackUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(121, 39);
            this.btnBackUp.TabIndex = 51;
            this.btnBackUp.Text = "Back Up";
            this.btnBackUp.UseVisualStyleBackColor = false;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // btnPathBackUp
            // 
            this.btnPathBackUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.btnPathBackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPathBackUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnPathBackUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnPathBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPathBackUp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnPathBackUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(154)))), ((int)(((byte)(79)))));
            this.btnPathBackUp.Location = new System.Drawing.Point(613, 67);
            this.btnPathBackUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnPathBackUp.Name = "btnPathBackUp";
            this.btnPathBackUp.Size = new System.Drawing.Size(37, 33);
            this.btnPathBackUp.TabIndex = 51;
            this.btnPathBackUp.Text = "...";
            this.btnPathBackUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPathBackUp.UseVisualStyleBackColor = false;
            this.btnPathBackUp.Click += new System.EventHandler(this.btnPathBackUp_Click);
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(830, 154);
            this.Controls.Add(this.btnPathBackUp);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRutaBackUp);
            this.Controls.Add(this.txtRutaBackUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackUpRestore";
            this.Load += new System.EventHandler(this.BackUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRutaBackUp;
        private System.Windows.Forms.Label lblRutaBackUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnPathBackUp;
    }
}