
namespace Trendyol_Api
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.btnDowland = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(24, 13);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(457, 23);
            this.prgBar.TabIndex = 0;
            // 
            // btnDowland
            // 
            this.btnDowland.BackColor = System.Drawing.Color.OliveDrab;
            this.btnDowland.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDowland.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.btnDowland.Location = new System.Drawing.Point(374, 42);
            this.btnDowland.Name = "btnDowland";
            this.btnDowland.Size = new System.Drawing.Size(107, 35);
            this.btnDowland.TabIndex = 1;
            this.btnDowland.Text = "Dowland";
            this.btnDowland.UseVisualStyleBackColor = false;
            this.btnDowland.Click += new System.EventHandler(this.btnDowland_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 89);
            this.Controls.Add(this.btnDowland);
            this.Controls.Add(this.prgBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Button btnDowland;
    }
}

