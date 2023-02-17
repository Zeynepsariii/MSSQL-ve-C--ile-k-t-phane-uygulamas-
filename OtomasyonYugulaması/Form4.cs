using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomasyonYugulaması
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'mevcutDataSet.mevcut' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mevcutTableAdapter.Fill(this.mevcutDataSet.mevcut);

        }
        public void button1_Click(object sender, EventArgs e)
        {
            SqlOperationsForMevcut.CheckConnection(SqlOperationsForMevcut.baglanti2);

            string kayit = "insert into mevcut (kitapAdi,yazarAdi,basimYili,türü,fiyati) values (@kitapAd,@yazarAd,@yil,@tur,@fiyat)";
            SqlCommand komut = new SqlCommand(kayit, SqlOperationsForMevcut.baglanti2);
            komut.Parameters.AddWithValue("@kitapAd", textBox1.Text);
            komut.Parameters.AddWithValue("@yazarAd", textBox2.Text);
            komut.Parameters.AddWithValue("@yil", textBox3.Text);
            komut.Parameters.AddWithValue("@tur", textBox4.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox5.Text);
            int result = komut.ExecuteNonQuery();
            SqlOperationsForMevcut.baglanti2.Close();

            if (result == 1)
            {

                MessageBox.Show("yeni kitap eklendi");
                this.Close();
            }
            else
            {

                MessageBox.Show("kitap eklenirken bir hata oluştu ");
            }


            SqlOperationsForMevcut.baglanti2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlOperationsForMevcut.CheckConnection(SqlOperationsForMevcut.baglanti2);
            //baglanti.Open();
            string kayit = "DELETE FROM mevcut WHERE kitapAdi = @kitapAd";
            SqlCommand komut = new SqlCommand(kayit, SqlOperationsForMevcut.baglanti2);
            komut.Parameters.AddWithValue("@kitapAd", textBox1.Text);


            int result = komut.ExecuteNonQuery();
            SqlOperationsForMevcut.baglanti2.Close();

            if (result > 0)
            {

                MessageBox.Show("kitap silindi");
                this.Close();
            }
            else
            {

                MessageBox.Show("kitap silirken bir hata oluştu ");
            }


            SqlOperationsForMevcut.baglanti2.Close();
        }
    }
}
