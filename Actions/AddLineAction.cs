using System.Drawing;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public class AddLineAction : Action
    {
        private DragLine mDragLine;

        public AddLineAction(Project aProject)
            : base(aProject)
        {
        }

        public override bool OnMouseClick(ImagePanel aSender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int selected = Project.FindMarker(e.X, e.Y);
                if (selected == -1)
                {
                    CommandSystem.AddMarker(Project, e.X, e.Y);
                    selected = Project.FindMarker(e.X, e.Y);
                }

                if (mDragLine == null)
                {
                    mDragLine = new DragLine(selected, new PointF(e.X, e.Y));
                }
                else
                {
                    CommandSystem.AddLine(Project, mDragLine.StartMarker, selected);
                    mDragLine = null;
                }
                aSender.Invalidate();
                return false;
            }

            if (e.Button == MouseButtons.Right)
            {
                if (mDragLine != null)
                {
                    mDragLine = null;
                    aSender.Invalidate();
                    return false;
                }
            }

            return true;
        }

        public override bool OnMouseMove(ImagePanel aSender, MouseEventArgs e)
        {
            if (mDragLine != null)
            {
                mDragLine.EndMarker = Project.FindMarker(e.X, e.Y);
                mDragLine.MousePosition = new PointF(e.X, e.Y);
                aSender.Invalidate();
            }
            return true;
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
