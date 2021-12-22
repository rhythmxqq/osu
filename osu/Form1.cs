using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Media;
using System.IO;


namespace osu
{
    public partial class Form1 : Form
    {
        public Bitmap HandlerT = Resource1.cursor,
                      TargetT = Resource1.target;
        protected Point _targetpos = new Point(300, 300); 
        private Point _direction = Point.Empty;
        private int score = 0;
       


        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            int i = 90;
            timeme.Text = i.ToString();
            timer3.Interval = 1000;
            timer3.Enabled = true;
            timer3.Start();
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();  
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e) 
        {
            Random rand = new Random();
          
                timer2.Interval = rand.Next(25, 1000);
                _direction.X = rand.Next(-1, 2);
                _direction.Y = rand.Next(-1, 2);
           

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var localPosition = this.PointToClient(Cursor.Position);

            _targetpos.X += _direction.X * 15;
            _targetpos.Y += _direction.Y * 15 ;
            if(_targetpos.X < 10 ||   _targetpos.X > 800 )
            {
               _direction.X *= -1;

            }
            if (_targetpos.Y < 30 || _targetpos.Y > 490)
            {
                _direction.Y *= -1;

            }
            Point between = new Point(localPosition.X - _targetpos.X, localPosition.Y - _targetpos.Y);
            float distance = (float)Math.Sqrt((between.X * between.X) + (between.Y * between.Y));
            if (distance < 20)
            {
                score++;
                score1.Text = score.ToString();

            }
            var Hendlerbect = new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100, 100);
            var Targetbect = new Rectangle(_targetpos.X - 50, _targetpos.Y - 50, 100, 100);

            g.DrawImage(HandlerT, Hendlerbect);
            g.DrawImage(TargetT, Targetbect);
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\zxc1488\source\repos\osu\osu\Resources\chel.wav");
            player.Play();
            Hide();
            Form3 f = new Form3();
            f.ShowDialog();
            this.Close();

        }


        int i = 90;

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
            timeme.Text = (--i).ToString();
           
           
            if (i == 0)
            {
                timer1.Stop();
                MessageBox.Show("время закончилось, ваш счет :" + score);
                this.Close();
            }
     
        }
        



    }
}
