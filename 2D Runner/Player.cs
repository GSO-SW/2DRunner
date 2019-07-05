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

    class Player
    {
        Bitmap animatedImage;

        private int posx;
        private int posy;
        private int sizex;
        private int sizey;
        private int gravity;
        private int jumpvelocity;
        private int startposy;
        private Rectangle hitbox;

        private bool dead;
        bool isJumping;

        
        #region Props



        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }

        public Bitmap AnimatedImage
        {
            get { return animatedImage; }
            set { animatedImage = value; }
        }

        public bool Dead
        {
            get { return dead; }
            set { dead = value; }
        }
        public int StartPosY
        {
            get { return startposy; }
            set { startposy = value; }
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
        public int Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }
        public int JumpVelocity
        {
            get { return jumpvelocity; }
            set { jumpvelocity = value; }
        }
        #endregion




        //f1.ClientSize.Width / 10 - 20, Convert.ToInt32(ClientSize.Height / 1.5 - jumpVelocity)), new Size(20, 50)
        public Player(int posx1, int posy1, int gravity1, int jumpvelocity1)
        {
            animatedImage = new Bitmap(@"running.gif");

            startposy = posy1 - animatedImage.Height;
            PosX = posx1;
            PosY = posy1;

            Gravity = 1;
            JumpVelocity = jumpvelocity1;

            dead = false;
            isJumping = false;
            



        }

        public void DrawPlayer(PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen BlackPen = new Pen(Color.Black, 2);


            hitbox = new Rectangle(new Point(posx + animatedImage.Width/4,posy), new Size(animatedImage.Width/2, animatedImage.Height));
           //w g.DrawRectangle(BlackPen, hitbox);
            g.DrawImage(this.animatedImage, new Point(posx, posy));
           

            Font font = new Font("Comic Sans", 24);
            SizeF textSize = g.MeasureString("IAH71", font);

        }

        public void Jump(Keys e)
        {
            if (e == Keys.Space)
            {
                if (posy == startposy)
                {
                    isJumping = true;
                    
                }

            }
        }
        public void StopJump(Keys e)
        {

            if (e == Keys.Space)
            {
                isJumping = false;


            }

        }
        public void GoGround()
        {

            if (posy < startposy && isJumping == false)
            {

                //posy += jumpvelocity;
               
                gravity = 0;




            }

        }
        public void IsOnGround()
        {
            if (isJumping == false && posy > startposy)
            {
                posy = startposy;
                
                //gravity = 0;

            }

        }

        public void StartJump()
        {


            if (isJumping == true)
            {


                if (posy > startposy && gravity > 0)
                {
                    gravity = 0;
                    isJumping = false;
                    posy = startposy;



                }
                else
                {


                    if (jumpvelocity != gravity / 20 || posy == startposy)
                    {
                        posy -= jumpvelocity * 11;
                        posy += gravity;
                        gravity += 2;
                    }
                    else
                    {

                        posy -= jumpvelocity;
                        posy += gravity / 4;


                    }

                }
            }
        }
        
    }
}
