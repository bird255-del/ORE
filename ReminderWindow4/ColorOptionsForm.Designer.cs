namespace ReminderWindow4
{
    partial class ColorOptionsForm
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
            this.btnColor1 = new System.Windows.Forms.Button();
            this.pnlColor1 = new System.Windows.Forms.Panel();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.pnlColor2 = new System.Windows.Forms.Panel();
            this.chkGradient = new System.Windows.Forms.CheckBox();
            this.pnlGradientPreview = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnColor1
            // 
            this.btnColor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor1.Location = new System.Drawing.Point(382, 82);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(131, 23);
            this.btnColor1.TabIndex = 0;
            this.btnColor1.Text = "Select Color 1";
            this.btnColor1.UseVisualStyleBackColor = true;
            this.btnColor1.Click += new System.EventHandler(this.btnColor1_Click);
            // 
            // pnlColor1
            // 
            this.pnlColor1.Location = new System.Drawing.Point(382, 128);
            this.pnlColor1.Name = "pnlColor1";
            this.pnlColor1.Size = new System.Drawing.Size(200, 57);
            this.pnlColor1.TabIndex = 1;
            // 
            // btnColor2
            // 
            this.btnColor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor2.Location = new System.Drawing.Point(382, 206);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(131, 23);
            this.btnColor2.TabIndex = 2;
            this.btnColor2.Text = "Select Color 2";
            this.btnColor2.UseVisualStyleBackColor = true;
            this.btnColor2.Click += new System.EventHandler(this.btnColor2_Click);
            // 
            // pnlColor2
            // 
            this.pnlColor2.Location = new System.Drawing.Point(382, 263);
            this.pnlColor2.Name = "pnlColor2";
            this.pnlColor2.Size = new System.Drawing.Size(200, 59);
            this.pnlColor2.TabIndex = 3;
            // 
            // chkGradient
            // 
            this.chkGradient.AutoSize = true;
            this.chkGradient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGradient.Location = new System.Drawing.Point(87, 84);
            this.chkGradient.Name = "chkGradient";
            this.chkGradient.Size = new System.Drawing.Size(130, 21);
            this.chkGradient.TabIndex = 4;
            this.chkGradient.Text = "Enable Gradient";
            this.chkGradient.UseVisualStyleBackColor = true;
            this.chkGradient.CheckStateChanged += new System.EventHandler(this.chkGradient_CheckedChanged);
            // 
            // pnlGradientPreview
            // 
            this.pnlGradientPreview.Location = new System.Drawing.Point(87, 128);
            this.pnlGradientPreview.Name = "pnlGradientPreview";
            this.pnlGradientPreview.Size = new System.Drawing.Size(200, 57);
            this.pnlGradientPreview.TabIndex = 5;
            this.pnlGradientPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGradientPreview_Paint);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(87, 206);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(98, 41);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(87, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 41);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ColorOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.pnlGradientPreview);
            this.Controls.Add(this.chkGradient);
            this.Controls.Add(this.pnlColor2);
            this.Controls.Add(this.btnColor2);
            this.Controls.Add(this.pnlColor1);
            this.Controls.Add(this.btnColor1);
            this.Name = "ColorOptionsForm";
            this.Text = "Color Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Panel pnlColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Panel pnlColor2;
        private System.Windows.Forms.CheckBox chkGradient;
        private System.Windows.Forms.Panel pnlGradientPreview;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}