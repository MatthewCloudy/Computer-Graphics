using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Threading;

namespace p4
{
    public partial class Form1 : Form
    {
        // Z-buffer
        float[,] zBuffer;

        // Objects in scene
        Cube cube;
        Cube cube2;
        Sphere sphere;

        // Timer and params
        System.Windows.Forms.Timer animationTimer;
        float fTheta = 0.0f;
        float dZ = 1.0f;
        float angle = 0.0f; // aktualny k¹t (w radianach)
        float radius = 0.75f; // promieñ okrêgu
        float cubeX;
        float cubeY;
        // Shading params
        Vector3 light = new Vector3(0.0f, 0.0f, 20.5f);
        float ka = 0.2f;
        float kd = 5.0f;
        float ks = 4.0f;
        float alfa = 10f;
        float Ia = 1.0f;
        float Id = 1.0f;
        float Is = 1.0f;
        float Ac = 1f;
        float Al = 0.09f;
        float Aq = 0.032f;
        Color objectColor = Color.FromArgb(0, 0, 255);


        // Cameras params
        Vector3 CameraPosition = new Vector3(3.0f, 1.5f, 8.5f);
        Vector3 CameraTarget = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 CameraUpVector = new Vector3(0.0f, 1.0f, 0.0f);

        // Cameras params
        Vector3 CameraPosition1 = new Vector3(3.0f, 1.5f, 8.5f);
        Vector3 CameraTarget1 = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 CameraUpVector1 = new Vector3(0.0f, 1.0f, 0.0f);

        // Cameras params
        Vector3 CameraPosition2 = new Vector3(3.0f, 1.5f, 6.5f);
        Vector3 CameraTarget2 = new Vector3(1.0f, -1.0f, 0.0f);
        Vector3 CameraUpVector2 = new Vector3(0.0f, 1.0f, 0.0f);

