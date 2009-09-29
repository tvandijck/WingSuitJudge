using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WingSuitJudge
{
    class ImagePanel : UserControl
    {
        private Bitmap mBitmap = null;
        private RectangleF mBitmapRect;
        private int mZoom = 100;
        private PointF mOrigin = new PointF(0, 0);
        private Matrix mTransform = new Matrix(1, 0, 0, 1, 0, 0);
        
        private bool mMoveMode;
        private Point mMouseCursor;

        public ImagePanel()
        {
            DoubleBuffered = true;
            MoveMode = false;
        }

        public void LoadImage(string filename)
        {
            if (mBitmap != null)
            {
                mBitmap.Dispose();
                mBitmap = null;
            }

            mBitmap = new Bitmap(filename);
            mBitmapRect = new RectangleF(mBitmap.Width * -0.5f, mBitmap.Height * -0.5f, mBitmap.Width, mBitmap.Height);
            Invalidate();
        }

        public void ResetImage()
        {
            if (mBitmap != null)
            {
                mBitmap.Dispose();
                mBitmap = null;
            }
            Invalidate();
        }

        public int Zoom
        {
            get { return mZoom; }
            set 
            {
                if (mZoom != value && value >= 10)
                {
                    mZoom = value;
                    UpdateTransform();
                }
            }
        }

        public PointF Origin
        {
            get { return mOrigin; }
            set
            {
                if (mOrigin != value)
                {
                    mOrigin = value;
                    UpdateTransform();
                }
            }
        }

        public bool MoveMode
        {
            get { return mMoveMode; }
            set 
            {
                mMoveMode = value;
                Cursor = mMoveMode ? Cursors.SizeAll : Cursors.Default;
            }
        }

        public PointF ToScreen(PointF aPoint)
        {
            float dz = mZoom * 0.01f;
            float x = (aPoint.X * dz + Origin.X);
            float y = (aPoint.Y * dz + Origin.Y);
            return new PointF(x, y);
        }

        public Point ToScreen(Point aPoint)
        {
            float dz = mZoom * 0.01f;
            float x = (aPoint.X * dz + Origin.X);
            float y = (aPoint.Y * dz + Origin.Y);
            return new Point((int)x, (int)y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Transform = mTransform;
            e.Graphics.DrawLine(Pens.Black, -10000, 0, 10000, 0);
            e.Graphics.DrawLine(Pens.Black, 0, -10000, 0, 10000);

            if (mBitmap != null)
            {
                e.Graphics.DrawImage(mBitmap, mBitmapRect);
            }
            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!mMoveMode)
            {
                float dz = mZoom * 0.01f;
                float x = (e.X - Origin.X) / dz;
                float y = (e.Y - Origin.Y) / dz;

                MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, (int)x, (int)y, e.Delta);
                base.OnMouseClick(args);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mMoveMode && e.Button == MouseButtons.Left)
            {
                PointF pnt = Origin;
                pnt.X += e.X - mMouseCursor.X;
                pnt.Y += e.Y - mMouseCursor.Y;
                Origin = pnt;
            }
            else
            {
                float dz = mZoom * 0.01f;
                float x = (e.X - Origin.X) / dz;
                float y = (e.Y - Origin.Y) / dz;

                MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, (int)x, (int)y, e.Delta);
                base.OnMouseMove(args);
            }

            mMouseCursor.X = e.X;
            mMouseCursor.Y = e.Y;
        }

        private void UpdateTransform()
        {
            float dz = mZoom * 0.01f;
            mTransform = new Matrix(dz, 0, 0, dz, mOrigin.X, mOrigin.Y);
            Invalidate();
        }

    }
}
