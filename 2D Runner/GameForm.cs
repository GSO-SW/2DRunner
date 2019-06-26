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
        Obstacle obstacle;
        
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
           
           
            player = new Player(10,200,10,10,0,10);
            obstacle = new Obstacle(20, Convert.ToInt32(ClientSize.Width), player.StartPosY);
           
          
        }
      
        protected override void OnPaint(PaintEventArgs e)
        {
     
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen BlackPen = new Pen(Color.Black, 2);
            obstacle.DrawObstacle(e);
            
            player.DrawPlayer(e);
     
        }
        private void Timer_tick(object sender, EventArgs e)
        {
            
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
