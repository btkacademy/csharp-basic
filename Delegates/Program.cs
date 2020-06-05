using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void RouteDelegate();
        public delegate int Calc(int number1, int number2);
        static void Main(string[] args)
        {
            //Sample1();
            //Sample2();
            Doit(Sample1);
            Doit(() =>
            {
                int number1 = 10,number2=0;
                int result = number1 / number2;
            });
            Doit(delegate ()
            {
                Console.Write("Different syntax");
            });
            Console.ReadKey();
        }
        #region Sample1
        static void Go(Direcion direcion)
        {
            Console.WriteLine(string.Format("{0} gone.", direcion.ToString()));
        }
        static void Route1()
        {
            Go(Direcion.Left);
            Go(Direcion.Right);
        }
        static void Route2()
        {
            Go(Direcion.Up);
            Go(Direcion.Down);
        }
        static void Sample1()
        {
            RouteDelegate routeDelegate = Route1;
            routeDelegate += Route2;
            routeDelegate += Route2;
            routeDelegate();
        }
        #endregion
        #region Sample2
        static int Add(int number1, int number2) => number1 + number2;
        static int Multiply(int number1, int number2) => number1 * number2;
        static void Sample2()
        {
            Calc calc = Add;
            Console.WriteLine(calc(10, 10));

            calc += Add;
            calc += Multiply;//En son hangi metot atanmışsa onun sonucu gösterir(ama önceki metotlarıda çalıştırır)
            Console.WriteLine(calc(10, 10));
        }
        #endregion
        static void Doit(RouteDelegate routeDelegate)
        {
            try
            {
                routeDelegate.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmeye sorun oluştu detay=" + ex.Message);
            }
        }
    }
    enum Direcion
    {
        Up,
        Down,
        Left,
        Right
    }
}
