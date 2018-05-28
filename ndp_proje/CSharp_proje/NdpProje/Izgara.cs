using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class Izgara : Sekil
    {
        int _genislik;
        int _yukseklik;
        int _aralik;

        public int Genislik
        {
            get
            {
                return _genislik;
            }

            set
            {
                _genislik = value;
            }
        }
        public int Yukseklik
        {
            get
            {
                return _yukseklik;
            }

            set
            {
                _yukseklik = value;
            }
        }

        public int Aralik
        {
            get
            {
                return _aralik;
            }

            set
            {
                _aralik = value;
            }
        }



        public Izgara(int genislik,int yukseklik)
        {
            Genislik = genislik;
            Yukseklik = yukseklik;
            Aralik = 10;
            BaslangicX = 10;
            BaslangicY = 10;
        }
        public override void Ciz(Graphics g)
        {
            Brush brush = Brushes.LightGray;
          
            Pen p = new Pen(brush, 1.0f);
            p.DashPattern = new float[] { 1.0F, 1.0F, 1.0F,1.0F };

            g.DrawRectangle(Pens.Black, BaslangicX, BaslangicY, Genislik, Yukseklik);

            for (int i=BaslangicX;i<=Genislik;i+=Aralik)
            {
                g.DrawLine(p, i, BaslangicY, i, BaslangicY + Yukseklik);
            }
            for (int i = BaslangicY; i <= Yukseklik; i += Aralik)
            {
                g.DrawLine(p, BaslangicX, i, BaslangicX+Genislik, i);
            }
            g.DrawRectangle(Pens.Black, BaslangicX, BaslangicY, Genislik, Yukseklik);

        }

        public override void SonAta(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        
        public override bool SecildiMi(int fareX, int fareY)
        {
            throw new NotImplementedException();
        }

        public override void SecimCiz(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
