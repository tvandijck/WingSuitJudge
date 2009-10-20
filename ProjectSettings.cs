﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public partial class ProjectSettings : Form
    {
        public ProjectSettings()
        {
            InitializeComponent();
        }

        public ProjectSettings(Project aProject)
        {
            InitializeComponent();
            mDistanceTolerance.Value = aProject.DistanceTolerance;
            mAngleTolerance.Value = aProject.AngleTolerance;
            mDeg45.Checked = aProject.FlightZoneMode == FlightZone.Deg45;
            mDeg90.Checked = aProject.FlightZoneMode == FlightZone.Deg90;
            mDegBoth.Checked = aProject.FlightZoneMode == FlightZone.Both;
        }

        public int DistanceTolerance
        {
            get { return (int)mDistanceTolerance.Value; }
        }

        public int AngleTolerance
        {
            get { return (int)mAngleTolerance.Value; }
        }

        public FlightZone FlightZoneMode
        {
            get
            {
                if (mDeg45.Checked)
                {
                    return FlightZone.Deg45;
                }
                if (mDeg90.Checked)
                {
                    return FlightZone.Deg90;
                }
                return FlightZone.Both;
            }
        }
    }
}
