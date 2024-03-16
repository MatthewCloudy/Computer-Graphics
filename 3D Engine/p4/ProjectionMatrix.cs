using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    public class ProjectionMatrix
    {
        float[,] matrix = new float[4,4];
        float fNear = 0.1f;
        float fFar = 1000.0f;
        float fFov = 90.0f;
        float fAspectRatio;
        float fFovRad;

        public ProjectionMatrix(float fNear, float fFar, float fFov, float ScreenHeight, float ScreenWidth)
        {
            this.fNear = fNear;
            this.fFar = fFar;
            this.fFov = fFov;
            this.fAspectRatio = ScreenHeight / ScreenWidth;
            this.fFovRad = (float)(1.0f / Math.Tan(fFov * 0.5f / 180.0f * 3.14159f));

            matrix[0, 0] = fAspectRatio * fFovRad;
            matrix[1, 1] = fFovRad;
            matrix[2, 2] = fFar / (fFar - fNear);
            matrix[3, 2] = (-fFar * fNear) / (fFar - fNear);
            matrix[2, 3] = 1.0f;
            matrix[3, 3] = 0.0f;

        }

        public Vector3 Multiply(Vector3 vec)
        {

            Vector3 result = new Vector3();

            result.X = vec.X * this.matrix[0, 0] + vec.Y * this.matrix[1, 0] + vec.Z * this.matrix[2, 0] + this.matrix[3, 0];
            result.Y = vec.X * this.matrix[0, 1] + vec.Y * this.matrix[1, 1] + vec.Z * this.matrix[2, 1] + this.matrix[3, 1];
            result.Z = vec.X * this.matrix[0, 2] + vec.Y * this.matrix[1, 2] + vec.Z * this.matrix[2, 2] + this.matrix[3, 2];
            float w  = vec.X * this.matrix[0, 3] + vec.Y * this.matrix[1, 3] + vec.Z * this.matrix[2, 3] + this.matrix[3, 3];

            if (w != 0.0f)
            {
                vec.X /= w;
                vec.Y /= w;
                vec.Z /= w;
            }

            return result;
        }

        
    }
}
