using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> collection1 = new List<int>() { 1, 2, 3 };
            IList<int> collection2 = new List<int>() { 4, 5, 6 };

            var collection3 = collection1.Concat(collection2);

            foreach (int i in collection3)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
