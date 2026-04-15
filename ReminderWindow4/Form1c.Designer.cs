namespace ReminderWindow4
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
            this.components = new System.ComponentModel.Container();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbThickness = new System.Windows.Forms.TrackBar();
            this.lblThicknessValue = new System.Windows.Forms.Label();
            this.tbFlashSpeed = new System.Windows.Forms.TrackBar();
            this.lblFlashSpeedValue = new System.Windows.Forms.Label();
            this.btnColorOptions = new System.Windows.Forms.Button();
            this.tbInnerFade = new System.Windows.Forms.TrackBar();
            this.lblInnerFadeValue = new System.Windows.Forms.Label();
            this.Titleflashspeed = new System.Windows.Forms.Label();
            this.BorderThicknessLabel = new System.Windows.Forms.Label();
            this.LabelFadeStrength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btORE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFlashSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInnerFade)).BeginInit();
            this.SuspendLayout();
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(487, 63);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.chkStartWithWindows.TabIndex = 2;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            this.chkStartWithWindows.CheckedChanged += new System.EventHandler(this.chkStartWithWindows_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(544, 253);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: Idle";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(487, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(129, 37);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start Monitoring / F5";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(487, 179);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(129, 39);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop Monitoring / F6";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbThickness
            // 
            this.tbThickness.Location = new System.Drawing.Point(152, 188);
            this.tbThickness.Maximum = 200;
            this.tbThickness.Minimum = 1;
            this.tbThickness.Name = "tbThickness";
            this.tbThickness.Size = new System.Drawing.Size(195, 45);
            this.tbThickness.TabIndex = 6;
            this.tbThickness.TickFrequency = 5;
            this.tbThickness.Value = 100;
            this.tbThickness.Scroll += new System.EventHandler(this.tbThickness_Scroll);
            // 
            // lblThicknessValue
            // 
            this.lblThicknessValue.AutoSize = true;
            this.lblThicknessValue.Location = new System.Drawing.Point(353, 205);
            this.lblThicknessValue.Name = "lblThicknessValue";
            this.lblThicknessValue.Size = new System.Drawing.Size(33, 13);
            this.lblThicknessValue.TabIndex = 7;
            this.lblThicknessValue.Text = "50 px";
            // 
            // tbFlashSpeed
            // 
            this.tbFlashSpeed.Location = new System.Drawing.Point(152, 253);
            this.tbFlashSpeed.Maximum = 2000;
            this.tbFlashSpeed.Minimum = 50;
            this.tbFlashSpeed.Name = "tbFlashSpeed";
            this.tbFlashSpeed.Size = new System.Drawing.Size(195, 45);
            this.tbFlashSpeed.TabIndex = 8;
            this.tbFlashSpeed.TickFrequency = 50;
            this.tbFlashSpeed.Value = 1000;
            this.tbFlashSpeed.Scroll += new System.EventHandler(this.tbFlashSpeed_Scroll);
            // 
            // lblFlashSpeedValue
            // 
            this.lblFlashSpeedValue.AutoSize = true;
            this.lblFlashSpeedValue.Location = new System.Drawing.Point(353, 263);
            this.lblFlashSpeedValue.Name = "lblFlashSpeedValue";
            this.lblFlashSpeedValue.Size = new System.Drawing.Size(47, 13);
            this.lblFlashSpeedValue.TabIndex = 9;
            this.lblFlashSpeedValue.Text = "1000 ms";
            // 
            // btnColorOptions
            // 
            this.btnColorOptions.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnColorOptions.Location = new System.Drawing.Point(67, 53);
            this.btnColorOptions.Name = "btnColorOptions";
            this.btnColorOptions.Size = new System.Drawing.Size(129, 34);
            this.btnColorOptions.TabIndex = 10;
            this.btnColorOptions.Text = "Select Color";
            this.btnColorOptions.UseVisualStyleBackColor = false;
            this.btnColorOptions.Click += new System.EventHandler(this.btnColorOptions_Click);
            // 
            // tbInnerFade
            // 
            this.tbInnerFade.AccessibleName = "Inner Fade";
            this.tbInnerFade.Location = new System.Drawing.Point(152, 121);
            this.tbInnerFade.Maximum = 255;
            this.tbInnerFade.Name = "tbInnerFade";
            this.tbInnerFade.Size = new System.Drawing.Size(195, 45);
            this.tbInnerFade.TabIndex = 11;
            this.tbInnerFade.TickFrequency = 10;
            this.tbInnerFade.Value = 128;
            this.tbInnerFade.Scroll += new System.EventHandler(this.tbInnerFade_Scroll);
            // 
            // lblInnerFadeValue
            // 
            this.lblInnerFadeValue.AutoSize = true;
            this.lblInnerFadeValue.Location = new System.Drawing.Point(353, 132);
            this.lblInnerFadeValue.Name = "lblInnerFadeValue";
            this.lblInnerFadeValue.Size = new System.Drawing.Size(25, 13);
            this.lblInnerFadeValue.TabIndex = 12;
            this.lblInnerFadeValue.Text = "128";
            // 
            // Titleflashspeed
            // 
            this.Titleflashspeed.AutoSize = true;
            this.Titleflashspeed.Location = new System.Drawing.Point(64, 263);
            this.Titleflashspeed.Name = "Titleflashspeed";
            this.Titleflashspeed.Size = new System.Drawing.Size(66, 13);
            this.Titleflashspeed.TabIndex = 13;
            this.Titleflashspeed.Text = "Flash Speed";
            // 
            // BorderThicknessLabel
            // 
            this.BorderThicknessLabel.AutoSize = true;
            this.BorderThicknessLabel.Location = new System.Drawing.Point(64, 205);
            this.BorderThicknessLabel.Name = "BorderThicknessLabel";
            this.BorderThicknessLabel.Size = new System.Drawing.Size(90, 13);
            this.BorderThicknessLabel.TabIndex = 14;
            this.BorderThicknessLabel.Text = "Border Thickness";
            // 
            // LabelFadeStrength
            // 
            this.LabelFadeStrength.AutoSize = true;
            this.LabelFadeStrength.Location = new System.Drawing.Point(64, 132);
            this.LabelFadeStrength.Name = "LabelFadeStrength";
            this.LabelFadeStrength.Size = new System.Drawing.Size(74, 13);
            this.LabelFadeStrength.TabIndex = 15;
            this.LabelFadeStrength.Text = "Fade Strength";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 16;
            // 
            // btORE
            // 
            this.btORE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btORE.Location = new System.Drawing.Point(67, 335);
            this.btORE.Name = "btORE";
            this.btORE.Size = new System.Drawing.Size(75, 23);
            this.btORE.TabIndex = 17;
            this.btORE.Text = "About ORE";
            this.btORE.UseVisualStyleBackColor = true;
            this.btORE.Click += new System.EventHandler(this.btORE_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(693, 394);
            this.Controls.Add(this.btORE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelFadeStrength);
            this.Controls.Add(this.BorderThicknessLabel);
            this.Controls.Add(this.Titleflashspeed);
            this.Controls.Add(this.lblInnerFadeValue);
            this.Controls.Add(this.tbInnerFade);
            this.Controls.Add(this.btnColorOptions);
            this.Controls.Add(this.lblFlashSpeedValue);
            this.Controls.Add(this.tbFlashSpeed);
            this.Controls.Add(this.lblThicknessValue);
            this.Controls.Add(this.tbThickness);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkStartWithWindows);
            this.Name = "Form1";
            this.Text = "ORE Alert V 0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFlashSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInnerFade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar tbThickness;
        private System.Windows.Forms.Label lblThicknessValue;
        private System.Windows.Forms.TrackBar tbFlashSpeed;
        private System.Windows.Forms.Label lblFlashSpeedValue;
        private System.Windows.Forms.Button btnColorOptions;
        private System.Windows.Forms.TrackBar tbInnerFade;
        private System.Windows.Forms.Label lblInnerFadeValue;
        private System.Windows.Forms.Label Titleflashspeed;
        private System.Windows.Forms.Label BorderThicknessLabel;
        private System.Windows.Forms.Label LabelFadeStrength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btORE;
    }
}

