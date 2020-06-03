using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            CounterManager counterManager = new UserManager();
            CounterManager counterManager2 = new ClientManager();
            CounterManager counterManager3 = new CounterManager();
            counterManager.Add();
            counterManager.Add();
            counterManager.Add();
            counterManager2.Add();
            Console.WriteLine("Counter1="+counterManager.GetCounter());
            Console.WriteLine("Counter2="+counterManager2.GetCounter());
            Console.WriteLine("Counter3="+counterManager3.GetCounter());
            Console.ReadKey();
        }
    }
    public class CounterManager
    {
        int _counter;
        public void Add()
        {
            Console.WriteLine("Added");
            _counter++;
        }
        public int GetCounter() =>  _counter;
    }
    public class UserManager : CounterManager//Inheritance(kalıtım)
    {
        public void UserMethod() { }
    }
    public class ClientManager : CounterManager
    {
        public void ClientMethod() { }
    }
}
