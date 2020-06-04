using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            //private               =>sadece kendi erişebilir
            //protected             =>kalıtım ile miras alınmış çocuk sınıflar erişebilir
            //protected internal    =>aynı derlemedeki kalıtım ile miras alınmış çocuk sınıflar erişebilir
            //internal              =>aynı derlemedeki(asssembly) dosyalar erişebilir farklı bir projeden referans verildiği zaman erişilemez
            //public                =>herkes erişebilir

            Test2 test2 = new Test2();
            test2.field3 = 20;//protected internal
            test2.field4 = 30;//internal
            test2.field5 = 40;//public
        }
    }
    public class Test
    {
        private int filed1;
        protected int field2;
        protected internal int field3;
        internal int field4;
        public int field5;
    }
    public class Test2 : Test
    {
        public Test2()
        {
            field2 = 10;
            field3 = 20;
            field4 = 30;
            field5 = 40;
        }
    }
}
