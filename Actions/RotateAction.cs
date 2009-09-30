using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WingSuitJudge
{
    public class RotateAction : Action
    {
        RectangleF mBounds;

        public RotateAction(Project aProject)
            : base(aProject)
        {
            mBounds = Project.BoundingRect;
            mBounds.Inflate(15, 15);
        }

        public override bool OnMouseClick(ImagePanel aSender, MouseEventArgs e)
        {
            return true;
        }

        public override bool OnMouseMove(ImagePanel aSender, MouseEventArgs e)
        {
            return false;
        }

        public override void OnPaint(Graphics aGraphics)
        {
            float cx = (mBounds.Left + mBounds.Right) * 0.5f;
            float cy = (mBounds.Top + mBounds.Bottom) * 0.5f;
            aGraphics.DrawRectangle(Pens.Purple, mBounds.X, mBounds.Y, mBounds.Width, mBounds.Height);
            aGraphics.DrawRectangle(Pens.Purple, mBounds.Left - 5, mBounds.Top - 5, 10, 10);
            aGraphics.DrawRectangle(Pens.Purple, mBounds.Left - 5, mBounds.Bottom - 5, 10, 10);
            aGraphics.DrawRectangle(Pens.Purple, mBounds.Right - 5, mBounds.Top - 5, 10, 10);
            aGraphics.DrawRectangle(Pens.Purple, mBounds.Right - 5, mBounds.Bottom - 5, 10, 10);
            aGraphics.DrawEllipse(Pens.Purple, cx - 10, cy - 10, 20, 20);
        }
    }
}
