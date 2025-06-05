using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafikCezaUyg.Nesneler
{
    public interface IOdenecek

    {
        bool OdenmeDurumu { get; }
        int Tutar { get;  }
    }
}
