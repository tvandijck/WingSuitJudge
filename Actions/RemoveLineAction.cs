using System.Windows.Forms;

namespace Flock
{
    public class RemoveLineAction : Action
    {
        public RemoveLineAction(Project aProject)
            : base(aProject)
        {
        }

        public override bool OnMouseClick(ImagePanel aSender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int selected = Project.FindLine(e.X, e.Y);
                if (selected != -1)
                {
                    CommandSystem.RemoveLine(Project, selected);
                    aSender.Invalidate();
                    return false;
                }
            }
            return true;
        }
    }
}
