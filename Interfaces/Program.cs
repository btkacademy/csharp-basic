using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager();
            userManager.Add(new SqlUserDal());
            userManager.Add(new MySqlUserDal());
            Console.WriteLine(userManager.UserCounter);
            userManager.ComplextMethod();
            Console.ReadKey();
        }
    }
    public interface IUserDal
    {
        void Add();
    }
    public class SqlUserDal : IUserDal //Implementation
    {
        public void Add()
        {
            Console.WriteLine("Sql added");
        }
    }
    public class MySqlUserDal : IUserDal //Implementation
    {
        public void Add()
        {
            Console.WriteLine("Mysql added");
        }
    }

    public interface IUserService
    {
        int UserCounter { get; set; }
        void Add(IUserDal userDal); 
    }
    public interface IComplexService
    {
        void ComplextMethod();
    }
    public class UserManager : IUserService, IComplexService
    {
        public int UserCounter { get; set; }
        public void Add(IUserDal userDal)
        {
            userDal.Add();
            UserCounter++;
        }
        public void ComplextMethod()
        {
            //do complex thing
        }
    }
}
