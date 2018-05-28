using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class Daire : Sekil
    {
        int cap;

        public int Cap
        {
            get
            {
                return cap;
            }

            set
            {
                cap = value;
            }
        }


        public override void Ciz(Graphics g)
        {
            g.FillEllipse(new SolidBrush(DoldurmaRengi), BaslangicX - Cap / 2, BaslangicY - Cap / 2, Cap,Cap);
            g.DrawEllipse(new Pen(CizgiRengi), BaslangicX -Cap/2, BaslangicY - Cap / 2, Cap, Cap);
        }


        public override bool SecildiMi(int fareX, int fareY)
        {
            int dy = fareY - BaslangicY;
            int dx = fareX - BaslangicX;


            double length = Math.Sqrt(dx * dx + dy * dy);

            if(length<cap/2)
            {
                return true;
            }
            return false;
        }

        public override void SecimCiz(Graphics g)
        {
            Brush brush = Brushes.Black;

            Pen p = new Pen(brush, 1.0f);

            p.DashPattern = new float[] { 1.0F, 1.0F, 1.0F, 1.0F };

            g.DrawRectangle(p, BaslangicX - 5 - Cap / 2, BaslangicY - 5 - Cap / 2, Cap + 10, Cap + 10);

            g.FillRectangle(new SolidBrush(SecimRengi), BaslangicX - 5- Cap/2, BaslangicY - 5- Cap/2, Cap + 10, Cap + 10);
        }

        
        public override void SonAta(int x, int y, int width, int height)
        {
            int dx = Math.Abs(x - BaslangicX);
            int dy = Math.Abs(y - BaslangicY);

            if (dx > dy)
                Cap = dx*2;
            else
                Cap = dy*2;

            if (BaslangicX + Cap/2 > width + 9)
            {
                Cap = (width + 9 - BaslangicX)*2;
            }
            if (BaslangicY + Cap/2 > height + 9)
            {
                Cap = (height + 9 - BaslangicY)*2;
            }


            if (BaslangicX - Cap / 2 <= 10)
            {
                Cap = (BaslangicX - 11) * 2;
            }
            if (BaslangicY - Cap / 2 <=10)
            {
                Cap = (BaslangicY-11) * 2;
            }

        }
        public override string ToString()
        {
            string yazi = "Daire," + BaslangicX + "," + BaslangicY + "," + Cap + "," + DoldurmaRengi.ToString();

            return yazi;

        }

    }
}
