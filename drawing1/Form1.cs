// Ignore Spelling: Pointsarr

using System;
using System.Drawing;
using System.Windows.Forms;

namespace drawing1
{
    public partial class paint : Form
    {
        public paint()
        {
            InitializeComponent();
            setSize();
        }

        private class PointsArray
        {
            private int index = 0;
            private Point[] points;

            public PointsArray(int size)
            {
                if (size <= 0) { size = 2; }
                points = new Point[size];
            }

            public void setPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }

            public void resetIndex()
            {
                index = 0;
            }

            public int getLastIndex()
            {
                return index;
            }

            public Point[] getPoints()
            {
                return points;
            }
        }

        private PointsArray arrayPoints = new PointsArray(2);
        private bool isMouse = false;
        private Bitmap map = new Bitmap(100, 100);
        private Pen pen = new Pen(Color.Black, 3f);
        private Graphics g;

        private void setSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            g = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void sliderWidth_Scroll(object sender, EventArgs e)
        {
        }

        private void drawPlace_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
        }

        private void drawPlace_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.resetIndex();

        }

        private void drawPlace_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse) { return; }
            arrayPoints.setPoint(e.X, e.Y);
            if (arrayPoints.getLastIndex() >= 2)
            {
                g.DrawLines(pen, arrayPoints.getPoints());
                drawPlace.Image = map;
                arrayPoints.setPoint(e.X, e.Y);
            }
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {

        }
    }
}