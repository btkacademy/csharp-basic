using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList dynamicArray = new ArrayList();//System.Collections kütüphanesi altında
            dynamicArray.Add("eleman1");
            dynamicArray.Add(2);
            dynamicArray.Add(true);
            dynamicArray.Add(true);
            dynamicArray.Remove(true);//İlk true değeri olan elemanı siler.
            dynamicArray.RemoveAt(1);//index'i 1 olan elemanı siler.
            dynamicArray.Insert(2, 34.6);//parantez içindeki ilk değer dizinin hangi indexine ekleneceği ikinci değer indexin alacağı değerdir.bu şekilde belirtilen indexden itibaren bir kaydırır ve belirtilen indexe girilen veriyi aktarır.
            Console.WriteLine(dynamicArray[2]);//34.6 yazar
            Console.WriteLine(dynamicArray.Count);//dizinin eleman sayısını verir
            dynamicArray.Clear();//dizideki bütün elemanları siler.
            Console.ReadKey();
        }
    }
}
