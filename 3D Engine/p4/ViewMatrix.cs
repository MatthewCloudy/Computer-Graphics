using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    internal class ViewMatrix
    {
        public Matrix4x4 m;
        
        public ViewMatrix(Vector3 P, Vector3 T, Vector3 U)
        {

            Vector3 D = Vector3.Normalize(Vector3.Subtract(P, T));
            Vector3 R = Vector3.Normalize(Vector3.Cross(U, D));
            Vector3 Up = Vector3.Normalize(Vector3.Cross(D, R));

            Matrix4x4 mL = new Matrix4x4(R.X, R.Y, R.Z, 0,
                                         Up.X, Up.Y, Up.Z, 0,
                                         D.X, D.Y, D.Z, 0,
                                         0, 0, 0, 1);

            Matrix4x4 mR = new Matrix4x4(1, 0, 0, -P.X,
                                         0, 1, 0, -P.Y,
                                         0, 0, 1, -P.Z,
                                         0, 0, 0, 1);

            m = Matrix4x4.Multiply(mL, mR);
        }

    }
}
