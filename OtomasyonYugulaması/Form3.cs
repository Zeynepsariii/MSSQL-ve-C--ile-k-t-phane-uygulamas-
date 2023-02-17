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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

       

        public void button3_Click_1(object sender, EventArgs e)
        {
            SqlOperations.CheckConnection(SqlOperations.baglanti);

            string kayit = "insert into FUser (k_ad,k_sifre) values (@ad,@sifre)";
            SqlCommand komut = new SqlCommand(kayit, SqlOperations.baglanti);
            komut.Parameters.AddWithValue("@ad", textBox3.Text);
            komut.Parameters.AddWithValue("@sifre", textBox4.Text);
            int result = komut.ExecuteNonQuery();
            SqlOperations.baglanti.Close();
            
            if (result > 0)
            {

                MessageBox.Show("yeni kayıt eklendi");
                this.Close();
            }
            else
            {

                MessageBox.Show("kayıt sağlanamadı hata: ");
            }


            SqlOperations.baglanti.Close();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

