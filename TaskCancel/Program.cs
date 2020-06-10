using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancel
{
    class Program
    {
        static void Main(string[] args)
        {   //https://www.buraksenyurt.com/post/Task-Iptal-Islemlerinin-Izlenmesi(Monitoring-Cancellation)
            //Sample1();
            Sample2();
            Console.ReadKey();
        }
        static void Sample1()
        {
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            Task.Run(() =>
            {
            Thread.Sleep(1000);
            Console.WriteLine("İşlem 1 bitti");

            if (ct.IsCancellationRequested)
            {
                    Console.WriteLine("Görev iptal");
                    return;
                }
                Thread.Sleep(2000);
                Console.WriteLine("İşlem 2 bitti");

                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("Görev iptal");
                    //ct.ThrowIfCancellationRequested(); =>eğer görevin son durumunu iptal edildi olmasını istiyorsak bu satırıda çalıştırmalıyız
                    return;
                }
                Thread.Sleep(1000);
                Console.WriteLine("İşlem 3 bitti");
            }, ct);

            Thread.Sleep(3000);

            ts.Cancel();//Göreve iptal emri veren kod
        }
        static void Sample2()
        {
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            ct.Register(() =>
            {
                Console.WriteLine("Görev iptal olduğu zaman çalışması istenen kodlar");
            });
            Task.Run(() =>
            {
                while (true)//sonsuz döngü
                {
                    Thread.Sleep(100);
                    if (ct.IsCancellationRequested)//görev iptal emri verilmişse buraya girer
                    {
                        break;//döngüyü kırar
                    }
                }
                //daha yapılacak iş olmadığı için işi bitmiş olur
            }, ct);

            Console.WriteLine("İptal için bir tuşa bas...");
            Console.ReadKey();
            ts.Cancel();
        }
    }
}
