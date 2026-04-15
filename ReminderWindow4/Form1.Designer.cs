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
            this.btnToggleHotkey = new System.Windows.Forms.Button();
            this.cmbHotkey = new System.Windows.Forms.ComboBox();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnToggleHotkey
            // 
            this.btnToggleHotkey.Location = new System.Drawing.Point(238, 65);
            this.btnToggleHotkey.Name = "btnToggleHotkey";
            this.btnToggleHotkey.Size = new System.Drawing.Size(92, 46);
            this.btnToggleHotkey.TabIndex = 0;
            this.btnToggleHotkey.Text = "Enable Hotkey";
            this.btnToggleHotkey.UseVisualStyleBackColor = true;
            this.btnToggleHotkey.Click += new System.EventHandler(this.btnToggleHotkey_Click);
            // 
            // cmbHotkey
            // 
            this.cmbHotkey.FormattingEnabled = true;
            this.cmbHotkey.Location = new System.Drawing.Point(309, 117);
            this.cmbHotkey.Name = "cmbHotkey";
            this.cmbHotkey.Size = new System.Drawing.Size(153, 21);
            this.cmbHotkey.TabIndex = 1;
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(364, 70);
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
            this.lblStatus.Location = new System.Drawing.Point(255, 199);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkStartWithWindows);
            this.Controls.Add(this.cmbHotkey);
            this.Controls.Add(this.btnToggleHotkey);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggleHotkey;
        private System.Windows.Forms.ComboBox cmbHotkey;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timer1;
    }
}

