using System;
using System.Drawing;

namespace WingSuitJudge
{
    public struct Bound
    {
        public PointF Center;
        public PointF X;
        public PointF Y;

        public Bound(RectangleF aRect)
        {
            Center = PointF.Empty;
            Center.X = (aRect.Left + aRect.Right) * 0.5f;
            Center.Y = (aRect.Top + aRect.Bottom) * 0.5f;

            X = PointF.Empty;
            X.X = aRect.Width * 0.5f + 15.0f;
            X.Y = 0;

            Y = PointF.Empty;
            Y.X = 0;
            Y.Y = aRect.Height * 0.5f + 15.0f;
        }

        public void Offset(float dx, float dy)
        {
            Center.X += dx;
            Center.Y += dy;
        }

        public void Rotate(float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);

            X = new PointF(X.X * c + X.Y * s, X.X * -s + X.Y * c);
            Y = new PointF(Y.X * c + Y.Y * s, Y.X * -s + Y.Y * c);
        }

        public void Draw(Graphics aGraphics)
        {
            aGraphics.DrawLine(Pens.Purple, Center.X + X.X + Y.X, Center.Y + X.Y + Y.Y, Center.X - X.X + Y.X, Center.Y - X.Y + Y.Y);
            aGraphics.DrawLine(Pens.Purple, Center.X + X.X + Y.X, Center.Y + X.Y + Y.Y, Center.X + X.X - Y.X, Center.Y + X.Y - Y.Y);
            aGraphics.DrawLine(Pens.Purple, Center.X - X.X - Y.X, Center.Y - X.Y - Y.Y, Center.X - X.X + Y.X, Center.Y - X.Y + Y.Y);
            aGraphics.DrawLine(Pens.Purple, Center.X - X.X - Y.X, Center.Y - X.Y - Y.Y, Center.X + X.X - Y.X, Center.Y + X.Y - Y.Y);

            aGraphics.DrawEllipse(Pens.Purple, Center.X - 10, Center.Y - 10, 20, 20);
            aGraphics.DrawEllipse(Pens.Purple, Center.X - 50, Center.Y - 50, 100, 100);
        }
    }
}
