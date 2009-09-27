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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mZoomText = new System.Windows.Forms.ToolStripStatusLabel();
            this.mPictureBox = new WingSuitJudge.ImagePanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnMoveImage = new System.Windows.Forms.ToolStripButton();
            this.btnAddMarker = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveMarker = new System.Windows.Forms.ToolStripButton();
            this.btnMoveMarker = new System.Windows.Forms.ToolStripButton();
            this.btnAddLine = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mPictureBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1084, 805);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1116, 851);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainMenu);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mZoomText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1116, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mZoomText
            // 
            this.mZoomText.Name = "mZoomText";
            this.mZoomText.Size = new System.Drawing.Size(73, 17);
            this.mZoomText.Text = "Zoom: 100%";
            // 
            // mPictureBox
            // 
            this.mPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mPictureBox.MoveMode = false;
            this.mPictureBox.Name = "mPictureBox";
            this.mPictureBox.Origin = ((System.Drawing.PointF)(resources.GetObject("mPictureBox.Origin")));
            this.mPictureBox.Size = new System.Drawing.Size(1084, 805);
            this.mPictureBox.TabIndex = 0;
            this.mPictureBox.Zoom = 100;
            this.mPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPictureBoxPaint);
            this.mPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseMove);
            this.mPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnMoveImage,
            this.btnAddMarker,
            this.btnRemoveMarker,
            this.btnMoveMarker,
            this.btnAddLine,
            this.btnRemoveLine});
            this.toolStrip.Location = new System.Drawing.Point(0, 6);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(32, 214);
            this.toolStrip.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1116, 24);
            this.mainMenu.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OnFileOpenClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "Index";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = global::WingSuitJudge.Properties.Resources.zoom_in;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(30, 20);
            this.btnZoomIn.Text = "Zoom in";
            this.btnZoomIn.ToolTipText = "Zoom in (10%)";
            this.btnZoomIn.Click += new System.EventHandler(this.OnZoomInClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = global::WingSuitJudge.Properties.Resources.zoom_out;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(30, 20);
            this.btnZoomOut.Text = "Zoom out";
            this.btnZoomOut.ToolTipText = "Zoom out (10%)";
            this.btnZoomOut.Click += new System.EventHandler(this.OnZoomOutClick);
            // 
            // btnMoveImage
            // 
            this.btnMoveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveImage.Image = global::WingSuitJudge.Properties.Resources.arrow_in;
            this.btnMoveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveImage.Name = "btnMoveImage";
            this.btnMoveImage.Size = new System.Drawing.Size(30, 20);
            this.btnMoveImage.Text = "Move image";
            this.btnMoveImage.ToolTipText = "Move image";
            this.btnMoveImage.Click += new System.EventHandler(this.OnMoveImageClick);
            // 
            // btnAddMarker
            // 
            this.btnAddMarker.Checked = true;
            this.btnAddMarker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAddMarker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddMarker.Image = global::WingSuitJudge.Properties.Resources.add;
            this.btnAddMarker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddMarker.Name = "btnAddMarker";
            this.btnAddMarker.Size = new System.Drawing.Size(30, 20);
            this.btnAddMarker.Text = "Add marker";
            this.btnAddMarker.Click += new System.EventHandler(this.OnAddMarkerClick);
            // 
            // btnRemoveMarker
            // 
            this.btnRemoveMarker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveMarker.Image = global::WingSuitJudge.Properties.Resources.delete;
            this.btnRemoveMarker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveMarker.Name = "btnRemoveMarker";
            this.btnRemoveMarker.Size = new System.Drawing.Size(30, 20);
            this.btnRemoveMarker.Text = "Remove marker";
            this.btnRemoveMarker.Click += new System.EventHandler(this.OnRemoveMarkerClick);
            // 
            // btnMoveMarker
            // 
            this.btnMoveMarker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveMarker.Image = global::WingSuitJudge.Properties.Resources.mouse;
            this.btnMoveMarker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveMarker.Name = "btnMoveMarker";
            this.btnMoveMarker.Size = new System.Drawing.Size(30, 20);
            this.btnMoveMarker.Text = "Move marker";
            this.btnMoveMarker.Click += new System.EventHandler(this.OnMoveMarkerClick);
            // 
            // btnAddLine
            // 
            this.btnAddLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddLine.Image = global::WingSuitJudge.Properties.Resources.vector_add;
            this.btnAddLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(30, 20);
            this.btnAddLine.Text = "Add line";
            this.btnAddLine.Click += new System.EventHandler(this.OnAddLineClick);
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveLine.Image = global::WingSuitJudge.Properties.Resources.vector_delete;
            this.btnRemoveLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.Size = new System.Drawing.Size(30, 20);
            this.btnRemoveLine.Text = "Remove line";
            this.btnRemoveLine.Click += new System.EventHandler(this.OnRemoveLineClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 851);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Form1";
            this.Text = "Flock Judging Tool v1.01";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private ImagePanel mPictureBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripButton btnMoveImage;
        private System.Windows.Forms.ToolStripButton btnAddMarker;
        private System.Windows.Forms.ToolStripButton btnRemoveMarker;
        private System.Windows.Forms.ToolStripButton btnAddLine;
        private System.Windows.Forms.ToolStripButton btnRemoveLine;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mZoomText;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton btnMoveMarker;
    }
}

