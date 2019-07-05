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
        Random r = new Random();
        Rectangle rec, rec_2, rec_3, rec_4;

        List<int> Positions;
        List<Image> obstacles;

        Image obstacle_1;
        Image obstacle_2;
        Image obstacle_3;
        Image obstacle_4;

        List<Rectangle> recs;

        int lastObstacleIndex;
        int score;
        int a;
        int b;
        int startposy;
        int test;
        #region Probs
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public List<Rectangle> Recs
        {
            get { return recs; }
            set { recs = value; }
        }
        public Rectangle Rec_2
        {
            get { return rec_2; }
            set { rec_2 = value; }
        }
        public Rectangle Rec
        {
            get { return rec; }
            set { rec = value; }
        }
        private List<Rectangle> myReactangles;

        public List<Rectangle> MyRectangles
        {
            get { return myReactangles; }
            set { myReactangles = value; }
        }

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
        public Obstacle(int thisPosX, int thisPosY)
        {
            test = 100;
            speed = 9;
            recs = new List<Rectangle>();

            rec = new Rectangle(new Point(800, 105), new Size(30, 55));
            rec_2 = new Rectangle(new Point(800, 115), new Size(40, 50));
            rec_3 = new Rectangle(new Point(800, 105), new Size(30, 55));
            rec_4 = new Rectangle(new Point(800, 115), new Size(40, 50));
            recs.Add(rec);
            recs.Add(rec_2);
            recs.Add(rec_4);
            recs.Add(rec_4);



            obstacle_1 = Properties.Resources.obstacle_1_Black;
            obstacle_2 = Properties.Resources.obstacle_2_Black;
            obstacle_3 = Properties.Resources.obstacle_1_Black;
            obstacle_4 = Properties.Resources.obstacle_2_Black;

            obstacles = new List<Image>();
            obstacles.Add(obstacle_1);
            obstacles.Add(obstacle_2);
            obstacles.Add(obstacle_3);
            obstacles.Add(obstacle_4);


            Positions = new List<int>();


            SetRandomPositions();



            score = 0;
            speed = 8;



            startposy = thisPosY;
            posx = thisPosX;
            posy = thisPosY;


            sizex = 20;

        }
        public void DrawObstacle(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect1 = new Rectangle(new Point(posx, posy), new Size(sizex, sizey));

            g.DrawRectangle(Pens.Black, rect1);
            MoveObstacles(e);

        }
        public void CountScore()
        {
            test -= 6;
            if (test <= 0)
            {
                score++;
                test = 100;
            }
        }
        void MoveObstacles(PaintEventArgs e)
        {

            for (int i = 0; i < 4; i++)
            {
                Positions[i] -= speed;


                if (Positions[i] < -50)
                {                   
                    if (score > 100)
                    {
                        if (speed != 15)
                        {
                            speed++;
                        }
                    }
                    if (score > 300)
                    {
                        if (speed != 17)
                        {

                            speed++;
                        }
                    }

                    Positions.RemoveAt(i);

                    if (i != 0)
                    {
                        a = 1600 + posx + Positions[i - 1] + r.Next(r.Next(0, 600));

                    }
                    else
                    {
                        a = 800 + Positions[i] + r.Next(r.Next(0, 600));
                    }
                    do
                    {
                        b = r.Next(0, 4);
                    } while (b == lastObstacleIndex);
                    Positions.Insert(i, a);
                }
                Rectangle temp = recs[b];
                temp.X = Positions[i];
                recs[i] = temp;
                string scoreText = Convert.ToString("Score: " + score);
                e.Graphics.DrawString(scoreText, new Font("comic sans", 18), Brushes.Black, posx - 450, 5);
                e.Graphics.DrawImage(obstacles[b], Positions[i], startposy - obstacles[b].Height - obstacles[b].Height / 3);


                lastObstacleIndex = i;
            }
        }
        void SetRandomPositions()
        {
            for (int i = 0; i < 4; i++)
            {
                {
                    int test;
                    if (i != 0)
                    {
                        test = 1600 + posx + Positions[i - 1] + r.Next(r.Next(600, 1000));

                    }
                    else
                    {
                        test = 800 + posx + r.Next(r.Next(600, 1000));

                    }
                    Positions.Add(test);
                    Rectangle temp = recs[i];
                    temp.X = test;
                    recs[i] = temp;
                    b = r.Next(0, 4);
                }
            }
        }
    }
}
