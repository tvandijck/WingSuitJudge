using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WingSuitJudge
{
    public class Line
    {
        public Marker Start;
        public Marker End;

        public Line(Marker start, Marker end)
        {
            Start = start;
            End = end;
        }

        public void Draw(Graphics aGraphics, bool aSelected, bool aBase, bool aError)
        {
            Pen pen = Colors.BlackPen;
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
                else
                    if (aBase)
                    {
                        pen = Colors.BasePen;
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
                return d(aX, aY, xx, yy);
            }
        }

        public float GetLength()
        {
            return d(Start.Location.X, Start.Location.Y, End.Location.X, End.Location.Y);
        }

        static float d(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
        }
    }
}
