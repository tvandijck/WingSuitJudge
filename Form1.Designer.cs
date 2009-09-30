namespace WingSuitJudge
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
            this.importPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMenuPanel = new System.Windows.Forms.Panel();
            this.mAdvert = new System.Windows.Forms.PictureBox();
            this.mJudgingTools = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mDistanceTolerance = new System.Windows.Forms.NumericUpDown();
            this.mFormationTools = new System.Windows.Forms.GroupBox();
            this.mBtnFreeTransform = new WingSuitJudge.CheckButton();
            this.mHideFormation = new System.Windows.Forms.CheckBox();
            this.mBtnRemoveLine = new WingSuitJudge.CheckButton();
            this.mBtnAddLine = new WingSuitJudge.CheckButton();
            this.mBtnMoveMarker = new WingSuitJudge.CheckButton();
            this.mBtnRemoveMarker = new WingSuitJudge.CheckButton();
            this.mBtnAddMarker = new WingSuitJudge.CheckButton();
            this.mImageTools = new System.Windows.Forms.GroupBox();
            this.mColorPicker = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.mBtnCenterImage = new WingSuitJudge.CheckButton();
            this.mBtnMoveImage = new WingSuitJudge.CheckButton();
            this.mBtnZoomOut = new WingSuitJudge.CheckButton();
            this.mBtnZoomIn = new WingSuitJudge.CheckButton();
            this.mPictureBox = new WingSuitJudge.ImagePanel();
            this.mStatusBar.SuspendLayout();
            this.mMainMenu.SuspendLayout();
            this.mMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mAdvert)).BeginInit();
            this.mJudgingTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDistanceTolerance)).BeginInit();
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
            this.mStatusBar.Location = new System.Drawing.Point(0, 829);
            this.mStatusBar.Name = "mStatusBar";
            this.mStatusBar.Size = new System.Drawing.Size(1116, 22);
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
            this.mCopyright.Size = new System.Drawing.Size(901, 17);
            this.mCopyright.Spring = true;
            this.mCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mMainMenu
            // 
            this.mMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem5,
            this.helpToolStripMenuItem});
            this.mMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mMainMenu.Name = "mMainMenu";
            this.mMainMenu.Size = new System.Drawing.Size(1116, 24);
            this.mMainMenu.TabIndex = 5;
            this.mMainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPhotoToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem1,
            this.newToolStripMenuItem,
            this.openFormationToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveFormationToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importPhotoToolStripMenuItem
            // 
            this.importPhotoToolStripMenuItem.Name = "importPhotoToolStripMenuItem";
            this.importPhotoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importPhotoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.importPhotoToolStripMenuItem.Text = "Import photo...";
            this.importPhotoToolStripMenuItem.Click += new System.EventHandler(this.OnImportImageClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItem4.Text = "Reset photo";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.OnResetPhotoClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewClick);
            // 
            // openFormationToolStripMenuItem
            // 
            this.openFormationToolStripMenuItem.Name = "openFormationToolStripMenuItem";
            this.openFormationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFormationToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openFormationToolStripMenuItem.Text = "&Open...";
            this.openFormationToolStripMenuItem.Click += new System.EventHandler(this.OnOpenClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // saveFormationToolStripMenuItem
            // 
            this.saveFormationToolStripMenuItem.Name = "saveFormationToolStripMenuItem";
            this.saveFormationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFormationToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveFormationToolStripMenuItem.Text = "&Save...";
            this.saveFormationToolStripMenuItem.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.OnSaveAsClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(188, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.toolStripMenuItem6,
            this.propertiesToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItem5.Text = "&Project";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exportToolStripMenuItem.Text = "&Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.OnExportClick);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(133, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.propertiesToolStripMenuItem.Text = "Jump info...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.OnJumpInfoClick);
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
            this.mMenuPanel.Controls.Add(this.mAdvert);
            this.mMenuPanel.Controls.Add(this.mJudgingTools);
            this.mMenuPanel.Controls.Add(this.mFormationTools);
            this.mMenuPanel.Controls.Add(this.mImageTools);
            this.mMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mMenuPanel.Location = new System.Drawing.Point(0, 24);
            this.mMenuPanel.Name = "mMenuPanel";
            this.mMenuPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mMenuPanel.Size = new System.Drawing.Size(116, 805);
            this.mMenuPanel.TabIndex = 6;
            // 
            // mAdvert
            // 
            this.mAdvert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mAdvert.Location = new System.Drawing.Point(13, 495);
            this.mAdvert.Name = "mAdvert";
            this.mAdvert.Size = new System.Drawing.Size(90, 300);
            this.mAdvert.TabIndex = 9;
            this.mAdvert.TabStop = false;
            // 
            // mJudgingTools
            // 
            this.mJudgingTools.Controls.Add(this.label3);
            this.mJudgingTools.Controls.Add(this.label1);
            this.mJudgingTools.Controls.Add(this.mDistanceTolerance);
            this.mJudgingTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mJudgingTools.Location = new System.Drawing.Point(3, 247);
            this.mJudgingTools.Name = "mJudgingTools";
            this.mJudgingTools.Size = new System.Drawing.Size(110, 78);
            this.mJudgingTools.TabIndex = 8;
            this.mJudgingTools.TabStop = false;
            this.mJudgingTools.Text = "Judging Tools";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Distance tolerance:";
            // 
            // mDistanceTolerance
            // 
            this.mDistanceTolerance.Location = new System.Drawing.Point(6, 43);
            this.mDistanceTolerance.Name = "mDistanceTolerance";
            this.mDistanceTolerance.Size = new System.Drawing.Size(81, 20);
            this.mDistanceTolerance.TabIndex = 0;
            this.mDistanceTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mDistanceTolerance.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.mDistanceTolerance.ValueChanged += new System.EventHandler(this.OnDistanceToleranceValueChanged);
            // 
            // mFormationTools
            // 
            this.mFormationTools.Controls.Add(this.mBtnFreeTransform);
            this.mFormationTools.Controls.Add(this.mHideFormation);
            this.mFormationTools.Controls.Add(this.mBtnRemoveLine);
            this.mFormationTools.Controls.Add(this.mBtnAddLine);
            this.mFormationTools.Controls.Add(this.mBtnMoveMarker);
            this.mFormationTools.Controls.Add(this.mBtnRemoveMarker);
            this.mFormationTools.Controls.Add(this.mBtnAddMarker);
            this.mFormationTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mFormationTools.Location = new System.Drawing.Point(3, 135);
            this.mFormationTools.Name = "mFormationTools";
            this.mFormationTools.Size = new System.Drawing.Size(110, 112);
            this.mFormationTools.TabIndex = 7;
            this.mFormationTools.TabStop = false;
            this.mFormationTools.Text = "Formation Tools";
            // 
            // mBtnFreeTransform
            // 
            this.mBtnFreeTransform.Checked = false;
            this.mBtnFreeTransform.Image = ((System.Drawing.Image)(resources.GetObject("mBtnFreeTransform.Image")));
            this.mBtnFreeTransform.Location = new System.Drawing.Point(74, 53);
            this.mBtnFreeTransform.Name = "mBtnFreeTransform";
            this.mBtnFreeTransform.Size = new System.Drawing.Size(28, 27);
            this.mBtnFreeTransform.TabIndex = 13;
            this.mBtnFreeTransform.Tooltip = "Free transform formation";
            this.mBtnFreeTransform.Click += new System.EventHandler(this.mFreeTransform_Click);
            // 
            // mHideFormation
            // 
            this.mHideFormation.AutoSize = true;
            this.mHideFormation.Location = new System.Drawing.Point(11, 86);
            this.mHideFormation.Name = "mHideFormation";
            this.mHideFormation.Size = new System.Drawing.Size(94, 17);
            this.mHideFormation.TabIndex = 12;
            this.mHideFormation.Text = "Hide formation";
            this.mHideFormation.UseVisualStyleBackColor = true;
            this.mHideFormation.CheckedChanged += new System.EventHandler(this.OnHideFormationCheckedChanged);
            // 
            // mBtnRemoveLine
            // 
            this.mBtnRemoveLine.Checked = false;
            this.mBtnRemoveLine.Image = global::WingSuitJudge.Properties.Resources.vector_delete;
            this.mBtnRemoveLine.Location = new System.Drawing.Point(40, 52);
            this.mBtnRemoveLine.Name = "mBtnRemoveLine";
            this.mBtnRemoveLine.Size = new System.Drawing.Size(28, 27);
            this.mBtnRemoveLine.TabIndex = 10;
            this.mBtnRemoveLine.Tooltip = "Remove line";
            this.mBtnRemoveLine.Click += new System.EventHandler(this.OnRemoveLineClick);
            // 
            // mBtnAddLine
            // 
            this.mBtnAddLine.Checked = false;
            this.mBtnAddLine.Image = global::WingSuitJudge.Properties.Resources.vector_add;
            this.mBtnAddLine.Location = new System.Drawing.Point(6, 52);
            this.mBtnAddLine.Name = "mBtnAddLine";
            this.mBtnAddLine.Size = new System.Drawing.Size(28, 27);
            this.mBtnAddLine.TabIndex = 9;
            this.mBtnAddLine.Tooltip = "Add line";
            this.mBtnAddLine.Click += new System.EventHandler(this.OnAddLineClick);
            // 
            // mBtnMoveMarker
            // 
            this.mBtnMoveMarker.Checked = false;
            this.mBtnMoveMarker.Image = global::WingSuitJudge.Properties.Resources.mouse;
            this.mBtnMoveMarker.Location = new System.Drawing.Point(74, 19);
            this.mBtnMoveMarker.Name = "mBtnMoveMarker";
            this.mBtnMoveMarker.Size = new System.Drawing.Size(28, 27);
            this.mBtnMoveMarker.TabIndex = 8;
            this.mBtnMoveMarker.Tooltip = "Move marker";
            this.mBtnMoveMarker.Click += new System.EventHandler(this.OnMoveMarkerClick);
            // 
            // mBtnRemoveMarker
            // 
            this.mBtnRemoveMarker.Checked = false;
            this.mBtnRemoveMarker.Image = global::WingSuitJudge.Properties.Resources.delete;
            this.mBtnRemoveMarker.Location = new System.Drawing.Point(40, 19);
            this.mBtnRemoveMarker.Name = "mBtnRemoveMarker";
            this.mBtnRemoveMarker.Size = new System.Drawing.Size(28, 27);
            this.mBtnRemoveMarker.TabIndex = 7;
            this.mBtnRemoveMarker.Tooltip = "Remove marker";
            this.mBtnRemoveMarker.Click += new System.EventHandler(this.OnRemoveMarkerClick);
            // 
            // mBtnAddMarker
            // 
            this.mBtnAddMarker.Checked = false;
            this.mBtnAddMarker.Image = global::WingSuitJudge.Properties.Resources.add;
            this.mBtnAddMarker.Location = new System.Drawing.Point(6, 19);
            this.mBtnAddMarker.Name = "mBtnAddMarker";
            this.mBtnAddMarker.Size = new System.Drawing.Size(28, 27);
            this.mBtnAddMarker.TabIndex = 6;
            this.mBtnAddMarker.Tooltip = "Add marker";
            this.mBtnAddMarker.Click += new System.EventHandler(this.OnAddMarkerClick);
            // 
            // mImageTools
            // 
            this.mImageTools.Controls.Add(this.mColorPicker);
            this.mImageTools.Controls.Add(this.label2);
            this.mImageTools.Controls.Add(this.mBtnCenterImage);
            this.mImageTools.Controls.Add(this.mBtnMoveImage);
            this.mImageTools.Controls.Add(this.mBtnZoomOut);
            this.mImageTools.Controls.Add(this.mBtnZoomIn);
            this.mImageTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mImageTools.Location = new System.Drawing.Point(3, 3);
            this.mImageTools.Name = "mImageTools";
            this.mImageTools.Size = new System.Drawing.Size(110, 132);
            this.mImageTools.TabIndex = 6;
            this.mImageTools.TabStop = false;
            this.mImageTools.Text = "Image Tools";
            // 
            // mColorPicker
            // 
            this.mColorPicker.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mColorPicker.Location = new System.Drawing.Point(35, 101);
            this.mColorPicker.Name = "mColorPicker";
            this.mColorPicker.Size = new System.Drawing.Size(40, 23);
            this.mColorPicker.TabIndex = 8;
            this.mColorPicker.Click += new System.EventHandler(this.OnColorPickerClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Background color:";
            // 
            // mBtnCenterImage
            // 
            this.mBtnCenterImage.Checked = false;
            this.mBtnCenterImage.Image = global::WingSuitJudge.Properties.Resources.arrow_in;
            this.mBtnCenterImage.Location = new System.Drawing.Point(40, 52);
            this.mBtnCenterImage.Name = "mBtnCenterImage";
            this.mBtnCenterImage.Size = new System.Drawing.Size(28, 27);
            this.mBtnCenterImage.TabIndex = 6;
            this.mBtnCenterImage.Tooltip = "Fit to screen";
            this.mBtnCenterImage.Click += new System.EventHandler(this.OnCenterImageClick);
            // 
            // mBtnMoveImage
            // 
            this.mBtnMoveImage.Checked = false;
            this.mBtnMoveImage.Image = global::WingSuitJudge.Properties.Resources.arrow_out;
            this.mBtnMoveImage.Location = new System.Drawing.Point(74, 19);
            this.mBtnMoveImage.Name = "mBtnMoveImage";
            this.mBtnMoveImage.Size = new System.Drawing.Size(28, 27);
            this.mBtnMoveImage.TabIndex = 5;
            this.mBtnMoveImage.Tooltip = "Move canvas";
            this.mBtnMoveImage.Click += new System.EventHandler(this.OnMoveImageClick);
            // 
            // mBtnZoomOut
            // 
            this.mBtnZoomOut.Checked = false;
            this.mBtnZoomOut.Image = global::WingSuitJudge.Properties.Resources.zoom_out;
            this.mBtnZoomOut.Location = new System.Drawing.Point(40, 19);
            this.mBtnZoomOut.Name = "mBtnZoomOut";
            this.mBtnZoomOut.Size = new System.Drawing.Size(28, 27);
            this.mBtnZoomOut.TabIndex = 4;
            this.mBtnZoomOut.Tooltip = "Zoom out";
            this.mBtnZoomOut.DoubleClick += new System.EventHandler(this.OnZoomOutClick);
            this.mBtnZoomOut.Click += new System.EventHandler(this.OnZoomOutClick);
            // 
            // mBtnZoomIn
            // 
            this.mBtnZoomIn.Checked = false;
            this.mBtnZoomIn.Image = global::WingSuitJudge.Properties.Resources.zoom_in;
            this.mBtnZoomIn.Location = new System.Drawing.Point(6, 19);
            this.mBtnZoomIn.Name = "mBtnZoomIn";
            this.mBtnZoomIn.Size = new System.Drawing.Size(28, 27);
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
            this.mPictureBox.Size = new System.Drawing.Size(1000, 805);
            this.mPictureBox.TabIndex = 7;
            this.mPictureBox.Zoom = 100;
            this.mPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPictureBoxPaint);
            this.mPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseMove);
            this.mPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseClick);
            this.mPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseDown);
            this.mPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 851);
            this.Controls.Add(this.mPictureBox);
            this.Controls.Add(this.mMenuPanel);
            this.Controls.Add(this.mStatusBar);
            this.Controls.Add(this.mMainMenu);
            this.Name = "Form1";
            this.Text = "Wingsuit Flock Judging Tool";
            this.mStatusBar.ResumeLayout(false);
            this.mStatusBar.PerformLayout();
            this.mMainMenu.ResumeLayout(false);
            this.mMainMenu.PerformLayout();
            this.mMenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mAdvert)).EndInit();
            this.mJudgingTools.ResumeLayout(false);
            this.mJudgingTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDistanceTolerance)).EndInit();
            this.mFormationTools.ResumeLayout(false);
            this.mFormationTools.PerformLayout();
            this.mImageTools.ResumeLayout(false);
            this.mImageTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel mZoomText;
        private System.Windows.Forms.MenuStrip mMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
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
        private System.Windows.Forms.GroupBox mJudgingTools;
        private CheckButton mBtnRemoveLine;
        private CheckButton mBtnAddLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown mDistanceTolerance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel mAccuracy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private CheckButton mBtnCenterImage;
        private System.Windows.Forms.Panel mColorPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox mAdvert;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel mCopyright;
        private System.Windows.Forms.CheckBox mHideFormation;
        private CheckButton mBtnFreeTransform;
    }
}

