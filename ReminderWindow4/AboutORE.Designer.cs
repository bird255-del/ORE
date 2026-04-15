namespace ReminderWindow4
{
    partial class AboutORE
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
            this.tbAboutORE = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbAboutORE
            // 
            this.tbAboutORE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAboutORE.Location = new System.Drawing.Point(54, 53);
            this.tbAboutORE.Multiline = true;
            this.tbAboutORE.Name = "tbAboutORE";
            this.tbAboutORE.ReadOnly = true;
            this.tbAboutORE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAboutORE.Size = new System.Drawing.Size(508, 293);
            this.tbAboutORE.TabIndex = 0;
            // 
            // AboutORE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 450);
            this.Controls.Add(this.tbAboutORE);
            this.Name = "AboutORE";
            this.Text = "AboutORE";
            this.Load += new System.EventHandler(this.AboutORE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAboutORE;
    }
}