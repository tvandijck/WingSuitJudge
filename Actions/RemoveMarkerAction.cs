using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WingSuitJudge
{
    public class RemoveMarkerAction : Action
    {
        public RemoveMarkerAction(Project aProject)
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
                    Project.RemoveMarker(selected);
                    return true;
                }
            }
            return false;
        }

        public override bool OnMouseMove(MouseEventArgs e)
        {
            return false;
        }

        public override void OnPaint(Graphics aGraphics)
        {
        }
    }
}
