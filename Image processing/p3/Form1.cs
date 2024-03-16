using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

namespace p3
{
    public partial class Form1 : Form
    {
        Bitmap originalBitmap;
        ditherMatrix matrix;

        double[,] FloydSteinbergFilter = {
            { 0, 0, 0 },
            { 0, 0, 7/(double)16 },
            { 3/(double)16, 5/(double)16, 1/(double)16 } };

        public Form1()
        {
            InitializeComponent();
            originalBitmap = new Bitmap(1, 1);
            matrix = new ditherMatrix();
        }


        private void reductionPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);
            if (averageDitheringButton.Checked)
            {
                bitmap = averageDitheringAlgorithm(originalBitmap.Width, originalBitmap.Height);
            }
            else if (errorDiffusionDitheringButton.Checked)
            {
                bitmap = errorDiffusionDitheringAlgorithm(originalBitmap.Width, originalBitmap.Height);
            }
            else if (orderedDitheringRandomButton.Checked)
            {
                bitmap = orderedDitheringAlgorithm(originalBitmap.Width, originalBitmap.Height, true);
            }
            else if (orderedDitheringRelativeButton.Checked)
            {
                bitmap = orderedDitheringAlgorithm(originalBitmap.Width, originalBitmap.Height, false);
            }
            else if (popularityAlgorithmButton.Checked)
            {
                bitmap = popularityAlgorithm(originalBitmap.Width, originalBitmap.Height);
            }
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        // Average dithering algorithm implementation
        private Bitmap averageDitheringAlgorithm(int bitmapWidth, int bitmapHeight)
        {
            Bitmap reductionBitmap = new Bitmap(bitmapWidth, bitmapHeight);

            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    Color pixel = originalBitmap.GetPixel(i, j);

                    int r = calculateColor(pixel.R, (int)KrControl.Value);
                    int g = calculateColor(pixel.G, (int)KgControl.Value);
                    int b = calculateColor(pixel.B, (int)KbControl.Value);

                    Color reductionPixel = Color.FromArgb(r, g, b);
                    reductionBitmap.SetPixel(i, j, reductionPixel);
                }
            }
            return reductionBitmap;
        }

        private int calculateColor(int color, int K)
        {
            int reductedColor;
            int step = 255 / (K - 1);
            int limitIndex = color / step;
            int diff = color % step;

            if (diff < (step / 2))
                reductedColor = limitIndex * step;
            else
                reductedColor = (limitIndex + 1) * step;


            return reductedColor;
        }

        // Error diffusion dithering algorithm implementation
        private Bitmap errorDiffusionDitheringAlgorithm(int bitmapWidth, int bitmapHeight)
        {
            Bitmap reductionBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            Bitmap workingBitmap = new Bitmap(originalBitmap);

            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    Color pixel = workingBitmap.GetPixel(i, j);

                    (int r, int errorR) = calculateColorError(pixel.R, (int)KrControl.Value);
                    (int g, int errorG) = calculateColorError(pixel.G, (int)KgControl.Value);
                    (int b, int errorB) = calculateColorError(pixel.B, (int)KbControl.Value);

                    Color reductionPixel = Color.FromArgb(r, g, b);
                    reductionBitmap.SetPixel(i, j, reductionPixel);

                    if ((i + 1) < bitmapWidth)
                    {
                        Color pixelError = workingBitmap.GetPixel(i + 1, j);
                        Color resColor = Color.FromArgb(
                            Math.Max(Math.Min((pixelError.R + (int)(FloydSteinbergFilter[1, 2] * errorR)), 255), 0),
                            Math.Max(Math.Min((pixelError.G + (int)(FloydSteinbergFilter[1, 2] * errorG)), 255), 0),
                            Math.Max(Math.Min((pixelError.B + (int)(FloydSteinbergFilter[1, 2] * errorB)), 255), 0));
                        workingBitmap.SetPixel(i + 1, j, resColor);
                    }
                    if ((j + 1) > bitmapHeight && (i - 1) >= 0)
                    {
                        Color pixelError = workingBitmap.GetPixel(i - 1, j + 1);
                        Color resColor = Color.FromArgb(
                            Math.Max(Math.Min((pixelError.R + (int)(FloydSteinbergFilter[2, 0] * errorR)), 255), 0),
                            Math.Max(Math.Min((pixelError.G + (int)(FloydSteinbergFilter[2, 0] * errorG)), 255), 0),
                            Math.Max(Math.Min((pixelError.B + (int)(FloydSteinbergFilter[2, 0] * errorB)), 255), 0));
                        workingBitmap.SetPixel(i - 1, j + 1, resColor);
                    }
                    if ((j + 1) < bitmapHeight)
                    {
                        Color pixelError = workingBitmap.GetPixel(i, j + 1);
                        Color resColor = Color.FromArgb(
                            Math.Max(Math.Min((pixelError.R + (int)(FloydSteinbergFilter[2, 1] * errorR)), 255), 0),
                            Math.Max(Math.Min((pixelError.G + (int)(FloydSteinbergFilter[2, 1] * errorG)), 255), 0),
                            Math.Max(Math.Min((pixelError.B + (int)(FloydSteinbergFilter[2, 1] * errorB)), 255), 0));
                        workingBitmap.SetPixel(i, j + 1, resColor);
                    }
                    if ((j + 1) < bitmapHeight && (i + 1) < bitmapWidth)
                    {
                        Color pixelError = workingBitmap.GetPixel(i + 1, j + 1);
                        Color resColor = Color.FromArgb(
                            Math.Max(Math.Min((pixelError.R + (int)(FloydSteinbergFilter[2, 2] * errorR)), 255), 0),
                            Math.Max(Math.Min((pixelError.G + (int)(FloydSteinbergFilter[2, 2] * errorG)), 255), 0),
                            Math.Max(Math.Min((pixelError.B + (int)(FloydSteinbergFilter[2, 2] * errorB)), 255), 0));
                        workingBitmap.SetPixel(i + 1, j + 1, resColor);
                    }
                }
            }
            return reductionBitmap;
        }
        private (int, int) calculateColorError(int color, int K)
        {
            int reductedColor;
            int step = 255 / (K - 1);
            int limitIndex = color / step;
            int diff = color % step;

            if (diff < (step / 2))
                reductedColor = limitIndex * step;
            else
                reductedColor = (limitIndex + 1) * step;

            int error = color - reductedColor;



            return (reductedColor, error);
        }


        // Ordered dithering algorithm implementation
        private Bitmap orderedDitheringAlgorithm(int bitmapWidth, int bitmapHeight, bool Random)
        {
            Bitmap reductionBitmap = new Bitmap(bitmapWidth, bitmapHeight);

            int[,] rMatr = calculateMatrixSize((int)KrControl.Value);
            int[,] gMatr = calculateMatrixSize((int)KgControl.Value);
            int[,] bMatr = calculateMatrixSize((int)KbControl.Value);

            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    Color pixel = originalBitmap.GetPixel(i, j);

                    int r = calculateColorOrderedDith(pixel.R, rMatr, i, j, Random, (int)KrControl.Value);
                    int g = calculateColorOrderedDith(pixel.G, gMatr, i, j, Random, (int)KgControl.Value);
                    int b = calculateColorOrderedDith(pixel.B, bMatr, i, j, Random, (int)KbControl.Value);

                    Color reductionPixel = Color.FromArgb(r, g, b);
                    reductionBitmap.SetPixel(i, j, reductionPixel);
                }
            }
            return reductionBitmap;
        }

        private int[,] calculateMatrixSize(int K)
        {
            List<int> sizes = new List<int> { 2, 3, 4, 6, 8, 12, 16 };

            int matrixSize = 16;
            int[,] returnMatrix;

            foreach (var v in sizes)
            {
                if (v * v * (K - 1) >= 256)
                {
                    matrixSize = v;
                    break;
                }
            }
            var dithMatr = new ditherMatrix();
            switch (matrixSize)
            {
                case 2:
                    {
                        returnMatrix = dithMatr.D2;
                        break;
                    }
                case 3:
                    {
                        returnMatrix = dithMatr.D3;
                        break;
                    }
                case 4:
                    {
                        returnMatrix = dithMatr.D4;
                        break;
                    }
                case 6:
                    {
                        returnMatrix = dithMatr.D6;
                        break;
                    }
                case 8:
                    {
                        returnMatrix = dithMatr.D8;
                        break;
                    }
                case 12:
                    {
                        returnMatrix = dithMatr.D12;
                        break;
                    }
                case 16:
                    {
                        returnMatrix = dithMatr.D16;
                        break;
                    }
                default:
                    {
                        returnMatrix = dithMatr.D16;
                        break;
                    }
            }

            return returnMatrix;
        }

        private int calculateColorOrderedDith(int color, int[,] ditherMatrix, int x, int y, bool rand, int K)
        {
            int n = ditherMatrix.GetLength(0);

            int col = color / (n * n);
            int re = color % (n * n);

            int i;
            int j;

            if (rand)
            {
                Random random = new Random();
                i = random.Next(0, n);
                j = random.Next(0, n);
            }
            else
            {
                i = x % n;
                j = y % n;
            }

            if (re > ditherMatrix[i, j]) col++;

            col = (int)(col * ((double)255 / (K - 1)));

            if (col > 255)
                col = 255;

            return col;
        }

        // Popularity algorithm implementation
        private Bitmap popularityAlgorithm(int bitmapWidth, int bitmapHeight)
        {
            Bitmap reductionBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            Dictionary<Color, int> colors = new Dictionary<Color, int>();

            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    Color pixel = originalBitmap.GetPixel(i, j);

                    if (colors.ContainsKey(pixel))
                    {
                        colors[pixel] += 1;
                    }
                    else
                    {
                        colors.Add(pixel, 1);
                    }
                }
            }

            List<Color> KtopColors = colors.OrderByDescending(kv => kv.Value).Take((int)KControl.Value)
                .Select(kv => kv.Key).ToList();

            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    Color pixel = originalBitmap.GetPixel(i, j);

                    Dictionary<Color, double> distances = new Dictionary<Color, double>();

                    foreach (var v in KtopColors)
                    {
                        double dist = Math.Sqrt((v.R - pixel.R) * (v.R - pixel.R) +
                            (v.G - pixel.G) * (v.G - pixel.G) + (v.B - pixel.B) * (v.B - pixel.B));
                        distances.Add(v, dist);
                    }

                    double minValue = distances.Values.Min();
                    Color reductionPixel = distances.First(kv => kv.Value == minValue).Key;

                    reductionBitmap.SetPixel(i, j, reductionPixel);
                }
            }

            return reductionBitmap;
        }



        // Load picture event
        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Choose image";
            openFileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    originalPictureBox.Image = new Bitmap(imagePath);
                    originalBitmap = new Bitmap(imagePath);
                    originalPictureBox.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d wczytywania obrazu: " + ex.Message);
                }
            }
        }

        // Refresh bitmap event
        private void refreshButton_Click(object sender, EventArgs e)
        {
            originalPictureBox.Invalidate();
            reductionPictureBox.Invalidate();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Bitmap createBitmap = new Bitmap(200,200);

            int alfa = 0;

            for(int i = 0; i < createBitmap.Width; i++)
            {
                for(int j = 0; j < createBitmap.Height; j++)
                {
                    HSL data = new HSL(alfa, i*(1/ (float)createBitmap.Width), j * (1 / (float)createBitmap.Height));
                    RGB value = HSLToRGB(data);
                    createBitmap.SetPixel(i, j, Color.FromArgb(value.R, value.G, value.B));
                }
            }
            originalPictureBox.Image = createBitmap;
            
            originalPictureBox.Refresh();
        }

        // NA PODSTAWIE ZRODLA: https://www.programmingalgorithms.com/algorithm/hsl-to-rgb/
        public struct RGB
        {
            private byte _r;
            private byte _g;
            private byte _b;

            public RGB(byte r, byte g, byte b)
            {
                this._r = r;
                this._g = g;
                this._b = b;
            }

            public byte R
            {
                get { return this._r; }
                set { this._r = value; }
            }

            public byte G
            {
                get { return this._g; }
                set { this._g = value; }
            }

            public byte B
            {
                get { return this._b; }
                set { this._b = value; }
            }

            public bool Equals(RGB rgb)
            {
                return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
            }
        }

        public struct HSL
        {
            private int _h;
            private float _s;
            private float _l;

            public HSL(int h, float s, float l)
            {
                this._h = h;
                this._s = s;
                this._l = l;
            }

            public int H
            {
                get { return this._h; }
                set { this._h = value; }
            }

            public float S
            {
                get { return this._s; }
                set { this._s = value; }
            }

            public float L
            {
                get { return this._l; }
                set { this._l = value; }
            }

            public bool Equals(HSL hsl)
            {
                return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
            }
        }

        public static RGB HSLToRGB(HSL hsl)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (hsl.S == 0)
            {
                r = g = b = (byte)(hsl.L * 255);
            }
            else
            {
                float v1, v2;
                float hue = (float)hsl.H / 360;

                v2 = (hsl.L < 0.5) ? (hsl.L * (1 + hsl.S)) : ((hsl.L + hsl.S) - (hsl.L * hsl.S));
                v1 = 2 * hsl.L - v2;

                r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
                g = (byte)(255 * HueToRGB(v1, v2, hue));
                b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
            }

            return new RGB(r, g, b);
        }

        private static float HueToRGB(float v1, float v2, float vH)
        {
            if (vH < 0)
                vH += 1;

            if (vH > 1)
                vH -= 1;

            if ((6 * vH) < 1)
                return (v1 + (v2 - v1) * 6 * vH);

            if ((2 * vH) < 1)
                return v2;

            if ((3 * vH) < 2)
                return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

            return v1;
        }

    }
}