using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public partial class JumpInfo : Form
    {
        public JumpInfo()
        {
            InitializeComponent();
        }

        public JumpInfo(Project aProject)
        {
            InitializeComponent();
            mDescription.Text = aProject.Description;
            mDate.Value = aProject.Date;
            mPlace.Text = aProject.Place;
            mGlideRatio.Text = aProject.GlideRatio.ToString();
            mJumpNumber.Value = aProject.JumpNumber;
            mFallrate.Value = aProject.Fallrate;
        }

        public string Description
        {
            get { return mDescription.Text; }
        }

        public DateTime Date
        {
            get { return mDate.Value; }
        }

        public string Place
        {
            get { return mPlace.Text; }
        }

        public float GlideRatio
        {
            get { return float.Parse(mGlideRatio.Text); }
        }

        public int JumpNumber
        {
            get { return (int)mJumpNumber.Value; }
        }

        public int Fallrate
        {
            get { return (int)mFallrate.Value; }
        }
    }
}
