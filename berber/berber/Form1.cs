using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace berber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            randevular = new List<Randevu>();
        }
        private List<Randevu> randevular;
     
        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Edis Kaçan");
            comboBox1.Items.Add("Ahmet Mehmat");
            comboBox1.Items.Add("Mehmet Erdoğan");


            comboBox2.Items.Add("10.00");
            comboBox2.Items.Add("11.00");
            comboBox2.Items.Add("15.00");
            comboBox2.Items.Add("16.00");
            comboBox2.Items.Add("21.00");

            comboBox3.Items.Add("Saç");
            comboBox3.Items.Add("Sakal");
            comboBox3.Items.Add("Saç ve Sakal");




        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ad = textBox2.Text.Trim();
            string soyad = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Lütfen ad ve soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string berber = comboBox1.SelectedItem.ToString();
            string saat = comboBox2.SelectedItem.ToString();
            string kesim = comboBox3.SelectedItem.ToString();
          

            if (randevular.Any(r => r.Saat == saat))
            {
                MessageBox.Show("Bu saatte randevu zaten alınmış. Lütfen başka bir saat seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
             Randevu yeniRandevu = new Randevu(berber, saat, kesim);
     
            randevular.Add(yeniRandevu);
            listBox1.Items.Insert(0, $"{soyad} {ad}");

            listBox1.Items.Add(yeniRandevu.ToString());

            MessageBox.Show("Randevunuz başarıyla alındı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Verilen saatte randevu alınıp alınmadığını kontrol eder
        private bool AlinmisMi(string saat)
        {
            foreach (var randevu in randevular)
            {
                if (randevu.Saat == saat)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Randevu
    {
        public string Ad { get; }
        public string Soyad { get; }

        public string Berber { get; }
        public string Saat { get; }
        public string Kesim { get; }

        public Randevu(string berber, string saat, string kesim)
        {
           
            Berber = berber;
            Saat = saat;
            Kesim = kesim;
        }

        public override string ToString()
        {
            return $"{Berber} - {Kesim} - {Saat}";
        }
    }
}

