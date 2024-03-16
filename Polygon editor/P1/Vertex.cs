using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Vertex
    {
        public Polygon parent;
        public Point point;
        public bool restrictionVertical = false;
        public bool restrictionHorizontal = false;
        public Vertex(int x, int y, Polygon parent) 
        {
            this.point = new Point(x, y);
            this.parent = parent;
        }

        public Vertex(Point p, Polygon parent)
        {
            this.point = new Point(p.X,p.Y);
            this.parent = parent;
        }
    }
}
