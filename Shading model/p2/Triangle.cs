using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p2
{
    public class Triangle
    {
        public Vector3 v1;
        public Vector3 v2;
        public Vector3 v3;
        public Vector3 n1;
        public Vector3 n2;
        public Vector3 n3;

        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 n1, Vector3 n2, Vector3 n3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
        }
    }
}
