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

namespace TrafikCezaUyg
{
    public partial class LoginForm : Form
    {
        public bool GirisBasarili { get; private set; } = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button1_Click_1(object sender, EventArgs e)
        { string kullaniciAdi = textBox1.Text;
            textBox2.UseSystemPasswordChar = true;
            string sifre = textBox2.Text;
           
            if (kullaniciAdi == "admin" && sifre == "1234")
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                GirisBasarili = true;
                this.Close(); // Formu kapat
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string yol = @"C:\Users\lenovo\source\repos\TrafikCezaUyg\TrafikCezaUyg\bin\Debug\arkaplan2.jpg";

            

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

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
    }

