using System.Drawing;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public abstract class Action
    {
        private Project mProject;

        protected Action(Project aProject)
        {
            mProject = aProject;
        }

        public Project Project
        {
            get { return mProject; }
        }

        public abstract bool OnMouseClick(MouseEventArgs e);
        public abstract bool OnMouseMove(MouseEventArgs e);
        public abstract void OnPaint(Graphics aGraphics);
    }
}
