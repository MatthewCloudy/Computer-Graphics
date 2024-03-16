using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    internal class zRotationMatrix
    {
        Matrix4x4 m;

        public zRotationMatrix(float alfa)
        {
            m = new Matrix4x4((float)Math.Cos(alfa), -(float)Math.Sin(alfa), 0, 0,
                              (float)Math.Sin(alfa),  (float)Math.Cos(alfa), 0, 0,
                              0, 0, 1, 0,
                              0, 0, 0, 1);
        }
    }
}
