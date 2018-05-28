using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class SecimPaneli:Dortgen
    {
        public delegate void SecimFonksiyonu();

        SecimFonksiyonu secimTiklandi;
        SecimFonksiyonu silTiklandi;

        Image sekilSec;
        Image sekilSil;
        Dortgen dortgenSekilSec;
        Dortgen dortgenSekilSil;

        string aktifSecenek = "";

        internal SecimFonksiyonu SecimTiklandi
        {
            get
            {
                return secimTiklandi;
            }

            set
            {
                secimTiklandi = value;
            }
        }

        internal SecimFonksiyonu SilTiklandi
        {
            get
            {
                return silTiklandi;
            }

            set
            {
                silTiklandi = value;
            }
        }

        public void DeaktifEt()
        {
            aktifSecenek = "";
        }
        
        public SecimPaneli()
        {
            sekilSec = Image.FromFile("arrow.png");
            sekilSil = Image.FromFile("sil.png");

            dortgenSekilSec = new Dortgen();
            dortgenSekilSec.Genislik = 70;
            dortgenSekilSec.Yukseklik = 70;
            dortgenSekilSec.DoldurmaRengi = Color.FromArgb(100, 155, 0, 155);
            dortgenSekilSec.CizgiRengi = Color.Black;


            dortgenSekilSil = new Dortgen();
            dortgenSekilSil.Genislik = 70;
            dortgenSekilSil.Yukseklik = 70;
            dortgenSekilSil.DoldurmaRengi = Color.FromArgb(100, 155, 0, 155);
            dortgenSekilSil.CizgiRengi = Color.Black;
        }
        public override bool SecildiMi(int fareX, int fareY)
        {
            if(base.SecildiMi(fareX, fareY))
            {
                if(dortgenSekilSec.SecildiMi(fareX,fareY))
                {
                    aktifSecenek = "sec";
                    return true;
                }
                if (dortgenSekilSil.SecildiMi(fareX, fareY))
                {
                    aktifSecenek = "sil";
                    if (SilTiklandi != null)
                        SilTiklandi();
                    return true;
                }
            }
            return false;
        }

        public override void Ciz(Graphics g)
        {
            base.Ciz(g);

            dortgenSekilSec.BaslangicX = BaslangicX + 10;
            dortgenSekilSec.BaslangicY = BaslangicY + 30;

            dortgenSekilSil.BaslangicX = BaslangicX + 90;
            dortgenSekilSil.BaslangicY = BaslangicY + 30;

            g.DrawString("Şekil İşlemleri", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, BaslangicX+10, BaslangicY);
            g.DrawImage(sekilSec, BaslangicX+10,BaslangicY+30,70,70);
            
            g.DrawImage(sekilSil, BaslangicX + 90, BaslangicY + 30, 70, 70);


            if(aktifSecenek=="sec")
                dortgenSekilSec.Ciz(g);
            if(aktifSecenek=="sil")
                dortgenSekilSil.Ciz(g);

        }

    }
}
