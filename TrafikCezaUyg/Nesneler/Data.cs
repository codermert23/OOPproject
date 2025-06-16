using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static TrafikCezaUyg.Program;
using System.Windows.Forms;

namespace TrafikCezaUyg
{
    public class Data : Ceza
    {
   
        
        public  void DataYaz(string plaka,string t)
        {
            string klasorYolu = @"C:\Users\lenovo\source\repos\TrafikCezaUyg\TrafikCeza";
            string dosyaYolu = Path.Combine(klasorYolu, plaka+".txt");

            // Klasör yoksa oluştur
            if (!Directory.Exists(klasorYolu))
            {
                Directory.CreateDirectory(klasorYolu);
            }
            try
            {
                if (Tutar == 0)
                    return;

                string satir = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ " " + t +": " + Tutar.ToString() + " TL";
                File.AppendAllText(dosyaYolu, satir + Environment.NewLine);
                MessageBox.Show("Ceza yazıldı... \nCeza miktarı : " + Tutar.ToString() + " TL");
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }
    }
}
