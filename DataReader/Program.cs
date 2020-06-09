using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainCon = Connection.ConnectionFactory.CreateTempTable();//RunCommand ile çalıştırılsaydı connection close olacağı için diğer commandlarda kullanılamazdı
            //ExecuteReader();
            //foreach (var item in ExecuteReader2())
            //    Console.WriteLine(item);
            ExecuteReader3();
            mainCon.Close();
            Console.ReadKey();
        }
        static void ExecuteReader()
        {
            Connection.ConnectionFactory.RunCommand((con) =>
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ##temptable", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                        Console.WriteLine("Sayı : " + dr["number"]);
                }
            });
        }
        static IEnumerable<int> ExecuteReader2()
        {
            using (SqlConnection con=Connection.ConnectionFactory.CreateConnection())//!!!yield ifadesi lambda ve anonymouse metotlarda kullanılamaz 
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ##temptable", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        yield return (int)dr["number"];
                    }
                }
            }//okuma işlemi bittiğinde buraya gelir connection dispose olur
        }
        static void ExecuteReader3()
        {
            Connection.ConnectionFactory.RunCommand((con) =>
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ##temptable", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//okuması bittiğinde connection otomatik kapatacak
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dt.Rows.Cast<DataRow>().ToList().ForEach(x => 
                    {
                        Console.WriteLine("Sayılar : "+ x["number"]);
                    });
                }
            });
        }
    }
}
