namespace WingSuitJudge
{
    partial class ProjectSettings
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
            this.mDistanceTolerance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mAngleTolerance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mJudgingTools = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mDeg45 = new System.Windows.Forms.RadioButton();
            this.mDeg90 = new System.Windows.Forms.RadioButton();
            this.mBtnOk = new System.Windows.Forms.Button();
            this.mBtnCancel = new System.Windows.Forms.Button();
            this.mDegBoth = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.mDistanceTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAngleTolerance)).BeginInit();
            this.mJudgingTools.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDistanceTolerance
            // 
            this.mDistanceTolerance.Location = new System.Drawing.Point(10, 43);
            this.mDistanceTolerance.Name = "mDistanceTolerance";
            this.mDistanceTolerance.Size = new System.Drawing.Size(81, 20);
            this.mDistanceTolerance.TabIndex = 0;
            this.mDistanceTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mDistanceTolerance.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
            // 
            // mAngleTolerance
            // 
            this.mAngleTolerance.Location = new System.Drawing.Point(10, 83);
            this.mAngleTolerance.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.mAngleTolerance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mAngleTolerance.Name = "mAngleTolerance";
            this.mAngleTolerance.Size = new System.Drawing.Size(81, 20);
            this.mAngleTolerance.TabIndex = 5;
            this.mAngleTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mAngleTolerance.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Angle tolerance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "°";
            // 
            // mJudgingTools
            // 
            this.mJudgingTools.Controls.Add(this.label4);
            this.mJudgingTools.Controls.Add(this.label2);
            this.mJudgingTools.Controls.Add(this.mAngleTolerance);
            this.mJudgingTools.Controls.Add(this.label3);
            this.mJudgingTools.Controls.Add(this.label1);
            this.mJudgingTools.Controls.Add(this.mDistanceTolerance);
            this.mJudgingTools.Location = new System.Drawing.Point(12, 12);
            this.mJudgingTools.Name = "mJudgingTools";
            this.mJudgingTools.Size = new System.Drawing.Size(118, 115);
            this.mJudgingTools.TabIndex = 9;
            this.mJudgingTools.TabStop = false;
            this.mJudgingTools.Text = "Tolerances";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mDegBoth);
            this.groupBox1.Controls.Add(this.mDeg45);
            this.groupBox1.Controls.Add(this.mDeg90);
            this.groupBox1.Location = new System.Drawing.Point(136, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 115);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formation Style";
            // 
            // mDeg45
            // 
            this.mDeg45.AutoSize = true;
            this.mDeg45.Checked = true;
            this.mDeg45.Location = new System.Drawing.Point(38, 31);
            this.mDeg45.Name = "mDeg45";
            this.mDeg45.Size = new System.Drawing.Size(41, 17);
            this.mDeg45.TabIndex = 0;
            this.mDeg45.Text = "45°";
            this.mDeg45.UseVisualStyleBackColor = true;
            // 
            // mDeg90
            // 
            this.mDeg90.AutoSize = true;
            this.mDeg90.Location = new System.Drawing.Point(38, 54);
            this.mDeg90.Name = "mDeg90";
            this.mDeg90.Size = new System.Drawing.Size(41, 17);
            this.mDeg90.TabIndex = 1;
            this.mDeg90.Text = "90°";
            this.mDeg90.UseVisualStyleBackColor = true;
            // 
            // mBtnOk
            // 
            this.mBtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mBtnOk.Location = new System.Drawing.Point(179, 133);
            this.mBtnOk.Name = "mBtnOk";
            this.mBtnOk.Size = new System.Drawing.Size(75, 23);
            this.mBtnOk.TabIndex = 11;
            this.mBtnOk.Text = "OK";
            this.mBtnOk.UseVisualStyleBackColor = true;
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mBtnCancel.Location = new System.Drawing.Point(98, 133);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.mBtnCancel.TabIndex = 12;
            this.mBtnCancel.Text = "Cancel";
            this.mBtnCancel.UseVisualStyleBackColor = true;
            // 
            // mDegBoth
            // 
            this.mDegBoth.AutoSize = true;
            this.mDegBoth.Location = new System.Drawing.Point(38, 77);
            this.mDegBoth.Name = "mDegBoth";
            this.mDegBoth.Size = new System.Drawing.Size(47, 17);
            this.mDegBoth.TabIndex = 2;
            this.mDegBoth.TabStop = true;
            this.mDegBoth.Text = "Both";
            this.mDegBoth.UseVisualStyleBackColor = true;
            // 
            // ProjectSettings
            // 
            this.AcceptButton = this.mBtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mBtnCancel;
            this.ClientSize = new System.Drawing.Size(267, 166);
            this.Controls.Add(this.mBtnCancel);
            this.Controls.Add(this.mBtnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mJudgingTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Settings";
            ((System.ComponentModel.ISupportInitialize)(this.mDistanceTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAngleTolerance)).EndInit();
            this.mJudgingTools.ResumeLayout(false);
            this.mJudgingTools.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown mDistanceTolerance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown mAngleTolerance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox mJudgingTools;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton mDeg45;
        private System.Windows.Forms.RadioButton mDeg90;
        private System.Windows.Forms.Button mBtnOk;
        private System.Windows.Forms.Button mBtnCancel;
        private System.Windows.Forms.RadioButton mDegBoth;

    }
}