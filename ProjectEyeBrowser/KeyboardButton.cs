using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ProjectEyeBrowser
{
    public partial class KeyboardButton : Button
    {
        public KeyboardButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs paintEvent)
        {
            base.OnPaint(paintEvent);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(15, 0, Width - 15, 0);
            graphicsPath.AddArc(Width - 30, 0, 30, 30, 270, 90);
            graphicsPath.AddLine(Width, 15, Width, Height - 15);
            graphicsPath.AddArc(Width - 30, Height - 30, 30, 30, 0, 90);
            graphicsPath.AddLine(Width - 15, Height, 15, Height);
            graphicsPath.AddArc(0, Height - 30, 30, 30, 90, 90);
            graphicsPath.AddLine(0, Height - 15, 0, 15);
            graphicsPath.AddArc(0, 0, 30, 30, 180, 90);
            graphicsPath.CloseFigure();
            this.Region = new Region(graphicsPath);
            paintEvent.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            using (Pen pen = new Pen(Color.Peru, 5))
            {
                pen.Alignment = PenAlignment.Outset;
                paintEvent.Graphics.DrawPath(pen, graphicsPath);
            }
        }

    }
}