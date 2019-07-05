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
        private Bitmap animatedImage;

        private int posx, posy, gravity, jumpvelocity, startposy;
        private Rectangle hitbox;

        private bool isJumping, dead;

        #region Properties
        public bool Dead
        {
            get { return dead; }
            set {dead = value; }
        }
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
        /// <summary>
        /// Initialisieren
        /// </summary>
        /// <param name="posx1">Ein Teil der Clientbreite mit der weiter berechnet wird</param>
        /// <param name="posy1">Ein Teil der Clienthöhe mit der weiter berechnet wird</param>
        /// <param name="gravity1">Gravitationskraft</param>
        /// <param name="jumpvelocity1">Sprungkraft</param>
        public Player(int posx1, int posy1, int gravity1, int jumpvelocity1)
        {
            animatedImage = new Bitmap(@"running.gif");

            startposy = posy1 - animatedImage.Height;
            PosX = posx1;
            PosY = posy1;
            Gravity = 1;
            JumpVelocity = jumpvelocity1;
 
            isJumping = false;

        }
        /// <summary>
        /// Malt den Spieler auf die Form
        /// </summary>
        /// <param name="e">Ist ein PaintEventArg</param>
        public void DrawPlayer(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            hitbox = new Rectangle(new Point(posx + animatedImage.Width/4,posy), new Size(animatedImage.Width/2, animatedImage.Height));         
            g.DrawImage(this.animatedImage, new Point(posx, posy));  
        }
        /// <summary>
        /// Wenn Space gedrückt wird ist das Springen erlaubt
        /// </summary>
        /// <param name="e">Ist eine Taste</param>
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
        /// <summary>
        /// Wenn der Spieler unterhalb der Starthöhe ist wird seine Höhe wieder auf diese gesetzt
        /// </summary>
        public void IsOnGround()
        {
            if (isJumping == false && posy > startposy)
            {
                posy = startposy;          
            }
        }
        /// <summary>
        /// Ermöglicht das Springen
        /// Gravity wird erhöht und läuft gegen Jumpvelocity bis es dafür sorgt, dass der Spieler wieder nach unten Befördert wird
        /// </summary>
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
