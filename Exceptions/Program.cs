using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionHandling();
            TryFinally();
            Console.ReadKey();
        }
        static void ExceptionHandling()
        {
            Calc calc = new Calc(10, 0);
            try
            {
                int result = calc.Divide();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Sıfıra bölme hatası oluştu");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Genel hata oluştu detay=" + exception.ToString());
            }
            finally
            {
                Console.WriteLine("Tüm işler bitti");
            }
        }
        static void TryFinally()
        {
            try
            {
                Console.WriteLine("İşlem başladı");
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            finally 
            {
                Console.WriteLine("Tüm işler bitti(try-finally)");
            }
        }
    }
    public class Calc
    {
        int _number1;
        int _number2;
        public Calc(int Number1, int Number2)
        {
            _number1 = Number1;
            _number2 = Number2;
        }
        public int Divide()
        {
            return _number1 / _number2;
        }
    }
}
