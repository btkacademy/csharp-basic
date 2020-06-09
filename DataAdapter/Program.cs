using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainCon = Connection.ConnectionFactory.CreateTempTable();
            Connection.ConnectionFactory.RunCommand((con) =>
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ##temptable", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                        Console.WriteLine(row["number"]);
                }
            });
            Console.ReadKey();
        }
    }
}
