using Microsoft.Win32;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ReminderWindow4
{
    public partial class Form1 : Form
    {
        private BOverlayForm borderOverlay;
        private bool monitoring = false;

        // Hotkey API
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Window detection API
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkStartWithWindows.Checked = IsStartupEnabled();

            borderOverlay = new BOverlayForm();
            borderOverlay.Show();

            // Initialize slider labels
            lblThicknessValue.Text = tbThickness.Value + " px";
            lblFlashSpeedValue.Text = tbFlashSpeed.Value + " ms";
            lblInnerFadeValue.Text = tbInnerFade.Value.ToString();


            // Apply initial slider values
            borderOverlay.BorderThickness = tbThickness.Value;
            borderOverlay.FlashInterval = tbFlashSpeed.Value;
            borderOverlay.InnerFadeStrength = tbInnerFade.Value;
            

            // Register F5/F6 hotkeys
            RegisterHotKey(this.Handle, 1, 0, (int)Keys.F5);
            RegisterHotKey(this.Handle, 2, 0, (int)Keys.F6);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();

                if (id == 1) // F5
                    btnStart_Click(null, null);

                if (id == 2) // F6
                    btnStop_Click(null, null);
            }

            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!monitoring)
                return;

            if (IsReminderWindowOpen())
            {
                lblStatus.Text = "Status: Reminder Detected";
                FlashScreen();
            }
            else
            {
                borderOverlay.StopFlashing();
            }
        }

        private void FlashScreen()
        {
            borderOverlay.StartFlashing();
        }

        private static bool IsReminderWindowOpen()
        {
            bool found = false;

            EnumWindows((hWnd, lParam) =>
            {
                StringBuilder sb = new StringBuilder(256);
                GetWindowText(hWnd, sb, sb.Capacity);

                string title = sb.ToString();

                if (string.IsNullOrWhiteSpace(title))
                    return true;

                if (title.IndexOf("Outlook Reminder Extraordinaire", StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;

                if (title.IndexOf("ReminderWindow4.exe", StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;

                // Outlook Reminder window (ANY count, ANY version, love input on how to improve detection)
                if (title.IndexOf("reminder", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    found = true;
                    return false;
                }

                return true;

            }, IntPtr.Zero);

            return found;
        }


        private bool IsStartupEnabled()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                return key.GetValue("ReminderWatcher") != null;
            }
        }

        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (chkStartWithWindows.Checked)
                    key.SetValue("ReminderWatcher", Application.ExecutablePath);
                else
                    key.DeleteValue("ReminderWatcher", false);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            monitoring = true;
            timer1.Start();
            lblStatus.Text = "Status: Running";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            monitoring = false;
            timer1.Stop();
            borderOverlay.StopFlashing();
            lblStatus.Text = "Status: Stopped";
        }

        // Slider: Border Thickness
        private void tbThickness_Scroll(object sender, EventArgs e)
        {
            lblThicknessValue.Text = tbThickness.Value + " px";
            borderOverlay.BorderThickness = tbThickness.Value;
        }

        // Slider: Flash Speed
        private void tbFlashSpeed_Scroll(object sender, EventArgs e)
        {
            lblFlashSpeedValue.Text = tbFlashSpeed.Value + " ms";
            borderOverlay.FlashInterval = tbFlashSpeed.Value;
        }

        // Slider: Inner Fade Strength
        private void tbInnerFade_Scroll(object sender, EventArgs e)
        {
            lblInnerFadeValue.Text = tbInnerFade.Value.ToString();
            borderOverlay.InnerFadeStrength = tbInnerFade.Value;
        }

        // Color Options Button
        private void btnColorOptions_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorOptionsForm())
            {
                dlg.PrimaryColor = borderOverlay.PrimaryColor;
                dlg.SecondaryColor = borderOverlay.SecondaryColor;
                dlg.GradientEnabled = borderOverlay.GradientEnabled;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    borderOverlay.PrimaryColor = dlg.PrimaryColor;
                    borderOverlay.SecondaryColor = dlg.SecondaryColor;
                    borderOverlay.GradientEnabled = dlg.GradientEnabled;
                    borderOverlay.GetType(); 

                    typeof(BOverlayForm)
                        .GetMethod("RedrawOverlay", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.Invoke(borderOverlay, null);
                }
            }
        }

        // Slider: Fade Thickness 
        private void tbFadeThickness_Scroll(object sender, EventArgs e)
        {
                       
        }

        private void btORE_Click(object sender, EventArgs e)
        {
            AboutORE aboutWindow = new AboutORE();
            aboutWindow.Show();   

        }
    }
}

