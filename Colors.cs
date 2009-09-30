using System.Drawing;
using System.Drawing.Drawing2D;

namespace WingSuitJudge
{
    static class Colors
    {
        public static Pen BlackPen = new Pen(Color.Black, 3);
        public static Pen SelectedPen = new Pen(Color.Yellow, 3);
        public static Pen BasePen = new Pen(Color.Green, 3);
        public static Pen ErrorPen = new Pen(Color.Red, 5);
        public static Pen ThinGrayPen = new Pen(Color.Silver, 1);

        public static Brush MarkerNormal = new SolidBrush(Color.FromArgb(unchecked((int)0x80800000)));
        public static Brush MarkerBase = new SolidBrush(Color.FromArgb(unchecked((int)0x80008000)));

        public static Pen DashedBlack = new Pen(Color.Black, 3);

        static Colors()
        {
            DashedBlack.DashStyle = DashStyle.Dash;
        }
    }
}
