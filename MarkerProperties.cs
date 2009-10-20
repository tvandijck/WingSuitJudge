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
            mShowFlightZone.Checked = mMarker.ShowFlightZone;
        }

        public string NameTag
        {
            get { return mNameTag.Text; }
        }

        public string Description
        {
            get { return mDescription.Text; }
        }

        public bool ShowFlightZone
        {
            get { return mShowFlightZone.Checked; }
        }
    }
}
