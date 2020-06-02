using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = string.Empty;
            int counter = 0;
            do
            {
                key = Console.ReadLine();
                counter++;
            } while (key=="a");//a tuşuna hiç basmasa bile 1 defa çalışır
            Console.WriteLine("Tuşa basma sayısı="+counter);
            Console.ReadKey();
        }
    }
}
