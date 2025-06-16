using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafikCezaUyg.Nesneler;

namespace TrafikCezaUyg
{
    internal class CezaYönetimi : Ceza
    {
        public void HızcezaYaz(string tip, string plaka, int hız,string yol)
        {
            Arac a = new Arac(tip, plaka);
            Ceza h = new HızCeza(a, hız,yol);
            Data d = new Data();
            d.Tutar = h.Tutar;
            plaka.ToUpper();
            d.DataYaz(plaka,"Hız Cezası ");
            OdenmeDurumu = false;
        }
        public void ParkCezaYaz(string plaka)

        {  
            Ceza yaz = new ParkCeza();
            Data d = new Data();
            d.Tutar=yaz.Tutar;
            plaka.ToUpper();
            d.DataYaz(plaka,"Park Cezası ");
            OdenmeDurumu = false;


        }
        public void KirmiziCezaYaz(string plaka)

        {
            Ceza yaz = new KirmiziCeza();
            Data d = new Data();
            d.Tutar = yaz.Tutar;
            plaka.ToUpper();
            d.DataYaz(plaka,"Kırmızı Işık Cezası ");
            OdenmeDurumu = false;


        }
        public void CezaOde()
        {

        }
        public void borcHesapla()
        {

        }
    }
}
