using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in readNumber())
                Console.WriteLine(item);

            foreach (var item in Power(3,3))//üslü sayı hesaplama
                Console.WriteLine(item);

            Console.ReadKey();
        }
        static IEnumerable<int> readNumber()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }
    }
}
