using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    internal class TranslationMatrix
    {
        public Matrix4x4 m;

        public TranslationMatrix(float x, float y, float z)
        {
            m = new Matrix4x4(1, 0, 0, x,
                              0, 1, 0, y,
                              0, 0, 1, z,
                              0, 0, 0, 1);
        }
    }
}
