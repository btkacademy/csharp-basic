using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskStart();
            //TaskWithReturn();
            //ContinueWith();
            ContinueWithState();
            Console.ReadKey();
        }
        static void TaskStart()
        {
            Console.WriteLine("Tüm işlemler başladı");
            Task t = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var threadId = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine("Thread Id:" + threadId);
                }
            });
            t.Start();//işlemi başlatır
            for (int i = 0; i < 100; i++)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("Thread Id " + threadId);
            }
            t.Wait();//işlem bitene kadar alt satıra geçmez
           Console.WriteLine("Tüm işlemler bitti");
        }
        static void TaskWithReturn()
        {
            Task<int> t = Task.Run(() =>
            {
                return DateTime.Now.Year;
            });
            Console.WriteLine(t.Result); 
        }
        static void ContinueWith()
        {
            Task<int> t = Task.Run(() =>
            {
                return DateTime.Now.Year;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine(i.Result);
            });
        }
        static void ContinueWithState()
        {
            Task<int> t = Task.Run(() =>
            {
                //throw new Exception("123"); => bu satır çalıştığında ekrana Faulted yazar
                return DateTime.Now.Year;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);//sadece iptal edildiğinde çalışır

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);//sadece hataya düştüğünde çalışır

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine(i.Result);
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);//sadece işlem tamamlandığında

        }
    }
}
