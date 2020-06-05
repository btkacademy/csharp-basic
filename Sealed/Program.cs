
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seal
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Base
    {
        protected virtual  void F() { Console.WriteLine("Base.F"); }//Sealed yapılamaz
        protected virtual void F2() { Console.WriteLine("Base.F2"); }
    }

    class Inherit1 : Base
    {
        sealed protected override void F() { Console.WriteLine("Inherit1.F"); }//Sadece override edilebilen metotlarda yapılabilir
        protected override void F2() { Console.WriteLine("Inherit1.F2"); }
    }

    sealed class Inherit2 : Inherit1//Sınıflarda sealed yapılabilir
    {
         //protected override void F() { Console.WriteLine("Z.F"); } => hata verir sealed ile override edildiği için
        protected override void F2() { Console.WriteLine("Z.F2"); }
    }

    //class Inherit3 : Inherit2 {})=>Hata verir
   
}
