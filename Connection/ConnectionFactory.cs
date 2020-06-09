using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public static class ConnectionFactory
    {
        //https://www.connectionstrings.com/sql-server/
        public static SqlConnection CreateConnection() => new SqlConnection("Server=.;Database=master;Trusted_Connection=True");
        public static void RunCommand(Action<SqlConnection> action)
        {
            using (var connection = Connection.ConnectionFactory.CreateConnection())
            {
                try
                {
                    connection.Open();
                    action(connection);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }//connection dispose olacak close etmesekte zaten dispose olurken close yapacaktı kendisi
        }
        public static SqlConnection CreateTempTable()
        {
            var connection = Connection.ConnectionFactory.CreateConnection();
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(@"
            create table ##temptable --herkesin kullanabileceği geçici tablo oluşturuyor connection kapanana kadar diğer connectionlarda erişebilir
            (
	            number int 
            )
            insert into ##temptable values(1), (2), (3)", connection))
            {
                int Result = cmd.ExecuteNonQuery();
            };
            return connection;
        }
        static void ConnectionInfo()
        {
            //Server=.;Database=master;User Id=sa;Password=xx;
            //Server=.;Database=master;Trusted_Connection=True
            var Connection = CreateConnection();
            //Connection.State =>Bağlantı durumu 
            //Connection.Open();
            //Connection.Close();
        }
    }
}
