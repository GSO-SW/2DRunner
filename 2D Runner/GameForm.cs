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
        Ground ground;
        Player player;
        Obstacle obs;
        Timer timer;
        //Initialisierung
        public GameForm()
        {          
            InitializeComponent();
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += Timer_tick;
            timer.Start();
            DoubleBuffered = true;
         
            ground = new Ground(Width);
            player = new Player(Width / 10, Height / 2, 1, 2);
            obs = new Obstacle(Width, Height / 2);
            
            AnimateImage();
        }
        /// <summary>
        /// Malt die angebenen Objekte auf die Form
        /// </summary>
        /// <param name="e">Ist ein PaintEventArg</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            ImageAnimator.UpdateFrames();

            obs.DrawObstacle(e);
            ground.DrawGround(e);
            player.DrawPlayer(e);
            if(player.Dead)
            {     
              e.Graphics.DrawString("Enter for Restart", new Font("comic sans", 18), Brushes.Black, 100, 5);             
              e.Graphics.DrawString("Esc to Exit", new Font("comic sans", 18), Brushes.Black, 100, 25);
            }
        }
        /// <summary>
        /// Die Methoden in der Methode werden pro Tick aufgerufen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_tick(object sender, EventArgs e)
        {
            ground.LoopGround(obs.Speed);
            obs.CountScore();
            player.StartJump();
            player.IsOnGround();          
            Gamend();
            Invalidate();
            Refresh();
        }
        /// <summary>
        /// Animiert den Spieler
        /// </summary>
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
        /// <summary>
        /// Beended das Spiel bei kontakt mit einem Hinderniss
        /// </summary>
        private void Gamend()
        {
            for (int i = 0; i <= obs.Recs.Count - 1; i++)
            {
                if (player.Hitbox.IntersectsWith(obs.Recs[i]))
                {
                    player.Dead = true;
                    ImageAnimator.StopAnimate(player.AnimatedImage, new EventHandler(Timer_tick));
                }
            }
            if (player.Dead)
            {        
                player.AnimatedImage = Properties.Resources.dead;
                timer.Stop(); 
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            player.Jump(e.KeyCode);
            if(player.Dead)
            {
                if(e.KeyData == Keys.Enter)
                {
                    InitializeComponent();
                    timer = new Timer();
                    timer.Enabled = true;
                    timer.Interval = 10;
                    timer.Tick += Timer_tick;
                    timer.Start();
                    DoubleBuffered = true;

                    ground = new Ground(Width);
                    player = new Player(Width / 10, Height / 2, 1, 2);
                    obs = new Obstacle(Width, Height / 2);

                    AnimateImage();
                    player.Dead = false;
                }
                if(e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
        }


    }
}
