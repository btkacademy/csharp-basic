using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {   //Referans tiplerdir(Value type)
            Struct1 str;
            str.field1 = 10;
            //str.prop1 = 250; =>hata verir
            Console.WriteLine(str.field1);

            Struct1 str2 = new Struct1();
            str2.prop1 = 350;
            Console.WriteLine(str2.field1);

            Console.ReadKey();
        }
    }
    public struct Struct1
    {
        //public Struct1() { } => yapıcı fonksiyonları olmaz
        public int field1;
        public int prop1 { get; set; }
        public void TestMethod()
        {
            Console.WriteLine("Test metodu");
        }
    }
    public struct Struct2 : IInterface1
    {
        public void Do()
        {
            Console.WriteLine("Do it");
        }
    }
    //public struct Struct3 : Struct1 { } =>Hata verir
    //public struct Struct4 : Class1 { } =>Hata verir

    public interface IInterface1
    {
        void Do();
    }
    public class Class1
    {
        public int field1;
    }
}
