using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Bilinçsiz Tür Dönüşümü(Implicit)
            //Küçük türdeki veriyi daha büyük bir türe aktarmaya denir.
            byte a = 5;//0-255 arasındaki tam sayı değerleri tutabiliyordu."a" adında 5 değeri olan bir byte değişkeni oluşturduk.
            short b = 10;//(-32.768)-32.767 arasındaki tam sayı değerlerini tutabiliyordu."b" adında 10 değeri olan bir short değişkeni oluşturduk.
            sbyte c = 30;//(-128)-127 arasındaki tam sayı değerlerini tutabiliyordu."c" adında 30 değeri olan bir short değişkeni oluşturduk.
            int d = a + b + c;//(-2.147.483.648)-2.147.483.647 arasındaki tam sayı değerlerini tutabiliyordu."d" adında "a=5"+"b=10"+"c=30" olmak üzere 45 değeri olan bir int değişkeni oluşturduk.
            string e = "deneme";//Sınırsız metin tutabiliyordu."e" adında deneme değeri olan bir string değişkeni oluşturduk.
            char f = 'k';//Tek bir karakteri tutabiliyordu."f" adında k değeri olan bir char değişkeni oluşturduk.
            object g = e + f + d;//Bütün veri tiplerini tutabiliyordu."g" adında "e=deneme"+"f=k"+"d=45" olmak üzere denemek45 değeri olan bir object değişkeni oluşturduk.
            long h = d;//(-9.223.372.036.854.775.808)-9.223.372.036.854.775.807 arasındaki tam sayı değerlerini tutabiliyordu."h" adında "d=45" olmak üzere 45 değeri olan bir long değişkeni oluşturduk.
            float i = h;//±1.5*10-45, ..., ±3.4*1038  aralığındaki reel sayıları tutabiliyordu.​​​"i" adında "h=d=45" olmak üzere 45 değeri olan bir float değişkeni oluşturduk.
            double j = i;//±5.0*10-324, ..., ±1.7*10308  aralığındaki reel sayıları tutabiliyordu."j" adında "i=h=d=45" olmak üzere 45 değeri olan bir double değişkeni oluşturduk.
            #endregion

            #region Bilinçli Tür Dönüşümü(Explicit)
            //Büyük türdeki veriyi küçük türe aktarmaya denir
            int _a = 256;          //"a" adında 256 değeri olan bir int değişkeni oluşturduk.
            byte _b = (byte)_a;    //"b" adında "a değişkeninin değerinin byte karşılığı tutan" bir byte değişkeni oluşturduk.byte değişkenleri 0-255 arası tam sayıları tutabiliyordu 256 olduğu zaman 255'e kadar olan kısmı taşıyor ve 256'ıncı değer olarak 0 alıyor eğer bu "a" 256 yerine 257 olsaydı "b" 0 yerine 1 değerini tutacaktı.
            Console.WriteLine(b); //Ekrana 0 yazar.
            #endregion

            //Referans ve Değer Türleri Arasındaki Dönüşüm
            //https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/types/boxing-and-unboxing
            #region Kutulama(Boxing)
            //Değer tipindeki(value type) verileri "object" nesnesine çevirir
            int number1 = 100;
            object unknown = number1;
            object unknown2 = (object)number1;//Bilinçli ve bilinçsiz şekilde yapılabilir
            #endregion

            #region Kutudan çıkartma(Unboxing)
            //Referans tipindeki(reference type) değişkenler değer tipine(value type) dönüşmüş olur
            int number2 = 10;
            object o = number2;//Bilinçsiz olarak kutulama(boxing) yapıldı
            int number3 = (int)o;//Bilinçli olarak kutudan çıkartma(unboxing) yapıldı
            #endregion

            #region System.Convert sınıfı ile tür dönüşümü
            //String değerleri ve temel veri türlerini birbirine çevirmek için kullanılır
            int number = Convert.ToInt32(Console.ReadLine());//kullanıcıdan alınan metni integer'a çevirip number adında değişkene aktarıldı
            int _number = int.Parse(Console.ReadLine());//aynı işlemin farklı syntax ile yapılması

            byte flag = 1;
            bool flag2 = Convert.ToBoolean(flag);//Sonuç true olacaktır
            #endregion
        }
    }
}
