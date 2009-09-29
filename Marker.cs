using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace WingSuitJudge
{
    public class Marker
    {
        private PointF mLocation;
        private string mNameTag;
        private string mDescription;
        private bool mShowArea;

        public Marker(float x, float y)
        {
            mLocation.X = x;
            mLocation.Y = y;
        }

        public Marker(float x, float y, string tag)
        {
            mLocation.X = x;
            mLocation.Y = y;
            mNameTag = tag;
        }  

        [Browsable(false)]
        public PointF Location
        {
            get { return mLocation; }
            set { mLocation = value; }
        }

        public string NameTag
        {
            get { return mNameTag; }
            set { mNameTag = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public bool ShowArea
        {
            get { return mShowArea; }
            set { mShowArea = value; }
        }

        public void Draw(Graphics aGraphics, bool aSelected, bool aBase)
        {
            Pen penColor = aSelected ? Colors.SelectedPen : Colors.BlackPen;
            Brush fillColor = aBase ? Brushes.DarkGreen : Brushes.DarkRed;

            aGraphics.FillEllipse(fillColor, mLocation.X - 8, mLocation.Y - 8, 16, 16);
            aGraphics.DrawEllipse(penColor, mLocation.X - 8, mLocation.Y - 8, 16, 16);

            if (!string.IsNullOrEmpty(mNameTag))
            {
                SizeF size = aGraphics.MeasureString(mNameTag, SystemFonts.DefaultFont);
                aGraphics.DrawString(mNameTag, SystemFonts.DefaultFont, Brushes.White, mLocation.X + 10, mLocation.Y - (size.Height / 2));
            }
        }
    }
}
