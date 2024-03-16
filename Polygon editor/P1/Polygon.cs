using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Polygon
    {
        public List<Vertex> Vertices;
        int eps = 10;
        public bool isCompleted;
        public List<(Vertex, Vertex)> restrictedEdges = new List<(Vertex, Vertex)> ();
        public List<(Vertex, Vertex)> restrictedHorizontalEdges = new List<(Vertex, Vertex)> ();
        public List<(Vertex, Vertex)> offsetEdges = new List<(Vertex, Vertex)> ();
        public List<Vertex> offsetVertices = new List<Vertex> ();

        public Polygon()
        {
            this.Vertices = new List<Vertex>();
            isCompleted = false;
        }

        public void addVertex(Vertex v)
        {
            Vertices.Add(v);
            return;
        }

        public bool isVertexFirst(int locationX, int locationY)
        {
            if (Vertices.Count > 2 && Math.Abs(locationX - Vertices[0].point.X) < eps && Math.Abs(locationY - Vertices[0].point.Y) < eps)
                return true;
            return false;
        }

        public void calculateOffsetEdges(int offset)
        {
            offsetEdges.Clear();
            for(int i = 0; i < Vertices.Count; i++)
            {
                (int, int) vec = (Vertices[(i + 1) % Vertices.Count].point.X - Vertices[i].point.X, 
                    Vertices[(i + 1) % Vertices.Count].point.Y - Vertices[i].point.Y);

                if(vec.Item2 == 0)
                {
                    if(vec.Item1 < 0)
                    {
                        offsetEdges.Add((new Vertex(Vertices[i].point.X, Vertices[i].point.Y - offset, null),
                            new Vertex(Vertices[(i + 1) % Vertices.Count].point.X, Vertices[(i + 1) % Vertices.Count].point.Y - offset, null)));
                    }
                    else
                    {
                        offsetEdges.Add((new Vertex(Vertices[i].point.X, Vertices[i].point.Y + offset, null),
                            new Vertex(Vertices[(i + 1) % Vertices.Count].point.X, Vertices[(i + 1) % Vertices.Count].point.Y + offset, null)));
                    }
                    continue;
                }

                double w1 = Math.Sqrt((offset * offset) / (1 + (vec.Item1 * vec.Item1) / (vec.Item2 * vec.Item2)));
                double w2 = -vec.Item1 * w1 / vec.Item2;


                if(vec.Item2 > 0)
                {
                    w1 = -Math.Sqrt((float)(offset * offset) / ((float)(1 + (vec.Item1 * vec.Item1) / (vec.Item2 * vec.Item2))));
                    w2 = -vec.Item1 * w1 / vec.Item2;
                }
                if(vec.Item2 < 0)
                {
                    w1 = Math.Sqrt((float)(offset * offset) / ((float)(1 + (vec.Item1 * vec.Item1) / (vec.Item2 * vec.Item2))));
                    w2 = -vec.Item1 * w1 / vec.Item2;
                }


                int offsetX1 = (int)(Vertices[i].point.X + w1);
                int offsetY1 = (int)(Vertices[i].point.Y + w2);

                int offsetX2 = (int)(Vertices[(i + 1) % Vertices.Count].point.X + w1);
                int offsetY2 = (int)(Vertices[(i + 1) % Vertices.Count].point.Y + w2);
                offsetEdges.Add((new Vertex(offsetX1, offsetY1, null), new Vertex(offsetX2, offsetY2, null)));
            }
        }
        public void calculateOffsetVertices()
        {
            int c = offsetEdges.Count;
            offsetVertices.Clear();
            for (int i = 0; i < c; i++)
            {
                (Vertex, Vertex) e1 = offsetEdges[i];
                (Vertex, Vertex) e2 = offsetEdges[(i + 1) % c];

                int x1 = e1.Item1.point.X;
                int y1 = e1.Item1.point.Y;

                int x2 = e1.Item2.point.X;
                int y2 = e1.Item2.point.Y;

                int x3 = e2.Item1.point.X;
                int y3 = e2.Item1.point.Y;

                int x4 = e2.Item2.point.X;
                int y4 = e2.Item2.point.Y;

                int Px;
                int Py;



                if(y1==y2 && x3==x4)
                {
                    Px = x3;
                    Py = y1;
                    offsetVertices.Add(new Vertex(Px, Py, this));
                    continue;

                }
                if (y3 == y4 && x1 == x2)
                {
                    Px = x1;
                    Py = y3;
                    offsetVertices.Add(new Vertex(Px, Py, this));
                    continue;
                }

                if (y1 == y2 && y3 == y4 || x1 == x2 && x3 == x4)
                {
                    Px = x1;
                    Py = y1;
                    offsetVertices.Add(new Vertex(Px, Py, this));
                    continue;
                }

                if (x1 == x2 && x2 == x3)
                {
                    Px = x1;
                    Py = y2;
                    offsetVertices.Add(new Vertex(Px, Py, this));
                    continue;
                }

                if (x2 == x3 && x3 == x4)
                {
                    Px = x2;
                    Py = y3;
                    offsetVertices.Add(new Vertex(Px, Py, this));
                    continue;
                }

                // Ten sam punkt
                if(x1== x2 && y1 == y2)
                {
                    Px = x1;
                    Py = y1;
                    offsetVertices.Add(new Vertex(Px, Py, this));
                    continue;
                }
                if (x3 == x4 && y3 == y4)
                {
                    Px = x1;
                    Py = y1;
                    offsetVertices.Add(new Vertex(Px, Py, this));
                    continue;
                }
                if((x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4) == 0)
                {
                    continue;
                }


                Px = ((x1*y2-y1*x2)*(x3-x4)-(x1-x2)*(x3*y4-y3*x4)) / ((x1-x2)*(y3-y4)-(y1-y2)*(x3-x4));
                Py = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / ((x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4));

                offsetVertices.Add(new Vertex(Px, Py, this));
            }
        }
    }
}
