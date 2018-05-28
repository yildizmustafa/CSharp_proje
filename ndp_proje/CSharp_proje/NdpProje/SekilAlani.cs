using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    class SekilAlani : Dortgen
    {

        Dortgen cizimDorgen;
        Daire cizimDaire;
        Ucgen cizimUcgen;
        Altigen cizimAltigen;
        

        string aktifSekil="";
        public void DeaktifEt()
        {
            aktifSekil = "";
        }
        public Sekil AktifSekil
        {
            get
            {
                Sekil donus=null;
                switch(aktifSekil)
                {
                    case "Dortgen":
                        donus = new Dortgen();
                        break;
                    case "Daire":
                        donus = new Daire();
                        break;
                    case "Altigen":
                        donus = new Altigen();

                        break;
                    case "Ucgen":
                        donus = new Ucgen();
                        break;
                }

                return donus;
            }

        }
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
                cizimDorgen.BaslangicX = BaslangicX + 10;
                cizimDorgen.BaslangicY = BaslangicY + margin;

                cizimDaire.BaslangicX = BaslangicX+125;
                cizimDaire.BaslangicY = BaslangicY + margin+35;

                cizimUcgen.BaslangicX = BaslangicX + 45;
                cizimUcgen.BaslangicY = BaslangicY+125+ margin;

                cizimAltigen.BaslangicX = BaslangicX + 125;
                cizimAltigen.BaslangicY = BaslangicY+115+ margin;
                cizimAltigen.Kenar = 35;
            }
        }



        public SekilAlani()
        {
            cizimDorgen = new Dortgen();


            cizimDorgen.Genislik = 70;
            cizimDorgen.Yukseklik = 70;
            cizimDorgen.DoldurmaRengi = System.Drawing.Color.LightCoral;
            cizimDorgen.CizgiRengi = System.Drawing.Color.Black;

            cizimDaire = new Daire();


            cizimDaire.Cap = 70;
            cizimDaire.DoldurmaRengi = System.Drawing.Color.LightCyan;
            cizimDaire.CizgiRengi = System.Drawing.Color.Black;

            cizimUcgen = new Ucgen();

            cizimUcgen.Yaricap = 35;
            cizimUcgen.DoldurmaRengi = System.Drawing.Color.CornflowerBlue;
            cizimUcgen.CizgiRengi = System.Drawing.Color.Black;


            cizimAltigen = new Altigen();

            cizimAltigen.Kenar = 35;
            cizimAltigen.DoldurmaRengi = System.Drawing.Color.ForestGreen;
            cizimAltigen.CizgiRengi = System.Drawing.Color.Black;
 

        }

        public override bool SecildiMi(int fareX, int fareY)
        {
            
            if(base.SecildiMi(fareX, fareY))
            {
                bool sekilSecildimi = false;
                if(cizimAltigen.SecildiMi(fareX,fareY))
                {
                    aktifSekil = "Altigen";
                    sekilSecildimi = true;
                }
                if (cizimDaire.SecildiMi(fareX, fareY))
                {
                    aktifSekil = "Daire";
                    sekilSecildimi = true;
                }
                if (cizimUcgen.SecildiMi(fareX, fareY))
                {
                    aktifSekil = "Ucgen";
                    sekilSecildimi = true;
                }
                if (cizimDorgen.SecildiMi(fareX, fareY))
                {
                    aktifSekil = "Dortgen";
                    sekilSecildimi = true;
                }
               
                return sekilSecildimi;
            }
           
            return false;
        }



        public override void Ciz(Graphics g)
        {
            base.Ciz(g);

            cizimDorgen.Ciz(g);
            cizimDaire.Ciz(g);
            cizimUcgen.Ciz(g);
            cizimAltigen.Ciz(g);



            g.DrawString("Çizim Şekli", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, 830, 10);


            switch (aktifSekil)
            {
                case "Dortgen":
                    cizimDorgen.SecimCiz(g);
                    break;
                case "Daire":
                    cizimDaire.SecimCiz(g);
                    break;
                case "Altigen":
                    cizimAltigen.SecimCiz(g);

                    break;
                case "Ucgen":
                    cizimUcgen.SecimCiz(g);
                    break;
            }
        }
    }
}
