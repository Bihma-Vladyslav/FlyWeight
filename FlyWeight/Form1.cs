using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyWeight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }
        Graphics g;
        SnowFlake[] s = new SnowFlake[100];
        Param[] p = new Param[2];
        ParamOneYearSnowFlake p1 = new ParamOneYearSnowFlake();
        ParamTwoYearSnowFlake p2 = new ParamTwoYearSnowFlake();
        int count = 0;
        Random r = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (r.Next(0, 10) % 2 == 0)
                s[count] = new SnowFlake(r.Next(10, 1400), r.Next(10, 1400), p1);
            else
                s[count] = new SnowFlake(r.Next(10, 1400), r.Next(10, 1400), p2);

            g.DrawImage(s[count].p.pic, new Rectangle(s[count].x, s[count].y, s[count].p.h, 20));
            if (count < 99)
                count++;
            else
                timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach(SnowFlake sf in s)
            {
                g.FillRectangle(Brushes.White, sf.x, sf.y, sf.p.h, 20);
                sf.fall();
                g.DrawImage(sf.p.pic, new Rectangle(sf.x, sf.y, sf.p.h, 20));
            }
        }
    }
}
