using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Runner
{
   class Obstacle
    {
        public Obstacle(int thisSizeX)
        {
            sizex = thisSizeX;
        }
        private int posX;

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }
        private int posy;

        public int PosY
        {
            get { return posy; }
            set { posy = value; }
        }
        private int sizex;

        public int SizeX
        {
            get { return sizex; }
            set { sizex = value; }
        }

        private int sizey;

        public int SizeY
        {
            get { return sizey; }
            set { sizey = value; }
        }

        public void DrawObstacle(PaintEventArgs e)
        {
            int i;
            int[] HeightObstacle = { 5, 10, 15 };
            Random  r = new Random();
            i = r.Next(1, 3);
            sizey = HeightObstacle[i];

            
            
            Graphics g = e.Graphics;
            Rectangle rect1 = new Rectangle(new Point(posX, posy), new Size(sizex, sizey));
            g.DrawRectangle(Pens.Black, rect1);
        }



    }
}
