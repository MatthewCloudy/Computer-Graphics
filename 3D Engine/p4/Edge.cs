using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    public class Edge
    {
        public int ymax;
        public float x;
        public float slope;
        public Edge(int ymax, int x, float slope)
        {
            this.ymax = ymax;
            this.x = x;
            this.slope = slope;
        }
    }
}
