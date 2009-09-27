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
            this.mMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFormationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMenuPanel = new System.Windows.Forms.Panel();
            this.mJudgingTools = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mDistanceTolerance = new System.Windows.Forms.NumericUpDown();
            this.mFormationTools = new System.Windows.Forms.GroupBox();
            this.mBtnRemoveLine = new WingSuitJudge.CheckButton();
            this.mBtnAddLine = new WingSuitJudge.CheckButton();
            this.mBtnMoveMarker = new WingSuitJudge.CheckButton();
            this.mBtnRemoveMarker = new WingSuitJudge.CheckButton();
            this.mBtnAddMarker = new WingSuitJudge.CheckButton();
            this.mImageTools = new System.Windows.Forms.GroupBox();
            this.mBtnMoveImage = new WingSuitJudge.CheckButton();
            this.mBtnZoomOut = new WingSuitJudge.CheckButton();
            this.mBtnZoomIn = new WingSuitJudge.CheckButton();
            this.mPictureBox = new WingSuitJudge.ImagePanel();
            this.mAccuracy = new System.Windows.Forms.ToolStripStatusLabel();
            this.mStatusBar.SuspendLayout();
            this.mMainMenu.SuspendLayout();
            this.mMenuPanel.SuspendLayout();
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
            this.mAccuracy});
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
            // mMainMenu
            // 
            this.mMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
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
            this.importPhotoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.importPhotoToolStripMenuItem.Text = "Import photo";
            this.importPhotoToolStripMenuItem.Click += new System.EventHandler(this.OnImportImageClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewClick);
            // 
            // openFormationToolStripMenuItem
            // 
            this.openFormationToolStripMenuItem.Name = "openFormationToolStripMenuItem";
            this.openFormationToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.openFormationToolStripMenuItem.Text = "&Open...";
            this.openFormationToolStripMenuItem.Click += new System.EventHandler(this.OnOpenClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // saveFormationToolStripMenuItem
            // 
            this.saveFormationToolStripMenuItem.Name = "saveFormationToolStripMenuItem";
            this.saveFormationToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveFormationToolStripMenuItem.Text = "&Save...";
            this.saveFormationToolStripMenuItem.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.OnSaveAsClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
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
            // mJudgingTools
            // 
            this.mJudgingTools.Controls.Add(this.label3);
            this.mJudgingTools.Controls.Add(this.label1);
            this.mJudgingTools.Controls.Add(this.mDistanceTolerance);
            this.mJudgingTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mJudgingTools.Location = new System.Drawing.Point(3, 162);
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
            // 
            // mFormationTools
            // 
            this.mFormationTools.Controls.Add(this.mBtnRemoveLine);
            this.mFormationTools.Controls.Add(this.mBtnAddLine);
            this.mFormationTools.Controls.Add(this.mBtnMoveMarker);
            this.mFormationTools.Controls.Add(this.mBtnRemoveMarker);
            this.mFormationTools.Controls.Add(this.mBtnAddMarker);
            this.mFormationTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mFormationTools.Location = new System.Drawing.Point(3, 62);
            this.mFormationTools.Name = "mFormationTools";
            this.mFormationTools.Size = new System.Drawing.Size(110, 100);
            this.mFormationTools.TabIndex = 7;
            this.mFormationTools.TabStop = false;
            this.mFormationTools.Text = "Formation Tools";
            // 
            // mBtnRemoveLine
            // 
            this.mBtnRemoveLine.Checked = false;
            this.mBtnRemoveLine.Image = global::WingSuitJudge.Properties.Resources.vector_delete;
            this.mBtnRemoveLine.Location = new System.Drawing.Point(40, 52);
            this.mBtnRemoveLine.Name = "mBtnRemoveLine";
            this.mBtnRemoveLine.Size = new System.Drawing.Size(28, 27);
            this.mBtnRemoveLine.TabIndex = 10;
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
            this.mBtnAddMarker.Click += new System.EventHandler(this.OnAddMarkerClick);
            // 
            // mImageTools
            // 
            this.mImageTools.Controls.Add(this.mBtnMoveImage);
            this.mImageTools.Controls.Add(this.mBtnZoomOut);
            this.mImageTools.Controls.Add(this.mBtnZoomIn);
            this.mImageTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.mImageTools.Location = new System.Drawing.Point(3, 3);
            this.mImageTools.Name = "mImageTools";
            this.mImageTools.Size = new System.Drawing.Size(110, 59);
            this.mImageTools.TabIndex = 6;
            this.mImageTools.TabStop = false;
            this.mImageTools.Text = "Image Tools";
            // 
            // mBtnMoveImage
            // 
            this.mBtnMoveImage.Checked = false;
            this.mBtnMoveImage.Image = global::WingSuitJudge.Properties.Resources.arrow_out;
            this.mBtnMoveImage.Location = new System.Drawing.Point(74, 19);
            this.mBtnMoveImage.Name = "mBtnMoveImage";
            this.mBtnMoveImage.Size = new System.Drawing.Size(28, 27);
            this.mBtnMoveImage.TabIndex = 5;
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
            this.mBtnZoomIn.DoubleClick += new System.EventHandler(this.OnZoomInClick);
            this.mBtnZoomIn.Click += new System.EventHandler(this.OnZoomInClick);
            // 
            // mPictureBox
            // 
            this.mPictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
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
            // 
            // mAccuracy
            // 
            this.mAccuracy.AutoSize = false;
            this.mAccuracy.Name = "mAccuracy";
            this.mAccuracy.Size = new System.Drawing.Size(100, 17);
            this.mAccuracy.Text = "Accuracy: ??";
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
            this.Text = "Wingsuit Flock Judging Tool v1.01";
            this.mStatusBar.ResumeLayout(false);
            this.mStatusBar.PerformLayout();
            this.mMainMenu.ResumeLayout(false);
            this.mMainMenu.PerformLayout();
            this.mMenuPanel.ResumeLayout(false);
            this.mJudgingTools.ResumeLayout(false);
            this.mJudgingTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDistanceTolerance)).EndInit();
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
    }
}

