using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            //OrderBy(studentList);
            //OrderByWithExtension(studentList);
            //MultipleOrderBy(studentList);
            ThenBy(studentList);
            studentList.Reverse();//indexine göre tersine sıralıyor

            Console.ReadKey();
        }
        static void OrderBy(List<Student> studentList)
        {
            var orderByResult = from s in studentList
                                orderby s.StudentName
                                select s;
            foreach (var item in orderByResult)
                Console.WriteLine(item.StudentName);

            Console.WriteLine("****");

            var orderByDescendingResult = from s in studentList
                                          orderby s.StudentName descending
                                          select s;
            foreach (var item in orderByDescendingResult)
                Console.WriteLine(item.StudentName);
        }
        static void OrderByWithExtension(List<Student> studentList)
        {
            var studentsInAscOrder = studentList.OrderBy(s => s.StudentName);
            var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);
        }
        static void MultipleOrderBy(List<Student> studentList)
        {
            var orderByResult = from s in studentList
                                orderby s.StudentName, s.Age descending
                                select new { s.StudentName, s.Age };
            foreach (var item in orderByResult)
                Console.WriteLine(item.StudentName + " " + item.Age);

            //var orderByResult2 = studentList.OrderBy(o => o.StudentName).OrderByDescending(o2=> o2.Age).Select(s => new { s.StudentName, s.Age }); !!! aynı mantıkta çalışmıyor doğru sonuç getirmez thenby kullanılması gerekiyor
        }
        static void ThenBy(List<Student> studentList)
        {
            var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);
            foreach (var item in thenByResult)
                Console.WriteLine(item.StudentName + " " + item.Age);
            Console.WriteLine("******");
            var thenByDescResult = studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age);
            foreach (var item in thenByDescResult)
                Console.WriteLine(item.StudentName + " " + item.Age);
        }
    }
}
