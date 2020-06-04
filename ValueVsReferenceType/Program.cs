using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueVsReferenceType
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStruct struct1 = new MyStruct();
            struct1.Field1 = 100;
            MyStruct struct2 =struct1;//Deep copy
            struct2.Field1 = 500;
            Console.WriteLine("struct1 field1="+struct1.Field1);
            Console.WriteLine("struct2 field1=" + struct2.Field1);

            MyClass class1 = new MyClass();
            class1.Field1 = 100;
            MyClass class2 = class1;//Shallow copy
            class2.Field1 = 500;
            Console.WriteLine("class1 field1=" + class1.Field1);
            Console.WriteLine("class2 field1=" + class2.Field1);

            Change(struct1);
            Console.WriteLine("Change metodu dışında struct field1=" + struct1.Field1);
            Change(class1);
            Console.WriteLine("Change metodu dışında class field1=" + class1.Field1);

            SetNull(class1);
            if (class1 == null)//!!!!!!metot içinde değiştirilen özellikler geçerli olsada null'a set edildiği zaman parametre olarak gönderilen referans null'a set olmuyor
                Console.WriteLine("SetNull metodu dışında null");
            else
                Console.WriteLine("SetNull metodu dışında class NULL değil!!!");
            Console.ReadKey();

        }
        static void Change(MyStruct myStruct)
        {
            myStruct.Field1 = 1000;
            Console.WriteLine("Change metodu içinde struct field1="+myStruct.Field1);
        }
        static void Change(MyClass myClass)
        {
            myClass.Field1 = 1000;
            Console.WriteLine("Change metodu içinde class field1=" + myClass.Field1);

          
        }
        static void SetNull(MyStruct myStruct)
        {   //structlar null'a set edilemez
            //myStruct = null;
            //if (myStruct == null)
            //    Console.WriteLine("SetNull metodu içinde struct null");
        }
        static void SetNull(MyClass myClass)
        {
            myClass = null;
            if (myClass == null)
                Console.WriteLine("SetNull metodu içinde class null");
        }
    }
    public struct MyStruct//Değer tip(Value type)
    {
        public int Field1 { get; set; }
    }
    public class MyClass//Referans tip(Reference type)
    {
        public int Field1 { get; set; }
    }
}
