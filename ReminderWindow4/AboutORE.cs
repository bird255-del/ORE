using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ReminderWindow4
{
    public partial class AboutORE : Form
    {
        public AboutORE()
        {
            InitializeComponent();

            tbAboutORE.Text =

@"This program was created to provide a simple, customizable reminder tool for Microsoft Outlook users who want to stay organized and on top of their tasks.
When you're working on a project or have another window maximized, the Outlook Reminder window may appear behind your work, making it easy to miss important events.
This program helps ensure you never miss an Outlook reminder again.

This program is free for personal use.
I hope you find it helpful.

created by BCcustomservices

If you have questions or comments please
Contact me via email. bird255@gmail.com

One word of caution: This program looks for and detects any window with (reminder) in the title.
If you have other applications that use reminder in their window titles, they may also trigger this program. Please be aware of this when using it.

This program is not affiliated with Microsoft in any way. 
It is a third-party tool created by an independent developer. Use it at your own risk.
";

        }


        private void AboutORE_Load(object sender, EventArgs e)
        {

        }
    }
}
