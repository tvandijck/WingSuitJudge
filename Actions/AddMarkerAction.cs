using System.Windows.Forms;

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
                    CommandSystem.AddMarker(Project, e.X, e.Y);
                }
                else
                {
                    CommandSystem.MarkerToggleFlightZone(Project, selected);
                }
                aSender.Invalidate();
                return false;
            }
            return true;
        }
    }
}
