using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.tutorialsteacher.com/linq/linq-filtering-operators-where 
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            //Where(studentList);
            //WhereWithDelegate(studentList);
            WhereWithExtension(studentList);
            WhereWithMultiple(studentList);
            OfType();

            Console.ReadKey();
        }
        static void Where(List<Student> studentList)
        {
            var filteredResult = from s in studentList
                                 where s.Age > 12 && s.Age < 20
                                 select s.StudentName;
            foreach (var item in filteredResult)
                Console.WriteLine(item);
        }
        static void WhereWithDelegate(List<Student> studentList)
        {
            Func<Student, bool> isTeenAger = delegate (Student s)
            {
                return s.Age > 12 && s.Age < 20;
            };
            var filteredResult2 = from s in studentList
                                  where isTeenAger(s)
                                  select s;
        }
        static void WhereWithExtension(List<Student> studentList)
        {
            var filteredResult = studentList.Where(s => s.Age > 12 && s.Age < 20);//extension metotla listeleme 

            var filteredResult2 = studentList.Where((s, i) => {
                if (i % 2 == 0) // i=index
                    return true;
                return false;
            });
            foreach (var std in filteredResult2)
                Console.WriteLine(std.StudentName);
        }
        static void WhereWithMultiple(List<Student> studentList)
        {
            var filteredResult = from s in studentList
                                 where s.Age > 12
                                 where s.Age < 20
                                 select s;
            var filteredResult2 = studentList.Where(s => s.Age > 12).Where(s => s.Age < 20);
        }
        static void OfType()
        {
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = from s in mixedList.OfType<string>()
                               select s;
            var intResult = from s in mixedList.OfType<int>()
                            select s;
        }
    }
}
