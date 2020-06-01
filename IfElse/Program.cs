using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfElse
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Karşılaştırma Operatörleri(Comparison Operators)
                ==	Eşitlik
                <	Küçük
                >	Büyük
                <=	Küçük eşit
                >=	Büyük eşit
                !=	Eşit değil

            Mantıksal Operatörler(Logical Operators)
                &&	Ve
                ||	Veya
                !   Değil
            */
            int number = int.Parse(Console.ReadLine());//Kullanıcıdan bir sayı alınır

            //Eğer şart doğru olduğunda çalışması istenilen kod tek satır ise "{}" süslü parantez içersinde olmak zorunda değil
            if (number > 10)
                Console.WriteLine("Sayı 10 dan büyük");

            //Şart doğruysa birden çok satır çalışacağından dolayı süslü parantez içinde yazıldı
            if (number > 100)
            {
                Console.WriteLine("Sayı 10 dan büyük");
                Console.WriteLine("Sayı 100 den büyük");
            }

            //Şart doğru değilse çalışması istenilen kodlar olduğunda
            if (number > 0)
            {
                Console.WriteLine("Sayı pozitif");
            }
            else//şart doğru değilse buraya gelir
            {
                Console.WriteLine("Sayı 0 veya negatif");
            }

            //Birden çok şart olduğunda mantıksal operatörlerle birlikte istenilen şart kurulur
            if (number > 0 && number < 100)
            {
                Console.WriteLine("Sayı 0-100 arasındadır");
                if (number < 50)
                    Console.WriteLine("Sayı 0-50 arasındadır");
                else if (number < 70)
                    Console.WriteLine("Sayı 50-70 arasındadır");//Sayı eğer 50'den küçükse üstteki şarta gireceği için buraya gelmişse en az 50 demektir
                else
                    Console.WriteLine("Sayı 70-100 arasındadır");
            }

            //Tek satır şartlar(Single line if)
            Console.WriteLine(number > 10 && number <= 20 ? "Sayı 10 dan büyük ve 20'ye küçük eşittir" : "Sayı 10 dan küçük veya 20 den büyüktür");
            Console.WriteLine(number > 0 && number <= 100 
                ?(number<50? "Sayı 0-50 arasındadır": number<70? "Sayı 50-70 arasındadır" : "Sayı 70-100 arasındadır")
                : "Sayı 0-100 arasında değildir"
                );

            Console.ReadKey();
        }
    }
}
