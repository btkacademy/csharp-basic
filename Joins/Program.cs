using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joins
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            List<City> cities = dataContext.GetCities();
            //Join();
            //JoinWithExtension();
            //GroupJoin(studentList, cities);
            GroupJoinWithExtension(studentList, cities);
            Console.ReadKey();
        }
        static void Join()
        {
            IList<string> strList1 = new List<string>()
            {
                "bir",
                "iki",
                "üç",
                "dört"
            };
            IList<string> strList2 = new List<string>()
            {
                "bir",
                "iki",
                "beş",
                "altı"
            };
            var innerJoin = from str1 in strList1
                            join str2 in strList2
                            on str1 equals str2
                            select str1;

            foreach (var item in innerJoin)
            {
                Console.WriteLine(item);
            }
        }//inner join
        static void JoinWithExtension()
        {
            IList<string> strList1 = new List<string>()
            {
                "bir",
                "iki",
                "üç",
                "dört"
            };
            IList<string> strList2 = new List<string>()
            {
                "bir",
                "iki",
                "beş",
                "altı"
            };
            var innerJoin = strList1.Join(strList2,
                        str1 => str1,
                        str2 => str2,
                        (str1, str2) => str1);
        }//inner join
        static void GroupJoin(List<Student> studentList, List<City> cities)
        {
            var groupJoin = from citi in cities
                            join stu in studentList
                            on citi.CityID equals stu.CityRef
                            into studentGroup
                            select new
                            {
                                CityName = citi.CityName,
                                Students = studentGroup
                            };

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.CityName);

                foreach (var stud in item.Students)
                    Console.WriteLine("\t" + stud.StudentName);
            }
        }//left join 
        static void GroupJoinWithExtension(List<Student> studentList, List<City> cities)
        {
            var groupJoin = cities.GroupJoin(studentList,
                             std => std.CityID,
                             s => s.CityRef,
                             (std, studentsGroup) => new
                             {
                                 Students = studentsGroup,
                                 CityName = std.CityName
                             });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.CityName);

                foreach (var stud in item.Students)
                    Console.WriteLine("\t" + stud.StudentName);
            }
        }//left join 
    }
}
