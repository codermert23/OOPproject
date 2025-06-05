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
   
        
        public  void DataYaz(string plaka)
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
                string satir = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Ceza: " + Tutar.ToString() + " TL";
                File.AppendAllText(dosyaYolu, satir + Environment.NewLine);
                MessageBox.Show("Ceza yazıldı... Ceza miktarı : " + Tutar.ToString() + " TL");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }
    }
}
