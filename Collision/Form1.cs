using static System.Net.Mime.MediaTypeNames;

namespace Collision
{
    public partial class Form1 : Form
    {
        public static Bitmap bmp;
        public static Graphics graphics;
        public int number;
        public static List<Ball> balls;
        public Form1()
        {
            
            InitializeComponent();
            bmp = new Bitmap(PICTURE_BOX.Width, PICTURE_BOX.Height);
            graphics = Graphics.FromImage(bmp);
            PICTURE_BOX.Image = bmp;
            balls= new List<Ball>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            
            balls.Add(new Ball());
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            graphics.Clear(SystemColors.ActiveCaption);
            for(int i=0; i<balls.Count();i++)
            {
                Ball b = balls[i];
                for(int j=i+1; j<balls.Count();j++)
                {
                    Ball c = balls[j];    
                    b.Move(c);
                    b.Draw();
                }

            }
            PICTURE_BOX.Invalidate();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}