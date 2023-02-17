using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomasyonYugulaması
{
    public class SqlOperations
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=FPageUser;Integrated Security=True");
        
        public static void CheckConnection(SqlConnection temp)
        {
            if (temp.State == ConnectionState.Closed)
            {
                baglanti.Open();
                Console.WriteLine("bağlantı açıldı");
            }


        }
    }
}
