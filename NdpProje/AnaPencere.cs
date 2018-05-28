using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace NdpProje
{
    class AnaPencere:Form
    {
       


        RenkPaneli renkPaneli;
        SecimPaneli secimPaneli;
        SekilAlani sekilPaneli;
        DosyaPaneli dosyaPaneli;
        Izgara izgara = new Izgara(800, 700);
        Sekil aktifCizimSekli;
        List<Sekil> sekiller = new List<Sekil>();

        bool cizimAktifMi = false;
        bool cizimBasladiMi = false;
        bool secimAktifMi = false;
        Color aktifRenk= Color.Red;
        public AnaPencere(int width,int height)
        {

            Text = "Nesneye Dayalı Programlama Proje Ödevi(2017-2018)";
            SetClientSizeCore(width, height);
            Paint += AnaPencere_Paint;

            MouseClick += AnaPencere_MouseClick;
            MouseDown += AnaPencere_MouseDown;
            MouseUp += AnaPencere_MouseUp;
            MouseMove += AnaPencere_MouseMove;


            DoubleBuffered = true;

            sekilPaneli = new SekilAlani
            {
                BaslangicX = 820,
                BaslangicY = 10,
                Genislik = 170,
                Yukseklik = 200,
                DoldurmaRengi = System.Drawing.Color.Beige,
                CizgiRengi = System.Drawing.Color.Black
            };

            renkPaneli = new RenkPaneli
            {
                BaslangicX = 820,
                BaslangicY = 220,
                Genislik = 170,
                Yukseklik = 200,
                DoldurmaRengi = System.Drawing.Color.LightBlue,
                CizgiRengi = System.Drawing.Color.Black

            };
            secimPaneli = new SecimPaneli
            {
                BaslangicX = 820,
                BaslangicY = 430,
                Genislik = 170,
                Yukseklik = 110,
                DoldurmaRengi = System.Drawing.Color.White,
                CizgiRengi = System.Drawing.Color.Black

            };

            dosyaPaneli = new DosyaPaneli
            {
                BaslangicX = 820,
                BaslangicY = 550,
                Genislik = 170,
                Yukseklik = 160,
                DoldurmaRengi = System.Drawing.Color.Aquamarine,
                CizgiRengi = System.Drawing.Color.Black
            };

            secimPaneli.SilTiklandi = new SecimPaneli.SecimFonksiyonu(secimTiklandi);
           

        }
        public void secimTiklandi()
        {
            if (aktifCizimSekli != null)
            {
                sekiller.Remove(aktifCizimSekli);
                aktifCizimSekli = null;
                secimPaneli.DeaktifEt();
                secimAktifMi = false;

            }

        }

        private void AnaPencere_MouseMove(object sender, MouseEventArgs e)
        {
            if (cizimAktifMi&&cizimBasladiMi)
            {
               
                int X, Y;
                X = e.X;
                Y = e.Y;

                if (e.X > izgara.Genislik + 10)
                    X = izgara.Genislik + 10;

                if (e.Y >= izgara.Yukseklik + 10)
                    Y = izgara.Yukseklik+10;
                if (e.X < 10)
                    X = 10;
                if (e.Y < 10)
                    Y = 10;
           

                aktifCizimSekli.SonAta(X, Y,izgara.Genislik,izgara.Yukseklik);
            }
                
            Invalidate();
           
        }
        public bool FareCizimAlaninda(int X,int Y)
        {
            if ((X < izgara.Genislik + 10) && (X > 10) && (Y > 10) && (Y < izgara.Yukseklik + 10))
                return true;

            return false;
        }
        private void AnaPencere_MouseUp(object sender, MouseEventArgs e)
        {
            if(cizimAktifMi&&cizimBasladiMi)
            {
                int X, Y;
                X = e.X;
                Y = e.Y;
                if (e.X > izgara.Genislik + 10)
                    X = izgara.Genislik + 10;
                if (e.Y >= izgara.Yukseklik + 10)
                    Y = izgara.Yukseklik+10;
                if (e.X < 10)
                    X = 10;
                if (e.Y < 10)
                    Y = 10;

                aktifCizimSekli.SonAta(X, Y,izgara.Genislik,izgara.Yukseklik);

                sekiller.Add(aktifCizimSekli);

                cizimBasladiMi = false;
                aktifCizimSekli = null;
            }
            else
            {

            }
            
          
        }

        private void AnaPencere_MouseDown(object sender, MouseEventArgs e)
        {
            if(cizimAktifMi&&FareCizimAlaninda(e.X,e.Y))
            {
                aktifCizimSekli = sekilPaneli.AktifSekil;
                aktifCizimSekli.DoldurmaRengi = aktifRenk; 
                aktifCizimSekli.CizgiRengi = System.Drawing.Color.Aqua;
                aktifCizimSekli.BaslangicAta(e.X, e.Y);
                cizimBasladiMi = true;
            }
            else
            {

            }
            
        }

        private void AnaPencere_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
       
            if (sekilPaneli.SecildiMi(x, y))
            {
                cizimAktifMi = true;
                secimAktifMi = false;
                secimPaneli.DeaktifEt();
            }
            else
            {
                
            }

            if(renkPaneli.SecildiMi(x,y))
            {
                aktifRenk = renkPaneli.AktifSekil.DoldurmaRengi;

                if (aktifCizimSekli != null)
                {
                    aktifCizimSekli.DoldurmaRengi = aktifRenk;
                }
            }

            if(secimPaneli.SecildiMi(x,y))
            {
                sekilPaneli.DeaktifEt();

                cizimAktifMi = false;

                secimAktifMi = true;
            }
            dosyaPaneli.Sekiller = sekiller;
            if(dosyaPaneli.SecildiMi(x,y))
            {
                if(dosyaPaneli.DosyaOkundumu)
                {
                    sekiller = dosyaPaneli.Sekiller;
                }
            }

            if(secimAktifMi)
            {
                foreach(var siradaki in sekiller)
                {
                    if(siradaki.SecildiMi(x,y))
                    {
                        aktifCizimSekli = siradaki;
                    }
                }
            }

            Invalidate();
        }

        private void AnaPencere_Paint(object sender, PaintEventArgs e)
        {
            

            izgara.Ciz(e.Graphics);

            renkPaneli.Ciz(e.Graphics);

            secimPaneli.Ciz(e.Graphics);

            sekilPaneli.Ciz(e.Graphics);

            dosyaPaneli.Ciz(e.Graphics);

            foreach(var siradaki in sekiller)
            {
                
                siradaki.Ciz(e.Graphics);
            }

            if (secimAktifMi && aktifCizimSekli!=null)
                aktifCizimSekli.SecimCiz(e.Graphics);


            if (cizimBasladiMi)
                aktifCizimSekli.Ciz(e.Graphics);
        }
    }
}
