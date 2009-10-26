using System.Drawing;
using System.Windows.Forms;

namespace WingSuitJudge
{
    public class MoveMarkerAction : Action
    {
        int mSelected = -1;
        bool mShowFlightZone;
        PointF mOldLocation;
        PointF mNewLocation;

        public MoveMarkerAction(Project aProject)
            : base(aProject)
        {
        }

        public override bool OnMouseDown(ImagePanel aSender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mSelected = Project.FindMarker(e.X, e.Y);
                if (mSelected != -1)
                {
                    Marker marker = Project.GetMarker(mSelected);
                    mOldLocation = marker.Location;
                    mShowFlightZone = marker.ShowFlightZone;
                    marker.ShowFlightZone = true;
                    aSender.Invalidate();
                }
                return false;
            }
            return true;
        }

        public override bool OnMouseUp(ImagePanel aSender, MouseEventArgs e)
        {
            if (mSelected != -1)
            {
                // revert the 'action'.
                Marker marker = Project.GetMarker(mSelected);
                marker.ShowFlightZone = mShowFlightZone;
                marker.Location = mOldLocation;

                // notify the command system of our intent.
                if (mOldLocation != mNewLocation)
                {
                    CommandSystem.MoveMarker(Project, mSelected, mOldLocation, mNewLocation);
                }

                // redraw ;).
                aSender.Invalidate();
                mSelected = -1;
            }
            return true;
        }

        public override bool OnMouseMove(ImagePanel aSender, MouseEventArgs e)
        {
            if (mSelected != -1 && e.Button == MouseButtons.Left)
            {
                Marker marker = Project.GetMarker(mSelected);
                mNewLocation = new PointF(e.X, e.Y);
                marker.Location = mNewLocation;
                aSender.Invalidate();
                return false;
            }
            return true;
        }

    }
}
