using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generation
{
    class Program
    {
        static void Main(string[] args)
        {
            //DefaultIfEmpty();
            //Empty();
            //Range();
            Repeat();
            Console.ReadKey();
        }
        static void DefaultIfEmpty()
        {
            IList<string> emptyList = new List<string>();

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("Yok");

            Console.WriteLine("Toplam kayıt: {0}", newList1.Count());
            Console.WriteLine("Değer: {0}", newList1.ElementAt(0));//string.Empty

            Console.WriteLine("Toplam kayıt: {0}", newList2.Count());
            Console.WriteLine("Değer: {0}", newList2.ElementAt(0));//Yok
        }
        static void Empty()
        {
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<int>();

            Console.WriteLine("Toplam kayıt: {0} ", emptyCollection1.Count());
            Console.WriteLine("Tür: {0} ", emptyCollection1.GetType().Name);

            Console.WriteLine("Toplam kayıt: {0} ", emptyCollection2.Count());
            Console.WriteLine("Tür: {0} ", emptyCollection2.GetType().Name);
        }
        static void Range()
        {
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("Toplam kayıt: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Index {0} değer {1}", i, intCollection.ElementAt(i));
        }
        static void Repeat()
        {
            var intCollection = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("Toplam kayıt: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Index {0} değer {1}", i, intCollection.ElementAt(i));
        }
    }
}
