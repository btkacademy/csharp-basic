using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //async = await kullanılacak metotların başına eklenir(Task,void,lambda ifadeleri)
            //await = asenkron yapılan işlemler tamamlanana kadar sonraki satıra geçmez

            //Run();//asenkron çalıştırır
            //Awaiter();//asenkron çalıştırır
            GetSyncResult();//bu satır çalışırken işlem tamamlanana kadar alt satıra geçmez(senkron çalıştırır)
            Console.WriteLine("Program.cs diğer işler");
            Console.ReadKey();
        }
        static void Run()
        {
            Task.Run(async () =>
            {
                Job();
                await Job2();//eğer burada await koyulmasaydı Job3 daha önce biterdi
                int Result = await Job3();//eğer burada await koyulmasaydı result bilgisini alamazdık
            });
            Console.WriteLine("Diğer işler");
        }
        static void Awaiter()
        {
            var awaiter= Job3().GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                var result = awaiter.GetResult();
                Console.WriteLine(result);
            });
        }
        static void GetSyncResult()
        {
            int Result=Job3().Result;
            Console.WriteLine(Result);
        }
        #region Jobs
        static void Job()
        {
            Console.WriteLine("Job done");
        }
        static async Task Job2()
        {
            await Task.Delay(3000);//1 saniye bekle
            Console.WriteLine("Job2 done");
        }
        static async Task<int> Job3()
        {
            await Task.Delay(2000);//2 saniye bekle
            Console.WriteLine("Job3 done");
            return 0;
        }
        #endregion
    }
}
