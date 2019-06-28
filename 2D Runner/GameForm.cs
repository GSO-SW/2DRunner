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

        public GameForm()
        {
            //ClientSize, Convert.ToInt32(ClientSize) / 20, Convert.ToInt32(ClientSize) / 5, Convert.ToInt32(ClientSize) / 5, screensize / 3, screensize / 2
            InitializeComponent();
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += Timer_tick;
            timer.Start();
            DoubleBuffered = true;


            player = new Player(10, 200, 10, 10, 0, 15);


            obstacles = new List<Obstacle>();

            for (int i = 0; i < 10; i++)
                obstacles.Add(new Obstacle(this.ClientSize.Width + 100 *i));
            
            //foreach (Obstacle obs in obstacles)
            //{
            //    obs.Random_SizeY();
            //}
            //obstacles.Add(new Obstacle(20, Convert.ToInt32(ClientSize.Width), player.StartPosY - (player.SizeY / 2)));
            //obstacles.Add(new Obstacle(20, Convert.ToInt32(ClientSize.Width) + 30, player.StartPosY - (player.SizeY / 2)));



        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Font font = new Font("Comic Sans", 24);

            g.DrawString(Convert.ToString(obstacles[1].SizeY), font, Brushes.Black, 300, 5);
            Pen BlackPen = new Pen(Color.Black, 2);

            foreach (Obstacle obstacle in obstacles)
                g.DrawRectangle(Pens.Black, new Rectangle(new Point(obstacle.PosX, obstacle.PosY), new Size(obstacle.SizeX, obstacle.SizeY)));

            player.DrawPlayer(e);
        }
        private void Timer_tick(object sender, EventArgs e)
        {
            foreach (Obstacle obstacle in obstacles)
                obstacle.PosX--;

            player.IsOnGround();
            player.GoGround();
            player.StartJump();
            Invalidate();
            Refresh();
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
