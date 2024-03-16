using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace p4
{
    internal class Matrix
    {
        public float[,] matrix = new float[4, 4];
        public Vector3 Multiply(Vector3 vec)
        {

            Vector3 result = new Vector3();

            result.X = vec.X * this.matrix[0, 0] + vec.Y * this.matrix[1, 0] + vec.Z * this.matrix[2, 0] + this.matrix[3, 0];
            result.Y = vec.X * this.matrix[0, 1] + vec.Y * this.matrix[1, 1] + vec.Z * this.matrix[2, 1] + this.matrix[3, 1];
            result.Z = vec.X * this.matrix[0, 2] + vec.Y * this.matrix[1, 2] + vec.Z * this.matrix[2, 2] + this.matrix[3, 2];
            float w = vec.X * this.matrix[0, 3] + vec.Y * this.matrix[1, 3] + vec.Z * this.matrix[2, 3] + this.matrix[3, 3];

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
