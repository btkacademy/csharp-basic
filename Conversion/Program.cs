using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[] { 1, 2, 3, 4, 5 };
            //AsEnumerableAsQueryable(ints);
            //Cast(ints);
            //List<int> result = ToList(ints);
            //int[] result2 = ToArray(result);
            ToDictionary(ints);
            Console.ReadKey();
        }
        static void AsEnumerableAsQueryable(int[] ints)
        {
            ReportTypeProperties(ints);
            ReportTypeProperties(ints.AsEnumerable());
            ReportTypeProperties(ints.AsQueryable());
        }
        static void Cast(int[] ints) => ReportTypeProperties(ints.Cast<int>());
        static List<int> ToList(int[] ints) => ints.ToList();
        static int[] ToArray(List<int> ints) => ints.ToArray();
        static void ToDictionary(int[] ints)
        {
            var dicts = ints.ToDictionary<int, int>(x => x * 2);
            foreach (var item in dicts)
                Console.WriteLine(string.Format("Key={0} Value={1}", item.Key, item.Value));
        }
        static void ReportTypeProperties<T>(T obj)
        {
            Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
            Console.WriteLine("Actual type: {0}", obj.GetType().Name);
        }
    }
}
