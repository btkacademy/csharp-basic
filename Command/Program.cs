using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteNonQuery();
            ExecuteNonQueryWithPattern();
            ExecuteScaler();
            Console.ReadKey();
        }
        static void ExecuteNonQuery()
        {
            using (var connection = Connection.ConnectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("print 'Sql ile çalıştırıldı'", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
        static void ExecuteNonQueryWithPattern()
        {
            Connection.ConnectionFactory.RunCommand((connection) =>
            {
                using (SqlCommand cmd = new SqlCommand(@"
                create table #temptable --sadece geçerli connection kullanabileceği geçici tablo oluşturuyor
                (
	                number int 
                )
                insert into #temptable values(1), (2)
                drop table #temptable", connection))
                {
                    int Result = cmd.ExecuteNonQuery();
                    Console.WriteLine(string.Format("{0} etkilenen satır sayısı", Result));
                }
            });
        }
        static void ExecuteScaler()
        {
            Connection.ConnectionFactory.RunCommand((connection) =>
            {
                using (SqlCommand cmd = new SqlCommand("SELECT 'Ahmet'", connection))
                {
                    object Result=cmd.ExecuteScalar();
                    Console.WriteLine("Sonuç : "+Result.ToString());
                }
            });
        }
      
    }
}
