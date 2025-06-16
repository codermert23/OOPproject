using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafikCezaUyg
{
    public partial class Form1 : Form
    {
        CezaYönetimi c = new CezaYönetimi();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string secilenArac = null;
            string secilenYol = null;

            if (radioButton1.Checked)
                secilenArac = "otomobil";
            else if (radioButton2.Checked)
                secilenArac = "kamyonet";
            else if (radioButton3.Checked)
                secilenArac = "motosiklet";

            if (secilenArac == null)                            
                MessageBox.Show("Lütfen bir araç tipi seçin.", "UYARI !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (radioButton4.Checked)
                secilenYol = "Şehiriçi";
            else if (radioButton5.Checked)
                secilenYol = "Şehirdışı";

            if (secilenYol == null)                        
                MessageBox.Show("Lütfen bir Yol tipi seçin.", "UYARI !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            c.HızcezaYaz(secilenArac, textBox1.Text, Convert.ToInt32(textBox3.Text),secilenYol);
        }

        




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            c.ParkCezaYaz(textBox1.Text);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.KirmiziCezaYaz(textBox1.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
