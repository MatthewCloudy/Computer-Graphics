using System;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection;

namespace P1
{
    public partial class Form1 : Form
    {
        public Polygon polygon1 = new Polygon();
        public List<Polygon> polygonsList = new List<Polygon>();
        int locationX = 0;
        int locationY = 0;
        int eps = 10;
        bool lastIsFirst = false;
        Polygon currPolygon;
        bool isMouseDown = false;
        (bool, Vertex?, Polygon?) selectedVertex;
        (bool, Vertex?, Vertex?, Polygon?) selectedEdge;
        Point oldMousePoint = new Point(0, 0);
        int offset = 20;
        bool drawCircle = false;
        List<(Vertex, Vertex)> circles = new List<(Vertex,Vertex)>();
        Point click1 = new Point(0, 0);
        Point click2 = new Point(0, 0);
        bool clicked1 = false;
        bool clicked2 = false;
        Vertex center = new Vertex(0, 0, null);
        Vertex radius = new Vertex(0, 0, null);
        (bool, Vertex, Vertex) selectedCircle;
        public Form1()
        {
            InitializeComponent();
            currPolygon = new Polygon();
            polygonsList.Add(this.currPolygon);
            BresenhamAlgButton.Checked = true;
            addVertexButton.Checked = true;
            offsetPolygonButton.Checked = true;
            InitScene1();
        }

        public void InitScene1()
        {
            Polygon p1 = new Polygon();
            p1.addVertex(new Vertex(312, 678, p1));
            p1.Vertices[0].restrictionHorizontal = true;
            p1.addVertex(new Vertex(516, 678, p1));
            p1.Vertices[1].restrictionHorizontal = true;
            p1.restrictedHorizontalEdges.Add((p1.Vertices[0], p1.Vertices[1]));
            p1.restrictedHorizontalEdges.Add((p1.Vertices[1], p1.Vertices[0]));
            p1.addVertex(new Vertex(701, 539, p1));
            p1.Vertices[2].restrictionVertical = true;
            p1.addVertex(new Vertex(701, 346, p1));
            p1.Vertices[3].restrictionHorizontal = true;
            p1.Vertices[3].restrictionVertical = true;
            p1.restrictedEdges.Add((p1.Vertices[2], p1.Vertices[3]));
            p1.restrictedEdges.Add((p1.Vertices[3], p1.Vertices[2]));
            p1.addVertex(new Vertex(482, 346, p1));
            p1.Vertices[4].restrictionHorizontal = true;
            p1.restrictedHorizontalEdges.Add((p1.Vertices[3], p1.Vertices[4]));
            p1.restrictedHorizontalEdges.Add((p1.Vertices[4], p1.Vertices[3]));
            p1.addVertex(new Vertex(295, 410, p1));
            p1.addVertex(new Vertex(198, 562, p1));
            p1.isCompleted = true;
            polygonsList.Add(p1);


            Polygon p2 = new Polygon();
            p2.addVertex(new Vertex(84, 205, p2));
            p2.Vertices[0].restrictionHorizontal = true;
            p2.Vertices[0].restrictionVertical = true;

            p2.addVertex(new Vertex(334, 205, p2));
            p2.Vertices[1].restrictionHorizontal = true;
            p2.Vertices[1].restrictionVertical = true;
            p2.restrictedHorizontalEdges.Add((p2.Vertices[0], p2.Vertices[1]));
            p2.restrictedHorizontalEdges.Add((p2.Vertices[1], p2.Vertices[0]));


            p2.addVertex(new Vertex(334, 54, p2));
            p2.Vertices[2].restrictionHorizontal = true;
            p2.Vertices[2].restrictionVertical = true;

            p2.restrictedEdges.Add((p2.Vertices[1], p2.Vertices[2]));
            p2.restrictedEdges.Add((p2.Vertices[2], p2.Vertices[1]));


            p2.addVertex(new Vertex(84, 54, p2));
            p2.Vertices[3].restrictionHorizontal = true;
            p2.Vertices[3].restrictionVertical = true;

            p2.restrictedHorizontalEdges.Add((p2.Vertices[3], p2.Vertices[2]));
            p2.restrictedHorizontalEdges.Add((p2.Vertices[2], p2.Vertices[3]));


            p2.restrictedEdges.Add((p2.Vertices[3], p2.Vertices[0]));
            p2.restrictedEdges.Add((p2.Vertices[0], p2.Vertices[3]));



            p2.isCompleted = true;
            polygonsList.Add(p2);
        }

        public void InitScene2()
        {
            Polygon p1 = new Polygon();
            p1.addVertex(new Vertex(100, 200, p1));
            p1.addVertex(new Vertex(30, 100, p1));
            p1.addVertex(new Vertex(200, 60, p1));
            p1.addVertex(new Vertex(300, 300, p1));
            p1.isCompleted = true;
            polygonsList.Add(p1);

            Polygon p2 = new Polygon();
            p2.addVertex(new Vertex(600, 500, p2));
            p2.addVertex(new Vertex(450, 300, p2));
            p2.addVertex(new Vertex(350, 450, p2));
            p2.addVertex(new Vertex(300, 500, p2));
            p2.addVertex(new Vertex(450, 550, p2));
            p2.isCompleted = true;
            polygonsList.Add(p2);
        }

