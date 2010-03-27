namespace Flock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mStatusBar = new System.Windows.Forms.StatusStrip();
            this.mZoomText = new System.Windows.Forms.ToolStripStatusLabel();
            this.mAccuracy = new System.Windows.Forms.ToolStripStatusLabel();
            this.mCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.mMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.importPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDisplayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowMarkers = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowWingsuits = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowPhoto = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowFlightZones = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowDots = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.mBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLineColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mWingsuitColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMenuPanel = new System.Windows.Forms.Panel();
            this.mDotBox = new System.Windows.Forms.GroupBox();
            this.mDotDistance = new System.Windows.Forms.TrackBar();
            this.mDotSize = new System.Windows.Forms.TrackBar();
            this.mDotCount = new System.Windows.Forms.NumericUpDown();
            this.mSizeBox = new System.Windows.Forms.GroupBox();
            this.mWingsuitSize = new System.Windows.Forms.NumericUpDown();
            this.mAdvert = new System.Windows.Forms.PictureBox();
            this.mFormationTools = new System.Windows.Forms.GroupBox();
            this.mBtnFreeTransform = new Flock.CheckButton();
            this.mBtnRemoveLine = new Flock.CheckButton();
            this.mBtnAddLine = new Flock.CheckButton();
            this.mBtnMoveMarker = new Flock.CheckButton();
            this.mBtnRemoveMarker = new Flock.CheckButton();
            this.mBtnAddMarker = new Flock.CheckButton();
            this.mImageTools = new System.Windows.Forms.GroupBox();
            this.mBtnInvertPhoto = new Flock.CheckButton();
            this.mBtnCenterImage = new Flock.CheckButton();
            this.mBtnMoveImage = new Flock.CheckButton();
            this.mBtnZoomOut = new Flock.CheckButton();
            this.mBtnZoomIn = new Flock.CheckButton();
            this.mPictureBox = new Flock.ImagePanel();
            this.mStatusBar.SuspendLayout();
            this.mMainMenu.SuspendLayout();
            this.mMenuPanel.SuspendLayout();
            this.mDotBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDotDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDotSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDotCount)).BeginInit();
            this.mSizeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mWingsuitSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAdvert)).BeginInit();
            this.mFormationTools.SuspendLayout();
            this.mImageTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // mStatusBar
            // 
            this.mStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mZoomText,
            this.mAccuracy,
            this.mCopyright});
            this.mStatusBar.Location = new System.Drawing.Point(0, 708);
            this.mStatusBar.Name = "mStatusBar";
            this.mStatusBar.Size = new System.Drawing.Size(1008, 22);
            this.mStatusBar.TabIndex = 2;
            this.mStatusBar.Text = "statusStrip2";
            // 
            // mZoomText
            // 
            this.mZoomText.AutoSize = false;
            this.mZoomText.Name = "mZoomText";
            this.mZoomText.Size = new System.Drawing.Size(100, 17);
            this.mZoomText.Text = "Zoom: 100%";
            // 
            // mAccuracy
            // 
            this.mAccuracy.AutoSize = false;
            this.mAccuracy.Name = "mAccuracy";
            this.mAccuracy.Size = new System.Drawing.Size(100, 17);
            this.mAccuracy.Text = "Accuracy: ??";
            // 
            // mCopyright
            // 
            this.mCopyright.Name = "mCopyright";
            this.mCopyright.Size = new System.Drawing.Size(793, 17);
            this.mCopyright.Spring = true;
            this.mCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mMainMenu
            // 
            this.mMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem7,
            this.toolStripMenuItem5,
            this.mDisplayMenu,
            this.helpToolStripMenuItem});
            this.mMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mMainMenu.Name = "mMainMenu";
            this.mMainMenu.Size = new System.Drawing.Size(1008, 24);
            this.mMainMenu.TabIndex = 5;
            this.mMainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openFormationToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveFormationToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.printMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewClick);
            // 
            // openFormationToolStripMenuItem
            // 
            this.openFormationToolStripMenuItem.Image = global::Flock.Properties.Resources.open_project;
            this.openFormationToolStripMenuItem.Name = "openFormationToolStripMenuItem";
            this.openFormationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFormationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openFormationToolStripMenuItem.Text = "&Open...";
            this.openFormationToolStripMenuItem.Click += new System.EventHandler(this.OnOpenClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // saveFormationToolStripMenuItem
            // 
            this.saveFormationToolStripMenuItem.Image = global::Flock.Properties.Resources.save_project;
            this.saveFormationToolStripMenuItem.Name = "saveFormationToolStripMenuItem";
            this.saveFormationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFormationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveFormationToolStripMenuItem.Text = "&Save...";
            this.saveFormationToolStripMenuItem.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.OnSaveAsClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // printMenuItem
            // 
            this.printMenuItem.Image = global::Flock.Properties.Resources.printer;
            this.printMenuItem.Name = "printMenuItem";
            this.printMenuItem.Size = new System.Drawing.Size(155, 22);
            this.printMenuItem.Text = "Print...";
            this.printMenuItem.Click += new System.EventHandler(this.printMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem7.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.OnUndoClick);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.OnRedoClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPhotoToolStripMenuItem,
            this.resetPhotoToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem6,
            this.propertiesToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItem5.Text = "&Project";
            // 
            // importPhotoToolStripMenuItem
            // 
            this.importPhotoToolStripMenuItem.Image = global::Flock.Properties.Resources.image_add;
            this.importPhotoToolStripMenuItem.Name = "importPhotoToolStripMenuItem";
            this.importPhotoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importPhotoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.importPhotoToolStripMenuItem.Text = "Import photo...";
            this.importPhotoToolStripMenuItem.Click += new System.EventHandler(this.OnImportImageClick);
            // 
            // resetPhotoToolStripMenuItem
            // 
            this.resetPhotoToolStripMenuItem.Image = global::Flock.Properties.Resources.image_delete;
            this.resetPhotoToolStripMenuItem.Name = "resetPhotoToolStripMenuItem";
            this.resetPhotoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetPhotoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.resetPhotoToolStripMenuItem.Text = "Reset photo";
            this.resetPhotoToolStripMenuItem.Click += new System.EventHandler(this.OnResetPhotoClick);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::Flock.Properties.Resources.export;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportToolStripMenuItem.Text = "&Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.OnExportClick);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(188, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.propertiesToolStripMenuItem.Text = "Jump info...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.OnJumpInfoClick);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.OnSettingsClick);
            // 
            // mDisplayMenu
            // 
            this.mDisplayMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mShowLines,
            this.mShowMarkers,
            this.mShowWingsuits,
            this.mShowPhoto,
            this.mShowFlightZones,
            this.mShowDots,
            this.toolStripMenuItem8,
            this.mBackgroundColorToolStripMenuItem,
            this.mLineColorMenuItem,
            this.mWingsuitColorsToolStripMenuItem});
            this.mDisplayMenu.Name = "mDisplayMenu";
            this.mDisplayMenu.Size = new System.Drawing.Size(57, 20);
            this.mDisplayMenu.Text = "&Display";
            // 
            // mShowLines
            // 
            this.mShowLines.Checked = true;
            this.mShowLines.CheckOnClick = true;
            this.mShowLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mShowLines.Name = "mShowLines";
            this.mShowLines.Size = new System.Drawing.Size(212, 22);
            this.mShowLines.Text = "Lines";
            this.mShowLines.CheckedChanged += new System.EventHandler(this.OnRepaintEvent);
            // 
            // mShowMarkers
            // 
            this.mShowMarkers.Checked = true;
            this.mShowMarkers.CheckOnClick = true;
            this.mShowMarkers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mShowMarkers.Name = "mShowMarkers";
            this.mShowMarkers.Size = new System.Drawing.Size(212, 22);
            this.mShowMarkers.Text = "Markers";
            this.mShowMarkers.CheckedChanged += new System.EventHandler(this.OnRepaintEvent);
            // 
            // mShowWingsuits
            // 
            this.mShowWingsuits.CheckOnClick = true;
            this.mShowWingsuits.Name = "mShowWingsuits";
            this.mShowWingsuits.Size = new System.Drawing.Size(212, 22);
            this.mShowWingsuits.Text = "Wingsuits";
            this.mShowWingsuits.CheckedChanged += new System.EventHandler(this.OnShowWingsuitChangedEvent);
            // 
            // mShowPhoto
            // 
            this.mShowPhoto.Checked = true;
            this.mShowPhoto.CheckOnClick = true;
            this.mShowPhoto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mShowPhoto.Name = "mShowPhoto";
            this.mShowPhoto.Size = new System.Drawing.Size(212, 22);
            this.mShowPhoto.Text = "Background photo";
            this.mShowPhoto.CheckedChanged += new System.EventHandler(this.OnRepaintEvent);
            // 
            // mShowFlightZones
            // 
            this.mShowFlightZones.Checked = true;
            this.mShowFlightZones.CheckOnClick = true;
            this.mShowFlightZones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mShowFlightZones.Name = "mShowFlightZones";
            this.mShowFlightZones.Size = new System.Drawing.Size(212, 22);
            this.mShowFlightZones.Text = "Flight Zones";
            this.mShowFlightZones.CheckedChanged += new System.EventHandler(this.OnRepaintEvent);
            // 
            // mShowDots
            // 
            this.mShowDots.CheckOnClick = true;
            this.mShowDots.Name = "mShowDots";
            this.mShowDots.Size = new System.Drawing.Size(212, 22);
            this.mShowDots.Text = "Dots";
            this.mShowDots.CheckedChanged += new System.EventHandler(this.OnShowDotChangedEvent);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(209, 6);
            // 
            // mBackgroundColorToolStripMenuItem
            // 
            this.mBackgroundColorToolStripMenuItem.Name = "mBackgroundColorToolStripMenuItem";
            this.mBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.mBackgroundColorToolStripMenuItem.Text = "Change background color";
            this.mBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.OnColorPickerClick);
            // 
            // mLineColorMenuItem
            // 
            this.mLineColorMenuItem.Name = "mLineColorMenuItem";
            this.mLineColorMenuItem.Size = new System.Drawing.Size(212, 22);
            this.mLineColorMenuItem.Text = "Change line colors";
            this.mLineColorMenuItem.Click += new System.EventHandler(this.OnLineColorClick);
            // 
            // mWingsuitColorsToolStripMenuItem
            // 
            this.mWingsuitColorsToolStripMenuItem.Name = "mWingsuitColorsToolStripMenuItem";
            this.mWingsuitColorsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.mWingsuitColorsToolStripMenuItem.Text = "Change wingsuit colors";
            this.mWingsuitColorsToolStripMenuItem.Click += new System.EventHandler(this.OnWingsuitColorsClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Enabled = false;
            this.indexToolStripMenuItem.Image = global::Flock.Properties.Resources.help;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(104, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutClick);
            // 
            // mMenuPanel
            // 
            this.mMenuPanel.Controls.Add(this.mDotBox);
            this.mMenuPanel.Controls.Add(this.mSizeBox);
            this.mMenuPanel.Controls.Add(this.mAdvert);
            this.mMenuPanel.Controls.Add(this.mFormationTools);
            this.mMenuPanel.Controls.Add(this.mImageTools);
            this.mMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mMenuPanel.Location = new System.Drawing.Point(0, 24);
            this.mMenuPanel.Name = "mMenuPanel";
            this.mMenuPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mMenuPanel.Size = new System.Drawing.Size(116, 684);
            this.mMenuPanel.TabIndex = 6;
            // 
            // mDotBox
            // 
            this.mDotBox.Controls.Add(this.mDotDistance);
            this.mDotBox.Controls.Add(this.mDotSize);
            this.mDotBox.Controls.Add(this.mDotCount);
            this.mDotBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.mDotBox.Location = new System.Drawing.Point(3, 241);
            this.mDotBox.Name = "mDotBox";
            this.mDotBox.Size = new System.Drawing.Size(110, 127);
            this.mDotBox.TabIndex = 11;
            this.mDotBox.TabStop = false;
            this.mDotBox.Text = "Dotting";
            // 
            // mDotDistance
            // 
            this.mDotDistance.LargeChange = 100;
            this.mDotDistance.Location = new System.Drawing.Point(56, 42);
            this.mDotDistance.Maximum = 500;
            this.mDotDistance.Minimum = 100;
            this.mDotDistance.Name = "mDotDistance";
            this.mDotDistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mDotDistance.Size = new System.Drawing.Size(45, 79);
            this.mDotDistance.TabIndex = 3;
            this.mDotDistance.TickFrequency = 100;
            this.mDotDistance.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.mDotDistance.Value = 250;
            this.mDotDistance.Scroll += new System.EventHandler(this.OnDotSettingChanged);
            // 
            // mDotSize
            // 
            this.mDotSize.LargeChange = 10;
            this.mDotSize.Location = new System.Drawing.Point(8, 42);
            this.mDotSize.Maximum = 200;
            this.mDotSize.Minimum = 40;
            this.mDotSize.Name = "mDotSize";
            this.mDotSize.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mDotSize.Size = new System.Drawing.Size(45, 79);
            this.mDotSize.TabIndex = 2;
            this.mDotSize.TickFrequency = 20;
            this.mDotSize.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.mDotSize.Value = 80;
            this.mDotSize.Scroll += new System.EventHandler(this.OnDotSettingChanged);
            // 
            // mDotCount
            // 
            this.mDotCount.Location = new System.Drawing.Point(9, 19);
            this.mDotCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mDotCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mDotCount.Name = "mDotCount";
            this.mDotCount.Size = new System.Drawing.Size(91, 20);
            this.mDotCount.TabIndex = 1;
            this.mDotCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mDotCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.mDotCount.ValueChanged += new System.EventHandler(this.OnDotSettingChanged);
            // 
            // mSizeBox
            // 
            this.mSizeBox.Controls.Add(this.mWingsuitSize);
            this.mSizeBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.mSizeBox.Location = new System.Drawing.Point(3, 191);
            this.mSizeBox.Name = "mSizeBox";
            this.mSizeBox.Size = new System.Drawing.Size(110, 50);
            this.mSizeBox.TabIndex = 10;
            this.mSizeBox.TabStop = false;
            this.mSizeBox.Text = "Wingsuit Size";
            this.mSizeBox.Visible = false;
            // 
            // mWingsuitSize
            // 
            this.mWingsuitSize.Location = new System.Drawing.Point(9, 19);
            this.mWingsuitSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mWingsuitSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mWingsuitSize.Name = "mWingsuitSize";
            this.mWingsuitSize.Size = new System.Drawing.Size(91, 20);
            this.mWingsuitSize.TabIndex = 0;
            this.mWingsuitSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mWingsuitSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.mWingsuitSize.ValueChanged += new System.EventHandler(this.OnWingsuitSizeValueChanged);
            // 
            // mAdvert
            // 
            this.mAdvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mAdvert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mAdvert.Image = global::Flock.Properties.Resources.banner01;
            this.mAdvert.InitialImage = null;
            this.mAdvert.Location = new System.Drawing.Point(13, 374);
            this.mAdvert.Name = "mAdvert";
            this.mAdvert.Size = new System.Drawing.Size(90, 300);
            this.mAdvert.TabIndex = 9;
            this.mAdvert.TabStop = false;
            // 
            // mFormationTools
            // 
            this.mFormationTools.Controls.Add(this.mBtnFreeTransform);
            this.mFormationTools.Controls.Add(this.mBtnRemoveLine);
            this.mFormationTools.Controls.Add(this.mBtnAddLine);
            this.mFormationTools.Controls.Add(this.mBtnMoveMarker);
            this.mFormationTools.Controls.Add(this.mBtnRemoveMarker);
            this.mFormationTools.Controls.Add(this.mBtnAddMarker);
            this.mFormationTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mFormationTools.Location = new System.Drawing.Point(3, 97);
            this.mFormationTools.Name = "mFormationTools";
            this.mFormationTools.Size = new System.Drawing.Size(110, 94);
            this.mFormationTools.TabIndex = 7;
            this.mFormationTools.TabStop = false;
            this.mFormationTools.Text = "Formation Tools";
            // 
            // mBtnFreeTransform
            // 
            this.mBtnFreeTransform.Checked = false;
            this.mBtnFreeTransform.Image = global::Flock.Properties.Resources.move_formation;
            this.mBtnFreeTransform.Location = new System.Drawing.Point(73, 53);
            this.mBtnFreeTransform.Name = "mBtnFreeTransform";
            this.mBtnFreeTransform.Size = new System.Drawing.Size(33, 33);
            this.mBtnFreeTransform.TabIndex = 13;
            this.mBtnFreeTransform.Tooltip = "Free transform formation [c]";
            this.mBtnFreeTransform.Click += new System.EventHandler(this.OnTransformClick);
            // 
            // mBtnRemoveLine
            // 
            this.mBtnRemoveLine.Checked = false;
            this.mBtnRemoveLine.Image = global::Flock.Properties.Resources.remove_line;
            this.mBtnRemoveLine.Location = new System.Drawing.Point(39, 53);
            this.mBtnRemoveLine.Name = "mBtnRemoveLine";
            this.mBtnRemoveLine.Size = new System.Drawing.Size(33, 33);
            this.mBtnRemoveLine.TabIndex = 10;
            this.mBtnRemoveLine.Tooltip = "Remove line [x]";
            this.mBtnRemoveLine.Click += new System.EventHandler(this.OnRemoveLineClick);
            // 
            // mBtnAddLine
            // 
            this.mBtnAddLine.Checked = false;
            this.mBtnAddLine.Image = global::Flock.Properties.Resources.add_line;
            this.mBtnAddLine.Location = new System.Drawing.Point(5, 53);
            this.mBtnAddLine.Name = "mBtnAddLine";
            this.mBtnAddLine.Size = new System.Drawing.Size(33, 33);
            this.mBtnAddLine.TabIndex = 9;
            this.mBtnAddLine.Tooltip = "Add line [z]";
            this.mBtnAddLine.Click += new System.EventHandler(this.OnAddLineClick);
            // 
            // mBtnMoveMarker
            // 
            this.mBtnMoveMarker.Checked = false;
            this.mBtnMoveMarker.Image = global::Flock.Properties.Resources.move_marker;
            this.mBtnMoveMarker.Location = new System.Drawing.Point(73, 19);
            this.mBtnMoveMarker.Name = "mBtnMoveMarker";
            this.mBtnMoveMarker.Size = new System.Drawing.Size(33, 33);
            this.mBtnMoveMarker.TabIndex = 8;
            this.mBtnMoveMarker.Tooltip = "Move marker [d]";
            this.mBtnMoveMarker.Click += new System.EventHandler(this.OnMoveMarkerClick);
            // 
            // mBtnRemoveMarker
            // 
            this.mBtnRemoveMarker.Checked = false;
            this.mBtnRemoveMarker.Image = global::Flock.Properties.Resources.remove_marker;
            this.mBtnRemoveMarker.Location = new System.Drawing.Point(39, 19);
            this.mBtnRemoveMarker.Name = "mBtnRemoveMarker";
            this.mBtnRemoveMarker.Size = new System.Drawing.Size(33, 33);
            this.mBtnRemoveMarker.TabIndex = 7;
            this.mBtnRemoveMarker.Tooltip = "Remove marker [s]";
            this.mBtnRemoveMarker.Click += new System.EventHandler(this.OnRemoveMarkerClick);
            // 
            // mBtnAddMarker
            // 
            this.mBtnAddMarker.Checked = false;
            this.mBtnAddMarker.Image = global::Flock.Properties.Resources.add_marker;
            this.mBtnAddMarker.Location = new System.Drawing.Point(5, 19);
            this.mBtnAddMarker.Name = "mBtnAddMarker";
            this.mBtnAddMarker.Size = new System.Drawing.Size(33, 33);
            this.mBtnAddMarker.TabIndex = 6;
            this.mBtnAddMarker.Tooltip = "Add marker [a]";
            this.mBtnAddMarker.Click += new System.EventHandler(this.OnAddMarkerClick);
            // 
            // mImageTools
            // 
            this.mImageTools.Controls.Add(this.mBtnInvertPhoto);
            this.mImageTools.Controls.Add(this.mBtnCenterImage);
            this.mImageTools.Controls.Add(this.mBtnMoveImage);
            this.mImageTools.Controls.Add(this.mBtnZoomOut);
            this.mImageTools.Controls.Add(this.mBtnZoomIn);
            this.mImageTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mImageTools.Location = new System.Drawing.Point(3, 3);
            this.mImageTools.Name = "mImageTools";
            this.mImageTools.Size = new System.Drawing.Size(110, 94);
            this.mImageTools.TabIndex = 6;
            this.mImageTools.TabStop = false;
            this.mImageTools.Text = "Image Tools";
            // 
            // mBtnInvertPhoto
            // 
            this.mBtnInvertPhoto.Checked = false;
            this.mBtnInvertPhoto.Image = global::Flock.Properties.Resources.invert_photo;
            this.mBtnInvertPhoto.Location = new System.Drawing.Point(39, 53);
            this.mBtnInvertPhoto.Name = "mBtnInvertPhoto";
            this.mBtnInvertPhoto.Size = new System.Drawing.Size(33, 33);
            this.mBtnInvertPhoto.TabIndex = 9;
            this.mBtnInvertPhoto.Tooltip = "Invert photo";
            this.mBtnInvertPhoto.Click += new System.EventHandler(this.OnInvertPhotoClick);
            // 
            // mBtnCenterImage
            // 
            this.mBtnCenterImage.Checked = false;
            this.mBtnCenterImage.Image = global::Flock.Properties.Resources.fit_to_screen;
            this.mBtnCenterImage.Location = new System.Drawing.Point(5, 53);
            this.mBtnCenterImage.Name = "mBtnCenterImage";
            this.mBtnCenterImage.Size = new System.Drawing.Size(33, 33);
            this.mBtnCenterImage.TabIndex = 6;
            this.mBtnCenterImage.Tooltip = "Fit to screen";
            this.mBtnCenterImage.Click += new System.EventHandler(this.OnCenterImageClick);
            // 
            // mBtnMoveImage
            // 
            this.mBtnMoveImage.Checked = false;
            this.mBtnMoveImage.Image = global::Flock.Properties.Resources.move_canvas;
            this.mBtnMoveImage.Location = new System.Drawing.Point(73, 19);
            this.mBtnMoveImage.Name = "mBtnMoveImage";
            this.mBtnMoveImage.Size = new System.Drawing.Size(33, 33);
            this.mBtnMoveImage.TabIndex = 5;
            this.mBtnMoveImage.Tooltip = "Move canvas [m]";
            this.mBtnMoveImage.Click += new System.EventHandler(this.OnMoveImageClick);
            // 
            // mBtnZoomOut
            // 
            this.mBtnZoomOut.Checked = false;
            this.mBtnZoomOut.Image = global::Flock.Properties.Resources.zoom_out;
            this.mBtnZoomOut.Location = new System.Drawing.Point(39, 19);
            this.mBtnZoomOut.Name = "mBtnZoomOut";
            this.mBtnZoomOut.Size = new System.Drawing.Size(33, 33);
            this.mBtnZoomOut.TabIndex = 4;
            this.mBtnZoomOut.Tooltip = "Zoom out";
            this.mBtnZoomOut.DoubleClick += new System.EventHandler(this.OnZoomOutClick);
            this.mBtnZoomOut.Click += new System.EventHandler(this.OnZoomOutClick);
            // 
            // mBtnZoomIn
            // 
            this.mBtnZoomIn.Checked = false;
            this.mBtnZoomIn.Image = global::Flock.Properties.Resources.zoom_in;
            this.mBtnZoomIn.Location = new System.Drawing.Point(5, 19);
            this.mBtnZoomIn.Name = "mBtnZoomIn";
            this.mBtnZoomIn.Size = new System.Drawing.Size(33, 33);
            this.mBtnZoomIn.TabIndex = 3;
            this.mBtnZoomIn.Tooltip = "Zoom in";
            this.mBtnZoomIn.DoubleClick += new System.EventHandler(this.OnZoomInClick);
            this.mBtnZoomIn.Click += new System.EventHandler(this.OnZoomInClick);
            // 
            // mPictureBox
            // 
            this.mPictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.mPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPictureBox.Location = new System.Drawing.Point(116, 24);
            this.mPictureBox.MoveMode = false;
            this.mPictureBox.Name = "mPictureBox";
            this.mPictureBox.Origin = ((System.Drawing.PointF)(resources.GetObject("mPictureBox.Origin")));
            this.mPictureBox.Size = new System.Drawing.Size(892, 684);
            this.mPictureBox.TabIndex = 7;
            this.mPictureBox.Zoom = 100F;
            this.mPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPictureBoxPaint);
            this.mPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseMove);
            this.mPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseClick);
            this.mPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseDown);
            this.mPictureBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.mPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.mPictureBox);
            this.Controls.Add(this.mMenuPanel);
            this.Controls.Add(this.mStatusBar);
            this.Controls.Add(this.mMainMenu);
            this.MainMenuStrip = this.mMainMenu;
            this.MinimumSize = new System.Drawing.Size(260, 768);
            this.Name = "Form1";
            this.Text = "Flock Briefing Tool";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.mStatusBar.ResumeLayout(false);
            this.mStatusBar.PerformLayout();
            this.mMainMenu.ResumeLayout(false);
            this.mMainMenu.PerformLayout();
            this.mMenuPanel.ResumeLayout(false);
            this.mDotBox.ResumeLayout(false);
            this.mDotBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDotDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDotSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDotCount)).EndInit();
            this.mSizeBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mWingsuitSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAdvert)).EndInit();
            this.mFormationTools.ResumeLayout(false);
            this.mImageTools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel mZoomText;
        private System.Windows.Forms.MenuStrip mMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFormationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFormationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel mMenuPanel;
        private ImagePanel mPictureBox;
        private System.Windows.Forms.GroupBox mImageTools;
        private CheckButton mBtnMoveImage;
        private CheckButton mBtnZoomOut;
        private CheckButton mBtnZoomIn;
        private System.Windows.Forms.GroupBox mFormationTools;
        private CheckButton mBtnMoveMarker;
        private CheckButton mBtnRemoveMarker;
        private CheckButton mBtnAddMarker;
        private CheckButton mBtnRemoveLine;
        private CheckButton mBtnAddLine;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel mAccuracy;
        private System.Windows.Forms.ToolStripMenuItem resetPhotoToolStripMenuItem;
        private CheckButton mBtnCenterImage;
        private System.Windows.Forms.PictureBox mAdvert;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel mCopyright;
        private CheckButton mBtnFreeTransform;
        private CheckButton mBtnInvertPhoto;
        private System.Windows.Forms.ToolStripMenuItem mDisplayMenu;
        private System.Windows.Forms.ToolStripMenuItem mShowLines;
        private System.Windows.Forms.ToolStripMenuItem mShowMarkers;
        private System.Windows.Forms.ToolStripMenuItem mShowWingsuits;
        private System.Windows.Forms.ToolStripMenuItem mShowPhoto;
        private System.Windows.Forms.ToolStripMenuItem mShowFlightZones;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem mBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mLineColorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mWingsuitColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem printMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.GroupBox mSizeBox;
        private System.Windows.Forms.NumericUpDown mWingsuitSize;
        private System.Windows.Forms.ToolStripMenuItem mShowDots;
        private System.Windows.Forms.GroupBox mDotBox;
        private System.Windows.Forms.TrackBar mDotSize;
        private System.Windows.Forms.NumericUpDown mDotCount;
        private System.Windows.Forms.TrackBar mDotDistance;
    }
}

