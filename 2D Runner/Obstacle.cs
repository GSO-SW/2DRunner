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
        //Deklarieren
        private Random r;
        private List<int> Positions;

        private Rectangle rec, rec_2, rec_3, rec_4;
        private List<Rectangle> recs;

        private List<Image> obstacles;
        private Image obstacle_1, obstacle_2, obstacle_3, obstacle_4;

        private int lastObstacleIndex, score, a, b, startposy, test, speed, posx, posy, sizex, sizey;

        #region Properties
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
        public int PosX
        {
            get { return posx; }
            set { posx = value; }
        }
        public int PosY
        {
            get { return posy; }
            set { posy = value; }
        }
        public int SizeX
        {
            get { return sizex; }
            set { sizex = value; }
        }
        public int SizeY
        {
            get { return sizey; }
            set { sizey = value; }
        }
        #endregion
        /// <summary>
        ///  Initialisieren
        /// </summary>
        /// <param name="thisPosX">Teil der Clientbreite mit der die X Koordinaten der Hindernisse berechnet werden</param>
        /// <param name="thisPosY">Teil der Clienthöhe mit der die Y Koordinaten der Hindernisse berechnet werden</param>
        public Obstacle(int thisPosX, int thisPosY)
        {
            r = new Random();

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

            test = 100;
            speed = 9;
            score = 0;
            speed = 8;
            startposy = thisPosY;
            posx = thisPosX;
            posy = thisPosY;
            sizex = 20;
        }
        /// <summary>
        /// Malt die Hindernisse auf die Form
        /// </summary>
        /// <param name="e">Ist ein PaintEventArg</param>
        public void DrawObstacle(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect1 = new Rectangle(new Point(posx, posy), new Size(sizex, sizey));

            g.DrawRectangle(Pens.Black, rect1);
            MoveObstacles(e);
        }
        /// <summary>
        /// Zähl die Punkte hoch die der Spieler beim Spielen erreicht
        /// </summary>
        public void CountScore()
        {
            test -= 6;
            if (test <= 0)
            {
                score++;
                test = 100;
            }
        }
        /// <summary>
        /// Eine Schleife bei der b randomized wird um den Index der Hinternisse und dessen Hitbox auszuwählen und anzeigen zu lassen
        /// Positions sind randomized Positionen die die Position der Hinternisse[b] angeben
        /// </summary>
        /// <param name="e">Ist ein PaintEventArg</param>
        void MoveObstacles(PaintEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                Positions[i] -= speed;

                if (Positions[i] < -50)
                {
                    //Erhöhung der Geschwindigkeit abhängig vom Score
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
                        
                        a = 600 + posx + Positions[i - 1] + r.Next(r.Next(200, 800));

                    }
                    else
                    {
                        a = posx + 400 + Positions[2] + r.Next(r.Next(200, 1000));
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
        /// <summary>
        /// Zu beginn werden die Positionen der Hindernisse gesetzt
        /// </summary>
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
