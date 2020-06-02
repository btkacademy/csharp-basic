using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            //goto=>belirtilen noktadan kodun çalışmasını sağlar
            //break=>döngüyü kırar
            //continue=>döngüyü atlar
            //return=>metotlar konusunda kullanılacak
            //throw=>try-catch konusunda kullanılacak
            #region Goto
            int counter = 0;
            startpoint:
            Console.WriteLine("Başlangıç noktası");
            if (counter<10)
            {
                Console.WriteLine("Şart sağlandı");
                counter++;
                goto startpoint;
            }
            Console.WriteLine(counter);//11 kere başlangıç noktası 10 defa şart sağlandı yazar 
            #endregion

            #region Break
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                    break;//döngüden çıkar 
                Console.WriteLine(i);
            }
            #endregion

            #region Continue
            for (int i = 0; i < 5; i++)
            {
                if (i == 3)
                    continue;//şart sağlandığı alt satırdaki kodu çalıştırmadan sonraki döngüye girer
                Console.WriteLine(i);
            }
            #endregion

            Console.ReadKey();

        }
    }
}
