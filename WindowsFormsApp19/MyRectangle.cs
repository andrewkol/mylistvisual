using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp19
{
    class MyRectangle
    {
        private int startX, startY, width, height;
        private string NUM;
        private Brush blackbrush;
        private Rectangle rect;
        public MyRectangle(int x, int y, int width, int height, string NUM)
        {
            this.startX = x;
            this.startY = y;
            this.height = height;
            this.width = width;
            this.NUM = NUM;
            blackbrush = new SolidBrush(Color.Olive);
            rect = new Rectangle(startX, startY, width, height);
        }
        public void ReRect(int X, int Y)
        {
            rect = new Rectangle(X, Y, width, height);
            startX = X;
            startY = Y;
        }
        public int StartX { get { return startX; } }
        public int StartY { get { return startY; } }
        public int Height { get { return height; } }
        public int Width { get { return width; } }
        public string _NUM { get { return NUM; } set { NUM = value; } }
        public Graphics Draw(Graphics graf)
        {
            graf.FillRectangle(blackbrush, rect);
            graf.DrawString(NUM, new Font("Arial", 14), Brushes.Black, rect.X + width / 4, rect.Y + height / 4);
            return graf;
        }
    }
}
