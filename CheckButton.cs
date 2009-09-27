using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public partial class CheckButton : UserControl
    {
        private Image mImage;
        private bool mHighlite = false;
        private bool mChecked = false;

        public CheckButton()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public Image Image
        {
            get { return mImage; }
            set
            {
                mImage = value;
                Invalidate();
            }
        }

        public bool Checked
        {
            get { return mChecked; }
            set
            {
                mChecked = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (mHighlite)
            {
                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(Pens.Gray, rect);
            }
            if (mChecked)
            {
                Rectangle rect = new Rectangle(1, 1, Width - 3, Height - 3);
                e.Graphics.DrawRectangle(Pens.LightBlue, rect);
            }
            if (mImage != null)
            {
                float x = (Width - mImage.Width) * 0.5f;
                float y = (Height - mImage.Height) * 0.5f;
                e.Graphics.DrawImage(mImage, x, y);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mHighlite = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mHighlite = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

    }
}
