using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager();

            User user1 = new User()
            {
                Id = userManager.GetId(),
                Name = "Ahmet Faruk",
                Surname = "Ulu",
                BirthYear = 1998
            };

            User user2 = new User()
            {
                Id=userManager.GetId(),
                Name = "Aygün",
                Surname = "Yıldız",
                BirthYear = 1996
            };

            userManager.AddRange(user1,user2);

            Console.ReadKey();
        }
    }
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }//property
        public string Surname { get; set; }//propery
        private int birthYear;//field
        public int BirthYear { get { return birthYear; } set { birthYear = value; } }//property
    }
    public class UserManager
    {
        public void Add(User user)
        {
            Console.WriteLine(string.Format("{0} named user added.Id={1}", user.Name,user.Id));
        }
        public void AddRange(params User[] users)
        {
            for (int i = 0; i < users.Length; i++)
            {
                Add(users[i]);
            }
        }
        public string GetId() => Guid.NewGuid().ToString();
    }
}
