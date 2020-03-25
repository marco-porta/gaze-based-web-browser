using System.Windows.Forms;
using System.Drawing;

namespace ProjectEyeBrowser
{
    public static class Utilities
    {

        private static readonly Color ActiveBackColor = Color.Gold;
        private static readonly Color NormalBackColor = Color.LightCyan;
        private static readonly Color ActiveBorderColor = Color.Teal;
        private static readonly Color NormalBorderColor = Color.MidnightBlue;
        private static readonly Color EnabledForeColor = Color.MidnightBlue;
        private static readonly Color DisabledForeColor = Color.Gray;
        private static readonly Color DisabledBackColor = Color.Gainsboro;

        public static void ButtonPaintUpdate(Button button, bool status)
        {
            if (status)
            {
                button.BackColor = ActiveBackColor;
                button.FlatAppearance.BorderColor = ActiveBorderColor;
                button.FlatAppearance.BorderSize = 3;
            }
            else
            {
                button.BackColor = NormalBackColor;
                button.FlatAppearance.BorderColor = NormalBorderColor;
                button.FlatAppearance.BorderSize = 2;
            }
        }

        public static void EnabledButtonPaint(Button button, bool active)
        {
            if (active)
            {
                button.ForeColor = EnabledForeColor;
                button.BackColor = NormalBackColor;
            }
            else
            {
                button.ForeColor = DisabledForeColor;
                button.BackColor = DisabledBackColor;
            }
        }

        public static void ResetLinkPanel(TableLayoutPanel panel)
        {
            foreach(Label label in panel.Controls)
            {
                label.Image = null;
                label.BackColor = Color.SteelBlue;
            }
        }

        public static Image FitImage(Image image, int width, int height)
        {
            double scaleFactor = System.Math.Min((double)width / (double)image.Width, (double)height / (double)image.Height);
            Bitmap bitmap = new Bitmap(image, (int)(image.Width * scaleFactor), (int)(image.Height * scaleFactor));
            return bitmap;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButton, int dwExtraInfo);

        public static void SimulateClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(0x02 | 0x04, x, y, 0, 0);
            SetCursorPos(10, 0);
        }

        public static void SimulateSingleClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(0x02 | 0x04, x, y, 0, 0);
        }

        public static void PerformClick(Point location)
        {
            mouse_event(0x02 | 0x04, location.X, location.Y, 0, 0);
        }

    }
}