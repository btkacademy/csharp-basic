using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            //Distinct();
            //Except();
            //Intersect();
            Union();
            Console.ReadKey();
        }
        static void Distinct()
        {
            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };
            var distinctList1 = intList.Distinct();
            foreach (var str in distinctList1)
                Console.WriteLine(str);
        }
        static void Except()
        {
            IList<string> strList1 = new List<string>() { "bir", "iki", "üç", "dört", "beş" };
            IList<string> strList2 = new List<string>() { "dört", "beş", "altı", "yedi", "sekiz" };
            var result = strList1.Except(strList2);
            foreach (string str in result)
                Console.WriteLine(str);
        }
        static void Intersect()
        {
            IList<string> strList1 = new List<string>() { "bir", "iki", "üç", "dört", "beş" };
            IList<string> strList2 = new List<string>() { "dört", "beş", "altı", "yedi", "sekiz" };
            var result = strList1.Intersect(strList2);
            foreach (string str in result)
                Console.WriteLine(str);
        }
        static void Union()
        {
            IList<string> strList1 = new List<string>() { "bir", "iki", "üç", "dört" };
            IList<string> strList2 = new List<string>() { "iki", "ÜÇ", "dört", "beş" };

            var result = strList1.Union(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }
    }
}
