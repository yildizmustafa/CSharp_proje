using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NdpProje
{
    class DosyaPaneli:Dortgen
    {

        List<Sekil> sekiller;

        Dortgen dosyadanOku;
        Dortgen dosyayaKaydet;
        Image okuResmi;
        Image yazResmi;
        bool dosyaOkundumu = false;
        internal List<Sekil> Sekiller
        {
            get
            {
                return sekiller;
            }

            set
            {
                sekiller = value;
            }
        }

        public bool DosyaOkundumu
        {
            get
            {
                return dosyaOkundumu;
            }

            set
            {
                dosyaOkundumu = value;
            }
        }

        public DosyaPaneli()
        {
            okuResmi = Image.FromFile("dosyaoku.png");
            yazResmi = Image.FromFile("dosyaYaz.png");
            dosyadanOku = new Dortgen();
            dosyadanOku.Genislik = 70;
            dosyadanOku.Yukseklik = 70;
            dosyadanOku.DoldurmaRengi = Color.Black;

            dosyayaKaydet = new Dortgen();
            dosyayaKaydet.Genislik = 70;
            dosyayaKaydet.Yukseklik = 70;
            dosyayaKaydet.DoldurmaRengi = Color.Black;
        }

        public override void Ciz(Graphics g)
        {
            base.Ciz(g);

            g.DrawString("Dosya İşlemleri", new System.Drawing.Font("Arial", 10), System.Drawing.Brushes.Black, BaslangicX + 10, BaslangicY);

            dosyadanOku.BaslangicX = BaslangicX + 10;
            dosyadanOku.BaslangicY = BaslangicY + 60;

            dosyayaKaydet.BaslangicX = BaslangicX + 90;
            dosyayaKaydet.BaslangicY = BaslangicY + 60;

            g.DrawImage(okuResmi, BaslangicX + 10, BaslangicY + 60, 70, 70);
            g.DrawImage(yazResmi, BaslangicX + 90, BaslangicY + 60, 70, 70);
        }

        public override bool SecildiMi(int fareX, int fareY)
        {
            dosyaOkundumu = false;
            if (base.SecildiMi(fareX, fareY))
            {
                if(dosyadanOku.SecildiMi(fareX,fareY))
                {
                    oku();
                    return true;
                    
                }
                if (dosyayaKaydet.SecildiMi(fareX, fareY))
                {
                    kaydet();
                    return true;
                }
            }
            
            return false;
        }
        private void kaydet()
        {
            SaveFileDialog savefileDialog = new SaveFileDialog();



            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(@savefileDialog.FileName);
                
                if(Sekiller!=null)
                {
                    foreach(var siradaki in Sekiller)
                    {
                        file.WriteLine(siradaki.ToString());
                    }
                }
                file.Close();
            }
        }
        private void oku()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string line;
            int counter = 0;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog.FileName);

                Sekiller = new List<Sekil>();
                while ((line = file.ReadLine()) != null)
                {
                    var ozellikler = line.Split(',');
                    Sekil yeniSekil = null;



                    string renk;
                    int length; 
                    Color renkyeni;

                    switch (ozellikler[0])
                    {
                        case "Dortgen":
                            Dortgen dortgen = new Dortgen();
                            dortgen.BaslangicX = Int32.Parse(ozellikler[1]);
                            dortgen.BaslangicY = Int32.Parse(ozellikler[2]);
                            dortgen.Genislik = Int32.Parse(ozellikler[3]);
                            dortgen.Yukseklik = Int32.Parse(ozellikler[4]);
                            
                            renk = ozellikler[5];
                            length = renk.Length - 8;
                            renk = renk.Substring(7, length);

                            renkyeni = Color.FromName(renk);


                            dortgen.DoldurmaRengi = renkyeni;

                            yeniSekil = dortgen;
                            break;
                        case "Daire":
                            Daire daire = new Daire();


                            daire.BaslangicX = Int32.Parse(ozellikler[1]);
                            daire.BaslangicY = Int32.Parse(ozellikler[2]);
                            daire.Cap = Int32.Parse(ozellikler[3]);
                         
                           
                            renk = ozellikler[4];

                            length = renk.Length - 8;
                            renk = renk.Substring(7, length);

                            renkyeni = Color.FromName(renk);

                            daire.DoldurmaRengi = renkyeni;


                            yeniSekil = daire;

                            break;
                        case "Altigen":
                            Altigen altigen = new Altigen();

                            
                            altigen.BaslangicX = Int32.Parse(ozellikler[1]);
                            altigen.BaslangicY = Int32.Parse(ozellikler[2]);
                            altigen.Kenar = Int32.Parse(ozellikler[3]);

                            renk = ozellikler[4];

                            length = renk.Length - 8;
                            renk = renk.Substring(7, length);

                            renkyeni = Color.FromName(renk);

                            altigen.DoldurmaRengi = renkyeni;

                            yeniSekil = altigen;

                            break;
                        case "Ucgen":
                            Ucgen ucgen = new Ucgen();


                            ucgen.BaslangicX = Int32.Parse(ozellikler[1]);
                            ucgen.BaslangicY = Int32.Parse(ozellikler[2]);
                            ucgen.Yaricap = Int32.Parse(ozellikler[3]);

                            renk = ozellikler[4];

                            length = renk.Length - 8;
                            renk = renk.Substring(7, length);

                            renkyeni = Color.FromName(renk);

                            ucgen.DoldurmaRengi = renkyeni;

                            yeniSekil = ucgen;
                            break;
                    }

                    sekiller.Add(yeniSekil);
                    counter++;
                }

                dosyaOkundumu = true;
                
                file.Close();
            }
        }
    }
}
