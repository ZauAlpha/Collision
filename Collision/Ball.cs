using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collision
{
   
    public class Ball
    {
        public int diameter;
        public float speedX;
        public float speedY;
        public PointF centroid;
        public Color color;

        public Ball() {
            
            Random rnd = new Random();
            diameter = rnd.Next(35, 150);
            centroid = new PointF(rnd.Next(diameter,Form1.bmp.Width-diameter), rnd.Next(diameter, Form1.bmp.Height-diameter));
            this.speedX = randomSpeed();
            this.speedY = randomSpeed();
            
            
            color = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));

            
        }
       
        public void Draw()
        {
            Form1.graphics.FillEllipse(new SolidBrush(color), centroid.X, centroid.Y, diameter, diameter);
        }
        public void Move()
        {
           
            centroid.X += speedX;
            centroid.Y += speedY;
            if (centroid.X < 0 || centroid.X + diameter  > Form1.bmp.Width)
            {
                speedX = -speedX;
            }

            
            if (centroid.Y < 0 || centroid.Y + diameter  > Form1.bmp.Height)
            {
                speedY = -speedY;
            }
            



        }
        private int randomSpeed()
        {
            Random rnd = new Random();
            int speed = rnd.Next(1, 20);
            if (rnd.Next(0, 2) == 0)
                return speed;
            else return -speed ;
            

        }


    }
}