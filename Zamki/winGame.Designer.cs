namespace Zamki
{
    partial class winGame
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
            this.btnEvil = new System.Windows.Forms.Button();
            this.btnLaw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEvil
            // 
            this.btnEvil.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnEvil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvil.ForeColor = System.Drawing.Color.Crimson;
            this.btnEvil.Location = new System.Drawing.Point(92, 135);
            this.btnEvil.Name = "btnEvil";
            this.btnEvil.Size = new System.Drawing.Size(75, 23);
            this.btnEvil.TabIndex = 17;
            this.btnEvil.Text = "Нет! Моё!";
            this.btnEvil.UseVisualStyleBackColor = false;
            this.btnEvil.Click += new System.EventHandler(this.btnEvil_Click);
            // 
            // btnLaw
            // 
            this.btnLaw.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnLaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaw.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnLaw.Location = new System.Drawing.Point(236, 135);
            this.btnLaw.Name = "btnLaw";
            this.btnLaw.Size = new System.Drawing.Size(75, 23);
            this.btnLaw.TabIndex = 18;
            this.btnLaw.Text = "Вернуть";
            this.btnLaw.UseVisualStyleBackColor = false;
            this.btnLaw.Click += new System.EventHandler(this.btnLaw_Click);
            // 
            // winGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Zamki.Properties.Resources.winGame;
            this.ClientSize = new System.Drawing.Size(394, 178);
            this.Controls.Add(this.btnLaw);
            this.Controls.Add(this.btnEvil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "winGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "winGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEvil;
        private System.Windows.Forms.Button btnLaw;
    }
}