using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Database> databases = new List<Database>
            {
                new Database(),
                new SqlServer(),
                new MySql()
            };
            foreach (Database database in databases)
            {
                database.Add();
            }
            Console.ReadKey();
        }
    }
    public class Database
    {
        public virtual void Add()
        {
            Console.WriteLine("Database added");
        }
    }
    public class SqlServer : Database
    {
        public override void Add()
        {
            Console.WriteLine("Sqlserver added");
        }
    }
    public class MySql : Database
    {
        public override void Add()
        {
            Console.WriteLine("MySql added");
        }
    }
}
