using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Adınız : ");
            string Name = Console.ReadLine();
            //SayHi(Name);
            SayHi2(Name);
            Console.ReadKey();
        }
        static void SayHi(string Name)
        {
            Connection.ConnectionFactory.RunCommand((con) =>
            {
                using (SqlCommand cmd = new SqlCommand("SELECT 'Selam ' + @Name + ' SQL ile çalıştı'", con))
                {
                    cmd.Parameters.AddWithValue("Name", Name);
                    Console.WriteLine(cmd.ExecuteScalar().ToString());
                }
            });
        }
        static void SayHi2(string Name)
        {
            Connection.ConnectionFactory.RunCommand((con) =>
            {
                using (SqlCommand cmd = new SqlCommand("SELECT 'Selam ' + @Name + ' SQL ile çalıştı'", con))
                {
                    cmd.Parameters.Add("Name",SqlDbType.VarChar,20).Value=Name;
                    Console.WriteLine(cmd.ExecuteScalar().ToString());
                }
            });
        }
    }
}
