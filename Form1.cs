using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Flock
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
            RemoveLine,
            FreeTransform
        }

        private Action mAction = null;
        private int mSelectedMarker = -1;
        private int mSelectedLine = -1;

        public Form1()
        {
            InitializeComponent();
            mCopyright.Text = CopyrightNotice;
            mPictureBox.Origin = new PointF(mPictureBox.Width * 0.5f, mPictureBox.Height * 0.5f);
            mPictureBox.MouseWheel += new MouseEventHandler(OnPictureBoxMouseWheel);
            ResetProject();
        }

        #region -- Properties -------------------------------------------------

        private Project mProject_;
        private Project Project
        {
            get { return mProject_; }
            set
            {
                if (!object.ReferenceEquals(mProject_, value))
                {
                    if (mProject_ != null)
                    {
                        mProject_.OnDirty -= new EventHandler(OnProjectDirty);
                    }

                    CommandSystem.Reset();
                    mProject_ = value;
                    mPictureBox.BackColor = mProject_.BackColor;
                    EditorMode = EditMode.AddMarker;

                    if (mProject_ != null)
                    {
                        mProject_.OnDirty += new EventHandler(OnProjectDirty);
                    }
                }
            }
        }

        private string mProjectName_;
        private string ProjectName
        {
            get { return mProjectName_; }
            set
            {
                string dirty = Project.Dirty ? "*" : "";
                mProjectName_ = value;
                if (string.IsNullOrEmpty(value))
                {
                    Text = string.Format("Flock Briefing Tool {0} [beta] - [noname.flock{1}]", Version, dirty);
                }
                else
                {
                    Text = string.Format("Flock Briefing Tool {0} [beta]  - [{1}{2}]", Version, Path.GetFileName(value), dirty);
                }
            }
        }

        private EditMode mEditMode_;
        private EditMode EditorMode
        {
            get { return mEditMode_; }
            set
            {
                mEditMode_ = value;
                mBtnMoveImage.Checked = mEditMode_ == EditMode.MoveImage;
                mBtnAddMarker.Checked = mEditMode_ == EditMode.AddMarker;
                mBtnRemoveMarker.Checked = mEditMode_ == EditMode.RemoveMarker;
                mBtnMoveMarker.Checked = mEditMode_ == EditMode.MoveMarker;
                mBtnAddLine.Checked = mEditMode_ == EditMode.AddLine;
                mBtnRemoveLine.Checked = mEditMode_ == EditMode.RemoveLine;
                mBtnFreeTransform.Checked = mEditMode_ == EditMode.FreeTransform;
                mPictureBox.MoveMode = mEditMode_ == EditMode.MoveImage;

                switch (mEditMode_)
                {
                    case EditMode.AddMarker:
                        mAction = new AddMarkerAction(Project);
                        break;
                    case EditMode.RemoveMarker:
                        mAction = new RemoveMarkerAction(Project);
                        break;
                    case EditMode.MoveMarker:
                        mAction = new MoveMarkerAction(Project);
                        break;
                    case EditMode.AddLine:
                        mAction = new AddLineAction(Project);
                        break;
                    case EditMode.RemoveLine:
                        mAction = new RemoveLineAction(Project);
                        break;
                    case EditMode.FreeTransform:
                        mAction = new RotateAction(Project);
                        break;
                    default:
                        mAction = null;
                        break;
                }

                mPictureBox.Invalidate();
            }
        }

        private float Zoom
        {
            get { return mPictureBox.Zoom; }
            set
            {
                mPictureBox.Zoom = value;
                mZoomText.Text = string.Format("Zoom: {0}%", (int)mPictureBox.Zoom);
            }
        }

        private string CopyrightNotice
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                AssemblyCopyrightAttribute notice = AssemblyDescriptionAttribute.GetCustomAttribute(
                        assembly, typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;
                if (notice != null)
                {
                    return notice.Copyright;
                }
                else
                {
                    return string.Empty;
                }
            }
        }


        private string Version
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);
                if (info != null)
                {
                    return string.Format("{0}.{1}.{2}", info.ProductMajorPart,
                        info.ProductMinorPart, info.ProductBuildPart);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #endregion

        #region -- PictureBox Events ------------------------------------------

        private void OnPictureBoxMouseClick(object sender, MouseEventArgs e)
        {
            if (mAction == null || mAction.OnMouseClick(mPictureBox, e))
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (mSelectedMarker != -1)
                    {
                        Marker marker = Project.GetMarker(mSelectedMarker);

                        MenuItem formationStyle = new MenuItem("Formation Style");
                        formationStyle.MenuItems.Add(NewMenuItem("45", new EventHandler(OnMarker45), mSelectedMarker, marker.FlightZoneMode == FlightZone.Deg45));
                        formationStyle.MenuItems.Add(NewMenuItem("90", new EventHandler(OnMarker90), mSelectedMarker, marker.FlightZoneMode == FlightZone.Deg90));
                        formationStyle.MenuItems.Add(NewMenuItem("Both", new EventHandler(OnMarkerBoth), mSelectedMarker, marker.FlightZoneMode == FlightZone.Both));
                        formationStyle.MenuItems.Add(NewMenuItem("Project", new EventHandler(OnMarkerProject), mSelectedMarker, marker.FlightZoneMode == FlightZone.Project));

                        ContextMenu menu = new ContextMenu();
                        menu.MenuItems.Add(NewMenuItem("Mark as base", new EventHandler(OnMakeMarkerBase), mSelectedMarker, false));
                        menu.MenuItems.Add(NewMenuItem("Toggle Flight Zone", new EventHandler(OnMarkerToggleFlightZone), mSelectedMarker, marker.ShowFlightZone));
                        menu.MenuItems.Add(formationStyle);
                        menu.MenuItems.Add("-");
                        menu.MenuItems.Add(NewMenuItem("Change wingsuit color", new EventHandler(OnChangeWingsuitColor), mSelectedMarker, false));
                        menu.MenuItems.Add("-");
                        menu.MenuItems.Add(NewMenuItem("Remove", new EventHandler(OnRemoveMarker), mSelectedMarker, false));
                        menu.MenuItems.Add(NewMenuItem("Properties", new EventHandler(OnMarkerProperties), mSelectedMarker, false));
                        menu.Show(this, mPictureBox.ToScreen(new Point(e.X, e.Y)));
                    }
                    else if (mSelectedLine != -1)
                    {
                        ContextMenu menu = new ContextMenu();
                        menu.MenuItems.Add(NewMenuItem("Change color", new EventHandler(OnChangeLineColor), mSelectedLine, false));
                        menu.MenuItems.Add("-");
                        menu.MenuItems.Add(NewMenuItem("Remove", new EventHandler(OnRemoveLine), mSelectedLine, false));
                        menu.Show(this, mPictureBox.ToScreen(new Point(e.X, e.Y)));
                    }
                }
            }
        }

        private void OnPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (mAction == null || mAction.OnMouseDown(mPictureBox, e))
            {
            }
        }

        private void OnPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (mAction == null || mAction.OnMouseUp(mPictureBox, e))
            {
            }
        }

        ToolTip mToolTip = new ToolTip();

        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (mAction == null || mAction.OnMouseMove(mPictureBox, e))
            {
                // find marker selection.
                int selected = Project.FindMarker(e.X, e.Y);
                if (selected != mSelectedMarker)
                {
                    mSelectedMarker = selected;
                    mSelectedLine = -1;
                    mPictureBox.Invalidate();
                }

                // find a line selection instead, but only if we are not dragging.
                if (mSelectedMarker == -1)
                {
                    selected = Project.FindLine(e.X, e.Y);
                    if (selected != mSelectedLine)
                    {
                        mSelectedLine = selected;
                        mPictureBox.Invalidate();

                        if (selected >= 0)
                        {
                            Line line = Project.GetLine(selected);
                            float baseLength = Project.BaseLength;
                            float length = line.GetLength();

                            int len = (int)((100.0f * length) / baseLength);

                            Point pnt = mPictureBox.ToScreen(new Point(e.X, e.Y));
                            mToolTip.Show(string.Format("length: {0}%", len), mPictureBox, pnt.X, pnt.Y, 3000);
                        }
                    }
                }
            }
        }

        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e)
        {
            float scroll = e.Delta * 0.001f;
            float offsetX = mPictureBox.Origin.X;
            float offsetY = mPictureBox.Origin.Y;

            float scale = (Zoom * 0.01f);
            float recipScale = 1.0f / scale;
            float selectedX = (e.X - offsetX) * recipScale;
            float selectedY = (e.Y - offsetY) * recipScale;

            scale += (scale * scroll);
            scale = Math.Max(scale, 0.1f);

            recipScale = 1.0f / scale;
            selectedX = (e.X - offsetX) * recipScale - selectedX;
            selectedY = (e.Y - offsetY) * recipScale - selectedY;

            offsetX += selectedX * scale;
            offsetY += selectedY * scale;

            mPictureBox.Origin = new PointF(offsetX, offsetY);
            Zoom = scale * 100;
        }

        private void OnMarkerProperties(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            if (index != -1)
            {
                Marker marker = Project.GetMarker(index);
                MarkerProperties props = new MarkerProperties(marker);
                if (props.ShowDialog(this) == DialogResult.OK)
                {
                    CommandSystem.AddRollback(Project);
                    marker.NameTag = props.NameTag;
                    marker.Description = props.Description;
                    marker.ShowFlightZone = props.ShowFlightZone;
                    mPictureBox.Invalidate();
                }
            }
        }

        private void OnMakeMarkerBase(object sender, EventArgs e)
        {
            int marker = (int)((MenuItem)sender).Tag;
            if (marker != Project.BaseMarker)
            {
                CommandSystem.AddRollback(Project);
                Project.BaseMarker = marker;
                mPictureBox.Invalidate();
            }
        }

        private void OnMarkerToggleFlightZone(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            if (index != -1)
            {
                CommandSystem.MarkerToggleFlightZone(Project, index);
                mPictureBox.Invalidate();
            }
        }

        private void OnChangeWingsuitColor(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            if (index != -1)
            {
                Marker marker = Project.GetMarker(index);

                ColorDialog dialog = new ColorDialog();
                dialog.Color = marker.SilhoutteColor;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (marker.SilhoutteColor != dialog.Color)
                    {
                        CommandSystem.AddRollback(Project);
                        marker.SilhoutteColor = dialog.Color;
                        mPictureBox.Invalidate();
                    }
                }
            }
        }

        private void SetMarkerMode(int index, FlightZone aMode)
        {
            if (index != -1)
            {
                Marker marker = Project.GetMarker(index);
                if (marker.FlightZoneMode != aMode)
                {
                    CommandSystem.AddRollback(Project);
                    marker.FlightZoneMode = aMode;
                }
            }
        }

        private void OnMarker45(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, FlightZone.Deg45);
        }

        private void OnMarker90(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, FlightZone.Deg90);
        }

        private void OnMarkerBoth(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, FlightZone.Both);
        }

        private void OnMarkerProject(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, FlightZone.Project);
        }

        private void OnChangeLineColor(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            if (index != -1)
            {
                Line line = Project.GetLine(index);

                ColorDialog dialog = new ColorDialog();
                dialog.Color = line.Color;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (line.Color != dialog.Color)
                    {
                        CommandSystem.AddRollback(Project);
                        line.Color = dialog.Color;
                        mPictureBox.Invalidate();
                    }
                }
            }
        }

        private void OnRemoveMarker(object sender, EventArgs e)
        {
            int marker = (int)((MenuItem)sender).Tag;
            if (marker != -1)
            {
                CommandSystem.RemoveMarker(Project, marker);
                mPictureBox.Invalidate();
            }
        }

        private void OnRemoveLine(object sender, EventArgs e)
        {
            int line = (int)((MenuItem)sender).Tag;
            if (line != -1)
            {
                CommandSystem.RemoveLine(Project, line);
                mPictureBox.Invalidate();
            }
        }

        private void OnPictureBoxPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (mShowPhoto.Checked)
            {
                mPictureBox.DrawBitmap(e.Graphics);
            }
            if (mShowWingsuits.Checked)
            {
                Project.PaintWingsuit(e.Graphics, Project.WingsuitSize * 0.01f);
            }
            if (mShowLines.Checked)
            {
                Project.PaintLines(e.Graphics, mSelectedLine);
            }
            if (mShowFlightZones.Checked)
            {
                Project.PaintFlightZones(e.Graphics);
            }
            if (mShowDots.Checked)
            {
                Project.PaintDots(e.Graphics, Project.DotCount, Project.DotSize * 1.0f,
                    Project.DotDistance * 0.5f, Project.DotStretch * 0.01f,
                    Project.DotRotate * (float)Math.PI / 1800.0f);
            }
            if (mShowMarkers.Checked)
            {
                Project.PaintMarkers(e.Graphics, mSelectedMarker, Project.WingsuitSize * 0.01f);
            }
            if (mAction != null)
            {
                mAction.OnPaint(e.Graphics);
            }

            // calculate accuracy.
            int accuracy = (int)Math.Round(Project.Accuracy * 100);
            mAccuracy.Text = string.Format("Accuracy: {0}%", accuracy);
        }

        #endregion

        #region -- Form Events ------------------------------------------------

        void OnProjectDirty(object sender, EventArgs e)
        {
            ProjectName = ProjectName;
        }

        private void OnImportImageClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Image File";
            dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ShowHelp = true;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                mPictureBox.LoadImage(dialog.FileName);
                Project.PhotoName = dialog.FileName;
                mPictureBox.Focus();
            }
        }

        private void OnZoomInClick(object sender, EventArgs e)
        {
            Zoom += 10;
            mPictureBox.Focus();
        }

        private void OnZoomOutClick(object sender, EventArgs e)
        {
            Zoom -= 10;
            mPictureBox.Focus();
        }

        private void OnAddMarkerClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.AddMarker;
            mPictureBox.Focus();
        }

        private void OnRemoveMarkerClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.RemoveMarker;
            mPictureBox.Focus();
        }

        private void OnMoveMarkerClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.MoveMarker;
            mPictureBox.Focus();
        }

        private void OnAddLineClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.AddLine;
            mPictureBox.Focus();
        }

        private void OnRemoveLineClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.RemoveLine;
            mPictureBox.Focus();
        }

        private void OnMoveImageClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.MoveImage;
            mPictureBox.Focus();
        }

        private void OnTransformClick(object sender, EventArgs e)
        {
            EditorMode = EditMode.FreeTransform;
            mPictureBox.Focus();
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnAboutClick(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog(this);
        }

        private void OnNewClick(object sender, EventArgs e)
        {
            if (IsItSaveToDestroyProject())
            {
                ResetProject();
            }
        }

        private void OnSaveAsClick(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save project";
            dialog.Filter = "Flock files (*.flock)|*.flock";
            dialog.CheckPathExists = true;
            dialog.AddExtension = true;
            dialog.ShowHelp = true;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ProjectName = dialog.FileName;
                Project.SaveProject(ProjectName);
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
                Project.SaveProject(ProjectName);
            }
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            if (IsItSaveToDestroyProject())
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Open project";
                dialog.Filter = "Flock files (*.flock)|*.flock";
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.ShowHelp = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        Project = new Project(dialog.FileName);
                        ProjectName = dialog.FileName;
                        SaveSettings();
                        OnCenterImageClick(sender, e);

                        if (!string.IsNullOrEmpty(Project.PhotoName))
                        {
                            if (File.Exists(Project.PhotoName))
                            {
                                mPictureBox.LoadImage(Project.PhotoName);
                            }
                            else
                            {
                                string photoName = Path.Combine(Path.GetDirectoryName(dialog.FileName), Path.GetFileName(Project.PhotoName));
                                if (File.Exists(photoName))
                                {
                                    mPictureBox.LoadImage(photoName);
                                }
                                else
                                {
                                    string message = string.Format("The photo [{0}] associated with this project could not be found.",
                                        Path.GetFileName(Project.PhotoName));
                                    MessageBox.Show(this, message, "Error loading associated photo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ResetProject();
                        MessageBox.Show(this, ex.Message, "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OnResetPhotoClick(object sender, EventArgs e)
        {
            mPictureBox.ResetImage();
            Project.PhotoName = null;
            mPictureBox.Focus();
        }

        private void OnCenterImageClick(object sender, EventArgs e)
        {
            int num = Project.NumMarkers;
            if (num > 0)
            {
                RectangleF rect = Project.BoundingRect;
                rect.Inflate(10, 10);
                rect.Height += 120;

                float width = rect.Width;
                float height = rect.Height;
                float cx = rect.Left + rect.Right;
                float cy = rect.Top + rect.Bottom;

                // calculate scale.
                float scaleX = mPictureBox.Width / width;
                float scaleY = mPictureBox.Height / height;
                float scale = Math.Min(4, Math.Min(scaleX, scaleY));
                Zoom = (int)(scale * 100);

                // calculate center.
                float x = (mPictureBox.Width * 0.5f) - (cx * scale * 0.5f);
                float y = (mPictureBox.Height * 0.5f) - (cy * scale * 0.5f);
                mPictureBox.Origin = new PointF(x, y);
            }
            else
            {
                mPictureBox.Origin = new PointF(mPictureBox.Width * 0.5f, mPictureBox.Height * 0.5f);
                Zoom = 100;
            }
            mPictureBox.Focus();
        }

        private void OnColorPickerClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = Project.BackColor;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (Project.BackColor != dialog.Color)
                {
                    CommandSystem.AddRollback(Project);
                    Project.BackColor = dialog.Color;
                    mPictureBox.BackColor = dialog.Color;
                }
            }
        }

        private void OnJumpInfoClick(object sender, EventArgs e)
        {
            JumpInfo dialog = new JumpInfo(Project);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                CommandSystem.AddRollback(Project);
                Project.Description = dialog.Description;
                Project.Date = dialog.Date;
                Project.Place = dialog.Place;
                Project.GlideRatio = dialog.GlideRatio;
                Project.JumpNumber = dialog.JumpNumber;
                Project.Fallrate = dialog.Fallrate;
            }
        }

        private void OnSettingsClick(object sender, EventArgs e)
        {
            ProjectSettings dialog = new ProjectSettings(Project);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                CommandSystem.AddRollback(Project);
                Project.DistanceTolerance = dialog.DistanceTolerance;
                Project.AngleTolerance = dialog.AngleTolerance;
                Project.FlightZoneMode = dialog.FlightZoneMode;

                // Sync UI.
                mDistanceTolerance.Value = Project.DistanceTolerance;
                mAngleTolerance.Value = Project.AngleTolerance;
                mPictureBox.Invalidate();
            }
        }

        private void OnExportClick(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export photo...";
            dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            dialog.CheckPathExists = true;
            dialog.AddExtension = true;
            dialog.DefaultExt = "jpg";
            dialog.ShowHelp = true;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Bitmap bitmap = mPictureBox.CloneBitmap();

                float x, y;
                if (bitmap == null)
                {
                    RectangleF rect = Project.BoundingRect;
                    rect.Inflate(50, 50);
                    rect.Height += 120;

                    bitmap = new Bitmap((int)rect.Width, (int)rect.Height, PixelFormat.Format24bppRgb);
                    using (Graphics gfx = Graphics.FromImage(bitmap))
                    {
                        gfx.Clear(BackColor);
                    }

                    float cx = rect.Left + rect.Right;
                    float cy = rect.Top + rect.Bottom;
                    x = (bitmap.Width * 0.5f) - (cx * 0.5f);
                    y = (bitmap.Height * 0.5f) - (cy * 0.5f);
                }
                else
                {
                    x = bitmap.Width * 0.5f;
                    y = bitmap.Height * 0.5f;
                }

                using (Graphics gfx = Graphics.FromImage(bitmap))
                {
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    gfx.Transform = new Matrix(1, 0, 0, 1, x, y);

                    if (mShowWingsuits.Checked)
                    {
                        Project.PaintWingsuit(gfx, Project.WingsuitSize * 0.01f);
                    }
                    if (mShowLines.Checked)
                    {
                        Project.PaintLines(gfx, -1);
                    }
                    if (mShowFlightZones.Checked)
                    {
                        Project.PaintFlightZones(gfx);
                    }
                    if (mShowDots.Checked)
                    {
                        Project.PaintDots(gfx, Project.DotCount, Project.DotSize * 1.0f,
                            Project.DotDistance * 0.5f, Project.DotStretch * 0.01f,
                            Project.DotRotate * (float)Math.PI / 1800.0f);
                    }
                    if (mShowMarkers.Checked)
                    {
                        Project.PaintMarkers(gfx, -1, Project.WingsuitSize * 0.01f);
                    }
                }
                bitmap.Save(dialog.FileName);
            }
        }

        private void OnRepaintEvent(object sender, EventArgs e)
        {
            mPictureBox.Invalidate();
        }

        private void OnShowWingsuitChangedEvent(object sender, EventArgs e)
        {
            mSizeBox.Visible = mShowWingsuits.Checked;
            mPictureBox.Invalidate();
        }

        private void OnShowDotChangedEvent(object sender, EventArgs e)
        {
            mDotBox.Visible = mShowDots.Checked;
            mPictureBox.Invalidate();
        }

        private void OnInvertPhotoClick(object sender, EventArgs e)
        {
            mPictureBox.InvertImage();
        }

        private void OnLineColorClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = Color.Black;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                CommandSystem.AddRollback(Project);
                int num = Project.NumLines;
                for (int i = 0; i < num; ++i)
                {
                    Project.GetLine(i).Color = dialog.Color;
                }
                Project.Dirty = true;
                mPictureBox.Invalidate();
            }
        }

        private void OnWingsuitColorsClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = Color.Black;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                CommandSystem.AddRollback(Project);
                int num = Project.NumMarkers;
                for (int i = 0; i < num; ++i)
                {
                    Project.GetMarker(i).SilhoutteColor = dialog.Color;
                }
                Project.Dirty = true;
                mPictureBox.Invalidate();
            }
        }

        private void OnWingsuitSizeValueChanged(object sender, EventArgs e)
        {
            Project.WingsuitSize = (int)mWingsuitSize.Value;
            mPictureBox.Invalidate();
        }

        private void OnToleranceChanged(object sender, EventArgs e)
        {
            Project.AngleTolerance = (int)mAngleTolerance.Value;
            Project.DistanceTolerance = (int)mDistanceTolerance.Value;
            mPictureBox.Invalidate();
        }

        private void OnDotSettingChanged(object sender, EventArgs e)
        {
            Project.DotCount = (int)mDotCount.Value;
            Project.DotSize = (int)mDotSize.Value;
            Project.DotDistance = (int)mDotDistance.Value;
            Project.DotStretch = (int)mDotStretch.Value;
            Project.DotRotate = (int)(mDotRotate.Value * 10);
            mPictureBox.Invalidate();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            if (!IsItSaveToDestroyProject())
            {
                e.Cancel = true;
            }
        }

        private void OnUndoClick(object sender, EventArgs e)
        {
            CommandSystem.Undo(Project);

            // reset the editor action and repaint.
            EditorMode = EditorMode;
            mPictureBox.Invalidate();
        }

        private void OnRedoClick(object sender, EventArgs e)
        {
            CommandSystem.Redo(Project);

            // reset the editor action and repaint.
            EditorMode = EditorMode;
            mPictureBox.Invalidate();
        }

        #endregion

        private static MenuItem NewMenuItem(string aName, EventHandler aHandler, object aTag, bool aChecked)
        {
            MenuItem item = new MenuItem(aName, aHandler);
            item.Tag = aTag;
            item.Checked = aChecked;
            return item;
        }

        private void ResetProject()
        {
            SaveSettings();
            Project = new Project();
            ProjectName = null;
            mPictureBox.ResetImage();
            SyncUI();
        }

        private void SaveSettings()
        {
            if (Project != null)
            {
                Settings.Default.ShowLines = mShowLines.Checked;
                Settings.Default.ShowMarkers = mShowMarkers.Checked;
                Settings.Default.ShowWingsuits = mShowWingsuits.Checked;
                Settings.Default.ShowPhoto = mShowPhoto.Checked;
                Settings.Default.ShowFlightZones = mShowFlightZones.Checked;
                Settings.Default.ShowDots = mShowDots.Checked;
                Settings.Default.AngleTolerance = Project.AngleTolerance;
                Settings.Default.DistanceTolerance = Project.DistanceTolerance;
                Settings.Default.WingsuitSize = Project.WingsuitSize;
                Settings.Default.DotCount = Project.DotCount;
                Settings.Default.DotSize = Project.DotSize;
                Settings.Default.DotDistance = Project.DotDistance;
                Settings.Default.DotStretch = Project.DotStretch;
                Settings.Default.DotRotate = Project.DotRotate;
                Settings.Default.Save();
                SyncUI();
            }
        }

        private void SyncUI()
        {
            mShowLines.Checked = Settings.Default.ShowLines;
            mShowMarkers.Checked = Settings.Default.ShowMarkers;
            mShowWingsuits.Checked = Settings.Default.ShowWingsuits;
            mShowPhoto.Checked = Settings.Default.ShowPhoto;
            mShowFlightZones.Checked = Settings.Default.ShowFlightZones;
            mShowDots.Checked = Settings.Default.ShowDots;

            mWingsuitSize.Value = Project.WingsuitSize;
            mDotCount.Value = Project.DotCount;
            mDotSize.Value = Project.DotSize;
            mDotDistance.Value = Project.DotDistance;
            mDotStretch.Value = Project.DotStretch;
            mDotRotate.Value = Convert.ToDecimal(Project.DotRotate * 0.1f);
            mSizeBox.Visible = mShowWingsuits.Checked;
            mDotBox.Visible = mShowDots.Checked;
            mAngleTolerance.Value = Project.AngleTolerance;
            mDistanceTolerance.Value = Project.DistanceTolerance;
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = pd;
                dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle margin = e.MarginBounds;
            float scale = 1.0f;
            float x = margin.X + margin.Width * 0.5f;
            float y = margin.Y + margin.Height * 0.5f;

            int num = Project.NumMarkers;
            if (num > 0)
            {
                RectangleF rect = Project.BoundingRect;
                rect.Inflate(50, 50);
                rect.Height += 120;

                float width = rect.Width;
                float height = rect.Height;
                float cx = rect.Left + rect.Right;
                float cy = rect.Top + rect.Bottom;

                // calculate scale.
                float scaleX = margin.Width / width;
                float scaleY = margin.Height / height;
                scale = Math.Min(4, Math.Min(scaleX, scaleY));

                // calculate center.
                x = margin.X + ((margin.Width * 0.5f) - (cx * scale * 0.5f));
                y = margin.Y + ((margin.Height * 0.5f) - (cy * scale * 0.5f));
            }

            e.Graphics.Clip = new Region(margin);
            e.Graphics.Transform = new Matrix(scale, 0, 0, scale, x, y);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (mShowPhoto.Checked)
            {
                mPictureBox.DrawBitmap(e.Graphics);
            }
            if (mShowWingsuits.Checked)
            {
                Project.PaintWingsuit(e.Graphics, Project.WingsuitSize * 0.01f);
            }
            if (mShowLines.Checked)
            {
                Project.PaintLines(e.Graphics, -1);
            }
            if (mShowFlightZones.Checked)
            {
                Project.PaintFlightZones(e.Graphics);
            }
            if (mShowMarkers.Checked)
            {
                Project.PaintMarkers(e.Graphics, -1, Project.WingsuitSize * 0.01f);
            }

            e.HasMorePages = false;
        }

        private bool IsItSaveToDestroyProject()
        {
            if (Project.Dirty)
            {
                switch (MessageBox.Show(this, "Project has been modified but not saved yet.\nDo you want to save first?",
                    "Project not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel:
                        return false;

                    case DialogResult.Yes:
                        OnSaveClick(this, EventArgs.Empty);
                        return !Project.Dirty;

                    case DialogResult.No:
                        return true;
                }
            }
            return true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    OnAddMarkerClick(sender, e);
                    break;
                case 's':
                    OnRemoveMarkerClick(sender, e);
                    break;
                case 'd':
                    OnMoveMarkerClick(sender, e);
                    break;
                case 'z':
                    OnAddLineClick(sender, e);
                    break;
                case 'x':
                    OnRemoveLineClick(sender, e);
                    break;
                case 'c':
                    OnTransformClick(sender, e);
                    break;
                case 'm':
                    OnMoveImageClick(sender, e);
                    break;
            }
        }
    }
}
