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
        int posx;
        int posy;
        int sizex;
        int sizey;
        int gravity;
        int jumpvelocity;
        int startposy;

        private bool testBool;
        bool isJumping;
        bool jumpAllowed;
       

        int[] gravityScale;

        #region Props

       

        public bool TestBool
        {
            get { return testBool; }
            set { testBool = value; }
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
        public Player(int posx1, int posy1, int sizex1, int sizey1, int gravity1, int jumpvelocity1)
        {
           
            startposy = posy1;
            PosX = posx1;
            PosY = posy1;
            SizeX = sizex1;
            SizeY = sizey1;
            Gravity = gravity1;
            JumpVelocity = jumpvelocity1;
            

            isJumping = false;
            jumpAllowed = true;
            
        }
            
       public void DrawPlayer( PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Pen BlackPen = new Pen(Color.Black, 2);
            Rectangle Player = new Rectangle(new Point(posx, posy), new Size(sizex, sizey));
            g.DrawRectangle(BlackPen, Player);


            Font font = new Font("Comic Sans", 24);
            SizeF textSize = g.MeasureString("IAH71", font);
            g.DrawString(Convert.ToString(startposy), font, Brushes.Black, 5,5);
            g.DrawString(Convert.ToString(posy), font, Brushes.Black, 100, 5);
            g.DrawString(Convert.ToString(gravity), font, Brushes.Black, 200, 5);
        }

        public void Jump(Keys e)
        {
            if(e == Keys.W)
            {
                if (posy == startposy)
                {
                    jumpAllowed = true;
                }
                if (jumpAllowed)
                {
                    isJumping = true;
                }
            }
        }
        public void StopJump(Keys e)
        {
            
            if (e == Keys.W)
            {
                isJumping = false;

                
            }

        }
        public void GoGround()
        {
            if(posy > startposy)
            {
                
            }
            if (posy < startposy && isJumping == false)
            {

                posy += jumpvelocity;
                jumpAllowed = false;
                gravity = 0;



            }
          
            
           
            
           
         

        }
        public void IsOnGround()
        {
            if (isJumping == false && posy > startposy)
            {
                posy = startposy;
                gravity = 0;
                jumpAllowed = false;
            }
           
        }

        public void StartJump()
        {
            

            if (isJumping == true && jumpAllowed == true )
            {


                if (posy >= startposy && gravity > 0)
                {
                    gravity = 0;
                    isJumping = false;
                   // posy = startposy ;
                   


                }
                else 
                {


                       
                        posy -= jumpvelocity;
                        posy += gravity;
                        gravity++;
                    
                }
                  
               
            }
        }

      
    }
}
