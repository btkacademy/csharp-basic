using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "cümlede a varmı?";
            if(word.CheckA())
                Console.WriteLine("cümlede a var");
            if(Utilities.CheckB(word))
                Console.WriteLine("cümlede b var");

            Console.ReadKey();
        }
    }
    public static class Utilities
    {
        public static bool CheckA(this string str)
        {
            return str.ToLower().Contains("a");
        }
        public static bool CheckB(string str)
        {
            return str.ToLower().Contains("b");
        }
    }
}
