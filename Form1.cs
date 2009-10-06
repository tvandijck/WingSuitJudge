using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

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
                    mProject_ = value;
                    mPictureBox.BackColor = mProject_.BackColor;
                    EditorMode = EditMode.AddMarker;
                }
            }
        }

        private string mProjectName_;
        private string ProjectName
        {
            get { return mProjectName_; }
            set
            {
                mProjectName_ = value;
                if (string.IsNullOrEmpty(value))
                {
                    Text = string.Format("Wingsuit Flock Judging Tool {0}", Version);
                }
                else
                {
                    Text = string.Format("Wingsuit Flock Judging Tool {0} - [{1}]", Version, Path.GetFileName(value));
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

        private int Zoom
        {
            get { return mPictureBox.Zoom; }
            set
            {
                mPictureBox.Zoom = value;
                mZoomText.Text = string.Format("Zoom: {0}%", mPictureBox.Zoom);
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
                        formationStyle.MenuItems.Add(NewMenuItem("45", new EventHandler(OnMarker45), mSelectedMarker, marker.AreaCircleMode == AreaCircle.Deg45));
                        formationStyle.MenuItems.Add(NewMenuItem("90", new EventHandler(OnMarker90), mSelectedMarker, marker.AreaCircleMode == AreaCircle.Deg90));
                        formationStyle.MenuItems.Add(NewMenuItem("Both", new EventHandler(OnMarkerBoth), mSelectedMarker, marker.AreaCircleMode == AreaCircle.Both));
                        formationStyle.MenuItems.Add(NewMenuItem("Project", new EventHandler(OnMarkerProject), mSelectedMarker, marker.AreaCircleMode == AreaCircle.Project));

                        ContextMenu menu = new ContextMenu();
                        menu.MenuItems.Add(NewMenuItem("Mark as base", new EventHandler(OnMakeMarkerBase), mSelectedMarker, false));
                        menu.MenuItems.Add(NewMenuItem("Toggle area circles", new EventHandler(OnMarkerToggleAreaCircle), mSelectedMarker, marker.ShowArea));
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
                    }
                }
            }
        }

        private void OnPictureBoxMouseWheel(object sender, MouseEventArgs e)
        {
            Zoom += Math.Sign(e.Delta) * 5;
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
            if (marker != Project.BaseMarker)
            {
                Project.BaseMarker = marker;
                mPictureBox.Invalidate();
            }
        }

        private void OnMarkerToggleAreaCircle(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            if (index != -1)
            {
                Marker marker = Project.GetMarker(index);
                marker.ShowArea = !marker.ShowArea;
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
                    marker.SilhoutteColor = dialog.Color;
                    mPictureBox.Invalidate();
                }
            }
        }

        private void SetMarkerMode(int index, AreaCircle aMode)
        {
            if (index != -1)
            {
                Marker marker = Project.GetMarker(index);
                marker.AreaCircleMode = aMode;
            }
        }

        private void OnMarker45(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, AreaCircle.Deg45);
        }

        private void OnMarker90(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, AreaCircle.Deg90);
        }

        private void OnMarkerBoth(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, AreaCircle.Both);
        }

        private void OnMarkerProject(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            SetMarkerMode(index, AreaCircle.Project);
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
                    line.Color = dialog.Color;
                    mPictureBox.Invalidate();
                }
            }
        }

        private void OnRemoveMarker(object sender, EventArgs e)
        {
            int marker = (int)((MenuItem)sender).Tag;
            if (marker != -1)
            {
                Project.RemoveMarker(marker);
                mPictureBox.Invalidate();
            }
        }

        private void OnRemoveLine(object sender, EventArgs e)
        {
            int line = (int)((MenuItem)sender).Tag;
            if (line != -1)
            {
                Project.RemoveLine(line);
                mPictureBox.Invalidate();
            }
        }

        private void OnPictureBoxPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (mShowWingsuits.Checked)
            {
                Project.PaintWingsuit(e.Graphics);
            }
            if (mShowLines.Checked)
            {
                Project.PaintLines(e.Graphics, mSelectedLine);
            }
            if (mShowAreaCircles.Checked)
            {
                Project.PaintAreaCircles(e.Graphics);
            }            
            if (mShowMarkers.Checked)
            {
                Project.PaintMarkers(e.Graphics, mSelectedMarker);
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
            }
        }

        private void OnZoomInClick(object sender, EventArgs e)
        {
            Zoom += 10;
        }

        private void OnZoomOutClick(object sender, EventArgs e)
        {
            Zoom -= 10;
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

        private void mFreeTransform_Click(object sender, EventArgs e)
        {
            EditorMode = EditMode.FreeTransform;
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
        }

        private void OnColorPickerClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = Project.BackColor;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Project.BackColor = dialog.Color;
                mPictureBox.BackColor = dialog.Color;
            }
        }

        private void OnJumpInfoClick(object sender, EventArgs e)
        {
            JumpInfo dialog = new JumpInfo(Project);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
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
                Project.DistanceTolerance = dialog.DistanceTolerance;
                Project.AngleTolerance = dialog.AngleTolerance;
                Project.AreaCircleMode = dialog.AreaCircleMode;
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
                using (Graphics gfx = Graphics.FromImage(bitmap))
                {
                    gfx.Transform = new Matrix(1, 0, 0, 1, bitmap.Width * 0.5f, bitmap.Height * 0.5f);
                    Project.PaintLines(gfx, -1);
                    Project.PaintMarkers(gfx, -1);
                }
                bitmap.Save(dialog.FileName);
            }
        }

        private void OnRepaintEvent(object sender, EventArgs e)
        {
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
                int num = Project.NumLines;
                for (int i = 0; i < num; ++i)
                {
                    Project.GetLine(i).Color = dialog.Color;
                }
                mPictureBox.Invalidate();
            }
        }
        
        private void OnWingsuitColorsClick(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = Color.Black;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                int num = Project.NumMarkers;
                for (int i = 0; i < num; ++i)
                {
                    Project.GetMarker(i).SilhoutteColor = dialog.Color;
                }
                mPictureBox.Invalidate();
            }
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
            Project = new Project();
            ProjectName = null;
            mPictureBox.ResetImage();
            mShowLines.Checked = true;
            mShowMarkers.Checked = true;
            mShowWingsuits.Checked = false;
            mShowPhoto.Checked = true;
            mShowAreaCircles.Checked = true;
        }

    }
}
