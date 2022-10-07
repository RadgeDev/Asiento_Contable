namespace _CYD_ASIENTOS_CONTABLES_2019
{
    partial class PRINCIPAL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PRINCIPAL));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recaudacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioRecaudacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colocacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioColocacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recaudacionToolStripMenuItem,
            this.colocacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // recaudacionToolStripMenuItem
            // 
            this.recaudacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioRecaudacionToolStripMenuItem});
            this.recaudacionToolStripMenuItem.Name = "recaudacionToolStripMenuItem";
            this.recaudacionToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.recaudacionToolStripMenuItem.Text = "Recaudacion";
            // 
            // formularioRecaudacionToolStripMenuItem
            // 
            this.formularioRecaudacionToolStripMenuItem.Name = "formularioRecaudacionToolStripMenuItem";
            this.formularioRecaudacionToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.formularioRecaudacionToolStripMenuItem.Text = "Formulario Recaudacion";
            this.formularioRecaudacionToolStripMenuItem.Click += new System.EventHandler(this.formularioRecaudacionToolStripMenuItem_Click);
            // 
            // colocacionesToolStripMenuItem
            // 
            this.colocacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioColocacionesToolStripMenuItem});
            this.colocacionesToolStripMenuItem.Name = "colocacionesToolStripMenuItem";
            this.colocacionesToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.colocacionesToolStripMenuItem.Text = "Colocaciones";
            // 
            // formularioColocacionesToolStripMenuItem
            // 
            this.formularioColocacionesToolStripMenuItem.Name = "formularioColocacionesToolStripMenuItem";
            this.formularioColocacionesToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.formularioColocacionesToolStripMenuItem.Text = "Formulario Colocaciones";
            this.formularioColocacionesToolStripMenuItem.Click += new System.EventHandler(this.formularioColocacionesToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(329, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(339, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1020, 634);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PRINCIPAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU RECAUDACION Y COLOCACIONES CONTABILIDAD";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem recaudacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colocacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formularioRecaudacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formularioColocacionesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}