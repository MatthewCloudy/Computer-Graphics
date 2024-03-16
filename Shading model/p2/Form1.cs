using System.Numerics;
using System.Windows.Forms;

namespace p2
{
    public partial class Form1 : Form
    {
        public double[,] zControl = {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 } };
        public Vector3[,] triangulation = new Vector3[0, 0];
        public Vector3[,] normalVectors = new Vector3[0, 0];
        public List<Triangle> triangles = new List<Triangle>();
        public Vector3 light = new Vector3(400, 300, 0.2f);
        public DirectBitmap directBitmap;
        public DirectBitmap directBitmapPicture;
        Bitmap picture;
        public double lightR = 255 / (double)255;
        public double lightG = 255 / (double)255;
        public double lightB = 255 / (double)255;
        // 17, 10, 77
        public double objectR = 127 / (double)255;
        public double objectG = 127 / (double)255;
        public double objectB = 127 / (double)255;
        System.Windows.Forms.Timer timer;
        string selectedFilePath = "";
        int r = 100;
        double angle = 0.05;
        bool isFileSelected = false;
        public Form1()
        {
            InitializeComponent();
            MakeTriangulation(5, 5);
            MakeNormalVectors(5, 5);
            CalculateTriangles();
            Bitmap.Invalidate();
            directBitmap = new DirectBitmap(Bitmap.Width, Bitmap.Height);
            Bitmap.Image = directBitmap.Bitmap;

            // timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            light.X = (float)(Bitmap.Width / 2 + r * Math.Cos(angle));
            light.Y = (float)(Bitmap.Height / 2 + r * Math.Sin(angle));
            angle += 0.97;
            Bitmap.Invalidate();

        }
        private void Bitmap_Paint(object sender, PaintEventArgs e)
        {
            MakeTriangulation(XtriangulationTrackBar.Value, YtriangulationTrackBar.Value);
            MakeNormalVectors(XtriangulationTrackBar.Value, YtriangulationTrackBar.Value);
            CalculateTriangles();

            if (!isFileSelected)
            {
                FillTriangles(e.Graphics);
            }
            else
            {
                FillTrianglesPicture(e.Graphics);
            }
            if (drawTrianglesBox.Checked)
            {
                DrawTriangles(e.Graphics);
            }
        }
        public void FillTrianglesPicture(Graphics g)
        {

            g.Clear(Color.Transparent);
            Graphics gg = Graphics.FromImage(directBitmapPicture.Bitmap);
            gg.Clear(Color.Transparent);
            foreach (Triangle triangle in triangles)
            {
                FillOneTrianglePicture(triangle, g, directBitmapPicture);
            }
            g.DrawImage(directBitmapPicture.Bitmap, 0, 0);
        }
        public void FillOneTrianglePicture(Triangle triangle, Graphics g, DirectBitmap b)
        {
            List<Edge>[] buckets = new List<Edge>[Bitmap.Height];
            float yminTmp = Math.Min(triangle.v1.Y, triangle.v2.Y);
            int ymin = (int)Math.Min(yminTmp, triangle.v3.Y);

            if (triangle.v1.Y == triangle.v2.Y)
            {
                if (triangle.v1.X == triangle.v3.X)
                {
                    int max = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y;
                    int min = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v3.Y > triangle.v2.Y ? (int)triangle.v3.Y : (int)triangle.v2.Y,
                        triangle.v3.Y > triangle.v2.Y ? (int)triangle.v2.X : (int)triangle.v3.X,
                        (double)(triangle.v3.X - triangle.v2.X) / ((triangle.v3.Y - triangle.v2.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };

                }
                else
                {
                    int max = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v2.Y : (int)triangle.v3.Y;
                    int min = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v2.Y;
                    Edge eVert = new Edge(max, (int)triangle.v2.X, 0);
                    Edge e2 = new Edge(triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y,
                        triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.X : (int)triangle.v1.X,
                        (double)(triangle.v1.X - triangle.v3.X) / ((triangle.v1.Y - triangle.v3.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };
                }
            }
            if (triangle.v3.Y == triangle.v2.Y)
            {
                if (triangle.v1.X == triangle.v3.X)
                {
                    int max = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y;
                    int min = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v1.Y > triangle.v2.Y ? (int)triangle.v1.Y : (int)triangle.v2.Y,
                        triangle.v1.Y > triangle.v2.Y ? (int)triangle.v2.X : (int)triangle.v1.X,
                        (double)(triangle.v1.X - triangle.v2.X) / ((triangle.v1.Y - triangle.v2.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };

                }
                else
                {
                    int max = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v1.Y : (int)triangle.v2.Y;
                    int min = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v2.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y,
                        triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.X : (int)triangle.v1.X,
                        (double)(triangle.v1.X - triangle.v3.X) / ((triangle.v1.Y - triangle.v3.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };
                }
            }
            if (triangle.v1.Y == triangle.v3.Y)
            {
                if (triangle.v1.X == triangle.v2.X)
                {
                    int max = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v1.Y : (int)triangle.v2.Y;
                    int min = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v2.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v2.Y > triangle.v3.Y ? (int)triangle.v2.Y : (int)triangle.v3.Y,
                        triangle.v2.Y > triangle.v3.Y ? (int)triangle.v3.X : (int)triangle.v2.X,
                        (double)(triangle.v3.X - triangle.v2.X) / ((triangle.v3.Y - triangle.v2.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };

                }
                else
                {
                    int max = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v2.Y : (int)triangle.v3.Y;
                    int min = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v2.Y;
                    Edge eVert = new Edge(max, (int)triangle.v2.X, 0);
                    Edge e2 = new Edge(triangle.v2.Y > triangle.v1.Y ? (int)triangle.v2.Y : (int)triangle.v1.Y,
                        triangle.v2.Y > triangle.v1.Y ? (int)triangle.v1.X : (int)triangle.v2.X,
                        (double)(triangle.v2.X - triangle.v1.X) / ((triangle.v2.Y - triangle.v1.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };
                }
            }

            // Wypelnianie
            buckets[ymin].Sort((e1, e2) => e1.x.CompareTo(e2.x));
            List<Edge> AET = buckets[ymin];
            SolidBrush b1 = new SolidBrush(Color.Coral);

            for (int i = ymin; i < AET[0].ymax; i++)
            {
                for (int j = (int)Math.Min(AET[0].x, AET[1].x); j < (int)Math.Max(AET[0].x, AET[1].x); j++)
                {
                    Color fromPicture = picture.GetPixel(j, i);
                    double R = Math.Min(CalculateColorPicture(j, i, lightR, fromPicture.R/(float)255, mTrackBar.Value, triangle, fromPicture), 1);
                    double G = Math.Min(CalculateColorPicture(j, i, lightG, fromPicture.G/(float)255, mTrackBar.Value, triangle, fromPicture), 1);
                    double B = Math.Min(CalculateColorPicture(j, i, lightB, fromPicture.B/(float)255, mTrackBar.Value, triangle, fromPicture), 1);
                    SolidBrush b2 = new SolidBrush(Color.FromArgb((int)(R * 255), (int)(G * 255), (int)(B * 255)));
                    b.SetPixel(j, i, Color.FromArgb((int)(R * 255), (int)(G * 255), (int)(B * 255)));
                }
                AET[0].x += (int)Math.Ceiling(AET[0].slope);
                AET[1].x += (int)Math.Ceiling(AET[1].slope);
            }
        }
        public void FillTriangles(Graphics g)
        {

            g.Clear(Color.Transparent);
            Graphics gg = Graphics.FromImage(directBitmap.Bitmap);
            gg.Clear(Color.Transparent);
            foreach (Triangle triangle in triangles)
            {
                FillOneTriangle(triangle, g, directBitmap);
            }
            g.DrawImage(directBitmap.Bitmap, 0, 0);
        }
        public void FillOneTriangle(Triangle triangle, Graphics g, DirectBitmap b)
        {
            List<Edge>[] buckets = new List<Edge>[Bitmap.Height];
            float yminTmp = Math.Min(triangle.v1.Y, triangle.v2.Y);
            int ymin = (int)Math.Min(yminTmp, triangle.v3.Y);

            if (triangle.v1.Y == triangle.v2.Y)
            {
                if (triangle.v1.X == triangle.v3.X)
                {
                    int max = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y;
                    int min = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v3.Y > triangle.v2.Y ? (int)triangle.v3.Y : (int)triangle.v2.Y,
                        triangle.v3.Y > triangle.v2.Y ? (int)triangle.v2.X : (int)triangle.v3.X,
                        (double)(triangle.v3.X - triangle.v2.X) / ((triangle.v3.Y - triangle.v2.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };

                }
                else
                {
                    int max = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v2.Y : (int)triangle.v3.Y;
                    int min = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v2.Y;
                    Edge eVert = new Edge(max, (int)triangle.v2.X, 0);
                    Edge e2 = new Edge(triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y,
                        triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.X : (int)triangle.v1.X,
                        (double)(triangle.v1.X - triangle.v3.X) / ((triangle.v1.Y - triangle.v3.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };
                }
            }
            if (triangle.v3.Y == triangle.v2.Y)
            {
                if (triangle.v1.X == triangle.v3.X)
                {
                    int max = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y;
                    int min = triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v1.Y > triangle.v2.Y ? (int)triangle.v1.Y : (int)triangle.v2.Y,
                        triangle.v1.Y > triangle.v2.Y ? (int)triangle.v2.X : (int)triangle.v1.X,
                        (double)(triangle.v1.X - triangle.v2.X) / ((triangle.v1.Y - triangle.v2.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };

                }
                else
                {
                    int max = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v1.Y : (int)triangle.v2.Y;
                    int min = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v2.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v1.Y > triangle.v3.Y ? (int)triangle.v1.Y : (int)triangle.v3.Y,
                        triangle.v1.Y > triangle.v3.Y ? (int)triangle.v3.X : (int)triangle.v1.X,
                        (double)(triangle.v1.X - triangle.v3.X) / ((triangle.v1.Y - triangle.v3.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };
                }
            }
            if (triangle.v1.Y == triangle.v3.Y)
            {
                if (triangle.v1.X == triangle.v2.X)
                {
                    int max = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v1.Y : (int)triangle.v2.Y;
                    int min = triangle.v1.Y > triangle.v2.Y ? (int)triangle.v2.Y : (int)triangle.v1.Y;
                    Edge eVert = new Edge(max, (int)triangle.v1.X, 0);
                    Edge e2 = new Edge(triangle.v2.Y > triangle.v3.Y ? (int)triangle.v2.Y : (int)triangle.v3.Y,
                        triangle.v2.Y > triangle.v3.Y ? (int)triangle.v3.X : (int)triangle.v2.X,
                        (double)(triangle.v3.X - triangle.v2.X) / ((triangle.v3.Y - triangle.v2.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };

                }
                else
                {
                    int max = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v2.Y : (int)triangle.v3.Y;
                    int min = triangle.v2.Y > triangle.v3.Y ? (int)triangle.v3.Y : (int)triangle.v2.Y;
                    Edge eVert = new Edge(max, (int)triangle.v2.X, 0);
                    Edge e2 = new Edge(triangle.v2.Y > triangle.v1.Y ? (int)triangle.v2.Y : (int)triangle.v1.Y,
                        triangle.v2.Y > triangle.v1.Y ? (int)triangle.v1.X : (int)triangle.v2.X,
                        (double)(triangle.v2.X - triangle.v1.X) / ((triangle.v2.Y - triangle.v1.Y)));
                    buckets[min] = new List<Edge> { eVert, e2 };
                }
            }

            // Wypelnianie
            buckets[ymin].Sort((e1, e2) => e1.x.CompareTo(e2.x));
            List<Edge> AET = buckets[ymin];
            SolidBrush b1 = new SolidBrush(Color.Coral);

            for (int i = ymin; i < AET[0].ymax; i++)
            {
                for (int j = (int)Math.Min(AET[0].x, AET[1].x); j < (int)Math.Max(AET[0].x, AET[1].x); j++)
                {
                    double R = Math.Min(CalculateColor(j, i, lightR, objectR, mTrackBar.Value, triangle), 1);
                    double G = Math.Min(CalculateColor(j, i, lightG, objectG, mTrackBar.Value, triangle), 1);
                    double B = Math.Min(CalculateColor(j, i, lightB, objectB, mTrackBar.Value, triangle), 1);
                    SolidBrush b2 = new SolidBrush(Color.FromArgb((int)(R * 255), (int)(G * 255), (int)(B * 255)));
                    b.SetPixel(j, i, Color.FromArgb((int)(R * 255), (int)(G * 255), (int)(B * 255)));
                }
                AET[0].x += (int)Math.Ceiling(AET[0].slope);
                AET[1].x += (int)Math.Ceiling(AET[1].slope);
            }
        }
        public double CalculateColor(int x, int y, double Il, double Io, int m, Triangle triangle)
        {

            float l1 = (float)((triangle.v2.Y - triangle.v3.Y) * (x - triangle.v3.X) + (triangle.v3.X - triangle.v2.X) * (y - triangle.v3.Y)) /
                (((triangle.v2.Y - triangle.v3.Y) * (triangle.v1.X - triangle.v3.X)) + ((triangle.v3.X - triangle.v2.X) * (triangle.v1.Y - triangle.v3.Y)));
            float l2 = (float)((triangle.v3.Y - triangle.v1.Y) * (x - triangle.v3.X) + (triangle.v1.X - triangle.v3.X) * (y - triangle.v3.Y)) /
                (((triangle.v2.Y - triangle.v3.Y) * (triangle.v1.X - triangle.v3.X)) + ((triangle.v3.X - triangle.v2.X) * (triangle.v1.Y - triangle.v3.Y)));
            float l3 = 1 - l1 - l2;
            Vector3 N = Vector3.Normalize(l1 * triangle.n1 + l2 * triangle.n2 + l3 * triangle.n3);
            float z = l1 * triangle.v1.Z + l2 * triangle.v2.Z + l3 * triangle.v3.Z;
            double kd = kdTrackBar.Value / (double)10;
            double ks = ksTrackBar.Value / (double)10;
            Vector3 L = Vector3.Normalize(new Vector3(light.X / (float)800 - x / (float)800, light.Y / (float)600 - y / (float)600, light.Z - z));
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(N, L) * N - L);

            double cosNL = Vector3.Dot(N, L) < 0 ? 0 : Vector3.Dot(N, L);
            double cosVR = Vector3.Dot(new Vector3(0, 0, 1), R);
            double cosmVR = Math.Pow(cosVR, m) > 0 ? Math.Pow(cosVR, m) : 0;

            return kd * Il * Io * cosNL + ks * Il * Io * cosmVR;
        }
        public double CalculateColorPicture(int x, int y, double Il, double Io, int m, Triangle triangle, Color fromPicture)
        {

            float l1 = (float)((triangle.v2.Y - triangle.v3.Y) * (x - triangle.v3.X) + (triangle.v3.X - triangle.v2.X) * (y - triangle.v3.Y)) /
                (((triangle.v2.Y - triangle.v3.Y) * (triangle.v1.X - triangle.v3.X)) + ((triangle.v3.X - triangle.v2.X) * (triangle.v1.Y - triangle.v3.Y)));
            float l2 = (float)((triangle.v3.Y - triangle.v1.Y) * (x - triangle.v3.X) + (triangle.v1.X - triangle.v3.X) * (y - triangle.v3.Y)) /
                (((triangle.v2.Y - triangle.v3.Y) * (triangle.v1.X - triangle.v3.X)) + ((triangle.v3.X - triangle.v2.X) * (triangle.v1.Y - triangle.v3.Y)));
            float l3 = 1 - l1 - l2;
            Vector3 Npow = Vector3.Normalize(l1 * triangle.n1 + l2 * triangle.n2 + l3 * triangle.n3);
            Vector3 Nteks = Vector3.Normalize(new Vector3((fromPicture.R / (float)127)-1,
                (fromPicture.G / (float)127) - 1, (fromPicture.B / (float)127) - 1));
            float z = l1 * triangle.v1.Z + l2 * triangle.v2.Z + l3 * triangle.v3.Z;
            Vector3 B;
            if (Npow == new Vector3(0, 0, 1))
                B = new Vector3(0, 0, 1);
            else
                B = Vector3.Cross(Npow, new Vector3(0, 0, 1));
            Vector3 T = Vector3.Cross(B, Npow);
            double kd = kdTrackBar.Value / (double)10;
            double ks = ksTrackBar.Value / (double)10;
            Vector3 L = Vector3.Normalize(new Vector3(light.X / (float)directBitmapPicture.Width - 
                x / (float)directBitmapPicture.Width, 
                light.Y / (float)directBitmapPicture.Height - 
                y / (float)directBitmapPicture.Height, 
                light.Z - z));
            Vector3 N = new Vector3(Nteks.X * T.X + Nteks.Y * B.X + Nteks.Z * Npow.X,
                Nteks.X * T.Y + Nteks.Y * B.Y + Nteks.Z * Npow.Y,
                Nteks.X * T.Z + Nteks.Y * B.Z + Nteks.Z * Npow.Z);
            Vector3 R = Vector3.Normalize(2 * Vector3.Dot(N, L) * N - L);

            double cosNL = Vector3.Dot(N, L) < 0 ? 0 : Vector3.Dot(N, L);
            double cosVR = Vector3.Dot(new Vector3(0, 0, 1), R);
            double cosmVR = Math.Pow(cosVR, m) > 0 ? Math.Pow(cosVR, m) : 0;

            return kd * Il * Io * cosNL + ks * Il * Io * cosmVR;
        }
        public void CalculateTriangles()
        {
            triangles = new List<Triangle>();
            int width = Bitmap.Size.Width;
            int height = Bitmap.Size.Height;

            for (int i = 0; i < triangulation.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < triangulation.GetLength(1) - 1; j++)
                {
                    Triangle upper = new Triangle(new Vector3(width, height, 1) * triangulation[i, j],
                        new Vector3(width, height, 1) * triangulation[i, j + 1],
                        new Vector3(width, height, 1) * triangulation[i + 1, j],
                        normalVectors[i, j],
                        normalVectors[i, j + 1],
                        normalVectors[i + 1, j]);

                    Triangle lower = new Triangle(new Vector3(width, height, 1) * triangulation[i, j + 1],
                        new Vector3(width, height, 1) * triangulation[i + 1, j + 1],
                        new Vector3(width, height, 1) * triangulation[i + 1, j],
                        normalVectors[i, j + 1],
                        normalVectors[i + 1, j + 1],
                        normalVectors[i + 1, j]);

                    triangles.Add(upper);
                    triangles.Add(lower);
                }
            }
        }
        public void MakeTriangulation(int k1, int k2)
        {
            triangulation = new Vector3[k1 + 1, k2 + 1];

            for (int i = 0; i < triangulation.GetLength(0); i++)
            {
                double u = i / (double)k1;

                for (int j = 0; j < triangulation.GetLength(1); j++)
                {
                    double v = j / (double)k2;

                    double z = Bezier.calculateZuv(zControl, u, v);
                    triangulation[i, j] = new Vector3((float)u, (float)v, (float)z);
                }
            }
        }

        public void MakeNormalVectors(int k1, int k2)
        {
            normalVectors = new Vector3[k1 + 1, k2 + 1];

            for (int i = 0; i < normalVectors.GetLength(0); i++)
            {
                double u = i / k1;

                for (int j = 0; j < normalVectors.GetLength(1); j++)
                {
                    double v = j / k2;

                    Vector3 dPu = Bezier.calculateDPu(zControl, u, v);
                    Vector3 dPv = Bezier.calculateDPv(zControl, u, v);
                    Vector3 Nuv = Vector3.Cross(dPu, dPv);
                    normalVectors[i, j] = Nuv;
                }
            }
        }
        public void DrawTriangles(Graphics g)
        {
            //g.Clear(Color.White);
            Pen p1 = new Pen(Color.Black);
            foreach (Triangle triangle in triangles)
            {
                g.DrawLine(p1, triangle.v1.X, triangle.v1.Y, triangle.v2.X, triangle.v2.Y);
                g.DrawLine(p1, triangle.v2.X, triangle.v2.Y, triangle.v3.X, triangle.v3.Y);
                g.DrawLine(p1, triangle.v1.X, triangle.v1.Y, triangle.v3.X, triangle.v3.Y);
            }
        }
        private void XtriangulationTrackBar_ValueChanged(object sender, EventArgs e)
        {

            Bitmap.Invalidate();
        }

        private void YtriangulationTrackBar_ValueChanged(object sender, EventArgs e)
        {

            Bitmap.Invalidate();
        }

        private void drawTrianglesBox_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap.Invalidate();
        }

        private void kdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap.Invalidate();
        }

        private void ksTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap.Invalidate();
        }

        private void mTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap.Invalidate();
        }

        private void animationStartButton_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void ChooseColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;

                objectR = selectedColor.R / (double)255;
                objectG = selectedColor.G / (double)255;
                objectB = selectedColor.B / (double)255;
                Bitmap.Invalidate();
            }
        }

        private void LightButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;

                lightR = selectedColor.R / (double)255;
                lightG = selectedColor.G / (double)255;
                lightB = selectedColor.B / (double)255;
                Bitmap.Invalidate();
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Wybierz plik";
            openFileDialog.Filter = "Obrazy (*.png;*.jpg)|*.png;*.jpg";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                isFileSelected = true;
                picture = new Bitmap(selectedFilePath);
                Bitmap.Width = picture.Width;
                Bitmap.Height = picture.Height;
                directBitmapPicture = new DirectBitmap(Bitmap.Width, Bitmap.Height);
                Bitmap.Image = directBitmapPicture.Bitmap;
                light = new Vector3(128, 128, 0.2f);
                Bitmap.Invalidate();
            }
        }

        private void ChangeControlButton_Click(object sender, EventArgs e)
        {
            zControl[Int32.Parse(xPointControl.Text), Int32.Parse(yPointControl.Text)]
                = Int32.Parse(yPointControl.Text);
            Bitmap.Invalidate();
        }

        private void animationStopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}