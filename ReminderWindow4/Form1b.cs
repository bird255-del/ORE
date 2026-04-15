using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ReminderWindow4
{
    public partial class Form1 : Form
    {
        // Hotkey API
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int HOTKEY_ID = 9000;
        private bool hotkeyEnabled = false;

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
            // Populate hotkey list (A–Z)
            for (int i = 65; i <= 90; i++)
                cmbHotkey.Items.Add(((Keys)i).ToString());

            cmbHotkey.SelectedIndex = 0;

            // Load startup setting
            chkStartWithWindows.Checked = IsStartupEnabled();
        }

        // Enable/Disable Hotkey
        private void btnToggleHotkey_Click(object sender, EventArgs e)
        {
            if (!hotkeyEnabled)
            {
                int key = (int)Enum.Parse(typeof(Keys), cmbHotkey.SelectedItem.ToString());
                RegisterHotKey(this.Handle, HOTKEY_ID, 0, key);

                hotkeyEnabled = true;
                btnToggleHotkey.Text = "Disable Hotkey";
                lblStatus.Text = "Status: Hotkey Enabled";
            }
            else
            {
                UnregisterHotKey(this.Handle, HOTKEY_ID);

                hotkeyEnabled = false;
                btnToggleHotkey.Text = "Enable Hotkey";
                lblStatus.Text = "Status: Hotkey Disabled";
            }
        }

        // Capture Hotkey Press
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312) // WM_HOTKEY
            {
                lblStatus.Text = "Status: Hotkey Pressed";
                FlashScreen();
            }

            base.WndProc(ref m);
        }

        // Timer loop — check for reminder window
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsReminderWindowOpen())
            {
                lblStatus.Text = "Status: Reminder Detected";
                FlashScreen();
            }
        }

        // Flash screen notification
        private async void FlashScreen()
        {
            var original = this.BackColor;
            this.BackColor = Color.Red;
            await Task.Delay(200);
            this.BackColor = original;
        }

        // Detect reminder window
        private static bool IsReminderWindowOpen()
        {
            bool found = false;

            EnumWindows((hWnd, lParam) =>
            {
                StringBuilder sb = new StringBuilder(256);
                GetWindowText(hWnd, sb, sb.Capacity);

                string title = sb.ToString();

                if (title.Length > 0)
                {
                    Console.WriteLine("Window: " + title); // TEMP DEBUG
                }

                if (title.Contains("Reminder"))
                {
                    Console.WriteLine("MATCH FOUND: " + title); // TEMP DEBUG
                    found = true;
                    return false;
                }

                return true;
            }, IntPtr.Zero);

            return found;
        }

        // Startup with Windows
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
    }
}
