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

        private const float version = 1.2f;
        private string mProjectName;
        private List<Marker> mMarkers = new List<Marker>();
        private List<Line> mLines = new List<Line>();
        private int mBaseMarker = 0;
        private int mBaseLine = 0;

        private int mSelectedMarker = -1;
        private int mSelectedLine = -1;
        private DragLine mDragLine;
        private EditMode mEditMode;

        public Form1()
        {
            InitializeComponent();
            ProjectName = "";
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
                if (string.IsNullOrEmpty(mProjectName))
                {
                    Text = string.Format("Wingsuit Flock Judging Tool v{0}", version);
                }
                else
                {
                    Text = string.Format("Wingsuit Flock Judging Tool v{0} - [{1}]", version, Path.GetFileName(mProjectName));
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
                            mMarkers.Add(new Marker(e.X, e.Y));
                            mPictureBox.Invalidate();
                        }
                        break;
                    case EditMode.RemoveMarker:
                        RemoveMarker(mSelectedMarker);
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
                                AddLine(mDragLine.StartMarker, mDragLine.EndMarker);
                                mDragLine = new DragLine(mSelectedMarker, new PointF(e.X, e.Y));
                                mPictureBox.Invalidate();
                            }
                        }
                        break;
                    case EditMode.RemoveLine:
                        RemoveLine(mSelectedLine);
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
            int marker = (int)((MenuItem)sender).Tag;
            if (marker != -1)
            {
                MarkerProperties props = new MarkerProperties(mMarkers[marker]);
                if (props.ShowDialog(this) == DialogResult.OK)
                {
                    mMarkers[marker].NameTag = props.NameTag;
                    mMarkers[marker].Description = props.Description;
                    mMarkers[marker].ShowArea = props.ShowArea;
                    mPictureBox.Invalidate();
                }
            }
        }

        private void OnMakeMarkerBase(object sender, EventArgs e)
        {
            int marker = (int)((MenuItem)sender).Tag;
            if (marker != mBaseMarker)
            {
                mBaseMarker = marker;
                mPictureBox.Invalidate();
            }
        }

        private void OnMakeLineBase(object sender, EventArgs e)
        {
            int line = (int)((MenuItem)sender).Tag;
            if (line != mBaseLine)
            {
                mBaseLine = line;
                mPictureBox.Invalidate();
            }
        }

        private void OnRemoveMarker(object sender, EventArgs e)
        {
            int marker = (int)((MenuItem)sender).Tag;
            RemoveMarker(marker);
        }

        private void OnRemoveLine(object sender, EventArgs e)
        {
            int line = (int)((MenuItem)sender).Tag;
            RemoveLine(line);
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

            // get line base length.
            float baseLength = 0;
            float minLength = 0;
            float maxLength = 1000;
            bool hasTolerance = false;
            if (mBaseLine >= 0 && mBaseLine < mLines.Count)
            {
                float dtol = (int)mDistanceTolerance.Value * 0.01f;
                baseLength = mLines[mBaseLine].GetLength();
                minLength = baseLength - (baseLength * dtol);
                maxLength = baseLength + (baseLength * dtol);
                hasTolerance = true;
            }

            // draw 'new' line.
            if (mDragLine != null)
            {
                Pen pen = new Pen(Color.Black, 3);
                pen.DashStyle = DashStyle.Dash;

                Marker start = mMarkers[mDragLine.StartMarker];
                if (mDragLine.EndMarker != -1)
                {
                    Marker end = mMarkers[mDragLine.EndMarker];
                    e.Graphics.DrawLine(pen, start.Location, end.Location);
                }
                else
                {
                    e.Graphics.DrawLine(pen, start.Location, mDragLine.MousePosition);
                }
            }

            // draw lines.
            int numLines = mLines.Count;
            for (int i = 0; i < numLines; i++)
            {
                Line line = mLines[i];
                float length = line.GetLength();
                bool error = (length < minLength) || (length > maxLength);
                line.Draw(e.Graphics, i == mSelectedLine, i == mBaseLine, error);
            }

            // draw tolerance areas.
            if (hasTolerance)
            {
                foreach (Marker marker in mMarkers)
                {
                    if (marker.ShowArea)
                    {
                        float x = marker.Location.X;
                        float y = marker.Location.Y;
                        e.Graphics.DrawEllipse(Colors.ThinGrayPen, x - minLength, y - minLength, minLength * 2, minLength * 2);
                        e.Graphics.DrawEllipse(Colors.ThinGrayPen, x - maxLength, y - maxLength, maxLength * 2, maxLength * 2);
                    }
                }
            }

            // draw markers.
            int numMarkers = mMarkers.Count;
            for (int i = 0; i < numMarkers; i++)
            {
                Marker marker = mMarkers[i];
                marker.Draw(e.Graphics, i == mSelectedMarker, i == mBaseMarker);
            }

            // calculate accuracy.
            mAccuracy.Text = string.Format("Accuracy: {0}%", (int)Math.Floor(CalculateAccuracy() * 100));
        }

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && EditorMode == EditMode.MoveMarker && mSelectedMarker != -1)
            {
                mMarkers[mSelectedMarker].Location = new PointF(e.X, e.Y);
                mPictureBox.Invalidate();
            }
            else
            {
                // find marker selection.
                int num = mMarkers.Count;
                int selected = -1;
                for (int i = 0; i < num; i++)
                {
                    float dx = e.X - mMarkers[i].Location.X;
                    float dy = e.Y - mMarkers[i].Location.Y;
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
                    num = mLines.Count;
                    selected = -1;
                    for (int i = 0; i < num; i++)
                    {
                        float d = mLines[i].GetDistance(e.X, e.Y);
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
            ProjectName = null;
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
                SaveProject();
            }
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectName))
            {
                OnSaveAsClick(sender, e);
                return;
            }
            SaveProject();
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
                LoadProject(dialog.FileName);
            }
        }

        private void OnResetPhotoClick(object sender, EventArgs e)
        {
            mPictureBox.ResetImage();
        }

        private void OnCenterImageClick(object sender, EventArgs e)
        {
            int num = mMarkers.Count;
            if (num > 0)
            {
                float minX = mMarkers[0].Location.X;
                float maxX = mMarkers[0].Location.X;
                float minY = mMarkers[0].Location.Y;
                float maxY = mMarkers[0].Location.Y;

                for (int i = 1; i < num; i++)
                {
                    minX = Math.Min(minX, mMarkers[i].Location.X);
                    maxX = Math.Max(maxX, mMarkers[i].Location.X);
                    minY = Math.Min(minY, mMarkers[i].Location.Y);
                    maxY = Math.Max(maxY, mMarkers[i].Location.Y);
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

        private void RemoveMarker(int aIndex)
        {
            if (aIndex != -1)
            {
                // delete lines that point to this marker.
                Marker marker = mMarkers[aIndex];
                int num = mLines.Count;
                for (int i = num - 1; i >= 0; i--)
                {
                    Line line = mLines[i];
                    if (object.ReferenceEquals(marker, line.Start) || object.ReferenceEquals(marker, line.End))
                    {
                        mLines.RemoveAt(i);
                    }
                }

                // remove marker.
                mMarkers.RemoveAt(aIndex);
                mBaseMarker = Math.Max(0, Math.Min(mBaseMarker, mMarkers.Count - 1));
                mPictureBox.Invalidate();
            }
        }

        private void AddLine(int aStart, int aEnd)
        {
            // can only add unique lines.
            Marker start = mMarkers[aStart];
            Marker end = mMarkers[aEnd];
            foreach (Line line in mLines)
            {
                if (object.ReferenceEquals(start, line.Start) && object.ReferenceEquals(end, line.End))
                    return;
                if (object.ReferenceEquals(start, line.End) && object.ReferenceEquals(end, line.Start))
                    return;
            }

            // found no matching lines.
            mLines.Add(new Line(start, end));
            mPictureBox.Invalidate();
        }

        private void RemoveLine(int aIndex)
        {
            if (aIndex != -1)
            {
                mLines.RemoveAt(aIndex);
                mBaseLine = Math.Max(0, Math.Min(mBaseLine, mLines.Count - 1));
                mPictureBox.Invalidate();
            }
        }

        private void SaveProject()
        {
            FileStream fileStream = new FileStream(ProjectName, FileMode.Create);
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                writer.Write((int)0x4b434c46);
                writer.Write((int)1);
                writer.Write(mBaseMarker);
                writer.Write(mBaseLine);
                writer.Write((int)mDistanceTolerance.Value);
                writer.Write(mMarkers.Count);
                foreach (Marker marker in mMarkers)
                {
                    writer.Write(marker.Location.X);
                    writer.Write(marker.Location.Y);
                    writer.Write(marker.ShowArea);

                    if (string.IsNullOrEmpty(marker.NameTag))
                    {
                        writer.Write("");
                    }
                    else
                    {
                        writer.Write(marker.NameTag);
                    }

                    if (string.IsNullOrEmpty(marker.Description))
                    {
                        writer.Write("");
                    }
                    else
                    {
                        writer.Write(marker.Description);
                    }
                }

                writer.Write(mLines.Count);
                foreach (Line line in mLines)
                {
                    writer.Write(FindMarker(line.Start));
                    writer.Write(FindMarker(line.End));
                }
            }
        }

        private void LoadProject(string aFilename)
        {
            FileStream fileStream = new FileStream(aFilename, FileMode.Open);
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                uint id = reader.ReadUInt32();
                if (id != 0x4b434c46)
                {
                    MessageBox.Show(this,
                        string.Format("'{0}' is not a flock file", Path.GetFileName(aFilename)),
                        "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int version = reader.ReadInt32();
                if (version == 1)
                {
                    ResetProject();
                    ProjectName = aFilename;

                    mBaseMarker = reader.ReadInt32();
                    mBaseLine = reader.ReadInt32();
                    mDistanceTolerance.Value = reader.ReadInt32();

                    int numMarkers = reader.ReadInt32();
                    for (int i = 0; i < numMarkers; i++)
                    {
                        float x = reader.ReadSingle();
                        float y = reader.ReadSingle();
                        Marker marker = new Marker(x, y);
                        marker.ShowArea = reader.ReadBoolean();
                        marker.NameTag = reader.ReadString();
                        marker.Description = reader.ReadString();
                        mMarkers.Add(marker);
                    }

                    int numLines = reader.ReadInt32();
                    for (int i = 0; i < numLines; i++)
                    {
                        int start = reader.ReadInt32();
                        int end = reader.ReadInt32();
                        mLines.Add(new Line(mMarkers[start], mMarkers[end]));
                    }
                }
                else
                {
                    MessageBox.Show(this,
                        string.Format("'{0}' has an unsupported version number.", Path.GetFileName(aFilename)),
                        "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetProject()
        {
            mMarkers.Clear();
            mLines.Clear();
            mBaseLine = 0;
            mBaseMarker = 0;
            mDistanceTolerance.Value = 25;
            mPictureBox.ResetImage();
        }

        private int FindMarker(Marker a)
        {
            int num = mMarkers.Count;
            for (int i = 0; i < num; i++)
            {
                if (object.ReferenceEquals(mMarkers[i], a))
                {
                    return i;
                }
            }
            return -1;
        }

        private float CalculateAccuracy()
        {
            // get line base length.
            if (mBaseLine >= 0 && mBaseLine < mLines.Count)
            {
                float dtol = (int)mDistanceTolerance.Value * 0.01f;
                float baseLength = mLines[mBaseLine].GetLength();
                float minLength = baseLength - (baseLength * dtol);
                float maxLength = baseLength + (baseLength * dtol);

                float totalError = 0;
                float totalLength = 0;
                int numLines = mLines.Count;
                for (int i = 0; i < numLines; i++)
                {
                    Line line = mLines[i];
                    float length = line.GetLength();
                    if (length < minLength)
                    {
                        totalError += (minLength - length);
                    }
                    if (length > maxLength)
                    {
                        totalError += (length - maxLength);
                    }
                    totalLength += length;
                }

                return 1.0f - (totalError / totalLength);
            }
            else
            {
                return 0;
            }
        }
    }
}
