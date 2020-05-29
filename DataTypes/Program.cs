using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Değer Tipleri ram'in stack bölgesinde tutulurken, Referans Tipleri heap bölgesinde tutulmaktadır.
            //Değer tipleri veriyi tutan değişken türleridir. Referans türleri ise veri yerine verinin bellekteki adresini tutan değişken türleridir!!!
            #region Değer Tipleri(Value Type)

            #region TamSayılar
            byte _byte;                                         //0 ile 255 arasında 8 bit
            sbyte _sbyte;                                       //-128 ile 127 arası 8 bit
            short _short;                                       //-32.768 ile 32.767 arası 16 bit
            ushort _ushort;                                     //0 ile 65.535 arası 16 bit
            int _int;                                           //-2.147.483.648 ile 2.147.483.647 arası 32 bit
            uint _uint;                                         //0 ile 4.294.967.295 arası 32 bit
            long _long;                                         //-9.223.372.036.854.775.808 ile 9.223.372.036.854.775.807 64 bit
            ulong _ulong;                                       //0 ile 18,446,744,073,709,551,615 64 bit
            #endregion
            #region KesirliSayılar
            float _float;                                       //±1,5 x 10−45 ila ±3,4 x 1038 32 bit
            double _double;                                     //±5,0 × 10−324 ile ±1,7 ×10 308  64 bit
            decimal _decimal;                                   //±1,0 x 10-28 ile ±7,9228 x 1028  128 bit
            #endregion

            bool _bool;                                        //0-1 mantıksal değer tutar 1 bit
            char _char;                                        //Tek karakter tutar 16 bit
            MyStruct myStruct;                                 //İhtiyaca göre tanımladığımız yapılar 
            Days days;                                         //Enumarations

            #endregion

            #region Referans Tipleri(Reference Type)
            object _object;                                    //Tüm türlerin atasıdır
            dynamic _dynamic;                                  //object'e benzer ama tür dönüşümü yapma ihtiyacı duyulmaz
            string _string;                                    //Metinsel ifadeleri tutar davranış bakımından değer tipleri gibidir
            MyClass myClass;                                   //İhtiyaca göre tanımladığımız sınıflar
            IInterface _interface;                             //İhtiyaca göre tanımladığımız arayüzler
            Array array;                                       //Diziler
            MyDelegate myDelegate;                             //Delegeler

            unsafe//Bu kodun çalışabilmesi için "Project properties/Build" sekmesinden Allow unsafe code işaretli olmak zorunda
            {
                int* ipointer;                                 //pointerlar 
            }
            #endregion
                                                               
            var _var=1;                                        //Variable anlamına gelen değişken tipi hangi değer verilirse o olur 

            Console.ReadKey();                                  
        }
        struct MyStruct
        {
            string Name;
            string Surname;
        }
        enum Days
        {
            Pazartesi,
            Sali
        }
        public class MyClass
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
        interface IInterface
        {

        }
        delegate void MyDelegate();
    }
}
