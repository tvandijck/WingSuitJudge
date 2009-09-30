using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WingSuitJudge
{
    public class AddLineAction : Action
    {
        private DragLine mDragLine;

        public AddLineAction(Project aProject)
            : base(aProject)
        {
        }

        public override bool OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int selected = Project.FindMarker(e.X, e.Y);
                if (selected != -1)
                {
                    if (mDragLine == null)
                    {
                        mDragLine = new DragLine(selected, new PointF(e.X, e.Y));
                    }
                    else
                    {
                        Project.AddLine(mDragLine.StartMarker, selected);
                        mDragLine = null;
                    }
                    return true;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (mDragLine != null)
                {
                    mDragLine = null;
                    return true;
                }
            }

            return false;
        }

        public override bool OnMouseMove(MouseEventArgs e)
        {
            if (mDragLine != null)
            {
                mDragLine.EndMarker = Project.FindMarker(e.X, e.Y);
                mDragLine.MousePosition = new PointF(e.X, e.Y);
                return true;
            }
            return false;
        }

        public override void OnPaint(Graphics aGraphics)
        {
            if (mDragLine != null)
            {
                Marker start = Project.GetMarker(mDragLine.StartMarker);
                if (mDragLine.EndMarker != -1)
                {
                    Marker end = Project.GetMarker(mDragLine.EndMarker);
                    aGraphics.DrawLine(Colors.DashedBlack, start.Location, end.Location);
                }
                else
                {
                    aGraphics.DrawLine(Colors.DashedBlack, start.Location, mDragLine.MousePosition);
                }
            }
        }

        private class DragLine
        {
            public int StartMarker;
            public int EndMarker;
            public PointF MousePosition;

            public DragLine(int aMarker, PointF aMousePosition)
            {
                StartMarker = aMarker;
                EndMarker = -1;
                MousePosition = aMousePosition;
            }
        }
    }
}
