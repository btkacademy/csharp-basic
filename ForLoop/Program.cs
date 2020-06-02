using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            for (uint i = 0; i < 100; i++)//if'de olduğu gibi döngü içinde çalışması istenilen kod tek satır ise "{}" süslü parantez olmak zorunda değil
                Console.WriteLine(i);
            for (int i = 0; i > -100; i -= 2)
            {
                Console.WriteLine(i);
                Console.WriteLine("****");
            }
            Console.ReadKey();
            for (; ;)
            {
                //sonsuz döngü
                Console.WriteLine("-");
            }
        }
    }
}
