using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReminderWindow4
{
    public partial class ColorOptionsForm : Form
    {
        public Color PrimaryColor { get; set; } = Color.Red;
        public Color SecondaryColor { get; set; } = Color.OrangeRed;
        public bool GradientEnabled { get; set; } = true;

        public ColorOptionsForm()
        {
            InitializeComponent();
            this.Load += ColorOptionsForm_Load;
            pnlGradientPreview.Paint += PnlGradientPreview_Paint;
        }

        private void ColorOptionsForm_Load(object sender, EventArgs e)
        {
            pnlColor1.BackColor = PrimaryColor;
            pnlColor2.BackColor = SecondaryColor;
            chkGradient.Checked = GradientEnabled;
            pnlGradientPreview.Invalidate();
        }

        private void btnColor1_Click(object sender, EventArgs e)
        {
            using (var cd = new ColorDialog())
            {
                cd.Color = PrimaryColor;
                if (cd.ShowDialog(this) == DialogResult.OK)
                {
                    PrimaryColor = cd.Color;
                    pnlColor1.BackColor = PrimaryColor;
                    pnlGradientPreview.Invalidate();
                }
            }
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            using (var cd = new ColorDialog())
            {
                cd.Color = SecondaryColor;
                if (cd.ShowDialog(this) == DialogResult.OK)
                {
                    SecondaryColor = cd.Color;
                    pnlColor2.BackColor = SecondaryColor;
                    pnlGradientPreview.Invalidate();
                }
            }
        }

        private void chkGradient_CheckedChanged(object sender, EventArgs e)
        {
            GradientEnabled = chkGradient.Checked;
            pnlGradientPreview.Invalidate();
        }

        private void PnlGradientPreview_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = pnlGradientPreview.ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            if (!GradientEnabled)
            {
                using (var b = new SolidBrush(PrimaryColor))
                    g.FillRectangle(b, rect);
                return;
            }

            using (var brush = new LinearGradientBrush(
                rect,
                PrimaryColor,
                SecondaryColor,
                LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, rect);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}