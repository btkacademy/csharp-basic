using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tekboyutlu diziler
            string[] array1 = new string[4];
            string[] array2 = new string[4] { "a", "b", "c", "d" };
            string[] array3 = new string[] { "d", "b", "c", "a" };
            string[] array4 = { "a", "b", "c", "d" };
            Console.WriteLine(array2[0]);//0-3 arası index numarasına sahiptir
            Console.WriteLine(array4.Length);//dizinin kaç elemanlı olduğunu verir
            Array.Sort(array3);//diziyi A-Z sıralar
            Array.Reverse(array4);//dizinin son indexlerini ilk indexleriyle yer değiştirir [3]=d iken bu işlemden sonra [0]=d ve [3]=a olur
            #endregion
            #region Çokboyutlu diziler(Multidimensional arrays)
            int[,] cokboyutlu = new int[2, 3];
            int[,] cokboyutlu2 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] cokboyutlu3 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] boykilo = new int[4, 2]
            {
                {180,80},
                {175,60},
                {188,93},
                {160,50 }
            };
            Console.WriteLine(boykilo[3, 1]);//50 yazacaktır
            Console.WriteLine(cokboyutlu2.GetUpperBound(1));//dizinin 2.boyutunun maksimum index sayısını verir indexler 0 dan başladığı için sonuç 2 yazacaktır
            #endregion
            #region Düzensiz diziler(Jagged arrays)
            int[][] jagged = new int[4][];
            jagged[0] = new int[4] { 1, 2, 3, 4 };
            jagged[1] = new int[] { 1, 40 };
            jagged[2] = new int[] { 1, 2, 3 };
            jagged[3] = new int[6];
            Console.WriteLine(jagged[1][1]);//40 yazacaktır
            #endregion
            Console.ReadKey();
        }
    }
}
