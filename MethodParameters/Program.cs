using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int refNumber = 10;
            WithRef(ref refNumber);
            Console.WriteLine(refNumber);

            //Refden farkı varsayılan değer verilmek zorunda değildir,metot içinde out olarak alınan parametrenin set edilmesi zorunludur yoksa hata verir
            int outNumber;
            WithOut(out outNumber);
            Console.WriteLine(outNumber);

            Concat("metin1", "metin2", "metin3");

            Console.ReadKey();
        }
        static void WithRef(ref int number)
        {
            number *= 2;
        }
        static void WithOut(out int number)
        {
            //number *= 2; => hata verir
            number = 50;
        }
        //static void WithIn(in int number){} //c# 7.2 den sonra gelen keyword basitçe ref readonly olarak kullanılır value set edemezsin sadece okuyabilirsin
        static void Concat(params string[] strings)
        {
            Console.WriteLine(string.Join("\n",strings));
        }
    }
}
