using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class RenkPaneli:Dortgen
    {


        Dictionary<string, Dortgen> renkler;

        Dortgen seciliRenk;

        Dortgen aktifSekil = null;

        public override int BaslangicX
        {
            get
            {
                return base.BaslangicX;
            }

            set
            {
                base.BaslangicX = value;
                int margin = 40;

                renkler["kirmizi"].BaslangicX = BaslangicX + 20;
                renkler["kirmizi"].BaslangicY = BaslangicY + margin;
                renkler["kirmizi"].Genislik = 30;
                renkler["kirmizi"].Yukseklik = 30;


                renkler["mavi"].BaslangicX = BaslangicX + 70;
                renkler["mavi"].BaslangicY = BaslangicY + margin;
                renkler["mavi"].Genislik = 30;
                renkler["mavi"].Yukseklik = 30;

                renkler["yesil"].BaslangicX = BaslangicX + 120;
                renkler["yesil"].BaslangicY = BaslangicY + margin;
                renkler["yesil"].Genislik = 30;
                renkler["yesil"].Yukseklik = 30;

                renkler["turuncu"].BaslangicX = BaslangicX + 20;
                renkler["turuncu"].BaslangicY = BaslangicY + margin + 50;
                renkler["turuncu"].Genislik = 30;
                renkler["turuncu"].Yukseklik = 30;

                renkler["siyah"].BaslangicX = BaslangicX + 70;
                renkler["siyah"].BaslangicY = BaslangicY + margin + 50;
                renkler["siyah"].Genislik = 30;
                renkler["siyah"].Yukseklik = 30;

                renkler["sari"].BaslangicX = BaslangicX + 120;
                renkler["sari"].BaslangicY = BaslangicY + margin + 50;
                renkler["sari"].Genislik = 30;
                renkler["sari"].Yukseklik = 30;

                renkler["mor"].BaslangicX = BaslangicX + 20;
                renkler["mor"].BaslangicY = BaslangicY + margin + 100;
                renkler["mor"].Genislik = 30;
                renkler["mor"].Yukseklik = 30;

                renkler["kahverengi"].BaslangicX = BaslangicX + 70;
                renkler["kahverengi"].BaslangicY = BaslangicY + margin + 100;
                renkler["kahverengi"].Genislik = 30;
                renkler["kahverengi"].Yukseklik = 30;

                renkler["beyaz"].BaslangicX = BaslangicX + 120;
                renkler["beyaz"].BaslangicY = BaslangicY + margin + 100;
                renkler["beyaz"].Genislik = 30;
                renkler["beyaz"].Yukseklik = 30;


            }
        }
        public override int BaslangicY
        {
            get
            {
                return base.BaslangicY;
            }

            set
            {
                base.BaslangicY = value;
                int margin = 40;

                renkler["kirmizi"].BaslangicX = BaslangicX + 20;
                renkler["kirmizi"].BaslangicY = BaslangicY + margin;
                renkler["kirmizi"].Genislik = 30;
                renkler["kirmizi"].Yukseklik = 30;


                renkler["mavi"].BaslangicX = BaslangicX + 70;
                renkler["mavi"].BaslangicY = BaslangicY + margin;
                renkler["mavi"].Genislik = 30;
                renkler["mavi"].Yukseklik = 30;
            
                renkler["yesil"].BaslangicX = BaslangicX + 120;
                renkler["yesil"].BaslangicY = BaslangicY + margin;
                renkler["yesil"].Genislik = 30;
                renkler["yesil"].Yukseklik = 30;

                renkler["turuncu"].BaslangicX = BaslangicX + 20;
                renkler["turuncu"].BaslangicY = BaslangicY + margin+50;
                renkler["turuncu"].Genislik = 30;
                renkler["turuncu"].Yukseklik = 30;

                renkler["siyah"].BaslangicX = BaslangicX + 70;
                renkler["siyah"].BaslangicY = BaslangicY + margin+50;
                renkler["siyah"].Genislik = 30;
                renkler["siyah"].Yukseklik = 30;

                renkler["sari"].BaslangicX = BaslangicX + 120;
                renkler["sari"].BaslangicY = BaslangicY + margin+50;
                renkler["sari"].Genislik = 30;
                renkler["sari"].Yukseklik = 30;

                renkler["mor"].BaslangicX = BaslangicX + 20;
                renkler["mor"].BaslangicY = BaslangicY + margin + 100;
                renkler["mor"].Genislik = 30;
                renkler["mor"].Yukseklik = 30;

                renkler["kahverengi"].BaslangicX = BaslangicX + 70;
                renkler["kahverengi"].BaslangicY = BaslangicY + margin + 100;
                renkler["kahverengi"].Genislik = 30;
                renkler["kahverengi"].Yukseklik = 30;
  
                renkler["beyaz"].BaslangicX = BaslangicX + 120;
                renkler["beyaz"].BaslangicY = BaslangicY + margin + 100;
                renkler["beyaz"].Genislik = 30;
                renkler["beyaz"].Yukseklik = 30;
            }
        }

        public Dortgen AktifSekil
        {
            get
            {
                return aktifSekil;
            }

            set
            {
                aktifSekil = value;
            }
        }

        public RenkPaneli()
        {
            renkler = new Dictionary<string, Dortgen>();

            renkler["kirmizi"] = new Dortgen();
            renkler["kirmizi"].DoldurmaRengi = Color.Red;
            renkler["kirmizi"].CizgiRengi = Color.Black;

            seciliRenk = new Dortgen();
            seciliRenk.Genislik = 35;
            seciliRenk.Yukseklik = 35;




            renkler["yesil"] = new Dortgen();
            renkler["yesil"].CizgiRengi = Color.Black;
            renkler["yesil"].DoldurmaRengi = Color.Green;


            renkler["mavi"] = new Dortgen();
            renkler["mavi"].DoldurmaRengi = Color.Blue;
            renkler["mavi"].CizgiRengi = Color.Black;

            renkler["turuncu"] = new Dortgen();
            renkler["turuncu"].DoldurmaRengi = Color.Orange;
            renkler["turuncu"].CizgiRengi = Color.Black;

            renkler["siyah"] = new Dortgen();
            renkler["siyah"].CizgiRengi = Color.Black;
            renkler["siyah"].DoldurmaRengi = Color.Black;


            renkler["sari"] = new Dortgen();
            renkler["sari"].DoldurmaRengi = Color.Yellow;
            renkler["sari"].CizgiRengi = Color.Black;


            renkler["mor"] = new Dortgen();
            renkler["mor"].DoldurmaRengi = Color.Purple;
            renkler["mor"].CizgiRengi = Color.Black;

            renkler["kahverengi"] = new Dortgen();
            renkler["kahverengi"].CizgiRengi = Color.Black;
            renkler["kahverengi"].DoldurmaRengi = Color.Brown;


            renkler["beyaz"] = new Dortgen();
            renkler["beyaz"].DoldurmaRengi = Color.White;
            renkler["beyaz"].CizgiRengi = Color.Black;
            AktifSekil = renkler["kirmizi"];

        }
        public override void Ciz(Graphics g)
        {
            Brush brush = new SolidBrush(Color.FromArgb(100, 155, 0, 155));
            base.Ciz(g);

            foreach (var siradaki in renkler)
            {
                siradaki.Value.Ciz(g);
            }

            g.DrawString("Renk Seçimi", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, BaslangicX+10, BaslangicY);


            if (AktifSekil != null)
            {
                AktifSekil.SecimCiz(g);
            }
        }
        public override bool SecildiMi(int fareX, int fareY)
        {
            if(base.SecildiMi(fareX, fareY))
            {
                foreach(var siradaki in renkler)
                {
                    if(siradaki.Value.SecildiMi(fareX,fareY))
                    {
                        AktifSekil = siradaki.Value;
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
