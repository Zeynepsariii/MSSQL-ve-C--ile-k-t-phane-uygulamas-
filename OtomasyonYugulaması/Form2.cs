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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'verilmisDataSet.verilmis' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.verilmisTableAdapter.Fill(this.verilmisDataSet.verilmis);

        }

        public void button1_Click(object sender, EventArgs e)
        {
            SqlOperationsForVerilmis.CheckConnection(SqlOperationsForVerilmis.baglanti1);

            string kayit = "insert into verilmis (kitapAdi,yazarAdi,basimYili,türü,fiyati) values (@kitapAd,@yazarAd,@yil,@tur,@fiyat)";
            SqlCommand komut = new SqlCommand(kayit, SqlOperationsForVerilmis.baglanti1);
            komut.Parameters.AddWithValue("@kitapAd", textBox1.Text);
            komut.Parameters.AddWithValue("@yazarAd", textBox2.Text);
            komut.Parameters.AddWithValue("@yil", textBox3.Text);
            komut.Parameters.AddWithValue("@tur", textBox4.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox5.Text);
            int result = komut.ExecuteNonQuery();
            SqlOperationsForVerilmis.baglanti1.Close();

            if (result == 1 )
            {

                MessageBox.Show("yeni kitap eklendi");
                this.Close();
            }
            else
            {

                MessageBox.Show("kitap eklenirken bir hata oluştu ");
            }


            SqlOperationsForVerilmis.baglanti1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlOperationsForVerilmis.CheckConnection(SqlOperationsForVerilmis.baglanti1);
            //baglanti.Open();
            string kayit = "DELETE FROM verilmis WHERE kitapAdi = @kitapAd";
            SqlCommand komut = new SqlCommand(kayit, SqlOperationsForVerilmis.baglanti1);
            komut.Parameters.AddWithValue("@kitapAd", textBox1.Text);


            int result = komut.ExecuteNonQuery();
            SqlOperationsForVerilmis.baglanti1.Close();

            if (result > 0)
            {

                MessageBox.Show("kitap silindi");
                this.Close();
            }
            else
            {

                MessageBox.Show("kitap silinirken bir hata oluştu");
            }


            SqlOperationsForVerilmis.baglanti1.Close();
        }
    }
}
