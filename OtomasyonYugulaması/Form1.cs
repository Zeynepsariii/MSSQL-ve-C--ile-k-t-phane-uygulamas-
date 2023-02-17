using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace OtomasyonYugulaması
{
    public partial class Form1 : Form
    {

        public static SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=FPageUser;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlOperations.CheckConnection(SqlOperations.baglanti);
            //baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From FUser Where k_ad = @ad AND k_sifre = @sifre", SqlOperations.baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", textBox2.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Form5 frmBn = new Form5();
                frmBn.Show();
                this.Hide();

            }
            else
            {

                MessageBox.Show("Hatalı kullanıcı adı veya şifre");

            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frmBn = new Form3();
            frmBn.Show();
        }
    }
    
}
