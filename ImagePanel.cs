using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Flock
{
    public class ImagePanel : UserControl
    {
        private Bitmap mBitmap = null;
        private RectangleF mBitmapRect;
        private float mZoom = 100;
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
                Invalidate();
            }
        }

        public void InvertImage()
        {
            if (mBitmap != null)
            {
                Bitmap dest = new Bitmap(mBitmap.Width, mBitmap.Height, mBitmap.PixelFormat);
                using (Graphics gfx = Graphics.FromImage(dest))
                {
                    float[][] colorMatrixElements = 
                        { 
                            new float[] {-1,   0,   0,  0,  0},
                            new float[] { 0,  -1,   0,  0,  0},
                            new float[] { 0,   0,  -1,  0,  0},
                            new float[] { 0,   0,   0,  1,  0},
                            new float[] { 1,   1,   1,  0,  1}
                        };

                    ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    gfx.DrawImage(mBitmap, new Rectangle(0, 0, mBitmap.Width, mBitmap.Height),
                        0, 0, mBitmap.Width, mBitmap.Height, GraphicsUnit.Pixel, imageAttributes);
                }
                mBitmap.Dispose();
                mBitmap = dest;
                Invalidate();
            }
        }

        public Bitmap CloneBitmap()
        {
            if (mBitmap != null)
            {
                return (Bitmap)mBitmap.Clone();
            }
            return null;
        }

        public float Zoom
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
            base.OnPaint(e);
        } 

        public void DrawBitmap(Graphics aGraphics)
        {
            if (mBitmap != null)
            {
                aGraphics.DrawImage(mBitmap, mBitmapRect);
            }
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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            float dz = mZoom * 0.01f;
            float x = (e.X - Origin.X) / dz;
            float y = (e.Y - Origin.Y) / dz;

            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, (int)x, (int)y, e.Delta);
            base.OnMouseDown(args);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            float dz = mZoom * 0.01f;
            float x = (e.X - Origin.X) / dz;
            float y = (e.Y - Origin.Y) / dz;

            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, (int)x, (int)y, e.Delta);
            base.OnMouseUp(args);
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