        bool movingClicked = false;
        public Form1()
        {
            InitializeComponent();

            cube = new Cube();
            cube2 = new Cube();
            sphere = new Sphere(5, 7, 1);
            zBuffer = new float[pictureBox1.Height + 2, pictureBox1.Width + 2];
            for (int i = 0; i < pictureBox1.Height + 1; i++)
            {
                for (int j = 0; j < pictureBox1.Width + 1; j++)
                {
                    zBuffer[i, j] = float.MinValue;
                }
            }
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 20;
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            fTheta += 0.05f;
            dZ -= 0.15f;

            // Zwiêksz k¹t, aby szeœcian przemieszcza³ siê po okrêgu
            angle += 0.05f;

            // Oblicz nowe pozycje szeœcianu na podstawie równañ parametrycznych okrêgu
            float x = (float)(radius * Math.Cos(angle));
            float y = (float)(radius * Math.Sin(angle));

            // Ustaw nowe pozycje szeœcianu
            cubeX = x;
            cubeY = y;
            pictureBox1.Invalidate();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            animationTimer.Start();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            for (int i = 0; i < pictureBox1.Height + 1; i++)
            {
                for (int j = 0; j < pictureBox1.Width + 1; j++)
                {
                    zBuffer[i, j] = float.MinValue;
                }
            }

            foreach (var triangle in sphere.triangles)
            {
                // Tranformation matrices

                Matrix4x4 translMatrix = new TranslationMatrix(0, 0, -2).m;
                Matrix4x4 viewMatrix = new ViewMatrix(CameraPosition, CameraTarget, CameraUpVector).m;
                Matrix4x4 projectionMatrix = new ProjMatrix(1.0f, 100.0f, 45.0f, pictureBox1.Height, pictureBox1.Width).m;


                // Projected triangle
                Triangle projTriangle = triangle.TriangleMatrixTransformation(new List<Matrix4x4> {
                                            translMatrix, viewMatrix, projectionMatrix}, new List<Matrix4x4> { });



                projTriangle.MoveToScreen(pictureBox1.Width, pictureBox1.Height);


                // Normal vector
                Vector3 line1 = Vector3.Subtract(projTriangle.vertices[1], projTriangle.vertices[0]);
                Vector3 line2 = Vector3.Subtract(projTriangle.vertices[2], projTriangle.vertices[0]);
                Vector3 normal = new Vector3();
                normal.X = line1.Y * line2.Z - line1.Z * line2.Y;
                normal.Y = line1.Z * line2.X - line1.X * line2.Z;
                normal.Z = line1.X * line2.Y - line1.Y * line2.X;

                normal = Vector3.Normalize(normal);
                Vector3 subtractVec = Vector3.Subtract(projTriangle.vertices[0], CameraPosition);

                // Drawing visible faces
                if (Vector3.Dot(normal, subtractVec) < 0.0f)
                {
                    FillTriangle(projTriangle, e.Graphics, triangle, projTriangle.normals);
                }

            }

            if (movingClicked)
            {
                // Tranformation matrices
                Matrix4x4 zRotationMatrix1 = Matrix4x4.CreateRotationZ(fTheta);
                Matrix4x4 xRotationMatrix1 = Matrix4x4.CreateRotationX(fTheta);
                Matrix4x4 translMatrix11 = new TranslationMatrix(1, -1, 0).m;
                Matrix4x4 translMatrix1 = new TranslationMatrix(cubeX, cubeY, 0).m;


                // Projected triangle
                Triangle tri = cube.triangles.First().TriangleMatrixTransformation(new List<Matrix4x4> {
                                            zRotationMatrix1, xRotationMatrix1,translMatrix11, translMatrix1},
                                            new List<Matrix4x4> { zRotationMatrix1, xRotationMatrix1 });
                CameraTarget = tri.vertices[0];
            }

            foreach (var triangle in cube.triangles)
            {
                // Tranformation matrices
                Matrix4x4 zRotationMatrix = Matrix4x4.CreateRotationZ(fTheta);
                Matrix4x4 xRotationMatrix = Matrix4x4.CreateRotationX(fTheta);
                Matrix4x4 translMatrix1 = new TranslationMatrix(1, -1, 0).m;
                Matrix4x4 translMatrix = new TranslationMatrix(cubeX, cubeY, 0).m;
                Matrix4x4 viewMatrix = new ViewMatrix(CameraPosition, CameraTarget, CameraUpVector).m;
                Matrix4x4 projectionMatrix = new ProjMatrix(1.0f, 100.0f, 45.0f, pictureBox1.Height, pictureBox1.Width).m;


                // Projected triangle
                Triangle projTriangle = triangle.TriangleMatrixTransformation(new List<Matrix4x4> {
                                            zRotationMatrix, xRotationMatrix,translMatrix1, translMatrix, viewMatrix, projectionMatrix},
                                            new List<Matrix4x4> { zRotationMatrix, xRotationMatrix });

                // World triangle
                Triangle worldTriangle = triangle.TriangleMatrixTransformation(new List<Matrix4x4> {
                                            zRotationMatrix, xRotationMatrix}, new List<Matrix4x4> { zRotationMatrix, xRotationMatrix });

                projTriangle.MoveToScreen(pictureBox1.Width, pictureBox1.Height);


                // Normal vector
                Vector3 line1 = Vector3.Subtract(projTriangle.vertices[1], projTriangle.vertices[0]);
                Vector3 line2 = Vector3.Subtract(projTriangle.vertices[2], projTriangle.vertices[0]);
                Vector3 normal = new Vector3();
                normal.X = line1.Y * line2.Z - line1.Z * line2.Y;
                normal.Y = line1.Z * line2.X - line1.X * line2.Z;
                normal.Z = line1.X * line2.Y - line1.Y * line2.X;

                normal = Vector3.Normalize(normal);
                Vector3 subtractVec = Vector3.Subtract(projTriangle.vertices[0], CameraPosition);

                // Drawing visible faces
                if (Vector3.Dot(normal, subtractVec) < 0.0f)
                {
                    FillTriangle(projTriangle, e.Graphics, worldTriangle, projTriangle.normals);
                }

            }


            foreach (var triangle in cube2.triangles)
            {
                // Matrices
                Matrix4x4 translationMatrix = new TranslationMatrix(-5, 0, -7).m;
                Matrix4x4 viewMatrix = new ViewMatrix(CameraPosition, CameraTarget, CameraUpVector).m;
                Matrix4x4 projectionMatrix = new ProjMatrix(1.0f, 100.0f, 45.0f, pictureBox1.Height, pictureBox1.Width).m;

                // Projected triangle
                Triangle projTriangle = triangle.TriangleMatrixTransformation(new List<Matrix4x4> {
                                            translationMatrix, viewMatrix, projectionMatrix}, new List<Matrix4x4> { });


                // Moving to screen
                projTriangle.MoveToScreen(pictureBox1.Width, pictureBox1.Height);

                // Normal vector
                Vector3 normal = projTriangle.CubeNormalVector();

                // Checking visibility
                Vector3 subtractVec = Vector3.Subtract(projTriangle.vertices[0], CameraPosition);

                // Drawing visible faces
                if (Vector3.Dot(normal, subtractVec) < 0.0f)
                {
                    FillTriangle(projTriangle, e.Graphics, triangle, projTriangle.normals);
                }

            }

            foreach (var triangle in cube2.triangles)
            {
                // Matrices
                Matrix4x4 translationMatrix = new TranslationMatrix(-6, -1, -5).m;
                Matrix4x4 viewMatrix = new ViewMatrix(CameraPosition, CameraTarget, CameraUpVector).m;
                Matrix4x4 projectionMatrix = new ProjMatrix(1.0f, 100.0f, 45.0f, pictureBox1.Height, pictureBox1.Width).m;

                Matrix4x4 tranlViewMatrix = Matrix4x4.Multiply(viewMatrix, translationMatrix);
                Matrix4x4 ViewProjMatr = Matrix4x4.Multiply(projectionMatrix, tranlViewMatrix);


                // Result vectors
                Triangle projTriangle = triangle.TriangleMultiply(ViewProjMatr);

                // Move and scale to bitmap
                projTriangle.MoveToScreen(pictureBox1.Width, pictureBox1.Height);


                // Normal vector
                Vector3 normal = projTriangle.CubeNormalVector();
                Vector3 subtractVec = Vector3.Subtract(projTriangle.vertices[0], CameraPosition);

                if (Vector3.Dot(normal, subtractVec) < 0.0f)
                {
                    FillTriangle(projTriangle, e.Graphics, triangle, projTriangle.normals);
                }

            }

        }

