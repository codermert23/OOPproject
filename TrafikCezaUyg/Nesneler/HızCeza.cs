using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafikCezaUyg

{
    internal class HızCeza : Ceza
    {
      
        public HızCeza(Arac a ,int hız,string yol)
        {
            
            double asım10 = a.Limit(a, yol) * (1.1);
            double asım30 = a.Limit(a, yol) * (1.3);
            double asım50 = a.Limit(a, yol) * (1.5);
            if (hız > asım50)
                Tutar = 9268;
            else if (hız >= asım30 && hız < asım50)
                Tutar = 4512;
            else if (hız >= asım10 && hız < asım30)
               Tutar= 2168;

            
            MessageBox.Show("limit : "+a.Limit(a,yol)+" "+ Tutar.ToString());

        }
        
    }
}
