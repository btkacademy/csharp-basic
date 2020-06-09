using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency
{
    class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDependency dependency;
        static void Main(string[] args)
        {
            Track();
            //konsol uygulaması çalıştıktan sonra tblde yapılan her güncellemede anlık olarak konsol bilgilendirelecek
            //insert into tbl values(575)
            //update tbl set number=100 where number=575
            //delete from tbl
            Console.ReadKey();
        }
        static void Track()
        {
            using (con = new SqlConnection("Server=.;Database=test;Trusted_Connection=True;"))
            {
                con.Open();
                using (cmd = new SqlCommand("Select number from dbo.tbl", con))
                {
                    //hangi alanlar değiştiğinde bilgi almak istiyorsak tek tek yazılmalı "*" yaparsak doğru çalışmaz 
                    //dbo.tbl yerine tbl yazılırsada doğru çalışmaz
                    Register();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        static void Register()
        {
            dependency = new SqlDependency(cmd);
            SqlDependency.Start(con.ConnectionString);
            dependency.OnChange += Dependency_OnChange;
        }
        private static void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            dependency.OnChange -= Dependency_OnChange;
            Console.WriteLine("Tablo değişti "+e.Info);
            Track();
        }
    }
}
/* dbscript
create database test
go
use test
create table tbl 
(
	number int 
)
insert into tbl values(1), (2), (3) 
GO
ALTER DATABASE test SET ENABLE_BROKER; -- dependency çalışabilmesi için service broker açık olmalı
*/
