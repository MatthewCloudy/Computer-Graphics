using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    internal class ProjMatrix
    {
        public Matrix4x4 m;
        float n = 0.1f;
        float f = 1000.0f;
        float fov = 90.0f;
        float fAspectRatio;
        float fFovRad;

        public ProjMatrix(float n, float f, float fov, float ScreenHeight, float ScreenWidth)
        {


            //    this.fNear = fNear;
            //    this.fFar = fFar;
            //    this.fFov = fFov;
            //    this.fAspectRatio = ScreenHeight / ScreenWidth;
            //    this.fFovRad = (float)(1.0f / Math.Tan(fFov * 0.5f / 180.0f * 3.14159f));

            this.fAspectRatio = ScreenWidth / ScreenHeight;

            float m11 = (1 / (float)Math.Tan((fov / 180.0f * Math.PI) / 2.0f)) / (float)fAspectRatio;
            float m22 = 1 / (float)Math.Tan((fov / 180.0f * Math.PI) / 2.0f);
            float m33 = (f + n) / (f - n);
            float m34 = -(2*f*n) / (f - n);

            m = new Matrix4x4(m11, 0, 0, 0,
                              0, m22, 0, 0,
                              0, 0, m33, m34,
                              0, 0, 1, 0);



        }
    }
}
