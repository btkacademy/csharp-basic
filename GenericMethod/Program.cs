using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ahmet Faruk";
            if (name.In("Can", "Murat", "Fatma", "Ahmet Faruk"))
                Console.WriteLine(string.Format("{0} adı verilen listede var", name));
            else
                Console.WriteLine(string.Format("{0} adı verilen listede yok", name));

            int number = 10;
            if (number.In(5, 15, 20, 25))
                Console.WriteLine(string.Format("{0} sayısı verilen listede var", number));
            else
                Console.WriteLine(string.Format("{0} sayısı verilen listede yok", number));

            Console.ReadKey();
        }
    }
    public static class Extensions
    {
        public static bool In<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }

    }
}
