using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p4
{
    public class Triangle
    {
        public Vector3[] vertices;
        public Vector3[] normals;

        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            vertices = new Vector3[3] { p1, p2, p3 };
            // Normal vector
            Vector3 line1 = Vector3.Subtract(this.vertices[1], this.vertices[0]);
            Vector3 line2 = Vector3.Subtract(this.vertices[2], this.vertices[0]);
            Vector3 normal = new Vector3();
            normal.X = line1.Y * line2.Z - line1.Z * line2.Y;
            normal.Y = line1.Z * line2.X - line1.X * line2.Z;
            normal.Z = line1.X * line2.Y - line1.Y * line2.X;

            normal = Vector3.Normalize(normal);

            normals = new Vector3[3] { normal, normal, normal };
        }
        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 n1, Vector3 n2, Vector3 n3)
        {
            vertices = new Vector3[3] { p1, p2, p3 };
            normals = new Vector3[3] { n1, n2, n3 };
        }
        public Triangle()
        {
            vertices = new Vector3[3];
        }

        public Vector3 MatrixMultiply(Matrix4x4 matrix, Vector3 vec)
        {
            Vector3 result = new Vector3();

            result.X = vec.X * matrix[0, 0] + vec.Y * matrix[0, 1] + vec.Z * matrix[0, 2] + matrix[0, 3];
            result.Y = vec.X * matrix[1, 0] + vec.Y * matrix[1, 1] + vec.Z * matrix[1, 2] + matrix[1, 3];
            result.Z = vec.X * matrix[2, 0] + vec.Y * matrix[2, 1] + vec.Z * matrix[2, 2] + matrix[2, 3];
            float w  = vec.X * matrix[3, 0] + vec.Y * matrix[3, 1] + vec.Z * matrix[3, 2] + matrix[3, 3];

            if (w != 0.0f)
            {
                result.X /= w;
                result.Y /= w;
                result.Z /= w;
            }

            return result;

        }

        public Triangle TriangleMultiply(Matrix4x4 matrix, Matrix4x4 matrixNormal)
        {
            Vector3 v1 = this.MatrixMultiply(matrix, this.vertices[0]);
            Vector3 v2 = this.MatrixMultiply(matrix, this.vertices[1]);
            Vector3 v3 = this.MatrixMultiply(matrix, this.vertices[2]);

            Vector3 n1 = this.MatrixMultiply(matrixNormal, this.vertices[0]);
            Vector3 n2 = this.MatrixMultiply(matrixNormal, this.vertices[1]);
            Vector3 n3 = this.MatrixMultiply(matrixNormal, this.vertices[2]);

            return new Triangle(v1, v2, v3, n1, n2, n3);
        }
        public Triangle TriangleMultiply(Matrix4x4 matrix)
        {
            Vector3 v1 = this.MatrixMultiply(matrix, this.vertices[0]);
            Vector3 v2 = this.MatrixMultiply(matrix, this.vertices[1]);
            Vector3 v3 = this.MatrixMultiply(matrix, this.vertices[2]);

            return new Triangle(v1, v2, v3, this.normals[0], this.normals[1], this.normals[2]);

        }
        public void MoveToScreen(int Width, int Height)
        {
            this.vertices[0].X += 1.0f;
            this.vertices[0].Y += 1.0f;
            this.vertices[1].X += 1.0f;
            this.vertices[1].Y += 1.0f;
            this.vertices[2].X += 1.0f;
            this.vertices[2].Y += 1.0f;
            this.vertices[0].X *= 0.5f * Width;
            this.vertices[0].Y *= 0.5f * Height;
            this.vertices[1].X *= 0.5f * Width;
            this.vertices[1].Y *= 0.5f * Height;
            this.vertices[2].X *= 0.5f * Width;
            this.vertices[2].Y *= 0.5f * Height;
        }

        public Triangle TriangleMatrixTransformation(List<Matrix4x4> matrices, List<Matrix4x4> matricesForNormals)
        {
            Matrix4x4 currentMatrix = matrices.First();

            matrices.RemoveAt(0);


            foreach(var matrix in matrices)
            {
                currentMatrix = Matrix4x4.Multiply(matrix, currentMatrix);
            }
            if(matricesForNormals.Count == 0)
            {
                return this.TriangleMultiply(currentMatrix);
            }
            Matrix4x4 currentMatrixNormals = matricesForNormals.First();
            matricesForNormals.RemoveAt(0);
            foreach (var matrixNormal in matricesForNormals)
            {
                currentMatrixNormals = Matrix4x4.Multiply(matrixNormal, currentMatrixNormals);
            }

            return this.TriangleMultiply(currentMatrix, currentMatrixNormals);
        }

        public Vector3 CubeNormalVector()
        {
            Vector3 normal = new Vector3();
            Vector3 line1 = Vector3.Subtract(this.vertices[1], this.vertices[0]);
            Vector3 line2 = Vector3.Subtract(this.vertices[2], this.vertices[0]);
            normal.X = line1.Y * line2.Z - line1.Z * line2.Y;
            normal.Y = line1.Z * line2.X - line1.X * line2.Z;
            normal.Z = line1.X * line2.Y - line1.Y * line2.X;

            return Vector3.Normalize(normal);
        }

        public float BaricentricInterpolateZ(float x, float y)
        {
            float l1 = (float)((this.vertices[1].Y - this.vertices[2].Y) * (x - this.vertices[2].X) + (this.vertices[2].X - this.vertices[1].X) * (y - this.vertices[2].Y)) /
                (((this.vertices[1].Y - this.vertices[2].Y) * (this.vertices[0].X - this.vertices[2].X)) + ((this.vertices[2].X - this.vertices[1].X) * (this.vertices[0].Y - this.vertices[2].Y)));
            float l2 = (float)((this.vertices[2].Y - this.vertices[0].Y) * (x - this.vertices[2].X) + (this.vertices[0].X - this.vertices[2].X) * (y - this.vertices[2].Y)) /
                (((this.vertices[1].Y - this.vertices[2].Y) * (this.vertices[0].X - this.vertices[2].X)) + ((this.vertices[2].X - this.vertices[1].X) * (this.vertices[0].Y - this.vertices[2].Y)));
            float l3 = 1 - l1 - l2;

            return this.vertices[0].Z * l1 + this.vertices[1].Z * l2 + this.vertices[2].Z * l3;
        }
        public (float, float, float) BaricentricParams(float x, float y)
        {
            float l1 = (float)((this.vertices[1].Y - this.vertices[2].Y) * (x - this.vertices[2].X) + (this.vertices[2].X - this.vertices[1].X) * (y - this.vertices[2].Y)) /
                (((this.vertices[1].Y - this.vertices[2].Y) * (this.vertices[0].X - this.vertices[2].X)) + ((this.vertices[2].X - this.vertices[1].X) * (this.vertices[0].Y - this.vertices[2].Y)));
            float l2 = (float)((this.vertices[2].Y - this.vertices[0].Y) * (x - this.vertices[2].X) + (this.vertices[0].X - this.vertices[2].X) * (y - this.vertices[2].Y)) /
                (((this.vertices[1].Y - this.vertices[2].Y) * (this.vertices[0].X - this.vertices[2].X)) + ((this.vertices[2].X - this.vertices[1].X) * (this.vertices[0].Y - this.vertices[2].Y)));
            float l3 = 1 - l1 - l2;

            return (l1, l2, l3);
        }
    }
}
