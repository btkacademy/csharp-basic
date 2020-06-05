using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialDefine
{
    class Program
    {
        static void Main(string[] args)
        {
            Cls cls = new Cls();
            cls.method1();
            cls.method2();
            Console.ReadKey();
        }
    }
    partial class Cls//Sınıf düzeyinde parçalama
    {
        public void method1() { Console.WriteLine("Method1"); method3(); }
        partial void method3();//Metot düzeyinde parçalama(erişim bildirgeçleri tanımlanamaz ve void olmak zorundadırlar)
    }

    partial class Cls//Sınıf düzeyinde parçalama
    {
        public void method2() { Console.WriteLine("Method2"); }
        partial void method3() { Console.WriteLine("Method3"); }
    }
}
