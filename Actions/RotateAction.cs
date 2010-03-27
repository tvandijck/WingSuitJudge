using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flock
{
    public class RotateAction : Action
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

        const int minSize = 50;

        private Bound mBounds;
        private Point mMousePosition;
        private Mode mMode = Mode.None;

        public RotateAction(Project aProject)
            : base(aProject)
        {
            mBounds = new Bound(Project.BoundingRect);
        }

        public override bool OnMouseDown(ImagePanel aSender, MouseEventArgs e)
        {
            GetCursor(e.X, e.Y, out mMode);
            if (mMode != Mode.None)
            {
                CommandSystem.AddRollback(Project);
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
                mBounds = new Bound(Project.BoundingRect);
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
                        Project.Offset(dx, dy);
                        break;
                    case Mode.Rotate:
                        Project.Rotate(mBounds.Center.X, mBounds.Center.Y, dy * 0.005f);
                        mBounds.Rotate(dy * 0.005f);
                        break;
                    case Mode.MoveLeft:
                        mBounds.X.X = Math.Max(mBounds.Center.X - e.X, minSize);
                        break;
                    case Mode.MoveRight:
                        mBounds.X.X = Math.Max(mBounds.Center.X + e.X, minSize);
                        break;
                    case Mode.MoveTop:
                        mBounds.Y.Y = Math.Max(mBounds.Center.Y - e.Y, minSize);
                        break;
                    case Mode.MoveBottom:
                        mBounds.Y.Y = Math.Max(mBounds.Center.Y + e.Y, minSize);
                        break;
                    case Mode.MoveTopLeft:
                        break;
                    case Mode.MoveTopRight:
                        break;
                    case Mode.MoveBottomLeft:
                        break;
                    case Mode.MoveBottomRight:
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

            if (distance > 40 && distance < 50)
            {
                mode = Mode.Rotate;
                return Colors.RotateCursor;
            }

            float left = mBounds.Center.X - mBounds.X.X;
            float right = mBounds.Center.X + mBounds.X.X;
            float top = mBounds.Center.Y - mBounds.Y.Y;
            float bottom = mBounds.Center.Y + mBounds.Y.Y;

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
