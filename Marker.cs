using System.Drawing;
using System.Drawing.Drawing2D;

namespace Flock
{
    public class Marker
    {
        private PointF mLocation;
        private string mNameTag;
        private string mDescription;
        private bool mShowFlightZone;
        private FlightZone mFlightZoneMode = FlightZone.Project;
        private Color mSilhoutteColor = Color.White;
        private Image mSilhoutte = ImageColorCache.GetWingsuitImage(Color.White);

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

        public bool ShowFlightZone
        {
            get { return mShowFlightZone; }
            set { mShowFlightZone = value; }
        }

        public FlightZone FlightZoneMode
        {
            get { return mFlightZoneMode; }
            set { mFlightZoneMode = value; }
        }

        public Color SilhoutteColor
        {
            get { return mSilhoutteColor; }
            set
            {
                if (mSilhoutteColor != value)
                {
                    mSilhoutteColor = value;
                    mSilhoutte = ImageColorCache.GetWingsuitImage(mSilhoutteColor);
                }
            }
        }

        public void DrawWingsuit(Graphics aGraphics, float aScale)
        {
            aGraphics.InterpolationMode = InterpolationMode.High;
            aGraphics.DrawImage(mSilhoutte, mLocation.X - (62 * aScale), mLocation.Y - (8 * aScale),
                mSilhoutte.Width * 0.5f * aScale, mSilhoutte.Height * 0.5f * aScale);
        }

        public void Draw(Graphics aGraphics, float aScale, bool aSelected, bool aBase)
        {
            Pen penColor = aSelected ? Colors.SelectedPen : Colors.BlackPen;
            Brush fillColor = aBase ? Colors.MarkerBase : Colors.MarkerNormal;
            penColor.Width = 3 * aScale;

            float size = 8 * aScale;
            aGraphics.FillEllipse(fillColor, mLocation.X - size, mLocation.Y - size, 2 * size, 2 * size);
            aGraphics.DrawEllipse(penColor, mLocation.X - size, mLocation.Y - size, 2 * size, 2 * size);

            if (!string.IsNullOrEmpty(mNameTag))
            {
                SizeF fontSize = aGraphics.MeasureString(mNameTag, SystemFonts.DefaultFont);
                aGraphics.DrawString(mNameTag, SystemFonts.DefaultFont, Brushes.White, mLocation.X + 10, mLocation.Y - (fontSize.Height / 2));
            }
        }
    }
}
