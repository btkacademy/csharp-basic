using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Act();
            Function();
            Console.ReadKey();
        }
        #region Action
        static void Act()
        {
            HandException(() =>
            {
                int number1 = 10, number2 = 0;
                int result = number1 / number2;
            });

            Action<string> action = Greeting;
            action += delegate (string name)
            {
                Console.WriteLine("2.iş parametre verilen isim=" + name);
            };
            action += (string name) =>
            {
                Console.WriteLine("3.iş parametre verilen isim=" + name);
            };
            action("Ahmet Faruk");
            action("Aygün");
        }
        static void HandException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmeyen sorun oluştu");
            }
        }
        static void Greeting(string name)
        {
            Console.WriteLine("Merhaba " + name);
        }
        #endregion
        static void Function()
        {
            Func<int> getRandom = () =>
            {
                Random r = new Random();
                System.Threading.Thread.Sleep(100);
                return r.Next(1, 100);
            };

            Func<int, int, int> Topla = Add;
            Console.WriteLine(Topla(getRandom(), getRandom()));

        }
        static int Add(int number1, int number2)
        {
            Console.WriteLine("Sayı1="+number1);
            Console.WriteLine("Sayı2="+number2);
            return number1 + number2;
        }
    }
}