        // Scanline algorithm
        private void FillTriangle(Triangle triangle, Graphics g, Triangle org, Vector3[] normals)
        {
            List<Edge>[] ET = new List<Edge>[10 * pictureBox1.Height];
            Edge e1, e2, e3;

            //foreach(var v in triangle.vertices)
            //{
            //    if(v.X >= pictureBox1.Width || v.Y >= pictureBox1.Height || v.X <= 0|| v.Y <= 0)
            //    {
            //        return;
            //    }
            //}

            if (triangle.vertices[0].X == triangle.vertices[1].X)
            {
                if (triangle.vertices[0].Y > triangle.vertices[1].Y)
                {
                    e1 = new Edge((int)triangle.vertices[0].Y, (int)triangle.vertices[1].X, 0);
                }
                else
                {
                    e1 = new Edge((int)triangle.vertices[1].Y, (int)triangle.vertices[0].X, 0);
                }
            }
            else
            {
                if (triangle.vertices[0].Y > triangle.vertices[1].Y)
                {
                    e1 = new Edge((int)triangle.vertices[0].Y, (int)triangle.vertices[1].X,
                        (triangle.vertices[0].X - triangle.vertices[1].X) / ((triangle.vertices[0].Y - triangle.vertices[1].Y)));
                }
                else
                {
                    e1 = new Edge((int)triangle.vertices[1].Y, (int)triangle.vertices[0].X,
                        (triangle.vertices[0].X - triangle.vertices[1].X) / ((triangle.vertices[0].Y - triangle.vertices[1].Y)));
                }
            }

            if (triangle.vertices[1].X == triangle.vertices[2].X)
            {
                if (triangle.vertices[1].Y > triangle.vertices[2].Y)
                {
                    e2 = new Edge((int)triangle.vertices[1].Y, (int)triangle.vertices[2].X, 0);
                }
                else
                {
                    e2 = new Edge((int)triangle.vertices[2].Y, (int)triangle.vertices[1].X, 0);
                }
            }
            else
            {
                if (triangle.vertices[1].Y > triangle.vertices[2].Y)
                {
                    e2 = new Edge((int)triangle.vertices[1].Y, (int)triangle.vertices[2].X,
                        (triangle.vertices[1].X - triangle.vertices[2].X) / ((triangle.vertices[1].Y - triangle.vertices[2].Y)));
                }
                else
                {
                    e2 = new Edge((int)triangle.vertices[2].Y, (int)triangle.vertices[1].X,
                        (triangle.vertices[1].X - triangle.vertices[2].X) / ((triangle.vertices[1].Y - triangle.vertices[2].Y)));
                }
            }

            if (triangle.vertices[0].X == triangle.vertices[2].X)
            {
                if (triangle.vertices[0].Y > triangle.vertices[2].Y)
                {
                    e3 = new Edge((int)triangle.vertices[0].Y, (int)triangle.vertices[2].X, 0);
                }
                else
                {
                    e3 = new Edge((int)triangle.vertices[2].Y, (int)triangle.vertices[0].X, 0);
                }
            }
            else
            {
                if (triangle.vertices[0].Y > triangle.vertices[2].Y)
                {
                    e3 = new Edge((int)triangle.vertices[0].Y, (int)triangle.vertices[2].X,
                        (triangle.vertices[0].X - triangle.vertices[2].X) / ((triangle.vertices[0].Y - triangle.vertices[2].Y)));
                }
                else
                {
                    e3 = new Edge((int)triangle.vertices[2].Y, (int)triangle.vertices[0].X,
                        (triangle.vertices[0].X - triangle.vertices[2].X) / ((triangle.vertices[0].Y - triangle.vertices[2].Y)));
                }
            }

            ET[(int)triangle.vertices[0].Y] = new List<Edge>(2);
            ET[(int)triangle.vertices[1].Y] = new List<Edge>(2);
            ET[(int)triangle.vertices[2].Y] = new List<Edge>(2);


            if (triangle.vertices[0].Y != triangle.vertices[1].Y)
            {
                int yMin1 = (int)Math.Min(triangle.vertices[0].Y, triangle.vertices[1].Y);
                ET[yMin1].Add(e1);
            }
            if (triangle.vertices[1].Y != triangle.vertices[2].Y)
            {
                int yMin2 = (int)Math.Min(triangle.vertices[1].Y, triangle.vertices[2].Y);
                ET[yMin2].Add(e2);
            }
            if (triangle.vertices[0].Y != triangle.vertices[2].Y)
            {
                int yMin3 = (int)Math.Min(triangle.vertices[0].Y, triangle.vertices[2].Y);
                ET[yMin3].Add(e3);
            }


            int ymin = (int)Math.Min(triangle.vertices[0].Y,
                Math.Min(triangle.vertices[1].Y, triangle.vertices[2].Y));

            // Wypelnianie
            ET[ymin].Sort((e1, e2) => e1.x.CompareTo(e2.x));
            List<Edge> AET = ET[ymin];
            SolidBrush b1 = new SolidBrush(Color.Coral);
            float Ru = 0.0f;
            float Gu = 0.0f;
            float Bu = 0.0f;
            float Ru0 = 0.0f;
            float Gu0 = 0.0f;
            float Bu0 = 0.0f;
            float Ru1 = 0.0f;
            float Gu1 = 0.0f;
            float Bu1 = 0.0f;
            float Ru2 = 0.0f;
            float Gu2 = 0.0f;
            float Bu2 = 0.0f;
            if (ConstantShading.Checked)
            {
                Ru = StaticShadingColor(org, objectColor.R / (float)255, normals);
                Gu = StaticShadingColor(org, objectColor.G / (float)255, normals);
                Bu = StaticShadingColor(org, objectColor.B / (float)255, normals);
            }
            if (GouroudShading.Checked)
            {
                Ru0 = GouroudShadingColor(org.vertices[0], objectColor.R / (float)255, normals[0]);
                Gu0 = GouroudShadingColor(org.vertices[0], objectColor.G / (float)255, normals[0]);
                Bu0 = GouroudShadingColor(org.vertices[0], objectColor.B / (float)255, normals[0]);
                Ru1 = GouroudShadingColor(org.vertices[1], objectColor.R / (float)255, normals[1]);
                Gu1 = GouroudShadingColor(org.vertices[1], objectColor.G / (float)255, normals[1]);
                Bu1 = GouroudShadingColor(org.vertices[1], objectColor.B / (float)255, normals[1]);
                Ru2 = GouroudShadingColor(org.vertices[2], objectColor.R / (float)255, normals[2]);
                Gu2 = GouroudShadingColor(org.vertices[2], objectColor.G / (float)255, normals[2]);
                Bu2 = GouroudShadingColor(org.vertices[2], objectColor.B / (float)255, normals[2]);
            }

            int R = (int)Math.Max(Math.Min(Ru * 255, 255), 0);
            int G = (int)Math.Max(Math.Min(Gu * 255, 255), 0);
            int B = (int)Math.Max(Math.Min(Bu * 255, 255), 0);

            if (checkBox1.Checked)
            {
                float len = (CameraPosition - triangle.vertices[0]).Length();

                R = Math.Clamp((int)(R + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                G = Math.Clamp((int)(G + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                B = Math.Clamp((int)(B + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
            }
            bool change = true;
            for (int i = ymin; i < Math.Max(AET[0].ymax, AET[1].ymax); i++)
            {
                if (i == AET[0].ymax && change)
                {
                    AET[0] = ET[i][0];
                    change = false;
                }
                if (i == AET[1].ymax && change)
                {
                    AET[1] = ET[i][0];
                    change = false;
                }
                for (int j = (int)Math.Min(AET[0].x, AET[1].x); j < (int)Math.Max(AET[0].x, AET[1].x); j++)
                {
                    float zInside = triangle.BaricentricInterpolateZ(j, i);
                    if (j >= pictureBox1.Width || i >= pictureBox1.Height)
                    {
                        continue;
                    }
                    if (zBuffer[j, i] > zInside)
                    {
                        continue;
                    }
                    else
                    {
                        if (ConstantShading.Checked)
                        {
                            Pen p1 = new Pen(Color.FromArgb(R, G, B));
                            g.DrawRectangle(p1, j, i, 1, 1);
                        }
                        if (GouroudShading.Checked)
                        {
                            var (l1, l2, l3) = triangle.BaricentricParams(j, i);
                            int Rg = (int)Math.Max(Math.Min((Ru0 * l1 + Ru1 * l2 + Ru2 * l3) * 255, 255), 0);
                            int Gg = (int)Math.Max(Math.Min((Gu0 * l1 + Gu1 * l2 + Gu2 * l3) * 255, 255), 0);
                            int Bg = (int)Math.Max(Math.Min((Bu0 * l1 + Bu1 * l2 + Bu2 * l3) * 255, 255), 0);
                            if (checkBox1.Checked)
                            {
                                float len = (CameraPosition - triangle.vertices[0]).Length();

                                Rg = Math.Clamp((int)(Rg + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                                Gg = Math.Clamp((int)(Gg + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                                Bg = Math.Clamp((int)(Bg + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                            }
                            Pen p2 = new Pen(Color.FromArgb(Rg, Gg, Bg));
                            g.DrawRectangle(p2, j, i, 1, 1);
                        }
                        if (PhongShading.Checked)
                        {
                            var (l1, l2, l3) = triangle.BaricentricParams(j, i);
                            float xInterpolated = l1 * org.vertices[0].X + l2 * org.vertices[1].X + l3 * org.vertices[2].X;
                            float yInterpolated = l1 * org.vertices[0].Y + l2 * org.vertices[1].Y + l3 * org.vertices[2].Y;
                            int Rp = (int)Math.Max(Math.Min(
                                PhongShadingColor(xInterpolated, yInterpolated, zInside, objectColor.R / (float)255, normals, l1, l2, l3) * 255, 255), 0);
                            int Gp = (int)Math.Max(Math.Min(
                                PhongShadingColor(xInterpolated, yInterpolated, zInside, objectColor.G / (float)255, normals, l1, l2, l3) * 255, 255), 0);
                            int Bp = (int)Math.Max(Math.Min(
                                PhongShadingColor(xInterpolated, yInterpolated, zInside, objectColor.B / (float)255, normals, l1, l2, l3) * 255, 255), 0);
                            if (checkBox1.Checked)
                            {
                                float len = (CameraPosition - triangle.vertices[0]).Length();

                                Rp = Math.Clamp((int)(Rp + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                                Gp = Math.Clamp((int)(Gp + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                                Bp = Math.Clamp((int)(Bp + 10 * (1.0f + len / (float)1000) * trackBar1.Value), 0, 255);
                            }
                            Pen p3 = new Pen(Color.FromArgb(Rp, Gp, Bp));
                            g.DrawRectangle(p3, j, i, 1, 1);
                        }
                        zBuffer[j, i] = zInside;
                    }


                }
                AET[0].x += AET[0].slope;
                AET[1].x += AET[1].slope;
            }

        }

        private float StaticShadingColor(Triangle triangle, float color, Vector3[] normals)
        {
            Vector3 Li = Vector3.Normalize(Vector3.Subtract(light, triangle.vertices[0]));
            Vector3 N = normals[0];
            Vector3 V = Vector3.Normalize(Vector3.Subtract(CameraPosition, triangle.vertices[0]));
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(Li, N) * N - Li);
            float dist = (float)Math.Sqrt((light.X + triangle.vertices[0].X) * (light.X + triangle.vertices[0].X) +
                (light.Y + triangle.vertices[0].Y) * (light.Y + triangle.vertices[0].Y) +
                (light.Z + triangle.vertices[0].Z) * (light.Z + triangle.vertices[0].Z));
            float If = 1.0f / (Ac + Al * dist + Aq * dist * dist);

            return ka * color + (kd * Vector3.Dot(Li, N) * color + ks * (float)Math.Pow(Vector3.Dot(R, V), alfa) * color) * If;
        }
        private float GouroudShadingColor(Vector3 v, float color, Vector3 normal)
        {
            Vector3 Li = Vector3.Normalize(Vector3.Subtract(light, v));
            Vector3 N = normal;
            Vector3 V = Vector3.Normalize(Vector3.Subtract(CameraPosition, v));
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(Li, N) * N - Li);
            float dist = (float)Math.Sqrt((light.X + v.X) * (light.X + v.X) +
                (light.Y + v.Y) * (light.Y + v.Y) +
                (light.Z + v.Z) * (light.Z + v.Z));
            float If = 1.0f / (Ac + Al * dist + Aq * dist * dist);

            return ka * color + (kd * Vector3.Dot(Li, N) * color + ks * (float)Math.Pow(Vector3.Dot(R, V), alfa) * color) * If;
        }
        private float PhongShadingColor(float x, float y, float z, float color, Vector3[] normals, float l1, float l2, float l3)
        {
            Vector3 Li = Vector3.Normalize(Vector3.Subtract(light, new Vector3(x, y, z)));
            Vector3 N = Vector3.Normalize(l1 * normals[0] + l2 * normals[1] + l3 * normals[2]);
            Vector3 V = Vector3.Normalize(Vector3.Subtract(CameraPosition, new Vector3(x, y, z)));
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(Li, N) * N - Li);
            float dist = (float)Math.Sqrt((light.X + x) * (light.X + x) +
                (light.Y + y) * (light.Y + y) +
                (light.Z + z) * (light.Z + z));
            float If = 1.0f / (Ac + Al * dist + Aq * dist * dist);

            return ka * color + (kd * Vector3.Dot(Li, N) * color + ks * (float)Math.Pow(Vector3.Dot(R, V), alfa) * color) * If;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //stopwatch.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CameraPosition.Z -= 0.2f;
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CameraPosition.X -= 0.2f;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CameraPosition.Y -= 0.2f;
        }

        private void staticButton_Click(object sender, EventArgs e)
        {
            CameraPosition = CameraPosition1;
            CameraTarget = CameraTarget1;
            CameraUpVector = CameraUpVector1;
            movingClicked = false;
            pictureBox1.Invalidate();
        }

        private void staticDirectedButton_Click(object sender, EventArgs e)
        {
            CameraPosition = CameraPosition2;
            CameraTarget = CameraTarget2;
            CameraUpVector = CameraUpVector2;
            movingClicked = false;
            pictureBox1.Invalidate();
        }

        private void MovingCameraButton_Click(object sender, EventArgs e)
        {
            //CameraPosition = new Vector3(3.0f, 1.5f, 8.5f);
            //CameraTarget = tmp;
            //CameraUpVector = new Vector3(0.0f, 1.0f, 0.0f);
        }

        private void MovingButton_Click(object sender, EventArgs e)
        {
            movingClicked = !movingClicked;
        }
    }
}