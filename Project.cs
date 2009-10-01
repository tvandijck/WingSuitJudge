using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace WingSuitJudge
{
    public class Project
    {
        private List<Marker> mMarkers = new List<Marker>();
        private List<Line> mLines = new List<Line>();
        private int mBaseMarker = 0;
        private int mBaseLine = 0;
        private int mDistanceTolerance = 25;
        private Color mBackColor = SystemColors.AppWorkspace;

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

        public Color BackColor
        {
            get { return mBackColor; }
            set { mBackColor = value; }
        }

        public int BaseMarker
        {
            get { return mBaseMarker; }
            set { mBaseMarker = value; }
        }

        public int BaseLine
        {
            get { return mBaseLine; }
            set { mBaseLine = value; }
        }

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

        public int DistanceTolerance
        {
            get { return mDistanceTolerance; }
            set { mDistanceTolerance = value; }
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

        #region -- Marker API -------------------------------------------------

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
                mBaseLine = Math.Max(0, Math.Min(mBaseLine, mLines.Count - 1));
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

        #endregion

        public void PaintSilhouette(Graphics aGraphics)
        {
            int numMarkers = mMarkers.Count;
            for (int i = 0; i < numMarkers; i++)
            {
                Marker marker = mMarkers[i];
                marker.DrawSilhouette(aGraphics);
            }
        }

        public void Paint(Graphics aGraphics, int aSelectedLine, int aSelectedMarker)
        {
            // get line base length.
            float baseLength = 0;
            float minLength = 0;
            float maxLength = 1000;
            bool hasTolerance = false;
            if (mBaseLine >= 0 && mBaseLine < mLines.Count)
            {
                float dtol = mDistanceTolerance * 0.01f;
                baseLength = mLines[mBaseLine].GetLength();
                minLength = baseLength - (baseLength * dtol);
                maxLength = baseLength + (baseLength * dtol);
                hasTolerance = true;
            }

            // draw lines.
            int numLines = mLines.Count;
            for (int i = 0; i < numLines; i++)
            {
                Line line = mLines[i];
                float length = line.GetLength();
                bool error = (length < minLength) || (length > maxLength);
                line.Draw(aGraphics, i == aSelectedLine, i == mBaseLine, error);
            }

            // draw tolerance areas.
            if (hasTolerance)
            {
                foreach (Marker marker in mMarkers)
                {
                    if (marker.ShowArea)
                    {
                        float x = marker.Location.X;
                        float y = marker.Location.Y;
                        aGraphics.DrawEllipse(Colors.ThinGrayPen, x - minLength, y - minLength, minLength * 2, minLength * 2);
                        aGraphics.DrawEllipse(Colors.ThinGrayPen, x - maxLength, y - maxLength, maxLength * 2, maxLength * 2);
                    }
                }
            }

            // draw markers.
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
                if (mBaseLine >= 0 && mBaseLine < mLines.Count)
                {
                    float dtol = mDistanceTolerance * 0.01f;
                    float baseLength = mLines[mBaseLine].GetLength();
                    float minLength = baseLength - (baseLength * dtol);
                    float maxLength = baseLength + (baseLength * dtol);

                    float totalError = 0;
                    float totalLength = 0;
                    int numLines = mLines.Count;
                    for (int i = 0; i < numLines; i++)
                    {
                        Line line = mLines[i];
                        float length = line.GetLength();
                        if (length < minLength)
                        {
                            totalError += (minLength - length);
                        }
                        if (length > maxLength)
                        {
                            totalError += (length - maxLength);
                        }
                        totalLength += length;
                    }

                    return 1.0f - (totalError / totalLength);
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
                writer.Write((int)3);
                writer.Write(mBaseMarker);
                writer.Write(mBaseLine);
                writer.Write(mDistanceTolerance);

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
                    writer.Write(marker.ShowArea);
                    writer.Write(marker.ShowSilhouette);
                    writer.Write(marker.SilhoutteColor.ToArgb());

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
                if (version == 1 || version == 2 || version == 3)
                {
                    mBaseMarker = reader.ReadInt32();
                    mBaseLine = reader.ReadInt32();
                    mDistanceTolerance = reader.ReadInt32();

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
                        marker.ShowArea = reader.ReadBoolean();
                        if (version >= 3)
                        {
                            marker.ShowSilhouette = reader.ReadBoolean();
                            marker.SilhoutteColor = Color.FromArgb(reader.ReadInt32());
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
    }
}
