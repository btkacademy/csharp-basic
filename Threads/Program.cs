using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://codewithshadman.com/tag/csharp-multithreading/
            //Thread.CurrentThread.ManagedThreadId => o an çalışan işlem idsi
            //Thread.Sleep(1000) => milisaniye cinsinden verilen süre kadar bekle demek
            //ThreadStart();
            //ThreadStartWithParameter();
            //ThreadWithPriority();
            ThreadJoin();
            Console.ReadKey();
        }
        static void ThreadStart()
        {
            Thread th1 = new Thread(new ThreadStart(WriteX));
            Thread th2 = new Thread(new ThreadStart(WriteO));
            th1.Start();
            th2.Start();
        }
        static void ThreadStartWithParameter()
        {
            Thread thread = new Thread(() => Method("işlem 1"));
            thread.Start();
            Console.WriteLine("Başka işler");
            for (int i = 0; i < 5; i++)
                Console.WriteLine(i);
        }
        static void ThreadWithPriority()
        {
            Thread th1 = new Thread(new ThreadStart(WriteX));
            Thread th2 = new Thread(new ThreadStart(WriteO));
            th1.Priority = ThreadPriority.Lowest;
            th2.Priority = ThreadPriority.Highest;
            th1.Start();
            th2.Start();
        }
        static void ThreadJoin()
        {
            Thread th1 = new Thread(new System.Threading.ThreadStart(()=> 
            {
                Method("uzun süren işlem");
            }));
            th1.Start();
            Console.WriteLine("Diğer işler");
            th1.Join();//işlem bitene kadar alt satıra geçmez
            //th1.Join(3000);//3 saniye içinde işi bititre true bitiremezse false döner 
            for (int i = 0; i < 5; i++)
                Console.WriteLine(i);
        }
        static void WriteX()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("X");
            }
        }
        static void WriteO()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("O");
            }
        }
        static void Method(string ProcName)
        {
            Console.WriteLine(ProcName+" başladı");
            Thread.Sleep(5000);
            Console.WriteLine(ProcName+ " bitti");
        }
    }
}
