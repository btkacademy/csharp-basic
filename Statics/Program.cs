using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StaticClass.field1);

            SomeClass.Do();
            SomeClass someClass = new SomeClass();
            someClass.Do2();
            someClass.Increment();

            SomeClass someClass2 = new SomeClass();
            someClass2.Increment();

            Console.WriteLine("Someclass field2="+someClass.filed2);
            Console.WriteLine("Someclass2 field2=" + someClass2.filed2);
            Console.WriteLine("SomeClass field1=" + SomeClass.filed1);
            Console.ReadKey();
        }
    }
    static class StaticClass
    {   //Herşey static olmak zorunda
        public static int field1 = 10;
        static StaticClass()
        {
            Console.WriteLine("Static class constructer");
        }
    }
    class SomeClass
    {
        public static int filed1;
        public int filed2;
      
        public static void Do()
        {   //Sadece static nesnelere erişilebilir 
            filed1 = filed1;
            //field2=field2=> erişilemez
            Console.WriteLine("Do");
        }
        public void Do2()
        {
            Console.WriteLine("Do2");
        }
        public void Increment()
        {
            filed1++;
            filed2++;
        }
    }
}
