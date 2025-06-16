using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafikCezaUyg.Program;
using TrafikCezaUyg.Nesneler;


namespace TrafikCezaUyg
{
    public class Ceza : IOdenecek
    {
       
        public int Tutar { get;  set; } 
        public bool OdenmeDurumu { get; protected set; } // ödenme durumu değişmesin
    }
}
