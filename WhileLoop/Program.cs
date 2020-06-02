using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = Convert.ToInt32(Console.ReadLine());
            while(counter>0)
            {
                Console.WriteLine(counter);
                counter--;
            }
            #region Örnek
            List<string> letters = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e"
            };
            while(letters.Count>0)
            {
                Console.WriteLine(letters[0]);
                letters.RemoveAt(0);
            }
            #endregion
            Console.ReadKey();
            while(true)
            {
                //sonsuz döngü
                Console.WriteLine("*");
            }
        }
    }
}
