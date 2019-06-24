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
   
    public partial class Form1 : Form
    {
        int screensize;
        Player player;
        double verschiebung;
        public Form1()
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
            verschiebung = 0.0;
          
        }

        protected override void OnPaint(PaintEventArgs e)
        {
     
            base.OnPaint(e);
            Graphics g = e.Graphics;
            player.DrawPlayer(e);
            //Rectangle rect1 = new Rectangle(new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 - 100), new Size(200, 200));
            //g.DrawEllipse(BlackPen, rect1);
            //g.DrawEllipse(BlackPen, ClientSize.Width / 2 - 10, ClientSize.Height / 2, 20, 20);
          
            //Rectangle rect2 = new Rectangle(new Point(Convert.ToInt32(ClientSize.Width / 2 - 5 + (Math.Cos(verschiebung) * 100)), Convert.ToInt32(ClientSize.Height / 2 - 5 + (Math.Sin(verschiebung) * 100))), new Size(10, 10));
            //g.DrawRectangle(BlackPen, rect2);
        }
        private void Timer_tick(object sender, EventArgs e)
        {
            //verschiebung += 0.03;
            
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
