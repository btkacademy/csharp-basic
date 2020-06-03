using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructerFinalizerDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFinalize();
            GC.Collect();
            System.Threading.Thread.Sleep(100);

            TestDispose();
            GC.Collect();

            Console.ReadKey();
        }
        public static void TestFinalize()
        {
            Test test = new Test("işlem 1");
        }//Finalize çağrıldığı nokta
        public static void TestDispose()
        {
            using (Test test =new Test("işlem 2"))
            {

            }//Dispose çağrıldığı nokta
        }
    }
    public class Test : IDisposable
    {
        string _procName;
        bool disposed = false;

        public Test(string ProcName)
        {
            _procName = ProcName;
            Console.WriteLine(string.Format("{0} Constructer", _procName));
        }//Constructer (Yapıcı)

        ~Test() 
        {  
            //Sınıfın kullanıldığı süslü parantez bitişinde destructor otomatik olarak çağrılır
            Console.WriteLine(string.Format("{0} Finalizer", _procName));
            Dispose(false);
        }//Yıkıcı (Destructor)

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//Dispose işlemi yapıldıktan sonra destructor gitmesine gerek olmadığı için bu kod çalışır
        }//Yokedici (Dispose)

        public void Dispose(bool disposing)
        {
            if(!disposed)
            {
                Console.WriteLine(string.Format("{0} Dispose", _procName));
                if(disposing)
                {
                    //Dispose managed resources.(.NET sınıfları)
                    //SqlConnection gibi
                }
                //Dispose unmanaged managed resources(.NET dışında bizim oluşturduğumuz sınıflar)
                //Modelleri null'a çekme Manager sınıflarını dispose ile çağırma yapılır
                GC.Collect();//boşa çıkmış nesneleri ramden temizler
                disposed = true;
            }
        }//Yıkıcı ve yokedici metotlar buraya gelir 
    }
}
