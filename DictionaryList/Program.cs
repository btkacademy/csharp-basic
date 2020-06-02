using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "bir");
            //dict.Add(1, "bir"); hata verir zaten bu anahtara sahip bir eleman var
            dict.Add(2, "iki");
            dict.Add(3, "üç");
            dict.Add(4, "dört");

            Console.WriteLine(dict[3]);//üç yazar köşeli parantez içinde index değil 3 keyine sahip elemanın değerini ver demek oluyor
            Console.WriteLine(dict.Keys.ElementAt(1));//2 yazar
            Console.WriteLine(dict.Values.ElementAt(1));//iki yazar

            if(dict.ContainsKey(4))
                Console.WriteLine("4 keyine sahip eleman var");
            if(dict.ContainsValue("beş"))
                Console.WriteLine("beş değerine sahip eleman var");
            dict.Contains(new KeyValuePair<int, string>(6, "altı"));//"6" keyine ve "altı" değerine sahip eleman varsa true dönder

            if(dict.TryGetValue(3,out string _str))//eğer verilen key elemanı yoksa false döner
                Console.WriteLine("3 keyine sahip elemanın değeri="+_str);

            int elemansayisi=dict.Count;
            dict.Remove(1);//1 keyine sahip elemanı siler
            dict.Clear();//sözlüğü temizler
            Console.ReadKey();
        }
    }
}
