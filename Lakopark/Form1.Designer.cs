namespace Lakopark
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox_Nevado = new System.Windows.Forms.PictureBox();
            this.panel_Hazak = new System.Windows.Forms.Panel();
            this.button_Novel = new System.Windows.Forms.Button();
            this.button_Csokkent = new System.Windows.Forms.Button();
            this.button_mentes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Nevado)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Nevado
            // 
            this.pictureBox_Nevado.Location = new System.Drawing.Point(13, 13);
            this.pictureBox_Nevado.Name = "pictureBox_Nevado";
            this.pictureBox_Nevado.Size = new System.Drawing.Size(142, 182);
            this.pictureBox_Nevado.TabIndex = 0;
            this.pictureBox_Nevado.TabStop = false;
            // 
            // panel_Hazak
            // 
            this.panel_Hazak.Location = new System.Drawing.Point(183, 13);
            this.panel_Hazak.Name = "panel_Hazak";
            this.panel_Hazak.Size = new System.Drawing.Size(835, 358);
            this.panel_Hazak.TabIndex = 1;
            // 
            // button_Novel
            // 
            this.button_Novel.BackgroundImage = global::Lakopark.Properties.Resources.jobbnyil;
            this.button_Novel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Novel.Location = new System.Drawing.Point(183, 401);
            this.button_Novel.Name = "button_Novel";
            this.button_Novel.Size = new System.Drawing.Size(113, 68);
            this.button_Novel.TabIndex = 2;
            this.button_Novel.UseVisualStyleBackColor = true;
            this.button_Novel.Click += new System.EventHandler(this.button_Novel_Click);
            // 
            // button_Csokkent
            // 
            this.button_Csokkent.BackgroundImage = global::Lakopark.Properties.Resources.balnyil;
            this.button_Csokkent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Csokkent.Location = new System.Drawing.Point(22, 401);
            this.button_Csokkent.Name = "button_Csokkent";
            this.button_Csokkent.Size = new System.Drawing.Size(124, 68);
            this.button_Csokkent.TabIndex = 3;
            this.button_Csokkent.UseVisualStyleBackColor = true;
            this.button_Csokkent.Click += new System.EventHandler(this.button_Csokkent_Click);
            // 
            // button_mentes
            // 
            this.button_mentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_mentes.Location = new System.Drawing.Point(343, 401);
            this.button_mentes.Name = "button_mentes";
            this.button_mentes.Size = new System.Drawing.Size(192, 68);
            this.button_mentes.TabIndex = 4;
            this.button_mentes.Text = "Adatok mentése";
            this.button_mentes.UseVisualStyleBackColor = true;
            this.button_mentes.Click += new System.EventHandler(this.button_mentes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 515);
            this.Controls.Add(this.button_mentes);
            this.Controls.Add(this.button_Csokkent);
            this.Controls.Add(this.button_Novel);
            this.Controls.Add(this.panel_Hazak);
            this.Controls.Add(this.pictureBox_Nevado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Nevado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Nevado;
        private System.Windows.Forms.Panel panel_Hazak;
        private System.Windows.Forms.Button button_Novel;
        private System.Windows.Forms.Button button_Csokkent;
        private System.Windows.Forms.Button button_mentes;
    }
}

