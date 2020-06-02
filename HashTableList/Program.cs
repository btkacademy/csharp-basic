using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictonary sınıfının güvenli tip olmadığı halidir
            Hashtable hashtable = new Hashtable();//System.Collections kütüphanesi altında
            hashtable.Add("key1", "değer1");
            //hashtable.Add("key1", "değer1"); hata verir zaten bu anahtara sahip bir eleman var
            Console.WriteLine(hashtable["key1"]);

            if (hashtable.ContainsKey("key4"))
                Console.WriteLine("4 keyine sahip eleman var");
            if (hashtable.ContainsValue("değer1"))
                Console.WriteLine("değer1 adına sahip eleman var");
            Console.ReadKey();
        }
    }
}
