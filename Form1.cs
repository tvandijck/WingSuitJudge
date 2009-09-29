using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml;
using System.IO;

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

        private class DragLine
        {
            public int StartMarker;
            public int EndMarker;
            public PointF MousePosition;

            public DragLine(int aMarker, PointF aMousePosition)
            {
                StartMarker = aMarker;
                EndMarker = -1;
                MousePosition = aMousePosition;
            }
        }

        private const float version = 1.3f;
        private Project mProject = new Project();
        private string mProjectName;

        private int mSelectedMarker = -1;
        private int mSelectedLine = -1;
        private DragLine mDragLine;
        private EditMode mEditMode;

        public Form1()
        {
            InitializeComponent();
            EditorMode = EditMode.AddMarker;
            mPictureBox.Origin = new PointF(mPictureBox.Width * 0.5f, mPictureBox.Height * 0.5f);
            mPictureBox.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
            ResetProject();
        }

        private EditMode EditorMode
        {
            get { return mEditMode; }
            set
            {
                mEditMode = value;
                mBtnMoveImage.Checked = mEditMode == EditMode.MoveImage;
                mBtnAddMarker.Checked = mEditMode == EditMode.AddMarker;
                mBtnRemoveMarker.Checked = mEditMode == EditMode.RemoveMarker;
                mBtnMoveMarker.Checked = mEditMode == EditMode.MoveMarker;
                mBtnAddLine.Checked = mEditMode == EditMode.AddLine;
                mBtnRemoveLine.Checked = mEditMode == EditMode.RemoveLine;
                mPictureBox.MoveMode = mEditMode == EditMode.MoveImage;
            }
        }

        private string ProjectName
        {
            get { return mProjectName; }
            set
            {
                mProjectName = value;
                if (string.IsNullOrEmpty(value))
                {
                    Text = string.Format("Wingsuit Flock Judging Tool v{0}", version);
                }
                else
                {
                    Text = string.Format("Wingsuit Flock Judging Tool v{0} - [{1}]", version, Path.GetFileName(value));
                }
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
                        if (mSelectedMarker == -1)
                        {
                            mProject.AddMarker(new Marker(e.X, e.Y));
                            mPictureBox.Invalidate();
                        }
                        break;

                    case EditMode.RemoveMarker:
                        mProject.RemoveMarker(mSelectedMarker);
                        mPictureBox.Invalidate();
                        break;

                    case EditMode.AddLine:
                        if (mSelectedMarker != -1)
                        {
                            if (mDragLine == null)
                            {
                                mDragLine = new DragLine(mSelectedMarker, new PointF(e.X, e.Y));
                                mPictureBox.Invalidate();
                            }
                            else
                            {
                                mProject.AddLine(mDragLine.StartMarker, mDragLine.EndMarker);
                                mDragLine = new DragLine(mSelectedMarker, new PointF(e.X, e.Y));
                                mPictureBox.Invalidate();
                            }
                        }
                        break;

                    case EditMode.RemoveLine:
                        mProject.RemoveLine(mSelectedLine);
                        mPictureBox.Invalidate();
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (mDragLine != null)
                {
                    mDragLine = null;
                    mPictureBox.Invalidate();
                }
                if (mSelectedMarker != -1)
                {
                    ContextMenu menu = new ContextMenu();
                    menu.MenuItems.Add(NewMenuItem("Mark as base", new EventHandler(OnMakeMarkerBase), mSelectedMarker));
                    menu.MenuItems.Add(NewMenuItem("Remove", new EventHandler(OnRemoveMarker), mSelectedMarker));
                    menu.MenuItems.Add("-");
                    menu.MenuItems.Add(NewMenuItem("Properties", new EventHandler(OnMarkerProperties), mSelectedMarker));
                    menu.Show(this, mPictureBox.ToScreen(new Point(e.X, e.Y)));
                }
                else if (mSelectedLine != -1)
                {
                    ContextMenu menu = new ContextMenu();
                    menu.MenuItems.Add(NewMenuItem("Mark as base", new EventHandler(OnMakeLineBase), mSelectedLine));
                    menu.MenuItems.Add("-");
                    menu.MenuItems.Add(NewMenuItem("Remove", new EventHandler(OnRemoveLine), mSelectedLine));
                    menu.Show(this, mPictureBox.ToScreen(new Point(e.X, e.Y)));
                }
            }
        }

        private void OnMarkerProperties(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            if (index != -1)
            {
                Marker marker = mProject.GetMarker(index);
                MarkerProperties props = new MarkerProperties(marker);
                if (props.ShowDialog(this) == DialogResult.OK)
                {
                    marker.NameTag = props.NameTag;
                    marker.Description = props.Description;
                    marker.ShowArea = props.ShowArea;
                    mPictureBox.Invalidate();
                }
            }
        }

        private void OnMakeMarkerBase(object sender, EventArgs e)
        {
            int marker = (int)((MenuItem)sender).Tag;
            if (marker != mProject.BaseMarker)
            {
                mProject.BaseMarker = marker;
                mPictureBox.Invalidate();
            }
        }

        private void OnMakeLineBase(object sender, EventArgs e)
        {
            int line = (int)((MenuItem)sender).Tag;
            if (line != mProject.BaseLine)
            {
                mProject.BaseLine = line;
                mPictureBox.Invalidate();
            }
        }

        private void OnRemoveMarker(object sender, EventArgs e)
        {
            int marker = (int)((MenuItem)sender).Tag;
            if (marker != -1)
            {
                mProject.RemoveMarker(marker);
                mPictureBox.Invalidate();
            }
        }

        private void OnRemoveLine(object sender, EventArgs e)
        {
            int line = (int)((MenuItem)sender).Tag;
            if (line != -1)
            {
                mProject.RemoveLine(line);
                mPictureBox.Invalidate();
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
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // draw 'new' line.
            if (mDragLine != null)
            {
                Pen pen = new Pen(Color.Black, 3);
                pen.DashStyle = DashStyle.Dash;

                Marker start = mProject.GetMarker(mDragLine.StartMarker);
                if (mDragLine.EndMarker != -1)
                {
                    Marker end = mProject.GetMarker(mDragLine.EndMarker);
                    e.Graphics.DrawLine(pen, start.Location, end.Location);
                }
                else
                {
                    e.Graphics.DrawLine(pen, start.Location, mDragLine.MousePosition);
                }
            }

            // render project.
            mProject.Paint(e.Graphics, mSelectedLine, mSelectedMarker);

            // calculate accuracy.
            int accuracy = (int)Math.Round(mProject.CalculateAccuracy() * 100);
            mAccuracy.Text = string.Format("Accuracy: {0}%", accuracy);
        }

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && EditorMode == EditMode.MoveMarker && mSelectedMarker != -1)
            {
                mProject.GetMarker(mSelectedMarker).Location = new PointF(e.X, e.Y);
                mPictureBox.Invalidate();
            }
            else
            {
                // find marker selection.
                int num = mProject.NumMarkers;
                int selected = -1;
                for (int i = 0; i < num; i++)
                {
                    float dx = e.X - mProject.GetMarker(i).Location.X;
                    float dy = e.Y - mProject.GetMarker(i).Location.Y;
                    if (dx * dx + dy * dy < 16 * 16)
                    {
                        selected = i;
                    }
                }
                if (selected != mSelectedMarker)
                {
                    mSelectedMarker = selected;
                    mSelectedLine = -1;
                    mPictureBox.Invalidate();
                }

                // find a line selection instead, but only if we are not dragging.
                if (mSelectedMarker == -1 && mDragLine == null)
                {
                    num = mProject.NumLines;
                    selected = -1;
                    for (int i = 0; i < num; i++)
                    {
                        float d = mProject.GetLine(i).GetDistance(e.X, e.Y);
                        if (d < 3)
                        {
                            selected = i;
                        }
                    }

                    if (selected != mSelectedLine)
                    {
                        mSelectedLine = selected;
                        mPictureBox.Invalidate();
                    }
                }

                // update dragline.
                if (mDragLine != null)
                {
                    mDragLine.EndMarker = mSelectedMarker;
                    mDragLine.MousePosition = new PointF(e.X, e.Y);
                    mPictureBox.Invalidate();
                }
            }
        }

        #endregion

        #region -- Form Events ------------------------------------------------

        private void OnImportImageClick(object sender, EventArgs e)
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

        private void OnAboutClick(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        private void OnNewClick(object sender, EventArgs e)
        {
            ResetProject();
        }

        private void OnSaveAsClick(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save project";
            dialog.Filter = "Flock files (*.flock)|*.flock";
            dialog.CheckPathExists = true;
            dialog.AddExtension = true;
            dialog.ShowHelp = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ProjectName = dialog.FileName;
                mProject.SaveProject(ProjectName);
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectName))
            {
                OnSaveAsClick(sender, e);
                return;
            }
            else
            {
                mProject.SaveProject(ProjectName);
            }
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open project";
            dialog.Filter = "Flock files (*.flock)|*.flock";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ShowHelp = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProjectName = dialog.FileName;
                    mProject = new Project(dialog.FileName);
                    mColorPicker.BackColor   = mProject.BackColor;
                    mPictureBox.BackColor    = mProject.BackColor;
                    mDistanceTolerance.Value = mProject.DistanceTolerance;
                }
                catch (Exception ex)
                {
                    ResetProject();
                    MessageBox.Show(this, ex.Message, "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnResetPhotoClick(object sender, EventArgs e)
        {
            mPictureBox.ResetImage();
        }

        private void OnCenterImageClick(object sender, EventArgs e)
        {
            int num = mProject.NumMarkers;
            if (num > 0)
            {
                Marker marker = mProject.GetMarker(0);
                float minX = marker.Location.X;
                float maxX = marker.Location.X;
                float minY = marker.Location.Y;
                float maxY = marker.Location.Y;

                for (int i = 1; i < num; i++)
                {
                    marker = mProject.GetMarker(i);
                    minX = Math.Min(minX, marker.Location.X);
                    maxX = Math.Max(maxX, marker.Location.X);
                    minY = Math.Min(minY, marker.Location.Y);
                    maxY = Math.Max(maxY, marker.Location.Y);
                }

                // add border.
                minX -= 10;
                minY -= 10;
                maxX += 10;
                maxY += 10;

                float width = maxX - minX;
                float height = maxY - minY;

                // calculate scale.
                float scaleX = mPictureBox.Width / width;
                float scaleY = mPictureBox.Height / height;
                float scale = Math.Min(4, Math.Min(scaleX, scaleY));
                SetZoom((int)(scale * 100));

                // calculate center.
                float x = (mPictureBox.Width * 0.5f) - ((minX + maxX) * scale * 0.5f);
                float y = (mPictureBox.Height * 0.5f) - ((minY + maxY) * scale * 0.5f);
                mPictureBox.Origin = new PointF(x, y);
            }
            else
            {
                mPictureBox.Origin = new PointF(mPictureBox.Width * 0.5f, mPictureBox.Height * 0.5f);
                SetZoom(100);
            }
        }

        private void OnColorPickerClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = mColorPicker.BackColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mProject.BackColor     = dialog.Color;
                mColorPicker.BackColor = dialog.Color;
                mPictureBox.BackColor  = dialog.Color;
            }
        }

        private void OnJumpInfoClick(object sender, EventArgs e)
        {
            JumpInfo dialog = new JumpInfo(mProject);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mProject.Description = dialog.Description;
                mProject.Date = dialog.Date;
                mProject.Place = dialog.Place;
                mProject.GlideRatio = dialog.GlideRatio;
                mProject.JumpNumber = dialog.JumpNumber;
                mProject.Fallrate = dialog.Fallrate;
            }
        }

        #endregion

        private static MenuItem NewMenuItem(string name, EventHandler handler, object tag)
        {
            MenuItem item = new MenuItem(name, handler);
            item.Tag = tag;
            return item;
        }

        private void SetZoom(int aZoom)
        {
            mPictureBox.Zoom = aZoom;
            mZoomText.Text = string.Format("Zoom: {0}%", mPictureBox.Zoom);
        }

        private void ResetProject()
        {
            ProjectName = null;
            mProject = new Project();
            mPictureBox.ResetImage();
            mDistanceTolerance.Value = mProject.DistanceTolerance;
        }

        private void mDistanceTolerance_ValueChanged(object sender, EventArgs e)
        {
            mProject.DistanceTolerance = (int)mDistanceTolerance.Value;
            mPictureBox.Invalidate();
        }
    }
}
