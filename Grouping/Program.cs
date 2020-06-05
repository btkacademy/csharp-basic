using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            GroupBy(studentList);
            ToLookUp(studentList);
            Console.ReadKey();
        }
        static void GroupBy(List<Student> studentList)
        {
            var groupedResult = from s in studentList
                                group s by s.Age;
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Yaş grubu: {0}", ageGroup.Key);

                foreach (Student s in ageGroup)
                    Console.WriteLine("Öğrenci adı: {0}", s.StudentName);
            }
        }
        static void GroupByWithExtension(List<Student> studentList) => studentList.GroupBy(s => s.Age);
        static void ToLookUp(List<Student> studentList)
        {   //GroupBy ile aynı işi yapar GroupBy listeleme sırasında gruplarken LookUp çağırılır çağrılmaz gruplar 
            //LookUp query syntaxı yok
            var lookupResult = studentList.ToLookup(s => s.Age);
            foreach (var ageGroup in lookupResult)
            {
                Console.WriteLine("Yaş grubu: {0}", ageGroup.Key);

                foreach (Student s in ageGroup)
                    Console.WriteLine("Öğrenci adı: {0}", s.StudentName);
            }
        }

    }
}
