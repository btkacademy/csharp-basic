using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    class Program
    {
        static List<int> sayilar = new List<int>();
        static void Main(string[] args)
        {
            //http://www.borakasmer.com/concurrentdictionary-concurrentbag-concurrentqueue-ve-concurrentstack-ile-thread-safe-collectionlar/
            //https://www.gencayyildiz.com/blog/thread-safe-concurrentqueue-concurrentdictionary-concurrentbag-concurrentstack-ve-blockingcollection-koleksiyonlari-ve-kullanim-durumlari/
            //QueueSample();
            //DictionarySample();
            //ConcurrentBagSample();
            ConcurrentStack(20);
            Console.ReadKey();
        }
        #region Queue
        static async void QueueSample()
        {
            #region Queue ile yapımı hata verir
            //Queue persons = new Queue();
            //for (int i = 0; i < 10; i++)
            //    persons.Enqueue(i + ".kişi");
            //var task1 = FillTable(persons, "Masa 1");
            //var task2 = FillTable(persons, "Masa 2");
            //var task3 = FillTable(persons, "Masa 3");
            //await Task.WhenAll(task1, task2, task3);
            #endregion

            ConcurrentQueue<string> cpersons = new ConcurrentQueue<string>();
            for (int i = 0; i < 10; i++)
                cpersons.Enqueue(i + ".kişi");
            var task1 = FillTable(cpersons, "Masa 1");
            var task2 = FillTable(cpersons, "Masa 2");
            var task3 = FillTable(cpersons, "Masa 3");
            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("Masa sırası bitmiştir.");
        }
        static async Task FillTable(Queue persons, string tableName)
        {
            while (persons.Count > 0)
            {
                await Task.Delay(1000);
                Console.WriteLine($"{tableName} - {persons.Dequeue()}");
            }
        }
        static async Task FillTable(ConcurrentQueue<string> cpersons, string tableName)
        {
            while (cpersons.Count > 0)
            {
                await Task.Delay(100);
                if (cpersons.TryDequeue(out string siradaki))
                    Console.WriteLine($"{tableName} - {siradaki}");
            }
        }
        #endregion
        #region Dictionary
        static async void DictionarySample()
        {
            //Dictionary<int, string> dict = new Dictionary<int, string>();
            //var t1=  FillDict(dict, "Grup1");
            //var t2 = FillDict(dict, "Grup2");
            //await Task.WhenAll(t1, t2);
            //foreach (KeyValuePair<int, string> item in dict)
            //    Console.WriteLine($"{item.Key} - {item.Value}");

            ConcurrentDictionary<int, string> cdict = new ConcurrentDictionary<int, string>();
            var t1 = FillDict(cdict, "Grup1");
            var t2 = FillDict(cdict, "Grup2");
            var t3 = FillDict(cdict, "Grup3");
            await Task.WhenAll(t1, t2, t3);
            foreach (KeyValuePair<int, string> item in cdict)
                Console.WriteLine($"{item.Key} - {item.Value}");
        }
        static async Task FillDict(Dictionary<int, string> dict, string Group)
        {
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(100);
                if (!dict.ContainsKey(i))
                    dict.Add(i, Group);
            }
        }
        static async Task FillDict(ConcurrentDictionary<int, string> cdict, string Group)
        {
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(100);
                if (!cdict.ContainsKey(i))
                    cdict.TryAdd(i, Group);
            }
        }
        #endregion
        static void ConcurrentBagSample()
        {
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();
            AutoResetEvent eventRest = new AutoResetEvent(false);
            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i < 6; i++)
                {
                    concurrentBag.Add(i);
                }
                while (concurrentBag.IsEmpty == false)
                {
                    if (concurrentBag.TryTake(out var i))
                    {
                        Console.WriteLine(i);
                    }
                }
                eventRest.WaitOne();
            });
            Task t2 = Task.Factory.StartNew(() =>
            {
                for (int i = 6; i < 9; i++)
                {
                    concurrentBag.Add(i);
                }
                eventRest.Set();
            });
        }
        public static void ConcurrentStack(int maxCount)
        {
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();
            AutoResetEvent eventRest = new AutoResetEvent(false);
            AutoResetEvent eventRest2 = new AutoResetEvent(false);

            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < maxCount; ++i)
                {
                    concurrentStack.Push(i);
                    eventRest.Set();
                    eventRest2.WaitOne();
                }
            });
            Task t2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < maxCount; ++i)
                {
                    eventRest.WaitOne();
                    if (concurrentStack.TryPop(out int item))
                    {
                        Console.WriteLine(item);
                    }
                    eventRest2.Set();
                }
            });
            Task.WaitAll(t1, t2);
            eventRest.Close();
            eventRest2.Close();
        }
    }
}
