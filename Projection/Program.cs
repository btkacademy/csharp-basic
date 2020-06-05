using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            //Select(studentList);
            //SelectWithExtension(studentList);
            SelectMany();
            Console.ReadKey();
        }
        static void Select(List<Student> studentList)
        {
            var selectResult = from s in studentList
                               select new { Name = "Ad :" + s.StudentName, Age = "Yaş :" + s.Age };
            foreach (var item in selectResult)
                Console.WriteLine("{0}, {1}", item.Name, item.Age);
        }
        static void SelectWithExtension(List<Student> studentList) => studentList.Select(s => new
                                                                          {
                                                                              Name = s.StudentName,
                                                                              Age = s.Age
                                                                          });
        static void SelectMany()
        {   //Dizi içinde dizi olan durumlarda hepsini tek listeye çekmek istediğimiz zaman kullanırız
            List<List<int>> lists = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 }
            };
            var allList = from list1 in lists
                          from list2 in list1
                          select list2;
            foreach (var item in allList)
                Console.WriteLine(item);

            #region Extension syntax
            var allList2 = lists.SelectMany(i => i);
            foreach (var item in allList)
                Console.WriteLine(item);
            #endregion
        }
    }
}
