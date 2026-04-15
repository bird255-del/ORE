

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ReminderWindow4
{
    public partial class BOverlayForm : Form
    {
        private Timer flashTimer;
        private bool visibleState = false;

        public Color PrimaryColor { get; set; } = Color.Red;
        public Color SecondaryColor { get; set; } = Color.Lime;
        public bool GradientEnabled { get; set; } = true;

        private int borderThickness = 200; 
        public int BorderThickness
        {
            get => borderThickness;
            set
            {
                borderThickness = Math.Max(1, value);
                RedrawOverlay();
            }
        }

        private int flashInterval = 500;
        public int FlashInterval
        {
            get => flashInterval;
            set
            {
                flashInterval = Math.Max(50, value);
                flashTimer.Interval = flashInterval;
            }
        }

        // Alpha at inner edge (0–255)
        private int innerFadeStrength = 128;
        public int InnerFadeStrength
        {
            get => innerFadeStrength;
            set
            {
                innerFadeStrength = Math.Max(0, Math.Min(255, value));
                RedrawOverlay();
            }
        }

        
        private Bitmap overlayBitmap;

        public BOverlayForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;

            // Full screen
            this.Bounds = Screen.PrimaryScreen.Bounds;

            flashTimer = new Timer();
            flashTimer.Interval = flashInterval;
            flashTimer.Tick += FlashTimer_Tick;
        }

        // Make this a layered window
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_LAYERED = 0x00080000;
                const int WS_EX_TRANSPARENT = 0x00000020;

                var cp = base.CreateParams;
                cp.ExStyle |= WS_EX_LAYERED | WS_EX_TRANSPARENT;
                return cp;
            }
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RedrawOverlay();
        }

        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            visibleState = !visibleState;
            RedrawOverlay();
        }

        public void StartFlashing()
        {
            if (!flashTimer.Enabled)
            {
                visibleState = true;
                flashTimer.Start();
                RedrawOverlay();

                this.TopMost = true;
                this.BringToFront();
                this.Activate();

                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
            }
        }

        public void StopFlashing()
        {
            flashTimer.Stop();
            visibleState = false;
            RedrawOverlay();
        } 
       
        //  SECTION 2 — REDRAW + LAYERED WINDOW ENGINE
       

        private void RedrawOverlay()
        {
            if (!this.IsHandleCreated)
                return;

            if (!visibleState)
            {
                // Clear the layered window (fully transparent)
                ApplyBitmapToLayer(null);
                return;
            }

            int w = this.Bounds.Width;
            int h = this.Bounds.Height;

            overlayBitmap?.Dispose();
            overlayBitmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(overlayBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                DrawFinalBorder(g, w, h);
            }

            ApplyBitmapToLayer(overlayBitmap);
        }


        private void ApplyBitmapToLayer(Bitmap bmp)
        {
            IntPtr screenDC = GetDC(IntPtr.Zero);
            IntPtr memDC = CreateCompatibleDC(screenDC);

            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                if (bmp != null)
                {
                    hBitmap = bmp.GetHbitmap(Color.FromArgb(0));
                    oldBitmap = SelectObject(memDC, hBitmap);

                    POINT topPos = new POINT(this.Left, this.Top);
                    SIZE size = new SIZE(bmp.Width, bmp.Height);
                    POINT srcPos = new POINT(0, 0);

                    BLENDFUNCTION blend = new BLENDFUNCTION
                    {
                        BlendOp = AC_SRC_OVER,
                        BlendFlags = 0,
                        SourceConstantAlpha = 255,
                        AlphaFormat = AC_SRC_ALPHA
                    };

                    UpdateLayeredWindow(
                        this.Handle,
                        screenDC,
                        ref topPos,
                        ref size,
                        memDC,
                        ref srcPos,
                        0,
                        ref blend,
                        ULW_ALPHA
                    );
                }
                else
                {
                    // Make window fully transparent
                    Bitmap empty = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    hBitmap = empty.GetHbitmap(Color.FromArgb(0));
                    oldBitmap = SelectObject(memDC, hBitmap);

                    POINT topPos = new POINT(this.Left, this.Top);
                    SIZE size = new SIZE(1, 1);
                    POINT srcPos = new POINT(0, 0);

                    BLENDFUNCTION blend = new BLENDFUNCTION
                    {
                        BlendOp = AC_SRC_OVER,
                        BlendFlags = 0,
                        SourceConstantAlpha = 0,
                        AlphaFormat = AC_SRC_ALPHA
                    };

                    UpdateLayeredWindow(
                        this.Handle,
                        screenDC,
                        ref topPos,
                        ref size,
                        memDC,
                        ref srcPos,
                        0,
                        ref blend,
                        ULW_ALPHA
                    );

                    empty.Dispose();
                }
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    SelectObject(memDC, oldBitmap);
                    DeleteObject(hBitmap);
                }

                DeleteDC(memDC);
                ReleaseDC(IntPtr.Zero, screenDC);
            }
        }
                       
        //  WINDOW MOVEMENT / RESIZE HANDLERS
       
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            RedrawOverlay();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Bounds = Screen.PrimaryScreen.Bounds;
            RedrawOverlay();
        }        
                 //  SECTION 3 — FINAL RECTANGULAR RADIAL FADE ENGINE
               
        private void DrawFinalBorder(Graphics g, int w, int h)
        {
            int t = borderThickness;

            Rectangle outer = new Rectangle(0, 0, w, h);
            Rectangle inner = new Rectangle(t, t, w - 2 * t, h - 2 * t);

           
            // 1. CREATE COLOR GRADIENT BITMAP (ONLY IF GRADIENT ENABLED)
           
            Bitmap colorBmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics cg = Graphics.FromImage(colorBmp))
            {
                cg.SmoothingMode = SmoothingMode.AntiAlias;
                cg.Clear(Color.Transparent);

                // CLIP FIRST — BEFORE DRAWING ANYTHING
                using (Region borderRegion = new Region(outer))
                {
                    borderRegion.Exclude(inner);
                    cg.SetClip(borderRegion, CombineMode.Replace);

                    if (GradientEnabled)
                    {
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            path.AddRectangle(outer);

                            using (PathGradientBrush colorBrush = new PathGradientBrush(path))
                            {
                                colorBrush.SurroundColors = new[] { PrimaryColor };
                                colorBrush.CenterColor = SecondaryColor;

                                float scaleX = (float)(w - 2 * t) / w;
                                float scaleY = (float)(h - 2 * t) / h;
                                colorBrush.FocusScales = new PointF(scaleX, scaleY);

                                cg.FillRectangle(colorBrush, outer);
                            }
                        }
                    }
                    else
                    {
                        using (SolidBrush sb = new SolidBrush(PrimaryColor))
                        {
                            cg.FillRectangle(sb, outer);
                        }
                    }

                    cg.ResetClip();
                }
            }

           
            // 2. CREATE LINEAR FADE MASK (CLIPPED TO BORDER)
            
            Bitmap fadeBmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics fg = Graphics.FromImage(fadeBmp))
            {
                fg.SmoothingMode = SmoothingMode.AntiAlias;
                fg.Clear(Color.Transparent);

                
                using (Region borderRegion = new Region(outer))
                {
                    borderRegion.Exclude(inner);
                    fg.SetClip(borderRegion, CombineMode.Replace);

                   
                    using (SolidBrush sb = new SolidBrush(Color.White))
                    {
                        fg.FillRectangle(sb, outer);
                    }

                    fg.ResetClip();
                }
            }

            
            // 3. COMBINE COLOR + TRUE LINEAR FADE (LOCKBITS)
         
            Rectangle rect = new Rectangle(0, 0, w, h);

            var cData = colorBmp.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            var fData = fadeBmp.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            var oData = overlayBitmap.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int bytes = cData.Stride * h;

            byte[] cBuf = new byte[bytes];
            byte[] fBuf = new byte[bytes];
            byte[] oBuf = new byte[bytes];

            Marshal.Copy(cData.Scan0, cBuf, 0, bytes);
            Marshal.Copy(fData.Scan0, fBuf, 0, bytes);

            // Precompute inner rectangle bounds
            int innerLeft = inner.Left;
            int innerTop = inner.Top;
            int innerRight = inner.Right;
            int innerBottom = inner.Bottom;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int i = y * cData.Stride + x * 4;

                    // If pixel is inside inner rectangle → fully transparent
                    if (x >= innerLeft && x < innerRight &&
                        y >= innerTop && y < innerBottom)
                    {
                        oBuf[i + 0] = 0;
                        oBuf[i + 1] = 0;
                        oBuf[i + 2] = 0;
                        oBuf[i + 3] = 0;
                        continue;
                    }

                    // Distance from pixel to inner edge (minimum of 4 sides)
                    int dx = 0;
                    if (x < innerLeft) dx = innerLeft - x;
                    else if (x >= innerRight) dx = x - (innerRight - 1);

                    int dy = 0;
                    if (y < innerTop) dy = innerTop - y;
                    else if (y >= innerBottom) dy = y - (innerBottom - 1);

                    int dist = Math.Min(dx, dy);

                    // Clamp distance to border thickness
                    if (dist < 0) dist = 0;
                    if (dist > t) dist = t;

                    
                    float lerp = (float)dist / t;
                    byte alpha = (byte)(innerFadeStrength + lerp * (255 - innerFadeStrength));

                    // Apply color from colorBmp
                    oBuf[i + 0] = cBuf[i + 0];
                    oBuf[i + 1] = cBuf[i + 1];
                    oBuf[i + 2] = cBuf[i + 2];
                    oBuf[i + 3] = alpha;
                }
            }

            Marshal.Copy(oBuf, 0, oData.Scan0, bytes);

            colorBmp.UnlockBits(cData);
            fadeBmp.UnlockBits(fData);
            overlayBitmap.UnlockBits(oData);

            colorBmp.Dispose();
            fadeBmp.Dispose();

            
            // 4. DRAW FINAL BORDER
           
            using (Region borderRegion = new Region(outer))
            {
                borderRegion.Exclude(inner);
                g.SetClip(borderRegion, CombineMode.Replace);
                g.DrawImage(overlayBitmap, 0, 0);
                g.ResetClip();
            }
        }


        
        //  SECTION 4 — P/INVOKE + STRUCTS + CONSTANTS
        

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool UpdateLayeredWindow(
        IntPtr hwnd,
        IntPtr hdcDst,
        ref POINT pptDst,
        ref SIZE psize,
        IntPtr hdcSrc,
        ref POINT pprSrc,
        int crKey,
        ref BLENDFUNCTION pblend,
        int dwFlags);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y) { X = x; Y = y; }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            public int cx;
            public int cy;
            public SIZE(int x, int y) { cx = x; cy = y; }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        private const int ULW_ALPHA = 0x00000002;
        private const byte AC_SRC_OVER = 0x00;
        private const byte AC_SRC_ALPHA = 0x01;
    }
}


