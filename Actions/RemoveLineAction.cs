﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WingSuitJudge
{
    public class RemoveLineAction : Action
    {
        public RemoveLineAction(Project aProject)
            : base(aProject)
        {
        }

        public override bool OnMouseClick(ImagePanel aSender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int selected = Project.FindLine(e.X, e.Y);
                if (selected != -1)
                {
                    Project.RemoveLine(selected);
                    aSender.Invalidate();
                    return false;
                }
            }
            return true;
        }
    }
}