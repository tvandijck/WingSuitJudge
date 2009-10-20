﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace WingSuitJudge
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
        private List<Marker> mMarkers = new List<Marker>();
        private List<Line> mLines = new List<Line>();
        private int mBaseMarker = 0;

        // project settings.
        private int mDistanceTolerance = 35;
        private int mAngleTolerance = 18;
        private Color mBackColor = SystemColors.AppWorkspace;
        private FlightZone mFlightZoneMode = FlightZone.Deg45;

        // project info.
        private string mDescription;
        private DateTime mDate = DateTime.Now;
        private string mPlace;
        private float mGlideRatio;
        private int mJumpNumber;
        private int mFallrate;

        public Project()
        {
        }

        public Project(string aFilename)
        {
            LoadProject(aFilename);
        }

        #region -- Project Settings -------------------------------------------

        public Color BackColor
        {
            get { return mBackColor; }
            set { mBackColor = value; }
        }

        public FlightZone FlightZoneMode
        {
            get { return mFlightZoneMode; }
            set { mFlightZoneMode = value; }
        }

        public int DistanceTolerance
        {
            get { return mDistanceTolerance; }
            set { mDistanceTolerance = value; }
        }

        public int AngleTolerance
        {
            get { return mAngleTolerance; }
            set { mAngleTolerance = value; }
        }

        #endregion

        #region -- Project Info -----------------------------------------------

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }

        public string Place
        {
            get { return mPlace; }
            set { mPlace = value; }
        }

        public float GlideRatio
        {
            get { return mGlideRatio; }
            set { mGlideRatio = value; }
        }

        public int JumpNumber
        {
            get { return mJumpNumber; }
            set { mJumpNumber = value; }
        }

        public int Fallrate
        {
            get { return mFallrate; }
            set { mFallrate = value; }
        }

        #endregion

        #region -- Marker API -------------------------------------------------

        public int BaseMarker
        {
            get { return mBaseMarker; }
            set { mBaseMarker = value; }
        }

        public void AddMarker(Marker marker)
        {
            mMarkers.Add(marker);
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
        }

        public void RemoveLine(int aIndex)
        {
            if (aIndex != -1)
            {
                mLines.RemoveAt(aIndex);
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

        public void PaintWingsuit(Graphics aGraphics)
        {
            int numMarkers = mMarkers.Count;
            for (int i = 0; i < numMarkers; i++)
            {
                Marker marker = mMarkers[i];
                marker.DrawWingsuit(aGraphics);
            }
        }

        private bool HasBaseLength(out float aBaseLength, out Marker aBaseMarker)
        {
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
            aBaseMarker = null;
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
                float angle = line.GetAngle();

                bool error = (length < minLength)
                    || (length > maxLength) 
                    || !IsAngleWithInTolerance(angle, line.End.FlightZoneMode) 
                    || !IsAngleWithInTolerance(angle, line.Start.FlightZoneMode);

                line.Draw(aGraphics, i == aSelectedLine, baseLine, error);
            }
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

        public void PaintMarkers(Graphics aGraphics, int aSelectedMarker)
        {
            int numMarkers = mMarkers.Count;
            for (int i = 0; i < numMarkers; i++)
            {
                Marker marker = mMarkers[i];
                marker.Draw(aGraphics, i == aSelectedMarker, i == mBaseMarker);
            }
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
            FileStream fileStream = new FileStream(aFilename, FileMode.Create);
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                writer.Write((int)0x4b434c46);
                writer.Write((int)7);
                writer.Write(mBaseMarker);
                writer.Write(mDistanceTolerance);
                writer.Write(mAngleTolerance);
                writer.Write((int)mFlightZoneMode);

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
            FileStream fileStream = new FileStream(aFilename, FileMode.Open);
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                uint id = reader.ReadUInt32();
                if (id != 0x4b434c46)
                {
                    throw new Exception(string.Format("'{0}' is not a flock file", Path.GetFileName(aFilename)));
                }

                int version = reader.ReadInt32();
                if (version <= 7)
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
                    throw new Exception(string.Format("'{0}' has an unsupported version number.", Path.GetFileName(aFilename)));
                }
            }
        }

        public void Offset(float dx, float dy)
        {
            int numMarkers = mMarkers.Count;
            for (int i = 0; i < numMarkers; i++)
            {
                Marker marker = mMarkers[i];
                marker.Location = new PointF(marker.Location.X + dx, marker.Location.Y + dy);
            }
        }

        public void Rotate(float cx, float cy, float angle)
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
        }
    }
}
