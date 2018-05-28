using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class Dortgen : Sekil
    {
        int genislik;
        int yukseklik;
        public Dortgen()
        {
           
        }
        public int Genislik
        {
            get
            {
                return genislik;
            }

            set
            {
                genislik = value;
            }
        }

        public int Yukseklik
        {
            get
            {
                return yukseklik;
            }

            set
            {
                yukseklik = value;
            }
        }
        public override void Ciz(Graphics g)
        {

            g.FillRectangle(new SolidBrush(DoldurmaRengi), BaslangicX, BaslangicY, Genislik, Yukseklik);

            g.DrawRectangle(new Pen(CizgiRengi), BaslangicX, BaslangicY, Genislik, Yukseklik);

            
        }


        public override bool SecildiMi(int fareX, int fareY)
        {
            if(fareX>=BaslangicX&&fareX<=BaslangicX+Genislik)
            {
                if (fareY >= BaslangicY && fareY <= BaslangicY + Yukseklik)
                {
                    return true;
                }
            }

            return false;
        }

        public override void SecimCiz(Graphics g)
        {
            Brush brush = Brushes.Black;

            Pen p = new Pen(brush, 1.0f);

            p.DashPattern = new float[] { 1.0F, 1.0F, 1.0F, 1.0F };

            g.DrawRectangle(p, BaslangicX - 5, BaslangicY - 5, Genislik + 10, Yukseklik + 10);

            g.FillRectangle(new SolidBrush(SecimRengi), BaslangicX-5, BaslangicY-5, Genislik+10, Yukseklik+10);
        }


        public override void SonAta(int x, int y, int width, int height)
        {
            int dx = Math.Abs(x - BaslangicX);
            int dy = Math.Abs(y - BaslangicY);
            Genislik = dx;
            Yukseklik = dy;
            if (BaslangicX+Genislik>width+9)
            {
                Genislik = width+9 - BaslangicX;
            }
            if(BaslangicY+Yukseklik>height+9)
            {
                Yukseklik = height + 9 - BaslangicY;
            }



        }
        public override string ToString()
        {
            string yazi = "Dortgen," + BaslangicX + "," + BaslangicY + "," + Genislik + ","+Yukseklik+"," + DoldurmaRengi.ToString();

            return yazi;
        }

    }
}
