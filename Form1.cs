using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public partial class Form1 : Form
    {
        private enum EditMode
        {
            MoveImage,
            AddMarker,
            RemoveMarker,
            MoveMarker,
            AddLine,
            RemoveLine
        }

        private List<PointF> mAnchors = new List<PointF>();
        private List<Delaunay.Triangle> mTriangles = null;
        private int mSelected = -1;
        private EditMode mEditMode;

        public Form1()
        {
            InitializeComponent();
            EditorMode = EditMode.AddMarker;
            mPictureBox.Origin = new PointF(mPictureBox.Width * 0.5f, mPictureBox.Height * 0.5f);
            mPictureBox.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
        }

        private EditMode EditorMode
        {
            get { return mEditMode; }
            set
            {
                mEditMode = value;
                btnMoveImage.Checked = mEditMode == EditMode.MoveImage;
                btnAddMarker.Checked = mEditMode == EditMode.AddMarker;
                btnRemoveMarker.Checked = mEditMode == EditMode.RemoveMarker;
                btnAddLine.Checked = mEditMode == EditMode.AddLine;
                btnRemoveLine.Checked = mEditMode == EditMode.RemoveLine;
                mPictureBox.MoveMode = mEditMode == EditMode.MoveImage;
            }
        }

        #region -- PictureBox Events ------------------------------------------

        private void OnPictureBoxMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (EditorMode)
                {
                    case EditMode.AddMarker:
                        if (mSelected == -1)
                        {
                            mAnchors.Add(new PointF(e.X, e.Y));
                            mTriangles = Delaunay.Triangulate(mAnchors);
                            mPictureBox.Invalidate();
                        }
                        break;
                    case EditMode.RemoveMarker:
                        if (mSelected != -1)
                        {
                            mAnchors.RemoveAt(mSelected);
                            mTriangles = Delaunay.Triangulate(mAnchors);
                            mPictureBox.Invalidate();
                        }
                        break;
                }
            }
        }

        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                SetZoom(mPictureBox.Zoom + 5);
            }
            else
            {
                SetZoom(mPictureBox.Zoom - 5);
            }
        }

        private void OnPictureBoxPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (mTriangles != null)
            {
                foreach (Delaunay.Triangle tri in mTriangles)
                {
                    PointF[] points = new PointF[] { mAnchors[tri.A], mAnchors[tri.B], mAnchors[tri.C] };
                    e.Graphics.DrawPolygon(new Pen(Color.Black, 3), points);
                }
            }
            
            int num = mAnchors.Count;
            for (int i = 0; i < num; i++)
            {
                Brush fillColor = Brushes.DarkRed;
                if (i == 0)
                {
                    fillColor = Brushes.DarkGreen;
                }

                PointF pnt = mAnchors[i];
                if (i == mSelected)
                {
                    e.Graphics.FillEllipse(fillColor, pnt.X - 8, pnt.Y - 8, 16, 16);
                    e.Graphics.DrawEllipse(new Pen(Color.Yellow, 3), pnt.X - 8, pnt.Y - 8, 16, 16);
                }
                else
                {
                    e.Graphics.FillEllipse(fillColor, pnt.X - 8, pnt.Y - 8, 16, 16);
                    e.Graphics.DrawEllipse(new Pen(Color.Black, 3), pnt.X - 8, pnt.Y - 8, 16, 16);
                }
            }
        }

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && EditorMode == EditMode.MoveMarker && mSelected != -1)
            {
                mAnchors[mSelected] = new PointF(e.X, e.Y);
                mTriangles = Delaunay.Triangulate(mAnchors);
                mPictureBox.Invalidate();
            }
            else
            {
                int num = mAnchors.Count;
                int selected = -1;
                for (int i = 0; i < num; i++)
                {
                    float dx = e.X - mAnchors[i].X;
                    float dy = e.Y - mAnchors[i].Y;
                    if (dx * dx + dy * dy < 16 * 16)
                    {
                        selected = i;
                    }
                }
                if (selected != mSelected)
                {
                    mSelected = selected;
                    mPictureBox.Invalidate();
                }
            }
        }

        #endregion

        #region -- Form Events ------------------------------------------------

        private void OnFileOpenClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Image File";
            dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ShowHelp = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mPictureBox.LoadImage(dialog.FileName);
            }
        }

        private void OnZoomInClick(object sender, EventArgs e)
        {
            SetZoom(mPictureBox.Zoom + 10);
        }

        private void OnZoomOutClick(object sender, EventArgs e)
        {
            SetZoom(mPictureBox.Zoom - 10);
        }

        private void OnAddMarkerClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.AddMarker;
        }

        private void OnRemoveMarkerClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.RemoveMarker;
        }

        private void OnMoveMarkerClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.MoveMarker;
        }

        private void OnAddLineClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.AddLine;
        }

        private void OnRemoveLineClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.RemoveLine;
        }

        private void OnMoveImageClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.MoveImage;
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void SetZoom(int aZoom)
        {
            mPictureBox.Zoom = aZoom;
            mZoomText.Text = string.Format("Zoom: {0}%", mPictureBox.Zoom);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }
    }
}
