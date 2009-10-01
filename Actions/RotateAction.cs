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
        [Flags]
        private enum Mode
        {
            None = 0,
            MoveCenter = 1,
            MoveTop = 2,
            MoveBottom = 4,
            MoveRight = 8,
            MoveLeft = 16,
            Rotate = 32
        }

        const int minSize = 50;

        private RectangleF mBounds;
        private Point mMousePosition;
        private RectangleF mDragBounds;
        private Point mDragPosition;
        private Mode mMode = Mode.None;

        public RotateAction(Project aProject)
            : base(aProject)
        {
            mBounds = Project.BoundingRect;
            mBounds.Inflate(15, 15);
        }

        public override bool OnMouseDown(ImagePanel aSender, MouseEventArgs e)
        {
            GetCursor(e.X, e.Y, out mMode);
            mMousePosition.X = e.X;
            mMousePosition.Y = e.Y;
            mDragBounds = mBounds;
            mDragPosition = mMousePosition;
            return true;
        }

        public override bool OnMouseUp(ImagePanel aSender, MouseEventArgs e)
        {
            mMode = Mode.None;
            return true;
        }

        public override bool OnMouseMove(ImagePanel aSender, MouseEventArgs e)
        {
            if (mMode != Mode.None)
            {
                int dx = e.X - mMousePosition.X;
                int dy = e.Y - mMousePosition.Y;

                if (mMode == Mode.MoveCenter)
                {
                    mBounds.Offset(dx, dy);
                }
                else
                {
                    int tdx = e.X - mDragPosition.X;
                    int tdy = e.Y - mDragPosition.Y;

                    if ((mMode & Mode.MoveLeft) != 0)
                    {
                        mBounds.X = Math.Min(mDragBounds.X + tdx, mDragBounds.Right - minSize);
                        mBounds.Width = Math.Max(mDragBounds.Width - tdx, minSize);
                    }
                    if ((mMode & Mode.MoveRight) != 0)
                    {
                        mBounds.Width = Math.Max(mDragBounds.Width + tdx, minSize);
                    }
                    if ((mMode & Mode.MoveTop) != 0)
                    {
                        mBounds.Y = Math.Min(mDragBounds.Y + tdy, mDragBounds.Bottom - minSize);
                        mBounds.Height = Math.Max(mDragBounds.Height - tdy, minSize);
                    }
                    if ((mMode & Mode.MoveBottom) != 0)
                    {
                        mBounds.Height = Math.Max(mDragBounds.Height + tdy, minSize);
                    }
                }

                aSender.Invalidate();
            }
            else
            {
                Mode mode;
                aSender.Cursor = GetCursor(e.X, e.Y, out mode);
            }
            mMousePosition.X = e.X;
            mMousePosition.Y = e.Y;
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

        private Cursor GetCursor(int x, int y, out Mode mode)
        {
            float cx = (mBounds.Left + mBounds.Right) * 0.5f;
            float cy = (mBounds.Top + mBounds.Bottom) * 0.5f;

            // center.
            if (Math2.Distance(x, y, cx, cy) < 20)
            {
                mode = Mode.MoveCenter;
                return Cursors.SizeAll;
            }

            // corners.
            if (Math2.Distance(x, y, mBounds.Left, mBounds.Top) < 8)
            {
                mode = Mode.MoveTop | Mode.MoveLeft;
                return Cursors.SizeNWSE;
            }
            if (Math2.Distance(x, y, mBounds.Right, mBounds.Bottom) < 8)
            {
                mode = Mode.MoveBottom | Mode.MoveRight;
                return Cursors.SizeNWSE;
            }
            if (Math2.Distance(x, y, mBounds.Left, mBounds.Bottom) < 8)
            {
                mode = Mode.MoveBottom | Mode.MoveLeft;
                return Cursors.SizeNESW;
            }
            if (Math2.Distance(x, y, mBounds.Right, mBounds.Top) < 8)
            {
                mode = Mode.MoveTop | Mode.MoveRight;
                return Cursors.SizeNESW;
            }

            // edges.
            if (x > mBounds.Left && x < mBounds.Right)
            {
                if (Math.Abs(y - mBounds.Top) < 3)
                {
                    mode = Mode.MoveTop;
                    return Cursors.SizeNS;
                }
                if (Math.Abs(y - mBounds.Bottom) < 3)
                {
                    mode = Mode.MoveBottom;
                    return Cursors.SizeNS;
                }
            }

            if (y > mBounds.Top && y < mBounds.Bottom)
            {
                if (Math.Abs(x - mBounds.Left) < 3)
                {
                    mode = Mode.MoveLeft;
                    return Cursors.SizeWE;
                }
                if (Math.Abs(x - mBounds.Right) < 3)
                {
                    mode = Mode.MoveRight;
                    return Cursors.SizeWE;
                }
            }

            mode = Mode.None;
            return Cursors.Default;
        }
    }
}
