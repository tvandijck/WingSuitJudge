using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace WingSuitJudge
{
    public static class CommandSystem
    {
        interface ICommand
        {
            void Undo();
        }

        class GenericRollback : ICommand
        {
            Project mProject;
            byte[] mMemory;

            public GenericRollback(Project aProject)
            {
                mProject = aProject;
                using (MemoryStream stream = new MemoryStream())
                {
                    mProject.Serialize(stream);
                    mMemory = stream.ToArray();
                }
            }

            public void Undo()
            {
                using (MemoryStream stream = new MemoryStream(mMemory))
                {
                    mProject.Clear();
                    mProject.Deserialize("undo", stream);
                    mProject.Dirty = true;
                }
            }
        }
        
        private static Stack<ICommand> mUndoStack = new Stack<ICommand>();
        private static Stack<ICommand> mRedoStack = new Stack<ICommand>();

        public static void Reset()
        {
            mUndoStack.Clear();
            mRedoStack.Clear();
        }

        public static void Undo(Project aProject)
        {
            if (mUndoStack.Count > 0)
            {
                mRedoStack.Push(new GenericRollback(aProject));
                mUndoStack.Pop().Undo();
            }
        }

        public static void Redo(Project aProject)
        {
            if (mRedoStack.Count > 0)
            {
                mUndoStack.Push(new GenericRollback(aProject));
                mRedoStack.Pop().Undo();
            }
        }

        public static void AddRollback(Project aProject)
        {
            mRedoStack.Clear();
            mUndoStack.Push(new GenericRollback(aProject));
        }

        public static void AddMarker(Project aProject, float aX, float aY)
        {
            AddRollback(aProject);
            aProject.AddMarker(new Marker(aX, aY));
        }

        public static void RemoveMarker(Project aProject, int aIndex)
        {
            AddRollback(aProject);
            aProject.RemoveMarker(aIndex);
        }

        public static void MoveMarker(Project aProject, int aIndex, PointF aOld, PointF aNew)
        {
            if (aIndex != -1)
            {
                AddRollback(aProject);
                Marker marker = aProject.GetMarker(aIndex);
                marker.Location = aNew;
                aProject.Dirty = true;
            }
        }

        public static void MarkerToggleFlightZone(Project aProject, int aIndex)
        {
            if (aIndex != -1)
            {
                AddRollback(aProject);
                Marker marker = aProject.GetMarker(aIndex);
                marker.ShowFlightZone = !marker.ShowFlightZone;
                aProject.Dirty = true;
            }
        }

        public static void AddLine(Project aProject, int aStart, int aEnd)
        {
            if (aStart != aEnd)
            {
                AddRollback(aProject);
                aProject.AddLine(aStart, aEnd);
            }
        }

        public static void RemoveLine(Project aProject, int aIndex)
        {
            if (aIndex != -1)
            {
                AddRollback(aProject);
                aProject.RemoveLine(aIndex);
            }
        }

    }
}
