using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample();
            BuilderVsDefault();
            Console.ReadKey();
        }
        static void Sample()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Ahmet");
            stringBuilder.AppendLine();
            stringBuilder.Append("Faruk");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("ULU");
            Console.WriteLine(stringBuilder.ToString());
        }
        static void BuilderVsDefault()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str = string.Empty;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                str += "a";
            }
            stopwatch.Stop();
            Console.WriteLine("Varsayılan string: {0}", stopwatch.Elapsed);

            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                stringBuilder.Append("a");
            }
            stopwatch.Stop();
            Console.WriteLine("String builder: {0}", stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
