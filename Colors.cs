using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace WingSuitJudge
{
    static class Colors
    {
        public static Pen BlackPen = new Pen(Color.Black, 3);
        public static Pen SelectedPen = new Pen(Color.Yellow, 3);
        public static Pen BasePen = new Pen(Settings.Default.BaseLineColor, 5);
        public static Pen ErrorPen = new Pen(Color.Red, 5);
        
        public static Pen FlightZonePen = new Pen(Color.Silver, 1);
        public static Brush FlightZoneBrush = new SolidBrush(Color.FromArgb(unchecked((int)0x4000c000)));

        public static Brush MarkerNormal = new SolidBrush(Color.FromArgb(unchecked((int)0x80800000)));
        public static Brush MarkerBase = new SolidBrush(Color.FromArgb(unchecked((int)0x80008000)));

        public static Pen DashedBlack = new Pen(Color.Black, 3);

        public static Cursor RotateCursor = new Cursor(new MemoryStream(Properties.Resources.rotate_cursor));

        static Colors()
        {
            DashedBlack.DashStyle = DashStyle.Dash;
        }
    }
}
