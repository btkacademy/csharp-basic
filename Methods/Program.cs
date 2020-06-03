using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <=3; i++)
                DoSomething();

            SkipCode();

            Console.Write("Adınız=");
            string name = Console.ReadLine();
            SayHi(name);

            Console.Write("Sayı girin=");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Faktöriyel="+GetFactorial(number));

            Console.WriteLine(Add(15));
            Console.WriteLine(Add2(15,60));

            Console.ReadKey();
        }
        static void DoSomething()
        {
            Console.WriteLine("Just do it");
        }
        static void SkipCode()
        {
            return;//alta yazılan kod hiçbir zaman çalışmayacaktır metottan çıkmak istediğimizde kullanırız
            Console.WriteLine("Çalışmayacak kod");
        }
        static void SayHi(string name)
        {
            Console.WriteLine("Selam " + name);
        }
        static int GetFactorial(int number)
        {
            int factor = 1;
            for (int i=number; i > 1; i--)
                factor *= i;
            return factor;
        }
        static int Add(int number1,int number2=10)
        {
            return number1 + number2;
        }
        static int Add2(int number1, int number2 = 15) => number1 + number2;//Add metodunun farklı syntaxla yazılmış hali
    }
}
