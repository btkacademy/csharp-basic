using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch_
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();//System.Diagnostics

            stopwatch.Start();

            //performansı ölçülecek işlemler yazılır
            System.Threading.Thread.Sleep(3000);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
