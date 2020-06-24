using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple_
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tuples = OldMethod();
            ////tuples.Item1 = 10; //sadece okunabilir (immutable)
            //Console.WriteLine(tuples.Item1);
            //OldMethod(Tuple.Create(1, "Yazı", true));

            var tuples2 = NewMethod();
            Console.WriteLine(tuples2.Item1);//iki şekildede değere ulaşabiliriz
            Console.WriteLine(tuples2.field1);
            tuples2.field1 = "123";//veri istenirse değiştirilebilir(mutable)
            NewMethod(tuples2);

            Console.ReadKey();
        }
        static void OldMethod(Tuple<int, string, bool> ComplexType)
        {
            Console.WriteLine(ComplexType.Item1);
            Console.WriteLine(ComplexType.Item2);
            Console.WriteLine(ComplexType.Item3);
            //ComplexType.Item2 = "metin"; =>immutable hata verir
        }
        static Tuple<int, string, bool> OldMethod()
        {
            return Tuple.Create(2, "Geri dön", false);
        }

        static void NewMethod((string field1, int field2) ComplexType)
        {
            Console.WriteLine(ComplexType.field1);
            ComplexType.field2 = 100;//mutable 
            Console.WriteLine(ComplexType.field2);
        }
        static (string field1, int filed2) NewMethod()
        {
            var unnamed = ("one", "two");//şeklindede isimsiz olarak tanımlanabilir
            unnamed.Item1 = "bir";

            return ("Yeni tuple", 10);
        }
    }
}
