using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            //For();
            //Foreach();
            //Break();
            SampleWithParallel();
            //SampleWithTask();
            Console.ReadLine();
        }
        static void For()
        {
            Parallel.For(1, 11, i =>
            {
                Console.WriteLine(i + " başladı");
                Thread.Sleep(2000);
                Console.WriteLine(i + " bitti");
            });
        }
        static void Foreach()
        {
            var numbers = Enumerable.Range(1, 15);
            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine(i + " başladı");
                Thread.Sleep(1000);
                Console.WriteLine(i + " bitti");
            });
        }
        static void Break()
        {
            Console.WriteLine("Başladı");
            ParallelLoopResult result = Parallel.For(0, 10, (int i, ParallelLoopState loopState) =>
            {
                Console.WriteLine(i + " geldi");
                if (i == 5)
                {
                    //Thread.Sleep(10); //=>!!!eş zamanlı çalıştığı için burada uyutma işlemi yaptığımızda döngüyü kırına kadar diğer döngüler tamamlanmış oluyor
                    Console.WriteLine("Döngü kırıldı");
                    loopState.Break();
                }
            });
            Console.WriteLine("Çıktı");
            Console.WriteLine(result.IsCompleted);//Döngü kırılmışsa false sonuç döner
            Console.WriteLine(result.LowestBreakIteration);//kaçıncı iterasyonda kırıldığını verir eğer kırılma olmazsa null döner
        }

        static void SampleWithParallel()
        {
            Parallel.For(1, 1000, i =>
            {
                Console.WriteLine(i + " başladı");
                int f = 0;
                for (int z = 0; z < 100000000; z++)
                {
                    f += z;
                }
                Console.WriteLine(i + " bitti");
            });
        }
        static void SampleWithTask()
        {
            for (int i = 0; i < 1000; i++)
            {
                int c = i;//c ye aktarmak yerine görev içinde i yi kullansaydık sürekli aynı sonuçları vermeye başlayacaktı çünkü görev başladığı anda i çoktan sonraki döngüye girmiş oluyor
                Task.Run(() =>
                {
                    Console.WriteLine(c + " başladı");
                    int f = 0;
                    for (int z = 0; z < 100000000; z++)
                    {
                        f += z;
                    }
                    Console.WriteLine(c + " bitti");
                });
            }
        }

    }
}
