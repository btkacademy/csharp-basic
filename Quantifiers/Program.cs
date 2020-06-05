using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            //AllAny(studentList);
            Contains(studentList);
            Console.ReadKey();
        }
        static void AllAny(List<Student> studentList)
        {
            bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);//tüm öğrenciler 12-20 yaş arasında mı
            Console.WriteLine(areAllStudentsTeenAger);//false

            bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);//12-20 yaş arasında herhangi bir öğrenci varmı
            Console.WriteLine(isAnyStudentTeenAger);//true
        }
        static void Contains(List<Student> studentList)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(list.Contains(4));//true 

            Student student = new Student() { StudentID = 1, StudentName = "Ayşe", Age = 13, CityRef = 28 };
            Console.WriteLine(studentList.Contains(student));//false referans tiplerde karşılaştırma nesnenin verisi üstünden değil hashkodu üstünden yapılır
            Console.WriteLine(studentList.Contains(student, new StudentComparer()));//true 
        }
    }
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID &&
                        x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }
        public int GetHashCode(Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
