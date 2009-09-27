using System;
using System.Collections.Generic;
using System.Drawing;

namespace WingSuitJudge
{
    public static class Delaunay
    {
        public struct Triangle
        {
            public int A;
            public int B;
            public int C;

            public Triangle(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }
        }

        private struct Edge
        {
            public int A;
            public int B;

            public Edge(int a, int b)
            {
                A = a;
                B = b;
            }
        }

        public static List<Triangle> Triangulate(List<PointF> aPoints)
        {
            int numPoints = aPoints.Count;
            if (numPoints < 3)
            {
                return null;
            }

            int maxNumTriangles = 4 * numPoints;
            List<Triangle> triangles = new List<Triangle>();

            // Find the maximum and minimum vertex bounds.
            // This is to allow calculation of the bounding supertriangle
            float xmin = aPoints[0].X;
            float ymin = aPoints[0].Y;
            float xmax = xmin;
            float ymax = ymin;
            for (int i = 1; i < numPoints; ++i)
            {
                xmin = Math.Min(xmin, aPoints[i].X);
                xmax = Math.Max(xmax, aPoints[i].X);
                ymin = Math.Min(ymin, aPoints[i].Y);
                ymax = Math.Max(ymax, aPoints[i].Y);
            }

            float dx = xmax - xmin;
            float dy = ymax - ymin;
            float dmax = Math.Max(dx, dy);
            float xmid = (xmax + xmin) * 0.5f;
            float ymid = (ymax + ymin) * 0.5f;

            // Set up the supertriangle
            // This is a triangle which encompasses all the sample aPoints.
            // The supertriangle coordinates are added to the end of the
            // aPoints list. The supertriangle is the first triangle in
            // the triangle list.
            aPoints.Add(new PointF((xmid - 2 * dmax), (ymid - dmax)));
            aPoints.Add(new PointF(xmid, (ymid + 2 * dmax)));
            aPoints.Add(new PointF((xmid + 2 * dmax), (ymid - dmax)));
            triangles.Add(new Triangle(numPoints, numPoints + 1, numPoints + 2));

            // Include each point one at a time into the existing mesh
            for (int i = 0; i < numPoints; i++)
            {
                List<Edge> edges = new List<Edge>();
                // Set up the edge buffer.
                // If the point (aPoints(i).X,aPoints(i).Y) lies inside the circumcircle then the
                // three edges of that triangle are added to the edge buffer and the triangle is removed from list.
                for (int j = 0; j < triangles.Count; j++)
                {
                    if (InCircle(aPoints[i], aPoints[triangles[j].A], aPoints[triangles[j].B], aPoints[triangles[j].C]))
                    {
                        edges.Add(new Edge(triangles[j].A, triangles[j].B));
                        edges.Add(new Edge(triangles[j].B, triangles[j].C));
                        edges.Add(new Edge(triangles[j].C, triangles[j].A));
                        triangles.RemoveAt(j);
                        j--;
                    }
                }
                if (i >= numPoints) continue; //In case the last duplicate point we removed was the last in the array

                // Remove duplicate edges
                // Note: if all triangles are specified anticlockwise then all
                // interior edges are opposite pointing in direction.
                for (int j = edges.Count - 2; j >= 0; j--)
                {
                    for (int k = edges.Count - 1; k >= j + 1; k--)
                    {
                        if (compareEdges(edges[j], edges[k]))
                        {
                            edges.RemoveAt(k);
                            edges.RemoveAt(j);
                            k--;
                            continue;
                        }
                    }
                }
                // Form new triangles for the current point
                // Skipping over any tagged edges.
                // All edges are arranged in clockwise order.
                for (int j = 0; j < edges.Count; j++)
                {
                    if (triangles.Count >= maxNumTriangles)
                    {
                        throw new ApplicationException("Exceeded maximum edges");
                    }
                    triangles.Add(new Triangle(edges[j].A, edges[j].B, i));
                }
                edges.Clear();
                edges = null;
            }

            // Remove triangles with supertriangle vertices
            // These are triangles which have a points number greater than nv
            for (int i = triangles.Count - 1; i >= 0; i--)
            {
                if (triangles[i].A >= numPoints || triangles[i].B >= numPoints || triangles[i].C >= numPoints)
                {
                    triangles.RemoveAt(i);
                }
            }

            //Remove SuperTriangle vertices
            aPoints.RemoveAt(aPoints.Count - 1);
            aPoints.RemoveAt(aPoints.Count - 1);
            aPoints.RemoveAt(aPoints.Count - 1);
            triangles.TrimExcess();
            return triangles;
        }

        // Checks whether two edges are equal disregarding the direction of the edges
        private static bool compareEdges(Edge first, Edge second)
        {
            return (((first.A == second.B) && (first.B == second.A)) ||
                    ((first.A == second.A) && (first.B == second.B)));
        }

        // Returns true if the point (p) lies inside the circumcircle made up by points (p1,p2,p3)
        private static bool InCircle(PointF p, PointF p1, PointF p2, PointF p3)
        {
            if (System.Math.Abs(p1.Y - p2.Y) < double.Epsilon && System.Math.Abs(p2.Y - p3.Y) < double.Epsilon)
            {
                //Points are coincident !!
                return false;
            }

            double m1, m2;
            double mx1, mx2;
            double my1, my2;
            // Circumcircle center point
            double xc, yc;

            if (System.Math.Abs(p2.Y - p1.Y) < double.Epsilon)
            {
                m2 = -(p3.X - p2.X) / (p3.Y - p2.Y);
                mx2 = (p2.X + p3.X) * 0.5;
                my2 = (p2.Y + p3.Y) * 0.5;
                //Calculate CircumCircle center (xc,yc)
                xc = (p2.X + p1.X) * 0.5;
                yc = m2 * (xc - mx2) + my2;
            }
            else if (System.Math.Abs(p3.Y - p2.Y) < double.Epsilon)
            {
                m1 = -(p2.X - p1.X) / (p2.Y - p1.Y);
                mx1 = (p1.X + p2.X) * 0.5;
                my1 = (p1.Y + p2.Y) * 0.5;
                //Calculate CircumCircle center (xc,yc)
                xc = (p3.X + p2.X) * 0.5;
                yc = m1 * (xc - mx1) + my1;
            }
            else
            {
                m1 = -(p2.X - p1.X) / (p2.Y - p1.Y);
                m2 = -(p3.X - p2.X) / (p3.Y - p2.Y);
                mx1 = (p1.X + p2.X) * 0.5;
                mx2 = (p2.X + p3.X) * 0.5;
                my1 = (p1.Y + p2.Y) * 0.5;
                my2 = (p2.Y + p3.Y) * 0.5;
                //Calculate CircumCircle center (xc,yc)
                xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
                yc = m1 * (xc - mx1) + my1;
            }

            double dx = p2.X - xc;
            double dy = p2.Y - yc;
            double rsqr = dx * dx + dy * dy;
            //double r = Math.Sqrt(rsqr); //Circumcircle radius
            dx = p.X - xc;
            dy = p.Y - yc;
            double drsqr = dx * dx + dy * dy;

            return (drsqr <= rsqr);
        }
    }
}
