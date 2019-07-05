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
    class Ground
    {       
        private Image groundImage1, groundImage2;

        int ground1PosX, ground2PosX, width;

        public Ground(int clientsizeWidth)
        {
            groundImage1 = Properties.Resources.Ground_Black;
            groundImage2 = Properties.Resources.Ground_Black;

            ground1PosX = 0;
            ground2PosX = groundImage1.Width + ground1PosX;

            width = clientsizeWidth;
        }
        public void DrawGround(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen BlackPen = new Pen(Color.Black, 2);
            g.DrawImage(groundImage1, new Point(ground1PosX,130));
            g.DrawImage(groundImage2, new Point(ground2PosX, 130));
        }

        public void LoopGround(int obstaclespeed)
        {
            ground1PosX -= obstaclespeed;
            ground2PosX -= obstaclespeed;
            if (ground1PosX < + 55-ground1PosX - groundImage1.Width * 2)
            {
                ground1PosX = width;
            }
            if (ground2PosX < +55 -ground2PosX - groundImage2.Width * 2)
            {
               ground2PosX = width;
            }

        }

    }
}
