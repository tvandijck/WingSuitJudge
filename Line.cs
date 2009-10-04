using System;
using System.Drawing;

namespace WingSuitJudge
{
    public class Line
    {
        private static Pen LinePen = new Pen(Color.Black, 3);

        public Marker Start;
        public Marker End;
        public Color Color = Color.Black;

        public Line(Marker start, Marker end)
        {
            Start = start;
            End = end;
        }

        public void Draw(Graphics aGraphics, bool aSelected, bool aBase, bool aError)
        {
            Pen pen;
            if (aSelected)
            {
                pen = Colors.SelectedPen;
            }
            else
            {
                if (aError)
                {
                    pen = Colors.ErrorPen;
                }
                else if (aBase)
                {
                    pen = Colors.BasePen;
                }
                else
                {
                    pen = LinePen;
                    pen.Color = Color;
                }
            }
            aGraphics.DrawLine(pen, Start.Location, End.Location);
        }

        public float GetDistance(float aX, float aY)
        {
            float A = aX - Start.Location.X;
            float B = aY - Start.Location.Y;
            float C = End.Location.X - Start.Location.X;
            float D = End.Location.Y - Start.Location.Y;

            float dot = A * C + B * D;
            float len_sq = C * C + D * D;
            float param = dot / len_sq;

            if (param < 0)
            {
                return 1000;
            }
            else if (param > 1)
            {
                return 1000;
            }
            else
            {
                float xx = Start.Location.X + param * C;
                float yy = Start.Location.Y + param * D;
                return Math2.Distance(aX, aY, xx, yy);
            }
        }

        public float GetLength()
        {
            return Math2.Distance(Start.Location.X, Start.Location.Y, End.Location.X, End.Location.Y);
        }

        public float GetAngle()
        {
            return (float)(Math.Atan2(End.Location.Y - Start.Location.Y, End.Location.X - Start.Location.X) * 180 / Math.PI);
        }
    }
}
