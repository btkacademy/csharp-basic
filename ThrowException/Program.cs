using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Throwing();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Sorun oluştu mesaj=" + exception.Message);
            }

            try
            {
                CustomException();
            }
            catch (MyException myException)
            {
                Console.WriteLine(string.Format("Sorun oluştu\nHata başlığı={0}\nMesaj={1}\nHata alma tarihi={2}",myException.ExceptionHeader,myException.Message,myException.ExceptionDate));
            }
         
            Console.ReadKey();
        }
        static void Throwing()
        {
            string word = null;
            if (word == null)
                throw new Exception("Word değişkeni null");
        }
        static void CustomException()
        {
            int dateOfBith = DateTime.Now.Year + 1;
            if (dateOfBith > DateTime.Now.Year)
                throw new MyException("Doğum tarihi ileri tarih olamaz","Tarih");
        }
    }
    public class MyException : Exception
    {
        public DateTime ExceptionDate{ get; private set; }
        public string ExceptionHeader { get; private set; }
        public MyException(string Message,string ExceptionHeader) : base(Message)
        {
            ExceptionDate = DateTime.Now;
            this.ExceptionHeader = ExceptionHeader;
        }
    }
}
