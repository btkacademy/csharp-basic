using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Ali");
            names.Add("Ayşe");
            names.AddRange(new string[]
            {
                "Leyla",
                "Murat",
                "a",
                "a",
                "a"
            });
            names.Insert(1, "Ayşe yerine eklenen");
            names.Remove("Leyla");//ilk bulduğu elemanı siler
            names.RemoveAt(1);//Ayşe yerine eklenen elemanını siler
            names.RemoveAll(x => x == "a");//"a" ismindeki tüm elemanları siler
            if (names.Contains("Murat"))
                Console.WriteLine("Murat adında eleman var demektir");
            Console.WriteLine(names.IndexOf("Murat"));//bulduğu ilk elemanın indexini verir eğer verilen isimdeki elemanı bulamazsa -1 döner
            string[] staticarray = names.ToArray();//tüm diziyi statik diziye aktarır
            names.Clear();//tüm elemanları siler
            Console.ReadKey();
        }
    }
}
