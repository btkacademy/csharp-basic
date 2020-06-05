using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            List<City> cities = dataContext.GetCities();
            //Aggregate(studentList);
            //Average(studentList);
            //Count(studentList);
            MinMax(studentList);
            Sum(studentList);
            Console.ReadKey();
        }
        static void Aggregate(List<Student> studentList)
        {
            IList<String> strList = new List<String>() { "bir", "iki", "üç", "dört", "beş" };
            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);
            Console.WriteLine(commaSeperatedString);

            int SumOfStudentsAge = studentList.Aggregate<Student, int>(0, (totalAge, s) => totalAge += s.Age);
            Console.WriteLine(SumOfStudentsAge);

            string studentNames = studentList.Aggregate<Student, string, string>(
                                            "Öğrenci isimleri :", // başlangıç değeri
                                            (str, s) => str += s.StudentName + ",",
                                            str => str.Substring(0, str.Length - 1)); //tüm liste dönüldüğünde sondaki "," silmesi için yapılıyor
            Console.WriteLine(studentNames);
        }
        static void Average(List<Student> studentList) => Console.WriteLine("Öğrenci yaş ortalaması :" + studentList.Average(s => s.Age));
        static void Count(List<Student> studentList)
        {
            int totalStudent = studentList.Count;
            int adultStudents = studentList.Count(x => x.Age >= 18);
            
            int totalStudent2 = (from stu in studentList select stu.Age).Count();
        }
        static void MinMax(List<Student> studentList)
        {
            Console.WriteLine(studentList.Max(i=>i.StudentID));
            int teenMaxage=studentList.Max(i =>
            {
                if (i.Age < 18)
                    return i.Age;
                return 0;
            });
            Console.WriteLine("Reşit olmayan en büyük yaşa sahip öğrenci :"+teenMaxage);

            Console.WriteLine(studentList.Min());//max ile aynı
        }
        static void Sum(List<Student> studentList)
        {
            studentList.Sum(y => y.Age);

            var AdultStudentSumOfAge=studentList.Sum(i =>
            {
                if (i.Age >= 18)
                    return i.Age;
                return 0;
            });
        }
    }
}
