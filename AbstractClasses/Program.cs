using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Database> databases = new List<Database>
            {
                //new Database(), => hata verir
                new SqlServer(),
                new MySql()
            };
            foreach (Database database in databases)
            {
                database.Add();
                database.Delete();
            }
            Console.ReadKey();
        }
    }
    public abstract class Database
    {
        public void Add()
        {
            Console.WriteLine("Default add");
        }
        public abstract void Delete();
    }
    public class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Delete from sqlserver");
        }
    }
    public class MySql : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Delete from mysql");
        }
    }
}
