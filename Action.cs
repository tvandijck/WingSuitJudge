using System.Drawing;
using System.Windows.Forms;

namespace Flock
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

        public virtual bool OnMouseDown(ImagePanel aSender, MouseEventArgs e)
        {
            return true;
        }

        public virtual bool OnMouseUp(ImagePanel aSender, MouseEventArgs e)
        {
            return true;
        }

        public virtual bool OnMouseClick(ImagePanel aSender, MouseEventArgs e)
        {
            return true;
        }

        public virtual bool OnMouseMove(ImagePanel aSender, MouseEventArgs e)
        {
            return true;
        }

        public virtual void OnPaint(Graphics aGraphics)
        {
        }
    }
}
