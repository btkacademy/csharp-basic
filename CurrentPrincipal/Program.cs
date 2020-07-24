using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Principal;

namespace CurrentPrincipal
{
    class Program
    {
        static void Main(string[] args)
        {
            //IsUserAuthenticated(); Thread.CurrentPrincipal.Identity.IsAuthenticated false döner fakat UserDataModele dönüştürmek istediğimizde daha önce herhangi bir set işlemi yapmadığımız için hata alırız
            //Thread.CurrentPrincipal.Identity set ettikten sonra projenin diğer katmanlarında da kullanılabilir

            Console.Write("Kullanıcı adı=");
            string username = Console.ReadLine();
            Console.Write("Şifre=");
            string password = Console.ReadLine();
            Login(username, password);
            IsUserAuthenticated();
            AdminMethod();
            UserMethod();
            Console.ReadKey();
        }
        static UserDataModel CreateIdentity(string Name, bool IsAuthenticated, string CustomProp1, int CustomProp2, DateTime CustomProp3, string[] Roles)
        {
            UserDataModel userDataModel = new UserDataModel();
            userDataModel.AuthenticationType = "ConsoleApp";
            userDataModel.Name = Name;
            userDataModel.IsAuthenticated = IsAuthenticated;
            userDataModel.CustomProp1 = CustomProp1;
            userDataModel.CustomProp2 = CustomProp2;
            userDataModel.CustomProp3 = CustomProp3;
            userDataModel.Roles = Roles;
            return userDataModel;
        }
        static void Login(string username, string password)
        {
            IIdentity userIdentity;
            if (username == "ahmetfaruk" && password == "ulu")
            {
                //IsAuthenticated true yolluyoruz giriş başarılı olduğu için
                userIdentity = CreateIdentity(username, true, "Özel alan1", 10, DateTime.Now, new string[] { "Admin", "User" });
            }
            else
            {
                //IsAuthenticated false yolluyoruz giriş hatalı olduğu için
                userIdentity = CreateIdentity(username, false, default(string), default(int), DateTime.MinValue, new string[] { "User" });
            }
            var principal = new GenericPrincipal(userIdentity, ((UserDataModel)userIdentity).Roles);
            Thread.CurrentPrincipal = principal;
        }
        static void IsUserAuthenticated()
        {
            if(Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                Console.WriteLine("Giriş başarılı");
            }
            else
            {
                Console.WriteLine("Giriş başarısız");
            }
            var user = ((UserDataModel)Thread.CurrentPrincipal.Identity);
            Console.WriteLine(string.Format("Kullanıcı özel alanı1={0}\nKullanıcı özel alanı2={1}\nKullanıcı özel alanı3={2}\nKullanıcı yetkiler = {3}", user.CustomProp1,user.CustomProp2,user.CustomProp3, string.Join(",", user.Roles))); 
             
        }
        static void AdminMethod()
        {
            if (!Thread.CurrentPrincipal.IsInRole("Admin"))
            {
                Console.WriteLine("Bu işlemi yapmaya yetkin yok");
                return;
            }
            Console.WriteLine("Admin işini yapar");
        }
        static void UserMethod()
        {
            if (!Thread.CurrentPrincipal.IsInRole("User"))
            {
                Console.WriteLine("Bu işlemi yapmaya yetkin yok");
                return;
            }
            Console.WriteLine("User işini yapar");
        }
    }
    public class UserDataModel : IIdentity
    {
        #region IIdentity propertyleri
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        #endregion

        #region Kendi oluşturduğumuz propertyler
        public string CustomProp1 { get; set; }
        public int CustomProp2 { get; set; }
        public DateTime CustomProp3 { get; set; }
        //... bu şekilde ne kadar alan gerekiyorsa oluşturulur
        public string[] Roles { get; set; }
        #endregion
    }
}
