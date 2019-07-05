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

    public partial class GameForm : Form
    {
        
        Player player;
        List<Obstacle> obstacles;
        Obstacle obs;




        Timer timer;

        public GameForm()
        {
            //ClientSize, Convert.ToInt32(ClientSize) / 20, Convert.ToInt32(ClientSize) / 5, Convert.ToInt32(ClientSize) / 5, screensize / 3, screensize / 2
            InitializeComponent();
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += Timer_tick;
            timer.Start();
            
            DoubleBuffered = true;
            obstacles = new List<Obstacle>();
            player = new Player(Width/10, Height/2, 1, 2);
           // player.PosY -= player.AnimatedImage.Height;
            obs = new Obstacle(Width , Height / 2 );
           // obs.PosY += player.AnimatedImage.Height; ;
            AnimateImage();
           
          

            //obstacles = new List<Obstacle>();

                //for (int i = 0; i < 10; i++)
                //   obstacles.Add(new Obstacle(this.ClientSize.Width + 100 *i, player.StartPosY + player.SizeY));




                //obstacles.Add(new Obstacle(20, Convert.ToInt32(ClientSize.Width), player.StartPosY - (player.SizeY / 2)));
                //obstacles.Add(new Obstacle(20, Convert.ToInt32(ClientSize.Width) + 30, player.StartPosY - (player.SizeY / 2)));



        }

        protected override void OnPaint(PaintEventArgs e)
        {
           
                base.OnPaint(e);
                Graphics g = e.Graphics;
                Font font = new Font("Comic Sans", 24);

                ImageAnimator.UpdateFrames();
                //g.DrawString(Convert.ToString(obstacles[1].PosY), font, Brushes.Black, 300, 5);
                Pen BlackPen = new Pen(Color.Black, 2);


                //foreach (Obstacle obs in obstacles)
                //{
                //    obs.DrawObstacle(e);
                //}

                obs.DrawObstacle(e);
            





            ////foreach (Obstacle obstacle in obstacles)
            //// g.DrawRectangle(Pens.Black, new Rectangle(new Point(obstacle.PosX, obstacle.PosY), new Size(obstacle.SizeX, obstacle.SizeY)));

            player.DrawPlayer(e);
        }
        private void Timer_tick(object sender, EventArgs e)
        {
            
            player.StartJump(); 
            player.IsOnGround();
            player.GoGround();
            Gamend();
            Invalidate();
            Refresh();
        }

        public void AnimateImage()
        {
            if (player.AnimatedImage != null)
            {
                ImageAnimator.Animate(player.AnimatedImage, new EventHandler(this.OnFrameChanged));
            }

        }
        private void OnFrameChanged(object o, EventArgs e)
        {


            this.Invalidate(player.Hitbox);
        }
        private void Gamend()
        {



            for (int i = 0; i <= obs.Recs.Count - 1; i++)
            {
                if(player.Hitbox.IntersectsWith(obs.Recs[i]))
                {
                    player.Dead = true;
                    ImageAnimator.StopAnimate(player.AnimatedImage, new EventHandler(Timer_tick));
                }
            }
            if(player.Dead)
            {
               
                timer.Stop();
                player.AnimatedImage = Properties.Resources.dead;
                Close();
            }
            
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            //player.StopJump(e.KeyCode);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            player.Jump(e.KeyCode);
        }

      
    }
}
