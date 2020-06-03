using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    class Program
    {
        static void Main(string[] args)
        {   
            Add(1, 10);
            Add(1.1, 10.1);
            Console.WriteLine(Add("metin1","metin2"));//!!!overload edilmiş metotların geri dönüş tipleri farklı olabilir
            Console.ReadKey();
        }
        static void Add(int n1,int n2)
        {
            Console.WriteLine("int metodu çalıştı sonuç="+(n1 + n2));
        }
        static void Add(double n1,double n2)
        {
            Console.WriteLine("double metodu çalıştı sonuç=" + (n1 + n2));
        }
        static string Add(string str1,string str2)
        {
            return str1 + str2;
        }
    }
}
