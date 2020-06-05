using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87, 21 };
            //ElementAt(intList);
            //FirstLast(intList);
            Single(intList);
            Console.ReadKey();
        }
        static void ElementAt(IList<int> intList)
        {
            Console.WriteLine("1.eleman: {0}", intList.ElementAt(0));
            //intList.ElementAt(9) => index out of range hatası veir
            Console.WriteLine("10.eleman", intList.ElementAtOrDefault(9));
        }
        static void FirstLast(IList<int> intList)
        {
            Console.WriteLine("1.eleman: {0}", intList.First());
            Console.WriteLine("Çift sayılı 1.eleman: {0}", intList.First(i => i % 2 == 0));
            //intList.First(i => i == 100); hata verir
            Console.WriteLine(intList.FirstOrDefault(i => i == 100));

            //First,FirstOrDefault ile aynı
            intList.Last();
        }
        static void Single(IList<int> intList)
        {
            intList.Single(x => x == 7);
            //intList.Single(i => i == 101); hiç kayıt olmadığı için hata verir
            //intList.Single(i => i == 21); birden çok 21 olduğu için hata verir
            intList.SingleOrDefault(i => i == 101);
            //intList.SingleOrDefault(i => i == 21); birden çok 21 olduğu için hata verir
        }
    }
}
