using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection.ConnectionFactory.CreateTempTable();
            using (SqlConnection con = Connection.ConnectionFactory.CreateConnection())
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                SqlTransaction sqlTransaction = con.BeginTransaction("tr1");
                cmd.Connection = con;
                cmd.Transaction = sqlTransaction;
                try
                {
                    cmd.CommandText = "insert into ##temptable values(4),(5)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into ##temptable values('6a')";
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();//catche düştüğü için 4 ve 5 de kaydedilmemiş olacak
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorun oluştu="+ex.ToString());
                    try
                    {
                        sqlTransaction.Rollback("tr1");
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback exception="+ex2.ToString());
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
