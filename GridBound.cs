using System;
using System.Drawing;

namespace Flock
{
    public struct GridBound
    {
        public PointF Center;
        public float Size;

        public GridBound(PointF aCenter, float aSize)
        {
            Center = aCenter;
            Size = aSize;
        }

        public void Offset(float dx, float dy)
        {
            Center.X += dx;
            Center.Y += dy;
        }

        public void Draw(Graphics aGraphics)
        {
            float s = Size * 0.27f;
            aGraphics.DrawRectangle(Pens.Purple, Center.X - s, Center.Y - s, s * 2, s * 2);
            aGraphics.DrawEllipse(Pens.Purple, Center.X - 10, Center.Y - 10, 20, 20);
            aGraphics.DrawEllipse(Pens.Purple, Center.X - (Size * 0.5f), Center.Y - (Size * 0.5f), Size, Size);
        }
    }
}
