using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Age
    {
        readonly int year;
        readonly int conquer = 1453;//veri atama 1.yöntem
        Age(int year)
        {
            this.year = year;//veri atama 2.yöntem
        }
        void ChangeYear()
        {
            //year = 1967; => hata verir
        }
    }
}
