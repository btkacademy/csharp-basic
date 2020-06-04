using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    class Program
    {
        static void Main(string[] args)
        {
            //InvokeMethod();
            //GetInfo();
            GetSetValue();
            Console.ReadKey();
        }
        static void InvokeMethod()
        {
            Type type = typeof(Greet);
            object instance = Activator.CreateInstance(type, "Ahmet Faruk");

            MethodInfo doit = instance.GetType().GetMethod("Doit");
            doit.Invoke(instance, null);

            #region Overload olan metotlarda
            MethodInfo sayhi = instance.GetType().GetMethod("Greeting",new Type[0]);
            Console.WriteLine(sayhi.Invoke(instance, null));

            MethodInfo sayhi2 = instance.GetType().GetMethod("Greeting", new Type[1] { typeof(string) });
            Console.WriteLine(sayhi2.Invoke(instance, new object[] { "Aygün"}));
            #endregion
        }
        static void GetInfo()
        {
            Type type = typeof(Greet);
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine(string.Format("***{0} metot adı", method.Name));
                foreach (var parameterInfo in method.GetParameters())
                    Console.WriteLine(string.Format("\t{0} parametre adı {1} parametre tipi", parameterInfo.Name, parameterInfo.ParameterType.ToString()));

                foreach (var attribute in method.GetCustomAttributes())
                {
                    Console.WriteLine(string.Format("\t{0} attribute tipi", attribute.GetType().Name));
                    if (attribute.GetType().Name == "MethodNameAttribute")
                        Console.WriteLine(string.Format("\t{0} attribute değeri", attribute.GetType().GetField("_methodName").GetValue(attribute)));
                }
            }
        }
        static void GetSetValue()
        {
            object basicModel = Activator.CreateInstance(typeof(BasicModel));
            Console.Write("Sayı girin=");
            basicModel.GetType().GetProperty("Id").SetValue(basicModel, int.Parse(Console.ReadLine()));
            int Id = (int)basicModel.GetType().GetProperty("Id").GetValue(basicModel);
            Console.WriteLine(Id);
        }
    }
    public class Greet
    {
        string _name;
        public Greet(string Name) => _name = Name;
        [MethodName("Selamla")]
        public string Greeting() => "Selam " + _name;
        public string Greeting(string Name) => "Selam " + Name;
        public void Doit()
        {
            Console.WriteLine("i do");
        }
    }

    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false)]
    public class MethodNameAttribute : Attribute
    {
       public string _methodName;
        public MethodNameAttribute(string methodName)
        {
            _methodName = methodName;
        }
    }

    public class BasicModel
    {
        public int Id { get; set; }
        public string Word { get; set; }
    }
}
