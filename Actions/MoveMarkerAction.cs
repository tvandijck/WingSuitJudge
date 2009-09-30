using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WingSuitJudge
{
    public class MoveMarkerAction : Action
    {
        int mSelected = -1;

        public MoveMarkerAction(Project aProject)
            : base(aProject)
        {
        }

        public override bool OnMouseDown(ImagePanel aSender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mSelected = Project.FindMarker(e.X, e.Y);
                return false;
            }
            return true;
        }

        public override bool OnMouseUp(ImagePanel aSender, MouseEventArgs e)
        {
            mSelected = -1;
            return true;
        }

        public override bool OnMouseMove(ImagePanel aSender, MouseEventArgs e)
        {
            if (mSelected != -1 && e.Button == MouseButtons.Left)
            {
                Marker marker = Project.GetMarker(mSelected);
                marker.Location = new PointF(e.X, e.Y);
                aSender.Invalidate();
                return false;
            }
            return true;
        }

    }
}
