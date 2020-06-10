using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample1();
            //Sample2();

            //WaitAll();
            //WaitAny();

            //WhenAll();
            WhenAny();

            Console.ReadKey();
        }
        #region Ana göreve eklenmiş alt görevlerin çalışma sırası(Attaching Child Tasks To A Parent Task)
        static void Sample1()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Ana görev başladı.");
                var child1 = Task.Factory.StartNew(() =>
                {

                    Console.WriteLine("Alt görev başladı.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Alt görev bitti.");
                }, TaskCreationOptions.AttachedToParent);//bu noktada eğer TaskCreationOptions.AttachedToParent enumu verilmezse ana görev alt görevden önce biter
            });
            parent.Wait();
            Console.WriteLine("Ana görev bitti.");
        }
        static void Sample2()
        {
            Task<int[]> parent = new Task<int[]>(() =>
            {
                var results = new int[3];

                new Task(() =>
                {
                    Thread.Sleep(1000);
                    results[0] = 50;
                }, TaskCreationOptions.AttachedToParent).Start();//aynı şekilde burada eğer TaskCreationOptions verilmezse [0] değeri 50 olarak dönsede ana görev daha önce biteceği için 0 yazar

                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();

                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });
            parent.Start();

            var finalTask = parent.ContinueWith(parentTask =>
            {
                var res = parentTask.Result;
                var res2 = parentTask.Result;
                foreach (int i in res)
                    Console.WriteLine(i);
            });
            finalTask.Wait();
        }
        #endregion
        static void WaitAll()
        {   
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });
            Console.WriteLine("Asenkron kısım");
            Task.WaitAll(tasks);//Tüm görevler bitene kadar alt satıra geçmez
            Console.WriteLine("Tüm görevler bitti");
        }
        static void WaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });
            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);//herhangi biri tamamlandığı anda alt satıra geçer geriye tamamlanan görevin indexini verir
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
                
            }
        }
        static async void WhenAll()
        {
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });
            Console.WriteLine("Asenkron kısım");
            await Task.WhenAll(tasks);//Tüm görevler bitene kadar alt satıra geçmez
            //Task.WhenAll(tasks); => bu şekilde çağırılsaydı alt satıra geçerdi
            Console.WriteLine("Tüm görevler bitti");
        }
        static async void WhenAny()
        {
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });
            while (tasks.Length > 0)
            {
                Task<int> completedTask = await Task.WhenAny(tasks);//herhangi biri tamamlandığı anda alt satıra geçer geriye tamamlanan görevin indexini verir!!!await konulmasaydı result alamazdık
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.Remove(completedTask);
                tasks = temp.ToArray();
            }
        }
    }
}
