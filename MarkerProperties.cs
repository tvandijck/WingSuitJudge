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
    public partial class MarkerProperties : Form
    {
        private Marker mMarker;
        public MarkerProperties()
        {
            InitializeComponent();
        }

        public MarkerProperties(Marker aMarker)
        {
            InitializeComponent();
            mMarker = aMarker;
            mNameTag.Text = mMarker.NameTag;
            mDescription.Text = mMarker.Description;
            mShowArea.Checked = mMarker.ShowArea;
        }

        public string NameTag
        {
            get { return mNameTag.Text; }
        }

        public string Description
        {
            get { return mDescription.Text; }
        }

        public bool ShowArea
        {
            get { return mShowArea.Checked; }
        }
    }
}