        // Zrodlo: https://www.geeksforgeeks.org/bresenhams-circle-drawing-algorithm/
        void MidpointCircle(int xx, int yy, int R, Graphics g)
        {
            SolidBrush br = new SolidBrush(Color.Black);
            int deltaE = 3;
            int deltaSE = 5 - 2 * R;
            int d = 1 - R;
            int x = xx;
            int y = yy;
            g.FillRectangle(br, x, y,1,1);
            while (y > x)
            {
                if (d < 0) //SelectE
                {
                    d += deltaE;
                    deltaE += 2;
                    deltaSE += 2;
                }
                else //Select SE 
                {
                    d += deltaSE;
                    deltaE += 2;
                    deltaSE += 4; y--;
                }
                x++;
                g.FillRectangle(br, x, y, 1, 1);
            }
        }
        // koniec zrodla

        private void Bitmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawCircleButton.Checked)
            {
                //MidpointCircle(50);
                if(clicked1 == false && clicked2==false)
                {
                    clicked1 = true;
                    center = new Vertex(e.X, e.Y, null);

                }
                else if (clicked1 == true && clicked2 == false)
                {
                    clicked2 = true;
                    radius = new Vertex(e.X, e.Y,null);
                    circles.Add((center, radius));
                    Bitmap.Invalidate();

                }
                else if (clicked1 == true && clicked2 == true)
                {
                    clicked1 = true;
                    clicked2 = false;
                    center = new Vertex(e.X, e.Y, null);
                    

                }
                drawCircle = true;
            }
            if (addVertexButton.Checked)
            {
                locationX = e.X;
                locationY = e.Y;

                if (!currPolygon.isVertexFirst(e.X, e.Y))
                {
                    currPolygon.addVertex(new Vertex(e.Location, currPolygon));
                    lastIsFirst = false;
                }
                else
                {
                    lastIsFirst = true;
                    currPolygon.isCompleted = true;
                    currPolygon = new Polygon();
                    polygonsList.Add(currPolygon);
                }

            }
            if (deleteVertexButton.Checked)
            {
                selectedVertex = isVertexSelected(e.X, e.Y);
                if (selectedVertex.Item1)
                {
                    if (selectedVertex.Item3.Vertices.Count <= 3)
                    {
                        MessageBox.Show("Nie mo¿na usun¹æ wierzcho³ka, bo figura nie bêdzie wielok¹tem", "Niedozwolona operacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    int index = selectedVertex.Item3.Vertices.IndexOf(selectedVertex.Item2);
                    int c = selectedVertex.Item3.Vertices.Count;

                    Vertex next = selectedVertex.Item3.Vertices[(index + 1) % c];
                    Vertex prev = selectedVertex.Item3.Vertices[(index - 1) % c];

                    if (index - 1 == -1)
                    {
                        next = selectedVertex.Item3.Vertices[(index + 1)];
                        prev = selectedVertex.Item3.Vertices[c - 1];
                    }

                    if (selectedVertex.Item3.restrictedEdges.Contains((next, selectedVertex.Item2)))
                    {
                        next.restrictionVertical = false;
                        selectedVertex.Item3.restrictedEdges.Remove((next, selectedVertex.Item2));
                        selectedVertex.Item3.restrictedEdges.Remove((selectedVertex.Item2, next));
                    }

                    if (selectedVertex.Item3.restrictedEdges.Contains((prev, selectedVertex.Item2)))
                    {
                        prev.restrictionVertical = false;
                        selectedVertex.Item3.restrictedEdges.Remove((prev, selectedVertex.Item2));
                        selectedVertex.Item3.restrictedEdges.Remove((selectedVertex.Item2, prev));
                    }
                    if (selectedVertex.Item3.restrictedHorizontalEdges.Contains((next, selectedVertex.Item2)))
                    {
                        next.restrictionHorizontal = false;
                        selectedVertex.Item3.restrictedHorizontalEdges.Remove((next, selectedVertex.Item2));
                        selectedVertex.Item3.restrictedHorizontalEdges.Remove((selectedVertex.Item2, next));
                    }


                    if (selectedVertex.Item3.restrictedHorizontalEdges.Contains((prev, selectedVertex.Item2)))
                    {
                        prev.restrictionHorizontal = false;
                        selectedVertex.Item3.restrictedHorizontalEdges.Remove((prev, selectedVertex.Item2));
                        selectedVertex.Item3.restrictedHorizontalEdges.Remove((selectedVertex.Item2, prev));
                    }
                    selectedVertex.Item3.Vertices.Remove(selectedVertex.Item2);
                }
            }
            if (addVertexOnEdge.Checked)
            {
                selectedEdge = isEdgeSelected(e.X, e.Y);
                if (selectedEdge.Item1)
                {
                    int index = selectedEdge.Item4.Vertices.IndexOf(selectedEdge.Item3);
                    Vertex v1 = selectedEdge.Item2;
                    Vertex v2 = selectedEdge.Item3;

                    if (selectedEdge.Item4.restrictedEdges.Contains((v1, v2)))
                    {
                        v1.restrictionVertical = false;
                        v2.restrictionVertical = false;
                        selectedEdge.Item4.restrictedEdges.Remove((v1, v2));
                        selectedEdge.Item4.restrictedEdges.Remove((v2, v1));
                    }

                    if (selectedEdge.Item4.restrictedHorizontalEdges.Contains((v1, v2)))
                    {
                        v1.restrictionHorizontal = false;
                        v2.restrictionHorizontal = false;
                        selectedEdge.Item4.restrictedHorizontalEdges.Remove((v1, v2));
                        selectedEdge.Item4.restrictedHorizontalEdges.Remove((v2, v1));
                    }

                    selectedEdge.Item4.Vertices.Insert(index, new Vertex(e.X, e.Y, selectedEdge.Item4));
                }

            }
            if (setVerticalEdge.Checked)
            {
                selectedEdge = isEdgeSelected(e.X, e.Y);
                if (selectedEdge.Item1)
                {
                    if (selectedEdge.Item2.restrictionVertical || selectedEdge.Item3.restrictionVertical)
                    {
                        MessageBox.Show("Nie mo¿na na³o¿yæ restrykcji na s¹siaduj¹ce krawêdzie", "Niedozwolona operacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    selectedEdge.Item2.restrictionVertical = true;
                    selectedEdge.Item3.restrictionVertical = true;

                    selectedEdge.Item4.restrictedEdges.Add((selectedEdge.Item2, selectedEdge.Item3));
                    selectedEdge.Item4.restrictedEdges.Add((selectedEdge.Item3, selectedEdge.Item2));

                    selectedEdge.Item3.point.X = selectedEdge.Item2.point.X;
                }

            }
            if (setHorizontalEdge.Checked)
            {
                selectedEdge = isEdgeSelected(e.X, e.Y);
                if (selectedEdge.Item1)
                {
                    if (selectedEdge.Item2.restrictionHorizontal || selectedEdge.Item3.restrictionHorizontal)
                    {
                        MessageBox.Show("Nie mo¿na na³o¿yæ restrykcji na s¹siaduj¹ce krawêdzie", "Niedozwolona operacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    selectedEdge.Item2.restrictionHorizontal = true;
                    selectedEdge.Item3.restrictionHorizontal = true;

                    selectedEdge.Item4.restrictedHorizontalEdges.Add((selectedEdge.Item2, selectedEdge.Item3));
                    selectedEdge.Item4.restrictedHorizontalEdges.Add((selectedEdge.Item3, selectedEdge.Item2));

                    selectedEdge.Item2.point.Y = selectedEdge.Item3.point.Y;
                }
            }
            if (deleteRestrictionButton.Checked)
            {
                selectedEdge = isEdgeSelected(e.X, e.Y);
                if (selectedEdge.Item1)
                {
                    Vertex v1 = selectedEdge.Item2;
                    Vertex v2 = selectedEdge.Item3;

                    if (selectedEdge.Item4.restrictedEdges.Contains((v1, v2)))
                    {
                        v1.restrictionVertical = false;
                        v2.restrictionVertical = false;
                        selectedEdge.Item4.restrictedEdges.Remove((v1, v2));
                        selectedEdge.Item4.restrictedEdges.Remove((v2, v1));
                    }

                    if (selectedEdge.Item4.restrictedHorizontalEdges.Contains((v1, v2)))
                    {
                        v1.restrictionHorizontal = false;
                        v2.restrictionHorizontal = false;
                        selectedEdge.Item4.restrictedHorizontalEdges.Remove((v1, v2));
                        selectedEdge.Item4.restrictedHorizontalEdges.Remove((v2, v1));
                    }
                }
            }
            Bitmap.Invalidate();
        }

        void drawCircle2(int xc, int yc, int x, int y, Graphics g)
        {
            SolidBrush sb = new SolidBrush(Color.Black);
            g.FillRectangle(sb,xc + x, yc + y,1,1);
            g.FillRectangle(sb, xc - x, yc + y, 1,1);
            g.FillRectangle(sb,xc + x, yc - y, 1,1);
            g.FillRectangle(sb,xc - x, yc - y, 1,1);
            g.FillRectangle(sb,xc + y, yc + x, 1,1);
            g.FillRectangle(sb,xc - y, yc + x, 1,1);
            g.FillRectangle(sb,xc + y, yc - x, 1,1);
            g.FillRectangle(sb,xc - y, yc - x, 1,1);
        }

        // Function for circle-generation 
        // using Bresenham's algorithm 
        void circleBres(int xc, int yc, int r,Graphics g)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;
            drawCircle2(xc, yc, x, y,g);
            while (y >= x)
            {
                // for each pixel we will 
                // draw all eight pixels 

                x++;

                // check for decision parameter 
                // and correspondingly  
                // update d, x, y 
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                    d = d + 4 * x + 6;
                drawCircle2(xc, yc, x, y,g);
            }
        }
        private void Bitmap_Paint(object sender, PaintEventArgs e)
        {
            if (defaultAlgButton.Checked)
            {
                drawPolygonsDefault(e.Graphics);
            }
            else
            {
                drawPolygonsBresenham(e.Graphics);
            }  
            foreach (var c in circles)
            {
                double r = Math.Sqrt((c.Item1.point.X - c.Item2.point.X) * (c.Item1.point.X - c.Item2.point.X) + (c.Item1.point.Y - c.Item2.point.Y) * (c.Item1.point.Y - c.Item2.point.Y));
                circleBres(c.Item1.point.X, c.Item1.point.Y,(int)r , e.Graphics);
            }
        }

        public void drawPolygonsBresenham(Graphics g)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.FromArgb(121, 172, 120), 1);
            Pen offsetPen = new Pen(Color.FromArgb(25, 38, 85), 1);
            SolidBrush brush = new SolidBrush(Color.FromArgb(97, 130, 100));
            SolidBrush restrictionBrush = new SolidBrush(Color.FromArgb(194, 217, 255));
            SolidBrush restrictionHorizontalBrush = new SolidBrush(Color.FromArgb(255, 240, 206));
            SolidBrush offsetBrush = new SolidBrush(Color.FromArgb(25, 38, 85));
            SolidBrush BresenhamBrush = new SolidBrush(Color.FromArgb(121, 172, 120));
            int radius = 5;

            foreach (Polygon p in polygonsList)
            {

                for (int i = 0; i < p.Vertices.Count; i++)
                {
                    g.FillEllipse(brush, p.Vertices[i].point.X - radius, p.Vertices[i].point.Y - radius, 2 * radius, 2 * radius);
                    if (i > 0)
                    {
                        DrawLineBresenham(BresenhamBrush, p.Vertices[i].point, p.Vertices[i - 1].point, g);
                        if (p.restrictedEdges.Contains((p.Vertices[i], p.Vertices[i - 1])))
                        {
                            int sx = (p.Vertices[i].point.X + p.Vertices[i - 1].point.X) / 2;
                            int sy = (p.Vertices[i].point.Y + p.Vertices[i - 1].point.Y) / 2;
                            g.FillEllipse(restrictionBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }
                        if (p.restrictedHorizontalEdges.Contains((p.Vertices[i], p.Vertices[i - 1])))
                        {
                            int sx = (p.Vertices[i].point.X + p.Vertices[i - 1].point.X) / 2;
                            int sy = (p.Vertices[i].point.Y + p.Vertices[i - 1].point.Y) / 2;
                            g.FillEllipse(restrictionHorizontalBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }
                    }

                    if (p.isCompleted)
                    {
                        DrawLineBresenham(BresenhamBrush, p.Vertices[0].point, p.Vertices[p.Vertices.Count - 1].point, g);
                        if (p.restrictedEdges.Contains((p.Vertices[0], p.Vertices[p.Vertices.Count - 1])))
                        {
                            int sx = (p.Vertices[0].point.X + p.Vertices[p.Vertices.Count - 1].point.X) / 2;
                            int sy = (p.Vertices[0].point.Y + p.Vertices[p.Vertices.Count - 1].point.Y) / 2;
                            g.FillEllipse(restrictionBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }
                        if (p.restrictedHorizontalEdges.Contains((p.Vertices[0], p.Vertices[p.Vertices.Count - 1])))
                        {
                            int sx = (p.Vertices[0].point.X + p.Vertices[p.Vertices.Count - 1].point.X) / 2;
                            int sy = (p.Vertices[0].point.Y + p.Vertices[p.Vertices.Count - 1].point.Y) / 2;
                            g.FillEllipse(restrictionHorizontalBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }

                    }

                }
                if (p.isCompleted && offsetPolygonButton.Checked)
                {
                    //int offset = 30;
                    p.calculateOffsetEdges(offset);
                    p.calculateOffsetVertices();
                    for (int i = 0; i < p.offsetVertices.Count; i++)
                    {
                        g.FillEllipse(offsetBrush, p.offsetVertices[i].point.X - radius, p.offsetVertices[i].point.Y - radius, 2 * radius, 2 * radius);
                        if (i > 0)
                        {
                            DrawLineBresenham(offsetBrush, p.offsetVertices[i].point, p.offsetVertices[i - 1].point, g);
                        }
                    }
                    DrawLineBresenham(offsetBrush, p.offsetVertices[0].point, p.offsetVertices[p.offsetVertices.Count - 1].point, g);
                }
            }
        }

        public void drawPolygonsDefault(Graphics g)
        {
            //Graphics g = e.Graphics;
            g.Clear(Color.White);
            Pen pen = new Pen(Color.FromArgb(121, 172, 120), 1);
            Pen offsetPen = new Pen(Color.FromArgb(25, 38, 85), 1);
            SolidBrush brush = new SolidBrush(Color.FromArgb(97, 130, 100));
            SolidBrush restrictionBrush = new SolidBrush(Color.FromArgb(194, 217, 255));
            SolidBrush restrictionHorizontalBrush = new SolidBrush(Color.FromArgb(255, 240, 206));
            SolidBrush offsetBrush = new SolidBrush(Color.FromArgb(25, 38, 85));
            SolidBrush BresenhamBrush = new SolidBrush(Color.FromArgb(121, 172, 120));
            int radius = 5;

            foreach (Polygon p in polygonsList)
            {

                for (int i = 0; i < p.Vertices.Count; i++)
                {
                    g.FillEllipse(brush, p.Vertices[i].point.X - radius, p.Vertices[i].point.Y - radius, 2 * radius, 2 * radius);
                    if (i > 0)
                    {
                        g.DrawLine(pen, p.Vertices[i].point, p.Vertices[i - 1].point);
                        if (p.restrictedEdges.Contains((p.Vertices[i], p.Vertices[i - 1])))
                        {
                            int sx = (p.Vertices[i].point.X + p.Vertices[i - 1].point.X) / 2;
                            int sy = (p.Vertices[i].point.Y + p.Vertices[i - 1].point.Y) / 2;
                            g.FillEllipse(restrictionBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }
                        if (p.restrictedHorizontalEdges.Contains((p.Vertices[i], p.Vertices[i - 1])))
                        {
                            int sx = (p.Vertices[i].point.X + p.Vertices[i - 1].point.X) / 2;
                            int sy = (p.Vertices[i].point.Y + p.Vertices[i - 1].point.Y) / 2;
                            g.FillEllipse(restrictionHorizontalBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }
                    }

                    if (p.isCompleted)
                    {
                        g.DrawLine(pen, p.Vertices[0].point, p.Vertices[p.Vertices.Count - 1].point);
                        if (p.restrictedEdges.Contains((p.Vertices[0], p.Vertices[p.Vertices.Count - 1])))
                        {
                            int sx = (p.Vertices[0].point.X + p.Vertices[p.Vertices.Count - 1].point.X) / 2;
                            int sy = (p.Vertices[0].point.Y + p.Vertices[p.Vertices.Count - 1].point.Y) / 2;
                            g.FillEllipse(restrictionBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }
                        if (p.restrictedHorizontalEdges.Contains((p.Vertices[0], p.Vertices[p.Vertices.Count - 1])))
                        {
                            int sx = (p.Vertices[0].point.X + p.Vertices[p.Vertices.Count - 1].point.X) / 2;
                            int sy = (p.Vertices[0].point.Y + p.Vertices[p.Vertices.Count - 1].point.Y) / 2;
                            g.FillEllipse(restrictionHorizontalBrush, sx - 2 * radius, sy - 2 * radius, 4 * radius, 4 * radius);
                        }

                    }

                }
                if (p.isCompleted && offsetPolygonButton.Checked)
                {
                    p.calculateOffsetEdges(offset);
                    p.calculateOffsetVertices();
                    for (int i = 0; i < p.offsetVertices.Count; i++)
                    {
                        g.FillEllipse(offsetBrush, p.offsetVertices[i].point.X - radius, p.offsetVertices[i].point.Y - radius, 2 * radius, 2 * radius);
                        if (i > 0)
                        {
                            g.DrawLine(offsetPen, p.offsetVertices[i].point, p.offsetVertices[i - 1].point);
                        }
                    }
                    g.DrawLine(offsetPen, p.offsetVertices[0].point, p.offsetVertices[p.offsetVertices.Count - 1].point);
                }
            }
        }

        (bool, Vertex? v, Polygon? p) isVertexSelected(int x, int y)
        {
            foreach (Polygon p in polygonsList)
            {
                foreach (var v in p.Vertices)
                {
                    if (Math.Abs(x - v.point.X) < eps && Math.Abs(y - v.point.Y) < eps)
                    {
                        return (true, v, p);
                    }
                }
            }
            return (false, null, null);
        }

        (bool, Vertex? v1, Vertex? v2, Polygon? p) isEdgeSelected(int x, int y)
        {
            foreach (Polygon p in polygonsList)
            {
                for (int i = 0; i < p.Vertices.Count; i++)
                {
                    int c = p.Vertices.Count;

                    int x1 = p.Vertices[i].point.X;
                    int y1 = p.Vertices[i].point.Y;

                    int x2 = p.Vertices[(i + 1) % c].point.X;
                    int y2 = p.Vertices[(i + 1) % c].point.Y;

                    double d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                    double d2 = Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
                    double d1 = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));

                    if (Math.Abs(d1 + d2 - d) < eps)
                        return (true, p.Vertices[i], p.Vertices[(i + 1) % c], p);

                }
            }
            return (false, null, null, null);
        }

        public (bool, Vertex v1, Vertex v2) isCircleSelected(int x, int y)
        {
            foreach (var c in circles)
            {
                double r = Math.Sqrt((c.Item1.point.X - c.Item2.point.X) * (c.Item1.point.X - c.Item2.point.X) + (c.Item1.point.Y - c.Item2.point.Y) * (c.Item1.point.Y - c.Item2.point.Y));
                double rApprox = Math.Sqrt((c.Item1.point.X - x) * (c.Item1.point.X - x) + (c.Item1.point.Y - y) * (c.Item1.point.Y - y));

                if((c.Item1.point.X - x)* (c.Item1.point.X - x) + (c.Item1.point.Y - y)* (c.Item1.point.Y - y) <= r*r)
                {
                    return (true, c.Item1, c.Item2);
                }

                //if (Math.Abs(rApprox - r) <= 10*eps)
                //    return (true, c.Item1, c.Item2);

                //if(c.Item1)
                //for (int i = 0; i < p.Vertices.Count; i++)
                //{
                //    int c = p.Vertices.Count;

                //    int x1 = p.Vertices[i].point.X;
                //    int y1 = p.Vertices[i].point.Y;

                //    int x2 = p.Vertices[(i + 1) % c].point.X;
                //    int y2 = p.Vertices[(i + 1) % c].point.Y;

                //    double d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                //    double d2 = Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
                //    double d1 = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));

                //    if (Math.Abs(d1 + d2 - d) < eps)
                //        return (true, p.Vertices[i], p.Vertices[(i + 1) % c], p);

            }
        
            return (false, new Vertex(0,0,null), new Vertex(0,0,null));
        }

        private void Bitmap_MouseDown(object sender, MouseEventArgs e)
        {
            oldMousePoint = new Point(e.X, e.Y);
            int x = e.X;
            int y = e.Y;
            selectedVertex = isVertexSelected(x, y);
            if (moveVertexButton.Checked)
            {
                if (selectedVertex.Item1 == true)
                {
                    isMouseDown = true;
                }
            }
            if (moveEdgeButton.Checked)
            {
                selectedEdge = isEdgeSelected(x, y);

                if (selectedEdge.Item1 == true)
                {
                    isMouseDown = true;
                }
            }
            if (movePolygonButton.Checked)
            {
                selectedEdge = isEdgeSelected(x, y);
                selectedCircle = isCircleSelected(x, y);
                if (selectedEdge.Item1 == true)
                {
                    isMouseDown = true;
                }
                if (selectedCircle.Item1 == true)
                {
                    isMouseDown = true;
                }
            }
            return;

        }

        //private List<Vertex> findNeighboringVertices(Vertex v)
        //{
        //    Polygon p = v.parent;
        //    int c = p.Vertices.Count;
        //    int index = p.Vertices.IndexOf(v);
        //    List<Vertex> neighboringVertices = new List<Vertex>();


        //    for(int i = (index)%c;  i < c-1; i=(i+1)%c)
        //    {
        //        if (p.Vertices[i].restrictionVertical || p.Vertices[i].restrictionHorizontal)
        //        {
        //            neighboringVertices.Add(p.Vertices[i]);
        //        }
        //        else
        //            break;
        //    }
        //    for (int i = index; i > index - c; i--)
        //    {
        //        if (p.Vertices[((i % c) + c) % c].restrictionVertical || p.Vertices[((i % c) + c) % c].restrictionHorizontal)
        //        {
        //            if(!neighboringVertices.Contains(p.Vertices[((i % c) + c) % c]))
        //                neighboringVertices.Add(p.Vertices[((i % c) + c) % c]);
        //        }
        //        else
        //            break;
        //    }
        //    return neighboringVertices;
        //}

        private void Bitmap_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (isMouseDown && moveVertexButton.Checked)
            {
                Vertex? v = selectedVertex.Item2;
                Polygon p = selectedVertex.Item3;
                int c = v.parent.Vertices.Count;
                int index = v.parent.Vertices.IndexOf(v);
                Vertex prev = v.parent.Vertices[(((index - 1) % c) + c) % c];
                Vertex next = v.parent.Vertices[((index + 1) % c)];

                if (!v.restrictionVertical && !v.restrictionHorizontal)
                {
                    v.point.X = x;
                    v.point.Y = y;
                }
                else if (v.restrictionHorizontal && v.restrictionVertical)
                {
                    if (prev.restrictionVertical && next.restrictionHorizontal && p.restrictedHorizontalEdges.Contains((v, next)))
                    {
                        prev.point.X += x - oldMousePoint.X;
                        next.point.Y += y - oldMousePoint.Y;
                    }
                    else
                    {
                        prev.point.Y += y - oldMousePoint.Y;
                        next.point.X += x - oldMousePoint.X;
                    }
                }
                else if (v.restrictionVertical)
                {
                    Vertex neighbor = next.restrictionVertical ? next : prev;
                    neighbor.point.X += x - oldMousePoint.X;
                }
                else if (v.restrictionHorizontal)
                {
                    Vertex neighbor = next.restrictionHorizontal ? next : prev;
                    neighbor.point.Y += y - oldMousePoint.Y;
                }
                v.point.X += x - oldMousePoint.X;
                v.point.Y += y - oldMousePoint.Y;
                oldMousePoint = new Point(e.X, e.Y);
                Bitmap.Invalidate();
            }
            if (isMouseDown && moveEdgeButton.Checked)
            {
                Vertex? v1 = selectedEdge.Item2;
                Vertex? v2 = selectedEdge.Item3;
                Polygon p = selectedEdge.Item4;

                int c = v1.parent.Vertices.Count;
                int indexV1 = v1.parent.Vertices.IndexOf(v1);
                int indexV2 = v2.parent.Vertices.IndexOf(v2);

                Vertex prev = indexV2 > indexV1 ? v1.parent.Vertices[(((indexV1 - 1) % c) + c) % c] : v2.parent.Vertices[(((indexV1 - 1) % c) + c) % c];
                Vertex next = indexV1 > indexV2 ? v1.parent.Vertices[((indexV2 + 1) % c)] : v2.parent.Vertices[((indexV2 + 1) % c)];

                if ((!p.restrictedHorizontalEdges.Contains((v1, v2)) && !p.restrictedEdges.Contains((v1, v2)) && !v1.restrictionVertical &&
                    !v1.restrictionHorizontal && !v2.restrictionVertical && !v2.restrictionHorizontal) &&
                    (!v1.restrictionVertical && !v2.restrictionVertical && !p.restrictedHorizontalEdges.Contains((v1, v2))) &&
                    (!v1.restrictionHorizontal && !v2.restrictionHorizontal && !p.restrictedEdges.Contains((v1, v2))))
                {
                    v1.point.X += e.X - oldMousePoint.X;
                    v1.point.Y += e.Y - oldMousePoint.Y;

                    v2.point.X += e.X - oldMousePoint.X;
                    v2.point.Y += e.Y - oldMousePoint.Y;
                    oldMousePoint = new Point(e.X, e.Y);
                }
                else if (p.restrictedHorizontalEdges.Contains((v1, v2)))
                {
                    if (v1.restrictionVertical ^ v2.restrictionVertical)
                    {
                        Vertex restricted = v1.restrictionVertical ? v1 : v2;

                        Vertex neighborRestricted = prev.restrictionVertical &&
                            p.restrictedEdges.Contains((restricted, prev)) ? prev : next;

                        neighborRestricted.point.X += e.X - oldMousePoint.X;
                    }
                    if (v1.restrictionVertical && v2.restrictionVertical)
                    {
                        next.point.X += e.X - oldMousePoint.X;

                        prev.point.X += e.X - oldMousePoint.X;

                    }
                    v1.point.X += e.X - oldMousePoint.X;
                    v1.point.Y += e.Y - oldMousePoint.Y;

                    v2.point.X += e.X - oldMousePoint.X;
                    v2.point.Y += e.Y - oldMousePoint.Y;
                    oldMousePoint = new Point(e.X, e.Y);
                }
                else if (p.restrictedEdges.Contains((v1, v2)))
                {
                    if (v1.restrictionHorizontal ^ v2.restrictionHorizontal)
                    {
                        Vertex restricted = v1.restrictionHorizontal ? v1 : v2;

                        Vertex neighborRestricted = prev.restrictionHorizontal &&
                            p.restrictedHorizontalEdges.Contains((restricted, prev)) ? prev : next;

                        neighborRestricted.point.Y += e.Y - oldMousePoint.Y;
                    }
                    if (v1.restrictionHorizontal && v2.restrictionHorizontal)
                    {
                        next.point.Y += e.Y - oldMousePoint.Y;

                        prev.point.Y += e.Y - oldMousePoint.Y;

                    }
                    v1.point.X += e.X - oldMousePoint.X;
                    v1.point.Y += e.Y - oldMousePoint.Y;

                    v2.point.X += e.X - oldMousePoint.X;
                    v2.point.Y += e.Y - oldMousePoint.Y;
                    oldMousePoint = new Point(e.X, e.Y);
                }
                else if (!p.restrictedEdges.Contains((v1, v2)) && !p.restrictedHorizontalEdges.Contains((v1, v2)))
                {
                    if (v1.restrictionHorizontal ^ v2.restrictionHorizontal)
                    {
                        Vertex restricted = v1.restrictionHorizontal ? v1 : v2;

                        Vertex neighborRestricted = prev.restrictionHorizontal &&
                            p.restrictedHorizontalEdges.Contains((restricted, prev)) ? prev : next;

                        neighborRestricted.point.Y += e.Y - oldMousePoint.Y;

                    }
                    if (v1.restrictionVertical ^ v2.restrictionVertical)
                    {
                        Vertex restricted = v1.restrictionVertical ? v1 : v2;

                        Vertex neighborRestricted = prev.restrictionVertical &&
                            p.restrictedEdges.Contains((restricted, prev)) ? prev : next;

                        neighborRestricted.point.X += e.X - oldMousePoint.X;

                    }
                    v1.point.X += e.X - oldMousePoint.X;
                    v1.point.Y += e.Y - oldMousePoint.Y;

                    v2.point.X += e.X - oldMousePoint.X;
                    v2.point.Y += e.Y - oldMousePoint.Y;
                    oldMousePoint = new Point(e.X, e.Y);
                }
                oldMousePoint = new Point(e.X, e.Y);
                Bitmap.Invalidate();

                //if (!v1.restrictionVertical && !v2.restrictionVertical && !v1.restrictionHorizontal && !v2.restrictionHorizontal)
                //{
                //    v1.point.X += e.X - oldMousePoint.X;
                //    v1.point.Y += e.Y - oldMousePoint.Y;

                //    v2.point.X += e.X - oldMousePoint.X;
                //    v2.point.Y += e.Y - oldMousePoint.Y;

                //    oldMousePoint = new Point(e.X, e.Y);
                //}

                //if (v1.restrictionHorizontal ^ v2.restrictionHorizontal)
                //{
                //    v1.point.X += e.X - oldMousePoint.X;
                //    //v1.point.Y += e.Y - oldMousePoint.Y;

                //    v2.point.X += e.X - oldMousePoint.X;
                //    //v2.point.Y += e.Y - oldMousePoint.Y;

                //    oldMousePoint = new Point(e.X, e.Y);
                //}
                //if (v1.restrictionHorizontal && v2.restrictionHorizontal &&
                //    !(v1.parent.restrictedHorizontalEdges.Contains((v1, v2)) || v2.parent.restrictedHorizontalEdges.Contains((v1, v2))))
                //{
                //    v1.point.X += e.X - oldMousePoint.X;
                //    //v1.point.Y += e.Y - oldMousePoint.Y;

                //    v2.point.X += e.X - oldMousePoint.X;
                //    //v2.point.Y += e.Y - oldMousePoint.Y;

                //    oldMousePoint = new Point(e.X, e.Y);
                //}
                //if (v1.parent.restrictedHorizontalEdges.Contains((v1, v2)) || v2.parent.restrictedHorizontalEdges.Contains((v1, v2)))
                //{
                //    if (v1.restrictionVertical || v2.restrictionVertical)
                //    {
                //        //v1.point.X += e.X - oldMousePoint.X;
                //        v1.point.Y += e.Y - oldMousePoint.Y;

                //        //v2.point.X += e.X - oldMousePoint.X;
                //        v2.point.Y += e.Y - oldMousePoint.Y;
                //    }
                //    else
                //    {
                //        v1.point.X += e.X - oldMousePoint.X;
                //        v1.point.Y += e.Y - oldMousePoint.Y;

                //        v2.point.X += e.X - oldMousePoint.X;
                //        v2.point.Y += e.Y - oldMousePoint.Y;
                //    }


                //    oldMousePoint = new Point(e.X, e.Y);
                //}



                //if (v1.restrictionVertical ^ v2.restrictionVertical)
                //{
                //    //v1.point.X += e.X - oldMousePoint.X;
                //    v1.point.Y += e.Y - oldMousePoint.Y;

                //    //v2.point.X += e.X - oldMousePoint.X;
                //    v2.point.Y += e.Y - oldMousePoint.Y;

                //    oldMousePoint = new Point(e.X, e.Y);
                //}
                //if (v1.restrictionVertical && v2.restrictionVertical && !(v1.parent.restrictedEdges.Contains((v1, v2)) || v2.parent.restrictedEdges.Contains((v1, v2))))
                //{
                //    //v1.point.X += e.X - oldMousePoint.X;
                //    v1.point.Y += e.Y - oldMousePoint.Y;

                //    //v2.point.X += e.X - oldMousePoint.X;
                //    v2.point.Y += e.Y - oldMousePoint.Y;

                //    oldMousePoint = new Point(e.X, e.Y);
                //}
                //if (v1.parent.restrictedEdges.Contains((v1, v2)) || v2.parent.restrictedEdges.Contains((v1, v2)))
                //{
                //    v1.point.X += e.X - oldMousePoint.X;
                //    v1.point.Y += e.Y - oldMousePoint.Y;

                //    v2.point.X += e.X - oldMousePoint.X;
                //    v2.point.Y += e.Y - oldMousePoint.Y;

                //    oldMousePoint = new Point(e.X, e.Y);
                //}
            }
            if (isMouseDown && movePolygonButton.Checked)
            {
                Polygon? p = selectedEdge.Item4;
                var selectedCircle = isCircleSelected(e.X, e.Y);

                if(selectedCircle.Item1)
                {
                    int id = circles.IndexOf((selectedCircle.Item2, selectedCircle.Item3));
                    circles[id].Item1.point.X += e.X - oldMousePoint.X;
                    circles[id].Item1.point.Y += e.Y - oldMousePoint.Y;

                    circles[id].Item2.point.X += e.X - oldMousePoint.X;
                    circles[id].Item2.point.Y += e.Y - oldMousePoint.Y;
                }
                if(selectedEdge.Item1)
                {
                    for (int i = 0; i < p.Vertices.Count; i++)
                    {
                        p.Vertices[i].point.X += e.X - oldMousePoint.X;
                        p.Vertices[i].point.Y += e.Y - oldMousePoint.Y;
                    }
                }

                oldMousePoint = new Point(e.X, e.Y);
            }

            Bitmap.Invalidate();
        }

        private void Bitmap_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            selectedVertex = (false, null, null);
            selectedEdge = (false, null, null, null);
        }

        private void clearFieldButton_Click(object sender, EventArgs e)
        {
            polygonsList.Clear();
            currPolygon = new Polygon();
            polygonsList.Add(currPolygon);
            circles.Clear();
            Bitmap.Invalidate();
        }

        // Zrodlo: https://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
        public void DrawLineBresenham(Brush color, Point p1, Point p2, Graphics g)
        {
            int x = p1.X;
            int y = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                g.FillRectangle(color, x, y, 1, 1);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
        // koniec zrodla

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            offset = trackBar1.Value;
            Bitmap.Invalidate();
        }

        private void offsetPolygonButton_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap.Invalidate();
        }
    }
}