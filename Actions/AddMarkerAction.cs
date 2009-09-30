using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WingSuitJudge
{
    public class AddMarkerAction: Action
    {
        public AddMarkerAction(Project aProject)
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
                    Project.AddMarker(new Marker(e.X, e.Y));

                }
                else
                {
                    Marker marker = Project.GetMarker(selected);
                    marker.ShowArea = !marker.ShowArea;
                }
                aSender.Invalidate();
                return false;
            }
            return true;
        }
    }
}
