using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeachLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cities = new List<string>
            {
                "istanbul",
                "berlin",
                "paris"
            };
            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }
            Console.ReadKey();
        }
    }
}
