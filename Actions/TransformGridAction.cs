using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flock
{
    public class TransformGridAction : Action
    {
        private enum Mode
        {
            None,
            MoveCenter,
            MoveTop,
            MoveBottom,
            MoveRight,
            MoveLeft,
            MoveTopLeft,
            MoveTopRight,
            MoveBottomLeft,
            MoveBottomRight,
            Rotate
        }

        const int minSize = 100;

        private GridBound mBounds;
        private Point mMousePosition;
        private Mode mMode = Mode.None;

        public TransformGridAction(Project aProject)
            : base(aProject)
        {
            mBounds = new GridBound(Project.GridOffset, Project.GridSize);
        }

        public override bool OnMouseDown(ImagePanel aSender, MouseEventArgs e)
        {
            GetCursor(e.X, e.Y, out mMode);
            if (e.Button == MouseButtons.Left)
            {
                if (mMode != Mode.None)
                {
                    CommandSystem.AddRollback(Project);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                switch (mMode)
                {
                    case Mode.Rotate:
                        Project.GridRotate = 0;
                        aSender.Invalidate();
                        break;
                }

                mMode = Mode.None;
            }

            mMousePosition.X = e.X;
            mMousePosition.Y = e.Y;

            return true;
        }

        public override bool OnMouseUp(ImagePanel aSender, MouseEventArgs e)
        {
            if (mMode != Mode.None)
            {
                mMode = Mode.None;
                mBounds = new GridBound(Project.GridOffset, Project.GridSize);
                aSender.Invalidate();
            }
            return true;
        }

        public override bool OnMouseMove(ImagePanel aSender, MouseEventArgs e)
        {
            if (mMode != Mode.None)
            {
                int dx = e.X - mMousePosition.X;
                int dy = e.Y - mMousePosition.Y;

                switch (mMode)
                {
                    case Mode.MoveCenter:
                        mBounds.Offset(dx, dy);
                        Project.MoveGrid(dx, dy);
                        break;
                    case Mode.Rotate:
                        Project.RotateGrid(dy * 0.005f);
                        break;
                    case Mode.MoveLeft:
                    case Mode.MoveRight:
                        mBounds.Size -= (dx * 3);
                        Project.GridSize = Math.Max(minSize, (int)mBounds.Size);
                        mBounds.Size = Project.GridSize;
                        break;
                    case Mode.MoveTop:
                    case Mode.MoveBottom:
                        mBounds.Size -= (dy * 3);
                        Project.GridSize = Math.Max(minSize, (int)mBounds.Size);
                        mBounds.Size = Project.GridSize;
                        break;
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
            mBounds.Draw(aGraphics);
        }

        private Cursor GetCursor(int x, int y, out Mode mode)
        {
            // center.
            float distance = Math2.Distance(x, y, mBounds.Center.X, mBounds.Center.Y);
            if (distance < 15)
            {
                mode = Mode.MoveCenter;
                return Cursors.SizeAll;
            }

            float r = mBounds.Size * 0.5f;
            if (distance > (r - 5) && distance < (r + 5))
            {
                mode = Mode.Rotate;
                return Colors.RotateCursor;
            }

            float s = mBounds.Size * 0.27f;
            float left = mBounds.Center.X - s;
            float right = mBounds.Center.X + s;
            float top = mBounds.Center.Y - s;
            float bottom = mBounds.Center.Y + s;

            // corners.
            if (Math2.Distance(x, y, left, top) < 8)
            {
                mode = Mode.MoveTopLeft;
                return Cursors.SizeNWSE;
            }
            if (Math2.Distance(x, y, right, bottom) < 8)
            {
                mode = Mode.MoveBottomRight;
                return Cursors.SizeNWSE;
            }
            if (Math2.Distance(x, y, left, bottom) < 8)
            {
                mode = Mode.MoveBottomLeft;
                return Cursors.SizeNESW;
            }
            if (Math2.Distance(x, y, right, top) < 8)
            {
                mode = Mode.MoveTopRight;
                return Cursors.SizeNESW;
            }

            // edges.
            if (x > left && x < right)
            {
                if (Math.Abs(y - top) < 3)
                {
                    mode = Mode.MoveTop;
                    return Cursors.SizeNS;
                }
                if (Math.Abs(y - bottom) < 3)
                {
                    mode = Mode.MoveBottom;
                    return Cursors.SizeNS;
                }
            }

            if (y > top && y < bottom)
            {
                if (Math.Abs(x - left) < 3)
                {
                    mode = Mode.MoveLeft;
                    return Cursors.SizeWE;
                }
                if (Math.Abs(x - right) < 3)
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
