using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partitioning
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strList = new List<string>() { "bir", "iki", "üç", "dört", "beş" };
            //Skip(strList);
            //SkipWhile(strList);
            //SkilWhileWithIndex();
            //Take(strList);
            //TakeWhile(strList);
            PagingSample(3, 5);

            Console.ReadKey();
        }
        static void Skip(IList<string> strList)
        {
            var newList = strList.Skip(2);

            foreach (var str in newList)
                Console.WriteLine(str);
        }
        static void SkipWhile(IList<string> strList)
        {
            var newList = strList.SkipWhile(s => s.Length == 3);
            //şart sağlandığı sürece atlar şart bir kere sağlanmadığı zaman daha sonrakilerde kontrol yapmaz
            //bir=3 karakter iki=3 karakter üç=2 karakter burada döngüsü kırılır
            //üç dört beş yazar
            foreach (var str in newList)
                Console.WriteLine(str);
        }
        static void SkilWhileWithIndex()
        {
            IList<string> strList2 = new List<string>() { "1", "11", "11", "1111", "11111" };
            var result = strList2.SkipWhile((s, i) => s.Length > i);
            //şart sağlandığı sürece atlamaya devam edecek
            //[2] de 11 değerinin uzunluğu indexinden büyük olmadığı için döngü bir kere kırılacak sonrası için kontrol yapmayacak
            //11 1111 1111 yazar
            foreach (string str in result)
                Console.WriteLine(str);
        }
        static void Take(IList<string> strList)
        {
            var newList = strList.Take(2);

            foreach (var str in newList)
                Console.WriteLine(str);
        }
        static void TakeWhile(IList<string> strList)
        {
            var result = strList.TakeWhile(s => s.Length == 3);
            //skipwhile ile aynı mantıkta çalışır onda şart sağlandığı sürece değerleri atlarken bunda şartın sağladığı değerleri alır
            //bir iki yazar üç de şart sağlanmadığı için döngü kırılır
            foreach (var str in result)
                Console.WriteLine(str);
        }
        static void PagingSample(int Page, int PageSize)
        {
            var Rows = Enumerable.Range(1, 100);
            var Result = Rows.Skip(PageSize * (Page - 1)).Take(PageSize);
            foreach (var item in Result)
                Console.WriteLine(item);
        }
    }
}
