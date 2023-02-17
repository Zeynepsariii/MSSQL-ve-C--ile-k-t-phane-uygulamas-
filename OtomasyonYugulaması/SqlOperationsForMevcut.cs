using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomasyonYugulaması
{
    public class SqlOperationsForMevcut
    {
        public static SqlConnection baglanti2 = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=mevcut;Integrated Security=True");

        public static void CheckConnection(SqlConnection temp)
        {
            if (temp.State == ConnectionState.Closed)
            {
                baglanti2.Open();
                Console.WriteLine("bağlantı açıldı");
            }


        }
    }
}
