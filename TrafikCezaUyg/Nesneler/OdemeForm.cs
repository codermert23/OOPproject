using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafikCezaUyg.Nesneler
{
    public partial class OdemeForm : Form
    {
        public bool OdemeBasarili { get; private set; } = false;
        public OdemeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox2.Text) ||
            string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            // Ödeme başarılı gibi davranalım
            MessageBox.Show("Ödeme başarılı!");
            OdemeBasarili = true;
            this.Close();
        }

        private void OdemeForm_Load(object sender, EventArgs e)
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

        private void OdemeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Ödeme tamamlanmadan çıktınız !!");
            Application.Exit();
        }
    }
}
