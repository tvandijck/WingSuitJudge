namespace WingSuitJudge
{
    partial class JumpInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.mDescription = new System.Windows.Forms.TextBox();
            this.mDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mPlace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mJumpNumber = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.mFallrate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.mGlideRatio = new System.Windows.Forms.TextBox();
            this.mBtnOK = new System.Windows.Forms.Button();
            this.mBtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mJumpNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mFallrate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            // 
            // mDescription
            // 
            this.mDescription.Location = new System.Drawing.Point(12, 27);
            this.mDescription.Name = "mDescription";
            this.mDescription.Size = new System.Drawing.Size(339, 20);
            this.mDescription.TabIndex = 1;
            // 
            // mDate
            // 
            this.mDate.Location = new System.Drawing.Point(151, 67);
            this.mDate.Name = "mDate";
            this.mDate.Size = new System.Drawing.Size(200, 20);
            this.mDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location:";
            // 
            // mPlace
            // 
            this.mPlace.Location = new System.Drawing.Point(151, 107);
            this.mPlace.Name = "mPlace";
            this.mPlace.Size = new System.Drawing.Size(200, 20);
            this.mPlace.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Jump number:";
            // 
            // mJumpNumber
            // 
            this.mJumpNumber.Location = new System.Drawing.Point(12, 67);
            this.mJumpNumber.Name = "mJumpNumber";
            this.mJumpNumber.Size = new System.Drawing.Size(120, 20);
            this.mJumpNumber.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fallrate (MPH):";
            // 
            // mFallrate
            // 
            this.mFallrate.Location = new System.Drawing.Point(12, 107);
            this.mFallrate.Name = "mFallrate";
            this.mFallrate.Size = new System.Drawing.Size(120, 20);
            this.mFallrate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Glide ratio:";
            // 
            // mGlideRatio
            // 
            this.mGlideRatio.Location = new System.Drawing.Point(12, 147);
            this.mGlideRatio.Name = "mGlideRatio";
            this.mGlideRatio.Size = new System.Drawing.Size(120, 20);
            this.mGlideRatio.TabIndex = 11;
            // 
            // mBtnOK
            // 
            this.mBtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mBtnOK.Location = new System.Drawing.Point(276, 173);
            this.mBtnOK.Name = "mBtnOK";
            this.mBtnOK.Size = new System.Drawing.Size(75, 23);
            this.mBtnOK.TabIndex = 12;
            this.mBtnOK.Text = "OK";
            this.mBtnOK.UseVisualStyleBackColor = true;
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mBtnCancel.Location = new System.Drawing.Point(195, 173);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.mBtnCancel.TabIndex = 13;
            this.mBtnCancel.Text = "Cancel";
            this.mBtnCancel.UseVisualStyleBackColor = true;
            // 
            // JumpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 208);
            this.Controls.Add(this.mBtnCancel);
            this.Controls.Add(this.mBtnOK);
            this.Controls.Add(this.mGlideRatio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mFallrate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mJumpNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mPlace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mDate);
            this.Controls.Add(this.mDescription);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JumpInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jump Information";
            ((System.ComponentModel.ISupportInitialize)(this.mJumpNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mFallrate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mDescription;
        private System.Windows.Forms.DateTimePicker mDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mPlace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown mJumpNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown mFallrate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mGlideRatio;
        private System.Windows.Forms.Button mBtnOK;
        private System.Windows.Forms.Button mBtnCancel;
    }
}