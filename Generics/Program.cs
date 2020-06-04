using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  Generic olabilecek türler
            //Interface
            //Abstract class
            //Class
            //Method
            //Static method
            //Property
            //Event
            //Delegates
            //Operator
            #endregion

            IRepository<User> userRepository = new RepositoryBase<User>();
            userRepository.AddOrUpdate(new User() { });

            IRepository<Project> projectRepository = new RepositoryBase<Project>();
            projectRepository.Delete(new Project());

            Console.ReadKey();
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Project
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime BeginDate { get; set; }
    }
    public interface IRepository<T> where T
        : class
        //,interface'ler yazılabilir
        , new()
    {
        int AddOrUpdate(T entity);
        void Delete(T entity);
        T Get(int id);
    }
    public class RepositoryBase<T> : IRepository<T> where T : class, new()
    {
        public int AddOrUpdate(T entity)
        {
            Console.WriteLine("Changes saved");
            return 0;
        }
        public void Delete(T entity)
        {
            Console.WriteLine("Entity deleted");
        }
        public T Get(int id)
        {
            Console.WriteLine("Entity find");
            return new T();
        }
    }
}
