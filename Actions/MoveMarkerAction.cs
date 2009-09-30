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

        public override bool OnMouseClick(MouseEventArgs e)
        {
            return false;
        }

        public override bool OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Marker marker = Project.GetMarker(mSelected);
                marker.Location = new PointF(e.X, e.Y);
                return true;
            }
            else
            {
                mSelected = Project.FindMarker(e.X, e.Y);
            }
            return false;
        }

        public override void OnPaint(Graphics aGraphics)
        {
        }
    }
}
