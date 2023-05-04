using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        public void Move(Ball ball)
        {
           
            centroid.X += speedX;
            centroid.Y += speedY;
            float distance = CalculateDistance(centroid.X,centroid.Y,ball.centroid.X,ball.centroid.Y);
            float minDistance = diameter / 2 + ball.diameter / 2;
            if (distance < minDistance)
            {

                float overlap = minDistance - distance;
                float ratio = overlap / distance;
                float dx = (ball.centroid.X - centroid.X) * ratio;
                float dy = (ball.centroid.Y - centroid.Y) * ratio;
                centroid.X -= dx / 2;
                centroid.Y -= dy / 2;
                ball.centroid.X += dx / 2;
                ball.centroid.Y += dy / 2;

                // Calculate the new velocities and directions of the balls after the collision
                float angle = (float)Math.Atan2(ball.centroid.Y - centroid.Y, ball.centroid.X - centroid.X);
                float sin = (float)Math.Sin(angle);
                float cos = (float)Math.Cos(angle);

                float vx1 = speedX * cos + speedY * sin;
                float vy1 = speedY * cos - speedX * sin;
                float vx2 = ball.speedX * cos + ball.speedY * sin;
                float vy2 = ball.speedY * cos - ball.speedX * sin;

                float temp = vx1;
                vx1 = vx2;
                vx2 = temp;

                speedX = vx1 * cos - vy1 * sin;
                speedY = vy1 * cos + vx1 * sin;
                ball.speedX = vx2 * cos - vy2 * sin;
                ball.speedY = vy2 * cos + vx2 * sin;
            }

        

            if (centroid.X < 0 || centroid.X + diameter  > Form1.bmp.Width)
            {
                speedX = -speedX;
            }

            
            if (centroid.Y < 0 || centroid.Y + diameter  > Form1.bmp.Height)
            {
                speedY = -speedY;
            }
            



        }
        
        public float CalculateDistance(float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private int randomSpeed()
        {
            Random rnd = new Random();
            int speed = rnd.Next(1, 10);
            if (rnd.Next(0, 2) == 0)
                return speed;
            else return -speed ;
            

        }


    }
}