using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class Ucgen : Sekil
    {
        int yaricap;
        Point[] points = new Point[3];
        public Ucgen()
        {

        }
        public int Yaricap
        {
            get
            {
                return yaricap;
            }

            set
            {
                yaricap = value;
            }
        }

        public override void Ciz(Graphics g)
        {

            points[0].X = BaslangicX;
            points[0].Y = BaslangicY -  Yaricap;

            points[1].X =BaslangicX-(int)(( Math.Sqrt(3) * Yaricap) /2.0);
            points[1].Y = BaslangicY+Yaricap/2;

            points[2].X = BaslangicX + (int)((Math.Sqrt(3) * Yaricap) / 2.0);
            points[2].Y = BaslangicY + Yaricap/2;

            g.DrawPolygon(new Pen(CizgiRengi), points);

            g.FillPolygon(new SolidBrush(DoldurmaRengi), points);

        }

        
        public override void SonAta(int x, int y, int width, int height)
        {


            int dx = Math.Abs(x - BaslangicX);
            int dy = Math.Abs(y - BaslangicY);

            if (dx > dy)
                Yaricap = dx;
            else
                Yaricap = dy;

            if (BaslangicX+Yaricap > width + 9)
            {
                Yaricap = (int)((width + 9 - BaslangicX)*2/Math.Sqrt(3)) ;
                Console.WriteLine(Yaricap);
               
            }
            if (BaslangicX-Yaricap <=10)
            {
                Yaricap = (int)((BaslangicX-11) * 2/Math.Sqrt(3));
                
              
            }
            if (BaslangicY+Yaricap > height + 9)
            {
                Yaricap = (height + 9 - BaslangicY) * 2;
            }

            if (BaslangicY-Yaricap <= 10)
            {
                Yaricap = BaslangicY - 11;
            }
            
        }

        float sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y- p3.Y) - (p2.X- p3.X) * (p1.Y - p3.Y);
        }
        public override bool SecildiMi(int fareX, int fareY)
        {

            bool b1, b2, b3;

            b1 = sign(new Point(fareX,fareY), points[0], points[1]) < 0.0f;
            b2 = sign(new Point(fareX, fareY), points[1], points[2]) < 0.0f;
            b3 = sign(new Point(fareX, fareY), points[2], points[0]) < 0.0f;

            return ((b1 == b2) && (b2 == b3));



        }

        public override void SecimCiz(Graphics g)
        {
            Brush brush = Brushes.Black;

            Pen p = new Pen(brush, 1.0f);

            p.DashPattern = new float[] { 1.0F, 1.0F, 1.0F, 1.0F };

            g.DrawRectangle(p, BaslangicX - 5 - yaricap, BaslangicY - 5 - yaricap, yaricap * 2 + 10, yaricap * 2 + 10);
            g.FillRectangle(new SolidBrush(SecimRengi), BaslangicX - 5 - yaricap, BaslangicY - 5 - yaricap, yaricap*2 + 10, yaricap*2 + 10);
        }

        public override string ToString()
        {
            string yazi = "Ucgen," + BaslangicX + "," + BaslangicY + "," + Yaricap + "," + DoldurmaRengi.ToString();

            return yazi;
        }
    }
}
