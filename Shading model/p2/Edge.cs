using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2
{
    public class Edge
    {
        public int ymax;
        public int x;
        public double slope;
        public Edge(int ymax, int x, double slope)
        {
            this.ymax = ymax;
            this.x = x;
            this.slope = slope;
        }
    }
}
