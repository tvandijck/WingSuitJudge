using System;
using System.Drawing;

namespace WingSuitJudge
{
    static class Math2
    {
        public static float Distance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
        }

        public static float Length(PointF a)
        {
            return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        public static PointF Add(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        public static PointF Sub(PointF a, PointF b)
        {
            return new PointF(a.X - b.X, a.Y - b.Y);
        }

        public static float NormalizeAngle(float angle)
        {
            while (angle < -180)
                angle += 360.0f;
            while (angle > 180.0f)
                angle -= 360.0f;
            return angle;
        }
    }
}
