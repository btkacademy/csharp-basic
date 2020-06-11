using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafe
{
    class Program
    {
        delegate void ASenkronMetodHandler();
        static void Main(string[] args)
        {
            //Sample1();
            Sample2();
            Console.ReadKey();
        }
        static void Sample1()
        {
            Account account = new Account(100);
            Parallel.For(1, 20, a =>//Eş zamanlı 20 defa para çekme talebinde bulunuyor
            {
                //account.WithdrawLock(50);
                account.WithdrawMonitor(50);
            });
            Console.WriteLine("Son para : " + account.Money);
        }
        static void Sample2()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread thread = new Thread(() =>
                {
                    //Manager manager = Manager.CreateManagerUnsafe();
                    Manager manager = Manager.CreateManagerSafe();
                });
                thread.Start();
            }
        }
    }
    class Account
    {
        private Object lockObject = new Object();
        public int Money;
        Random r = new Random();
        public Account(int Money)
        {
            this.Money = Money;
        }
        public void WithdrawLock(int amount)
        {
            lock (lockObject)
            //Eğer burada kitleme işlemi yapmazsak eş zamanlı gelen isteklerde düşen para henüz diğer threadlardaki Money değişkeni için güncellenmemiş olacaktı eksiye düşülecekti
            //****Senaryo 100 lira para var 3 thread aynı anda 50 lira çekmeye çalıştığında Money değişkeni hepsinde 100 lira olacaktı if (Money >= amount) şartını sağladığı için 3 görevde kod bloğuna girecekti ve kalan para -50 olacaktı
            //lock kullanıldığı zaman lock bloğu içinde gelen eş zamanlı istekleri sıraya alır ve her bir istek bittiğinde diğerine geçer böyle bir durumda 3 thread aynı anda para çekme metoduna girsede if (Money >= amount) şartını senkron yürüteceği için Money değişkeni 0'ın altına düşürmeyecek  
            {
                if (Money < 0)
                {
                    Console.WriteLine("Negatife düştü");
                    return;
                    //throw new Exception("Negatife düştü");
                }
                if (Money >= amount)
                {
                    Console.WriteLine("Para : " + Money);
                    Console.WriteLine("Çekilecek para :" + amount);
                    Money = Money - amount;
                    Console.WriteLine("Kalan para : " + Money);
                }
            }
        }
        public void WithdrawMonitor(int amount)
        {
            bool lockTaken = false;
            Monitor.Enter(lockObject, ref lockTaken);
            try
            {
                if (Money < 0)
                {
                    Console.WriteLine("Negatife düştü");
                    return;
                    //throw new Exception("Negatife düştü");
                }
                if (Money >= amount)
                {
                    Console.WriteLine("Para : " + Money);
                    Console.WriteLine("Çekilecek para :" + amount);
                    Money = Money - amount;
                    Console.WriteLine("Kalan para : " + Money);
                }
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(lockObject);
            }
        }
    }
    class Manager
    {
        static string lockobj = string.Empty;//lock objesi null olmayan referans tiplerden oluşabilir 
        static Manager manager;
        public static Manager CreateManagerSafe()
        {
            lock(lockobj)
            {
                if (manager == null)
                {
                    Thread.Sleep(1);
                    manager = new Manager();
                    Console.WriteLine("Manager oluşturuldu");
                }
                return manager;
            }
        }
        public static Manager CreateManagerUnsafe()
        {
            if (manager == null)
            {
                Thread.Sleep(1);
                manager = new Manager();
                Console.WriteLine("Manager oluşturuldu");
            }
            return manager;
        }
    }
}
