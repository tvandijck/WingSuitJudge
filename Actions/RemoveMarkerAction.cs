using System.Windows.Forms;

namespace WingSuitJudge
{
    public class RemoveMarkerAction : Action
    {
        public RemoveMarkerAction(Project aProject)
            : base(aProject)
        {
        }

        public override bool OnMouseClick(ImagePanel aSender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int selected = Project.FindMarker(e.X, e.Y);
                if (selected != -1)
                {
                    CommandSystem.RemoveMarker(Project, selected);
                    aSender.Invalidate();
                    return false;
                }
            }
            return true;
        }
    }
}
