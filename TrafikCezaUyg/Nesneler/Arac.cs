using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafikCezaUyg
{
    internal class Arac
    {
        public string AracTipi;
        public int Hızlimiti;
        public string plaka;

        public Arac(string A, string p)
        {
            AracTipi = A;
            plaka = p;

        }

        public double Limit(Arac a, string Yol)
        {
            if (a.AracTipi == "kamyonet" && Yol == "Şehiriçi")
                Hızlimiti = 50;


            else if (a.AracTipi == "kamyonet" && Yol == "Şehirdışı")
                Hızlimiti = 100;



            else if (a.AracTipi == "otomobil" && Yol == "Şehiriçi")
                Hızlimiti = 50;

            else if (a.AracTipi == "otomobil" && Yol == "Şehirdışı")
                Hızlimiti = 130;


            else if (a.AracTipi == "motosiklet" && Yol == "Şehiriçi")
                Hızlimiti = 50;


            else if (a.AracTipi == "motosiklet" && Yol == "Şehirdışı")
                Hızlimiti = 100;

            return Hızlimiti;
        }

    }
}
