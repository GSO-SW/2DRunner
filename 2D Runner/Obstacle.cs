using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Runner
{
    class Obstacle
    {
        public Rectangle rect2;


        public Obstacle(int thisPosX)
        {
            int[] SizeObstacle = { 5, 10, 15 };

            sizex = SizeObstacle[new Random().Next(0, 3)];
            Thread.Sleep(1);
            sizey = SizeObstacle[new Random().Next(0, 3)];
            Thread.Sleep(1);

            posx = thisPosX;
            posy = 200;
        }

        #region Probs
        private int posx;

        public int PosX
        {
            get { return posx; }
            set { posx = value; }
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

        #endregion

        public void DrawObstacle(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(posx, posy), new Size(sizex, sizey));
            g.DrawRectangle(Pens.Black, rect);
        }
        public void Random_SizeY()
        {
        }
    }
}
