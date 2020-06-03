using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessKeywords
{
    class Program
    {
        static void Main(string[] args)
        {   
            //this => bulunmuş olduğun sınıf içindeki nesnelere erişmeni sağlar
            //base => ata sınıfın içindeki nesnelere erişmeni sağlar
            BaseClass baseClass = new ChildClass(10);
            baseClass.DoSomething();
            baseClass.DoSomething2();
            Console.ReadKey();
        }
    }
    public class BaseClass
    {
        int Counter;
        public BaseClass(int Counter)
        {
            this.Counter = Counter;
        }
        public virtual void DoSomething()
        {
            Console.WriteLine("Base do");
        }
        public virtual void DoSomething2()
        {
            Console.WriteLine("Base do 2");
        }
    }
    public class ChildClass : BaseClass
    {
        public ChildClass(int Counter) : base (Counter)
        {
        }
        public override void DoSomething()
        {
            Console.WriteLine("Child do");
            base.DoSomething();
        }
        public override void DoSomething2()
        {
            Console.WriteLine("Child do 2");
        }
    }
}
