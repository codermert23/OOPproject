using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafikCezaUyg.Nesneler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plaka = textBox1.Text.Trim();
            plaka.ToUpper();

            if (string.IsNullOrEmpty(plaka))
            {
                MessageBox.Show("Lütfen bir plaka giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string klasorYolu = @"C:\Users\lenovo\source\repos\TrafikCezaUyg\TrafikCeza";
            string dosyaYolu = Path.Combine(klasorYolu, plaka + ".txt");

            if (!File.Exists(dosyaYolu))
            {
                MessageBox.Show("Bu plakaya ait ceza kaydı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string icerik = File.ReadAllText(dosyaYolu);

            if (string.IsNullOrEmpty(icerik))
            {
                MessageBox.Show("Ödenmemiş ceza kalmamıştır !! ");
            }

            try
            {
                string[] cezalar = File.ReadAllLines(dosyaYolu); // Satır satır oku
                listBox1.Items.Clear(); // Önceki verileri temizle

                foreach (string ceza in cezalar)
                {
                    listBox1.Items.Add(ceza); // Her satırı ListBox'a ekle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okuma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OdemeForm ode = new OdemeForm();

            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen ödemek istediğiniz cezaları seçin.");
                return;
            }

            string plaka = textBox1.Text.Trim(); // Plaka textbox'ından alınıyor
            string dosyaYolu = Path.Combine(@"C:\Users\lenovo\source\repos\TrafikCezaUyg\TrafikCeza", plaka + ".txt");

            if (!File.Exists(dosyaYolu))
            {
                MessageBox.Show("Dosya bulunamadı.");
                return;
            }

            // Dosyadaki tüm cezaları oku
            List<string> tumCezalar = File.ReadAllLines(dosyaYolu).ToList();
            ode.ShowDialog();

            // Seçilenleri sil
            foreach (var secili in listBox1.SelectedItems.Cast<string>().ToList())
            {
                tumCezalar.Remove(secili); 
                listBox1.Items.Remove(secili); 
            }

            
            File.WriteAllLines(dosyaYolu, tumCezalar);
            string icerik = File.ReadAllText(dosyaYolu);

            if (string.IsNullOrEmpty(icerik))
            {
                MessageBox.Show("Ödenmemiş ceza kalmamıştır !! ");              
            }

            MessageBox.Show("Seçilen cezalar ödendi ve dosyadan silindi.");
        
    }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string yol = @"C:\Users\lenovo\source\repos\TrafikCezaUyg\TrafikCezaUyg\bin\Debug\arkaplan.png";

          
            

            // 2. Resmi yükle ve yarı saydam hale getir
            Image img = Image.FromFile(yol);
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = 0.4f; // saydamlık derecesi

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height),
                    0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attributes);
            }

            // 3. PictureBox ayarları
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SendToBack();
        }

      
    }
    }

