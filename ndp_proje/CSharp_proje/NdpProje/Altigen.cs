using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class Altigen : Sekil
    {
        int kenar;
        Point[] points = new Point[6];
        public int Kenar
        {
            get
            {
                return kenar;
            }

            set
            {

                kenar = value;

                points[0].X = BaslangicX - Kenar;
                points[0].Y = BaslangicY;


                points[1].X = BaslangicX - Kenar / 2;
                points[1].Y = BaslangicY - (int)(Math.Sqrt(3) * Kenar / 2.0);

                points[2].X = BaslangicX + Kenar / 2;
                points[2].Y = BaslangicY - (int)(Math.Sqrt(3) * Kenar / 2.0);

                points[3].X = BaslangicX + Kenar;
                points[3].Y = BaslangicY;

                points[4].X = BaslangicX + Kenar / 2;
                points[4].Y = BaslangicY + (int)(Math.Sqrt(3) * Kenar / 2.0);

                points[5].X = BaslangicX - Kenar / 2;
                points[5].Y = BaslangicY + (int)(Math.Sqrt(3) * Kenar / 2.0);
            }
        }

        public override void Ciz(Graphics g)
        {



            g.DrawPolygon(new Pen(CizgiRengi), points);

            g.FillPolygon(new SolidBrush(DoldurmaRengi), points);
        }

        float sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
        public override bool SecildiMi(int fareX, int fareY)
        {
            return IsPointInPolygon(new Point(fareX, fareY), points);
        }

        public override void SonAta(int x, int y, int width, int height)
        {
            double cos60 = Math.Sqrt(3) / 2.0;

            if (x >= width)
                x = width;
            if (y >= height)
                y = height;

            if (x <= 10)
                x = 10;
            if (y <= 10)
                y = 10;

            int dx = Math.Abs(x - BaslangicX);
            int dy = Math.Abs(y - BaslangicY);




            if (dx > dy)
                Kenar = dx;
            else
                Kenar = dy;

            if (BaslangicX + Kenar > width+10)
            {
                Kenar = width+10 - BaslangicX;
            }

            if (BaslangicX - Kenar < 10)
            {
                Kenar = BaslangicX - 10;
            }

            if (BaslangicY + Kenar * cos60 > height + 10)
            {
                Kenar = (int)(2*(height + 10 - BaslangicY)/Math.Sqrt(3));
            }

            if (BaslangicY - Kenar * cos60 < 10)
            {
                Kenar = (int)(2 * (BaslangicY - 10) / Math.Sqrt(3));
            }


            points[0].X = BaslangicX - Kenar;
            points[0].Y = BaslangicY;


            points[1].X = BaslangicX - Kenar / 2;
            points[1].Y = BaslangicY - (int)(Math.Sqrt(3) * Kenar / 2.0);

            points[2].X = BaslangicX + Kenar / 2;
            points[2].Y = BaslangicY - (int)(Math.Sqrt(3) * Kenar / 2.0);

            points[3].X = BaslangicX + Kenar;
            points[3].Y = BaslangicY;

            points[4].X = BaslangicX + Kenar / 2;
            points[4].Y = BaslangicY + (int)(Math.Sqrt(3) * Kenar / 2.0);

            points[5].X = BaslangicX - Kenar / 2;
            points[5].Y = BaslangicY + (int)(Math.Sqrt(3) * Kenar / 2.0);
        }
        public bool IsPointInPolygon(Point point, Point[] polygon)
        {
            int polygonLength = polygon.Length, i = 0;
            bool inside = false;
            // x, y for tested point.
            float pointX = point.X, pointY = point.Y;
            // start / end point for the current polygon segment.
            float startX, startY, endX, endY;
            Point endPoint = polygon[polygonLength - 1];
            endX = endPoint.X;
            endY = endPoint.Y;
            while (i < polygonLength)
            {
                startX = endX; startY = endY;
                endPoint = polygon[i++];
                endX = endPoint.X; endY = endPoint.Y;
                //
                inside ^= (endY > pointY ^ startY > pointY) /* ? pointY inside [startY;endY] segment ? */
                          && /* if so, test if it is under the segment */
                          ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY));
            }
            return inside;
        }


        public override void SecimCiz(Graphics g)
        {
            Brush brush = Brushes.Black;

            Pen p = new Pen(brush, 1.0f);

            p.DashPattern = new float[] { 1.0F, 1.0F, 1.0F, 1.0F };

            g.DrawRectangle(p, BaslangicX - 5 - kenar, BaslangicY - 5 - kenar, kenar * 2 + 10, kenar * 2 + 10);

            g.FillRectangle(new SolidBrush(SecimRengi), BaslangicX - 5 - kenar, BaslangicY - 5 - kenar, kenar * 2 + 10, kenar * 2 + 10);
        }
        public override string ToString()
        {
            string yazi = "Altigen," + BaslangicX + "," + BaslangicY + "," + kenar + "," + DoldurmaRengi.ToString();

            return yazi;
        }
    }
}
