using System;
using System.Drawing;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public partial class CheckButton : UserControl
    {
        private Image mImage;
        private bool mHighlite = false;
        private bool mChecked = false;
        private string mTooltip;
        private ToolTip mToopTipCtrl = new ToolTip();

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

        public string Tooltip
        {
            get { return mTooltip; }
            set 
            { 
                mTooltip = value;
                mToopTipCtrl.SetToolTip(this, value);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (mHighlite || this.DesignMode)
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

                RectangleF srcRect = new RectangleF(0, 0, mImage.Width, mImage.Height);
                RectangleF destRect = new RectangleF(x, y, mImage.Width, mImage.Height);
                e.Graphics.DrawImage(mImage, destRect, srcRect, GraphicsUnit.Pixel);
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
