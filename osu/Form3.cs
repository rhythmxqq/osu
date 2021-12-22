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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\zxc1488\source\repos\osu\osu\Resources\chel.wav");
            player.Play();
            Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }
    }
}
