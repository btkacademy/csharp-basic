using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());//Kullanıcıdan bir sayı alınır

            switch (number)
            {
                case 1:
                    Console.WriteLine("Sayı=1");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("Sayı 2 veya 3'dür");
                    break;
                case 4:
                    Console.WriteLine("Sayı=4");
                    goto case 5;//Bu kod ile 4 girilsede 5 olduğu zaman ne çalışıyorsa o çalışır
                case 5:
                    Console.WriteLine("Sayı 5'den küçüktür");
                    break;
                case int val when val > 5 && val < 10://Mantıksal operatörlerle birlikte kullanımı
                    Console.WriteLine("Sayı 5 den büyük ve 10 dan küçüktür");
                    break;
                default:
                    Console.WriteLine("Hiçbir şart sağlanmadığı zaman çalışması istenilen kod bloğu");
                    break;
            }
            Console.ReadKey();
        }
    }
}
