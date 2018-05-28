using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdpProje
{
    abstract class  Sekil
    {
        int baslangicX;

        int baslangicY;

        Color cizgiRengi;

        Color doldurmaRengi;

        Color secimRengi;
        public Sekil()
        {
            SecimRengi = Color.FromArgb(100, 155, 0, 155);
        }
        public virtual int BaslangicX
        {
            get
            {
                return baslangicX;
            }

            set
            {
                baslangicX = value;
            }
        }
        public virtual int BaslangicY
        {
            get
            {
                return baslangicY;
            }

            set
            {
                baslangicY = value;
            }
        }
        public Color CizgiRengi
        {
            get
            {
                return cizgiRengi;
            }

            set
            {
                cizgiRengi = value;
            }
        }

        public Color DoldurmaRengi
        {
            get
            {
                return doldurmaRengi;
            }

            set
            {
                doldurmaRengi = value;
            }
        }

        public Color SecimRengi
        {
            get
            {
                return secimRengi;
            }

            set
            {
                secimRengi = value;
            }
        }

        public void BaslangicAta(int x, int y)
        {
            BaslangicX = x;
            BaslangicY = y;
        }
        public abstract void Ciz(Graphics g);
        public abstract void SecimCiz(Graphics g);
        public abstract void SonAta(int x, int y,int width,int height);


        public abstract bool SecildiMi(int fareX, int fareY);

        
    }
}
