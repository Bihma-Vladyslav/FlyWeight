using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;


namespace FlyWeight
{
   public class Param
    {
        public int h;
        public Bitmap pic;
    }
    public class ParamOneYearSnowFlake : Param
    {
        public ParamOneYearSnowFlake()
        {
            h = 50;
            pic = new Bitmap(@"D:\Завантаження диск D\11.jpg");
        }
    }
    public class ParamTwoYearSnowFlake : Param
    {
        public ParamTwoYearSnowFlake()
        {
            h = 100;
            pic = new Bitmap(@"D:\Завантаження диск D\12.jpg");
        }
    }
    public class SnowFlake
    {
        public int x, y;
        public int x0, wind;
        public Random r;
        public Param p;
        //------------
        SnowFlake(int x0, int wind, Param p, Random r)
        {
            this.x0 = x0;
            this.wind = wind;
            this.p = p;
            this.r = r;
            this.y = r.Next(0, 1000);
        }
        public void fall()
        {
            if (y > 1000)
            {
                y = r.Next(0, 50);
                x0 += r.Next(-15, 15);
                y += 25;
                x = x0 + wind * (int)Math.Sin(y);
            }
        }
        public SnowFlake()
        {
            // h = 10;
            x = 0; y = 0;

        }
        /* public SnowFlake(int x, int y, int ah, Bitmap apic)
         {
             h = ah;
             pic = apic;
             this.x = x;
             this.y = y;
         }*/
        public SnowFlake(int x, int y, Param p)
        {
            this.p = p;
            this.x = x;
            this.y = y;
        }
    }
}
