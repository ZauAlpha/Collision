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
            foreach (Ball b in balls)
            {
                b.Move();
                b.Draw();

            }
            PICTURE_BOX.Invalidate();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}