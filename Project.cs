﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Flock
{
    [Flags]
    public enum FlightZone
    {
        Project = 0,
        Deg45 = 1,
        Deg90 = 2,
        Both = Deg45 | Deg90
    };

    public class Project
    {
        private bool mDirty = false;
        private List<Marker> mMarkers = new List<Marker>();
        private List<Line> mLines = new List<Line>();
        private int mBaseMarker = 0;

        // project settings.
        private int mDistanceTolerance = Settings.Default.DistanceTolerance;
        private int mAngleTolerance = Settings.Default.AngleTolerance;
        private Color mBackColor = SystemColors.AppWorkspace;
        private FlightZone mFlightZoneMode = FlightZone.Deg45;
        private int mWingsuitSize = Settings.Default.WingsuitSize;
        private int mDotCount = Settings.Default.DotCount;
        private int mDotSize = Settings.Default.DotSize;
        private int mDotDistance = Settings.Default.DotDistance;
        private int mDotStretch = Settings.Default.DotStretch;
        private int mDotRotate = Settings.Default.DotRotate;
        private int mGridCount = Settings.Default.GridCount;
        private int mGridSize = Settings.Default.GridSize;
        private float mGridRotate = Settings.Default.GridRotate;
        private PointF mGridOffset = Point.Empty;

        // project info.
        private string mDescription;
        private DateTime mDate = DateTime.Now;
        private string mPlace;
        private float mGlideRatio;
        private int mJumpNumber;
        private int mFallrate;
        private string mPhotoName;

        public event EventHandler OnDirty;

        public Project()
        {
        }

        public Project(string aFilename)
        {
            LoadProject(aFilename);
        }

        public void Clear()
        {
            mMarkers.Clear();
            mLines.Clear();
            Dirty = true;
        }

        public bool Dirty
        {
            get { return mDirty; }
            set
            {
                if (mDirty != value)
                {
                    mDirty = value;
                    if (OnDirty != null)
                    {
                        OnDirty(this, EventArgs.Empty);
                    }
                }
            }
        }

        #region -- Project Settings -------------------------------------------

        public Color BackColor
        {
            get { return mBackColor; }
            set
            {
                if (value != mBackColor)
                {
                    mBackColor = value;
                    Dirty = true;
                }
            }
        }

        public FlightZone FlightZoneMode
        {
            get { return mFlightZoneMode; }
            set
            {
                if (value != mFlightZoneMode)
                {
                    mFlightZoneMode = value;
                    Dirty = true;
                }
            }
        }

        public int DistanceTolerance
        {
            get { return mDistanceTolerance; }
            set
            {
                if (value != mDistanceTolerance)
                {
                    mDistanceTolerance = value;
                    Dirty = true;
                }
            }
        }

        public int AngleTolerance
        {
            get { return mAngleTolerance; }
            set
            {
                if (value != mAngleTolerance)
                {
                    mAngleTolerance = value;
                    Dirty = true;
                }
            }
        }

        public int WingsuitSize
        {
            get { return mWingsuitSize; }
            set
            {
                if (value != mWingsuitSize)
                {
                    mWingsuitSize = value;
                    Dirty = true;
                }
            }
        }

        public int DotCount
        {
            get { return mDotCount; }
            set
            {
                if (value != mDotCount)
                {
                    mDotCount = value;
                    Dirty = true;
                }
            }
        }

        public int DotSize
        {
            get { return mDotSize; }
            set
            {
                if (value != mDotSize)
                {
                    mDotSize = value;
                    Dirty = true;
                }
            }
        }

        public int DotDistance
        {
            get { return mDotDistance; }
            set
            {
                if (value != mDotDistance)
                {
                    mDotDistance = value;
                    Dirty = true;
                }
            }
        }

        public int DotStretch
        {
            get { return mDotStretch; }
            set
            {
                if (value != mDotStretch)
                {
                    mDotStretch = value;
                    Dirty = true;
                }
            }
        }

        public int DotRotate
        {
            get { return mDotRotate; }
            set
            {
                if (value != mDotRotate)
                {
                    mDotRotate = value;
                    Dirty = true;
                }
            }
        }

        public int GridCount
        {
            get { return mGridCount; }
            set
            {
                if (value != mGridCount)
                {
                    mGridCount = value;
                    Dirty = true;
                }
            }
        }

        public int GridSize
        {
            get { return mGridSize; }
            set
            {
                if (value != mGridSize)
                {
                    mGridSize = value;
                    Dirty = true;
                }
            }
        }

        public float GridRotate
        {
            get { return mGridRotate; }
            set
            {
                if (value != mGridRotate)
                {
                    mGridRotate = value;
                    Dirty = true;
                }
            }
        }

        public PointF GridOffset
        {
            get { return mGridOffset; }
            set
            {
                if (value != mGridOffset)
                {
                    mGridOffset = value;
                    Dirty = true;
                }
            }
        }

        #endregion

        #region -- Project Info -----------------------------------------------

        public string Description
        {
            get { return mDescription; }
            set
            {
                if (value != mDescription)
                {
                    mDescription = value;
                    Dirty = true;
                }
            }
        }

        public DateTime Date
        {
            get { return mDate; }
            set
            {
                if (value != mDate)
                {
                    mDate = value;
                    Dirty = true;
                }
            }
        }

        public string Place
        {
            get { return mPlace; }
            set
            {
                if (value != mPlace)
                {
                    mPlace = value;
                    Dirty = true;
                }
            }
        }

        public float GlideRatio
        {
            get { return mGlideRatio; }
            set
            {
                if (value != mGlideRatio)
                {
                    mGlideRatio = value;
                    Dirty = true;
                }
            }
        }

        public int JumpNumber
        {
            get { return mJumpNumber; }
            set
            {
                if (value != mJumpNumber)
                {
                    mJumpNumber = value;
                    Dirty = true;
                }
            }
        }

        public int Fallrate
        {
            get { return mFallrate; }
            set
            {
                if (value != mFallrate)
                {
                    mFallrate = value;
                    Dirty = true;
                }
            }
        }

        public string PhotoName
        {
            get { return mPhotoName; }
            set
            {
                if (value != mPhotoName)
                {
                    mPhotoName = value;
                    Dirty = true;
                }
            }
        }

        #endregion

        #region -- Marker API -------------------------------------------------

        public int BaseMarker
        {
            get { return mBaseMarker; }
            set
            {
                if (value != mBaseMarker)
                {
                    mBaseMarker = value;
                    Dirty = true;
                }
            }
        }

        public void AddMarker(Marker marker)
        {
            mMarkers.Add(marker);
            Dirty = true;
        }

        public void RemoveMarker(int aIndex)
        {
            if (aIndex != -1)
            {
                // delete lines that point to this marker.
                Marker marker = mMarkers[aIndex];
                int num = mLines.Count;
                for (int i = num - 1; i >= 0; i--)
                {
                    Line line = mLines[i];
                    if (object.ReferenceEquals(marker, line.Start) || object.ReferenceEquals(marker, line.End))
                    {
                        mLines.RemoveAt(i);
                    }
                }

                // remove marker.
                mMarkers.RemoveAt(aIndex);
                mBaseMarker = Math.Max(0, Math.Min(mBaseMarker, mMarkers.Count - 1));
                Dirty = true;
            }
        }

        public int NumMarkers
        {
            get { return mMarkers.Count; }
        }

        public Marker GetMarker(int aIndex)
        {
            return mMarkers[aIndex];
        }

        public int FindMarker(Marker aMarker)
        {
            int num = mMarkers.Count;
            for (int i = 0; i < num; i++)
            {
                if (object.ReferenceEquals(mMarkers[i], aMarker))
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindMarker(float aX, float aY)
        {
            int num = mMarkers.Count;
            for (int i = 0; i < num; i++)
            {
                float dx = aX - mMarkers[i].Location.X;
                float dy = aY - mMarkers[i].Location.Y;
                if (dx * dx + dy * dy < 16 * 16)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool HasAnyFlightZones()
        {
            foreach (Marker marker in mMarkers)
            {
                if (marker.ShowFlightZone)
                    return true;
            }
            return false;
        }

        #endregion

        #region -- Line API ---------------------------------------------------

        public void AddLine(int aStart, int aEnd)
        {
            // can only add unique lines.
            Marker start = mMarkers[aStart];
            Marker end = mMarkers[aEnd];
            foreach (Line line in mLines)
            {
                if (object.ReferenceEquals(start, line.Start) && object.ReferenceEquals(end, line.End))
                    return;
                if (object.ReferenceEquals(start, line.End) && object.ReferenceEquals(end, line.Start))
                    return;
            }

            // found no matching lines.
            mLines.Add(new Line(start, end));
            Dirty = true;
        }

        public void RemoveLine(int aIndex)
        {
            if (aIndex != -1)
            {
                mLines.RemoveAt(aIndex);
                Dirty = true;
            }
        }

        public int NumLines
        {
            get { return mLines.Count; }
        }

        public Line GetLine(int aIndex)
        {
            return mLines[aIndex];
        }

        public int FindLine(Line aLine)
        {
            int num = mLines.Count;
            for (int i = 0; i < num; i++)
            {
                if (object.ReferenceEquals(mLines[i], aLine))
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindLine(float aX, float aY)
        {
            int num = mLines.Count;
            for (int i = 0; i < num; i++)
            {
                float d = mLines[i].GetDistance(aX, aY);
                if (d < 3)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        #region -- Rendering API ----------------------------------------------

        public void PaintWingsuit(Graphics aGraphics, float aScale)
        {
            int numMarkers = mMarkers.Count;
            for (int i = 0; i < numMarkers; i++)
            {
                Marker marker = mMarkers[i];
                marker.DrawWingsuit(aGraphics, aScale);
            }
        }

        public void PaintGrid(Graphics aGraphics, PointF aCenter, int aWidth, float aScale, float aOverlap, float aBase, float aRotate)
        {
            float sin = (float)Math.Sin(aRotate + (Math.PI * 0.25));
            float cos = (float)Math.Cos(aRotate + (Math.PI * 0.25));

            float _base = aBase * 0.005f;
            float center = aScale * 0.5f;
            float overlap = aScale * (aOverlap / 100.0f);

            Pen redPen = new Pen(Color.DarkRed, 2.0f);
            Pen blackPen = new Pen(Color.Black, 2.0f);

            for (int y = 0; y < aWidth; y++)
            {
                for (int x = 0; x < aWidth; x++)
                {
                    float x1 = ((aScale - overlap) * x) - center;
                    float y1 = ((aScale - overlap) * y) - center;
                    float x2 = x1 + aScale;
                    float y2 = y1 + aScale;

                    float xr1 = aCenter.X + (x1 * cos) - (y1 * sin);
                    float yr1 = aCenter.Y + (x1 * sin) + (y1 * cos);

                    float xr2 = aCenter.X + (x2 * cos) - (y1 * sin);
                    float yr2 = aCenter.Y + (x2 * sin) + (y1 * cos);

                    float xr3 = aCenter.X + (x2 * cos) - (y2 * sin);
                    float yr3 = aCenter.Y + (x2 * sin) + (y2 * cos);

                    float xr4 = aCenter.X + (x1 * cos) - (y2 * sin);
                    float yr4 = aCenter.Y + (x1 * sin) + (y2 * cos);

                    Pen pen = (((x + y) & 1) == 0) ? blackPen : redPen;
                    aGraphics.DrawLine(pen, xr1, yr1, xr2, yr2);
                    aGraphics.DrawLine(pen, xr2, yr2, xr3, yr3);
                    aGraphics.DrawLine(pen, xr3, yr3, xr4, yr4);
                    aGraphics.DrawLine(pen, xr4, yr4, xr1, yr1);

                    if (x == 0 && y == 0)
                    {
                        float xd = (xr2 - xr4) * 0.135f;
                        float yd = (yr2 - yr4) * 0.135f;

                        float baseX1 = xr1 + ((xr3 - xr1) * (0.5f - _base));
                        float baseY1 = yr1 + ((yr3 - yr1) * (0.5f - _base));
                        float baseX2 = xr1 + ((xr3 - xr1) * (0.5f + _base));
                        float baseY2 = yr1 + ((yr3 - yr1) * (0.5f + _base));

                        aGraphics.DrawLine(pen, baseX1 - xd, baseY1 - yd, baseX1 + xd, baseY1 + yd);
                        aGraphics.DrawLine(pen, baseX2 - xd, baseY2 - yd, baseX2 + xd, baseY2 + yd);
                    }
                }
            }
        }

        public void PaintDots(Graphics aGraphics, int aWidth, float aDotSize, float aDotDistance, float aStretch, float aRotate)
        {
            float baseLength;
            Marker baseMarker;
            HasBaseLength(out baseLength, out baseMarker);

            if (baseMarker != null)
            {
                float sin = (float)Math.Sin(aRotate);
                float cos = (float)Math.Cos(aRotate);

                float d = aDotSize * 0.5f;
                for (int y = 0; y < aWidth; y++)
                {
                    for (int x = 0; x < aWidth; x++)
                    {
                        float xc = ((x * aDotDistance) - (y * aDotDistance)) * aStretch;
                        float yc = ((y * aDotDistance) + (x * aDotDistance));

                        float xp = baseMarker.Location.X + (xc * cos) - (yc * sin);
                        float yp = baseMarker.Location.Y + (xc * sin) + (yc * cos);

                        float dist;
                        Marker marker;
                        FindClosestMarker(xp, yp, out dist, out marker);
                        if (dist < d)
                        {
                            aGraphics.FillEllipse(Colors.GreenDotBrush, xp - d, yp - d, aDotSize, aDotSize);
                            aGraphics.DrawEllipse(Colors.DotPen, xp - d, yp - d, aDotSize, aDotSize);
                        }
                        else if (dist < (d * 2))
                        {
                            aGraphics.FillEllipse(Colors.RedDotBrush, xp - d, yp - d, aDotSize, aDotSize);
                            aGraphics.DrawEllipse(Colors.DotPen, xp - d, yp - d, aDotSize, aDotSize);
                            aGraphics.DrawLine(Colors.ErrorPen, xp, yp, marker.Location.X, marker.Location.Y);
                        }
                        else
                        {
                            aGraphics.FillEllipse(Colors.GrayDotBrush, xp - d, yp - d, aDotSize, aDotSize);
                            aGraphics.DrawEllipse(Colors.DotPen, xp - d, yp - d, aDotSize, aDotSize);
                        }
                    }
                }
            }
        }

        private void FindClosestMarker(float aX, float aY, out float aDistance, out Marker aMarker)
        {
            aDistance = float.MaxValue;
            aMarker = null;
            foreach (Marker m in mMarkers)
            {
                float d = Math2.Distance(m.Location.X, m.Location.Y, aX, aY);
                if (d < aDistance)
                {
                    aDistance = d;
                    aMarker = m;
                }
            }
        }

        private bool HasBaseLength(out float aBaseLength, out Marker aBaseMarker)
        {
            aBaseMarker = null;
            if (mBaseMarker >= 0 && mBaseMarker < mMarkers.Count)
            {
                aBaseMarker = mMarkers[mBaseMarker];

                int numLines = 0;
                float length = 0.0f;
                foreach (Line line in mLines)
                {
                    if (aBaseMarker == line.End || aBaseMarker == line.Start)
                    {
                        length += line.GetLength();
                        numLines++;
                    }
                }

                if (numLines > 0)
                {
                    aBaseLength = length / numLines;
                    return true;
                }
            }
            aBaseLength = 0;
            return false;
        }

        public void PaintLines(Graphics aGraphics, int aSelectedLine)
        {
            // get line base length.
            Marker baseMarker = null;
            float baseLength = 0;
            float minLength = 0;
            float maxLength = 1000;
            if (HasBaseLength(out baseLength, out baseMarker))
            {
                float dtol = mDistanceTolerance * 0.01f;
                minLength = baseLength - (baseLength * dtol);
                maxLength = baseLength + (baseLength * dtol);
            }

            // draw lines.
            int numLines = mLines.Count;
            for (int i = 0; i < numLines; i++)
            {
                Line line = mLines[i];

                bool baseLine = baseMarker == line.End || baseMarker == line.Start;
                float length = line.GetLength();
                float angle = Math2.NormalizeAngle(line.GetAngle());

                bool distError = (length < minLength) || (length > maxLength);
                bool anglError = !IsAngleWithInTolerance(angle, line.End.FlightZoneMode) || !IsAngleWithInTolerance(angle, line.Start.FlightZoneMode);

                line.Draw(aGraphics, i == aSelectedLine, baseLine, distError || anglError);

                if (anglError)
                {
                    float closest = ClosestAngle(angle, line.Start.FlightZoneMode);
                    float diff = closest - angle;

                    float x1 = line.Start.Location.X;
                    float y1 = line.Start.Location.Y;
                    float x2 = line.End.Location.X;
                    float y2 = line.End.Location.Y;

                    GraphicsPath path = new GraphicsPath();
                    path.AddArc(x1 - 10, y1 - 10, 20, 20, angle, diff);
                    path.AddArc(x1 - minLength, y1 - minLength, minLength * 2, minLength * 2, closest, -diff);
                    path.CloseFigure();

                    path.AddArc(x2 - 10, y2 - 10, 20, 20, angle + 180, diff);
                    path.AddArc(x2 - minLength, y2 - minLength, minLength * 2, minLength * 2, closest + 180, -diff);
                    path.CloseFigure();

                    aGraphics.FillPath(Colors.RedDotBrush, path);
                }
            }
        }

        public float ClosestAngle(float aAngle, FlightZone aMode)
        {
            float input = Math2.NormalizeAngle(aAngle);
            float closest = float.MaxValue;
            FlightZone cirleMode = (aMode == FlightZone.Project) ? mFlightZoneMode : aMode;
            if ((cirleMode & FlightZone.Deg45) != 0)
            {
                float angle;
                for (int i = 0; i < 4; i++)
                {
                    angle = Math2.NormalizeAngle((i * 90 - mAngleTolerance) + 45);
                    if (Math.Abs(input - angle) < Math.Abs(input - closest))
                    {
                        closest = angle;
                    }
                    angle = Math2.NormalizeAngle((i * 90 + mAngleTolerance) + 45);
                    if (Math.Abs(input - angle) < Math.Abs(input - closest))
                    {
                        closest = angle;
                    }
                }
            }
            if ((cirleMode & FlightZone.Deg90) != 0)
            {
                float angle;
                for (int i = 0; i < 4; i++)
                {
                    angle = Math2.NormalizeAngle(i * 90 - mAngleTolerance);
                    if (Math.Abs(input - angle) < Math.Abs(input - closest))
                    {
                        closest = angle;
                    }
                    angle = Math2.NormalizeAngle(i * 90 + mAngleTolerance);
                    if (Math.Abs(input - angle) < Math.Abs(input - closest))
                    {
                        closest = angle;
                    }
                }
            }
            return closest;
        }

        private GraphicsPath CreatePath(float aMinLength, float aMaxLength, float aAngleOffset)
        {
            aMinLength = Math.Max(aMinLength, 0.01f);
            GraphicsPath path = new GraphicsPath();
            for (int i = 0; i < 4; i++)
            {
                path.AddArc(-aMinLength, -aMinLength, aMinLength * 2, aMinLength * 2, (i * 90 - mAngleTolerance) + aAngleOffset, mAngleTolerance * 2);
                path.AddArc(-aMaxLength, -aMaxLength, aMaxLength * 2, aMaxLength * 2, (i * 90 + mAngleTolerance) + aAngleOffset, -mAngleTolerance * 2);
                path.CloseFigure();
            }
            return path;
        }

        public void PaintFlightZones(Graphics aGraphics)
        {
            float baseLength = 0;
            Marker baseMarker = null;
            if (HasBaseLength(out baseLength, out baseMarker) && HasAnyFlightZones())
            {
                float dtol = mDistanceTolerance * 0.01f;
                float minLength = baseLength - (baseLength * dtol);
                float maxLength = baseLength + (baseLength * dtol);

                // Create path for 90.
                GraphicsPath path90 = CreatePath(minLength, maxLength, 0);
                GraphicsPath path45 = CreatePath(minLength, maxLength, 45);

                // draw all markers.
                foreach (Marker marker in mMarkers)
                {
                    if (marker.ShowFlightZone)
                    {
                        float x = marker.Location.X;
                        float y = marker.Location.Y;

                        FlightZone cirleMode = (marker.FlightZoneMode == FlightZone.Project) ? mFlightZoneMode : marker.FlightZoneMode;

                        if ((cirleMode & FlightZone.Deg45) != 0)
                        {
                            path45.Transform(new Matrix(1, 0, 0, 1, x, y));
                            aGraphics.FillPath(Colors.FlightZoneBrush, path45);
                            aGraphics.DrawPath(Colors.FlightZonePen, path45);
                            path45.Transform(new Matrix(1, 0, 0, 1, -x, -y));
                        }

                        if ((cirleMode & FlightZone.Deg90) != 0)
                        {
                            path90.Transform(new Matrix(1, 0, 0, 1, x, y));
                            aGraphics.FillPath(Colors.FlightZoneBrush, path90);
                            aGraphics.DrawPath(Colors.FlightZonePen, path90);
                            path90.Transform(new Matrix(1, 0, 0, 1, -x, -y));
                        }
                    }
                }
            }
        }

        public void PaintMarkers(Graphics aGraphics, int aSelectedMarker, float aScale)
        {
            int numMarkers = mMarkers.Count;
            for (int i = 0; i < numMarkers; i++)
            {
                Marker marker = mMarkers[i];
                marker.Draw(aGraphics, aScale, i == aSelectedMarker, i == mBaseMarker);
            }
        }

        #endregion

        #region -- Save/Load methods ------------------------------------------

        private static void WriteString(BinaryWriter aWriter, string aString)
        {
            if (string.IsNullOrEmpty(aString))
            {
                aWriter.Write("");
            }
            else
            {
                aWriter.Write(aString);
            }
        }

        public void SaveProject(string aFilename)
        {
            using (FileStream fileStream = new FileStream(aFilename, FileMode.Create))
            {
                Serialize(fileStream);
            }
            Dirty = false;
        }

        private const int Version = 10;

        public void Serialize(Stream aStream)
        {
            using (BinaryWriter writer = new BinaryWriter(aStream, System.Text.Encoding.UTF8))
            {
                writer.Write((int)0x4b434c46);      // identifier.
                writer.Write((int)Version);         // version number.
                writer.Write(mBaseMarker);
                writer.Write(mDistanceTolerance);
                writer.Write(mAngleTolerance);
                writer.Write((int)mFlightZoneMode);
                WriteString(writer, mPhotoName);
                writer.Write((int)mWingsuitSize);
                writer.Write((int)mDotCount);
                writer.Write((int)mDotSize);
                writer.Write((int)mDotDistance);
                writer.Write((int)mDotStretch);
                writer.Write((int)mDotRotate);
                writer.Write((int)mGridCount);
                writer.Write((int)mGridSize);
                writer.Write((float)mGridRotate);
                writer.Write((float)mGridOffset.X);
                writer.Write((float)mGridOffset.Y);

                writer.Write(mBackColor.ToArgb());
                WriteString(writer, mDescription);
                writer.Write(mDate.ToBinary());
                WriteString(writer, mPlace);
                writer.Write(mGlideRatio);
                writer.Write(mJumpNumber);
                writer.Write(mFallrate);

                writer.Write(mMarkers.Count);
                foreach (Marker marker in mMarkers)
                {
                    writer.Write(marker.Location.X);
                    writer.Write(marker.Location.Y);
                    writer.Write(marker.ShowFlightZone);
                    writer.Write(marker.SilhoutteColor.ToArgb());
                    writer.Write((int)marker.FlightZoneMode);

                    WriteString(writer, marker.NameTag);
                    WriteString(writer, marker.Description);
                }

                writer.Write(mLines.Count);
                foreach (Line line in mLines)
                {
                    writer.Write(FindMarker(line.Start));
                    writer.Write(FindMarker(line.End));
                    writer.Write(line.Color.ToArgb());
                }
            }
        }

        private void LoadProject(string aFilename)
        {
            using (FileStream fileStream = new FileStream(aFilename, FileMode.Open))
            {
                Deserialize(aFilename, fileStream);
            }
            Dirty = false;
        }

        public void Deserialize(string aFilename, Stream aStream)
        {
            using (BinaryReader reader = new BinaryReader(aStream, System.Text.Encoding.UTF8))
            {
                uint id = reader.ReadUInt32();
                if (id != 0x4b434c46)
                {
                    throw new Exception(string.Format("'{0}' is not a flock file", Path.GetFileName(aFilename)));
                }

                int version = reader.ReadInt32();
                if (version <= Version)
                {
                    mBaseMarker = reader.ReadInt32();
                    if (version < 6)
                    {
                        reader.ReadInt32();
                    }

                    mDistanceTolerance = reader.ReadInt32();

                    if (version >= 5)
                    {
                        mAngleTolerance = reader.ReadInt32();
                    }

                    if (version >= 7)
                    {
                        mFlightZoneMode = (FlightZone)reader.ReadInt32();
                    }

                    if (version >= 8)
                    {
                        mPhotoName = reader.ReadString();
                    }

                    if (version >= 9)
                    {
                        mWingsuitSize = reader.ReadInt32();
                        mDotCount = reader.ReadInt32();
                        mDotSize = reader.ReadInt32();
                        mDotDistance = reader.ReadInt32();
                        mDotStretch = reader.ReadInt32();
                        mDotRotate = reader.ReadInt32();
                    }

                    if (version >= 10)
                    {
                        mGridCount = reader.ReadInt32();
                        mGridSize = reader.ReadInt32();
                        mGridRotate = reader.ReadSingle();
                        mGridOffset.X = reader.ReadSingle();
                        mGridOffset.Y = reader.ReadSingle();
                    }

                    if (version >= 2)
                    {
                        mBackColor = Color.FromArgb(reader.ReadInt32());
                        mDescription = reader.ReadString();
                        long date = reader.ReadInt64();
                        mDate = DateTime.FromBinary(date);
                        mPlace = reader.ReadString();
                        mGlideRatio = reader.ReadSingle();
                        mJumpNumber = reader.ReadInt32();
                        mFallrate = reader.ReadInt32();
                    }

                    int numMarkers = reader.ReadInt32();
                    for (int i = 0; i < numMarkers; i++)
                    {
                        float x = reader.ReadSingle();
                        float y = reader.ReadSingle();
                        Marker marker = new Marker(x, y);
                        marker.ShowFlightZone = reader.ReadBoolean();
                        if (version >= 3)
                        {
                            if (version == 3)
                            {
                                reader.ReadBoolean();
                            }
                            marker.SilhoutteColor = Color.FromArgb(reader.ReadInt32());
                        }
                        if (version >= 7)
                        {
                            marker.FlightZoneMode = (FlightZone)reader.ReadInt32();
                        }

                        marker.NameTag = reader.ReadString();
                        marker.Description = reader.ReadString();
                        mMarkers.Add(marker);
                    }

                    int numLines = reader.ReadInt32();
                    for (int i = 0; i < numLines; i++)
                    {
                        int start = reader.ReadInt32();
                        int end = reader.ReadInt32();
                        Line line = new Line(mMarkers[start], mMarkers[end]);
                        if (version >= 3)
                        {
                            line.Color = Color.FromArgb(reader.ReadInt32());
                        }
                        mLines.Add(line);
                    }
                }
                else
                {
                    throw new Exception(string.Format("'{0}' has an unsupported version number {1}.", Path.GetFileName(aFilename), version));
                }
            }
        }

        #endregion

        public bool IsAngleWithInTolerance(float aAngle, FlightZone aMode)
        {
            FlightZone cirleMode = (aMode == FlightZone.Project) ? mFlightZoneMode : aMode;
            if ((cirleMode & FlightZone.Deg45) != 0)
            {
                float angle = Math2.NormalizeAngle(aAngle + 45);
                for (int i = 0; i < 4; i++)
                {
                    if (angle >= -mAngleTolerance && angle <= mAngleTolerance)
                        return true;
                    angle = Math2.NormalizeAngle(angle + 90);
                }
            }
            if ((cirleMode & FlightZone.Deg90) != 0)
            {
                float angle = Math2.NormalizeAngle(aAngle);
                for (int i = 0; i < 4; i++)
                {
                    if (angle >= -mAngleTolerance && angle <= mAngleTolerance)
                        return true;
                    angle = Math2.NormalizeAngle(angle + 90);
                }
            }
            return false;
        }

        public float Accuracy
        {
            get
            {
                // get line base length.
                float baseLength;
                Marker baseMarker = null;
                if (HasBaseLength(out baseLength, out baseMarker))
                {
                    float dtol = mDistanceTolerance * 0.01f;
                    float minLength = baseLength - (baseLength * dtol);
                    float maxLength = baseLength + (baseLength * dtol);

                    int numCorrectLines = 0;
                    int numLines = mLines.Count;
                    float totalLength = 0;
                    float errorLength = 0;
                    for (int i = 0; i < numLines; i++)
                    {
                        Line line = mLines[i];
                        float length = line.GetLength();
                        float angle = line.GetAngle();
                        if (length >= minLength
                            && length <= maxLength
                            && IsAngleWithInTolerance(angle, line.End.FlightZoneMode)
                            && IsAngleWithInTolerance(angle, line.Start.FlightZoneMode))
                        {
                            numCorrectLines++;
                        }
                        else
                        {
                            if (length < minLength)
                            {
                                errorLength += (minLength - length);
                            }
                            if (length > maxLength)
                            {
                                errorLength += (length - maxLength);
                            }
                        }
                        totalLength += length;
                    }

                    float correctRation = (float)numCorrectLines / (float)numLines;
                    float lengthRation = 1.0f - ((float)errorLength / (float)totalLength);
                    return correctRation * lengthRation;
                }
                else
                {
                    return 0;
                }
            }
        }

        public float BaseLength
        {
            get
            {
                float baseLength;
                Marker baseMarker = null;
                if (HasBaseLength(out baseLength, out baseMarker))
                {
                    return baseLength;
                }
                return 0;
            }
        }

        public RectangleF BoundingRect
        {
            get
            {
                int num = mMarkers.Count;
                if (num <= 0)
                {
                    return RectangleF.Empty;
                }

                Marker marker = mMarkers[0];
                float minX = marker.Location.X;
                float maxX = marker.Location.X;
                float minY = marker.Location.Y;
                float maxY = marker.Location.Y;

                for (int i = 1; i < num; i++)
                {
                    marker = mMarkers[i];
                    minX = Math.Min(minX, marker.Location.X);
                    maxX = Math.Max(maxX, marker.Location.X);
                    minY = Math.Min(minY, marker.Location.Y);
                    maxY = Math.Max(maxY, marker.Location.Y);
                }
                return new RectangleF(minX, minY, maxX - minX, maxY - minY);
            }
        }

        public void Offset(float dx, float dy)
        {
            if (dx != 0 || dy != 0)
            {
                int numMarkers = mMarkers.Count;
                for (int i = 0; i < numMarkers; i++)
                {
                    Marker marker = mMarkers[i];
                    marker.Location = new PointF(marker.Location.X + dx, marker.Location.Y + dy);
                }
                Dirty = true;
            }
        }

        public void Rotate(float cx, float cy, float angle)
        {
            if (angle != 0)
            {
                float c = (float)Math.Cos(angle);
                float s = (float)Math.Sin(angle);

                int numMarkers = mMarkers.Count;
                for (int i = 0; i < numMarkers; i++)
                {
                    Marker marker = mMarkers[i];

                    float x = marker.Location.X - cx;
                    float y = marker.Location.Y - cy;
                    marker.Location = new PointF(x * c + y * s + cx, x * -s + y * c + cy);
                }
                Dirty = true;
            }
        }

        public void MoveGrid(float dx, float dy)
        {
            if (dx != 0 || dy != 0)
            {
                mGridOffset.X += dx;
                mGridOffset.Y += dy;
                Dirty = true;
            }
        }

        public void RotateGrid(float dx)
        {
            if (dx != 0)
            {
                mGridRotate -= dx;
                Dirty = true;
            }
        }
    }
}
