using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            //SequenceEqual();
            SequenceEqualsWithReferenceType();
            Console.ReadKey();
        }
        static void SequenceEqual()
        {
            IList<string> strList1 = new List<string>() { "1", "2", "3", "4", "5" };
            IList<string> strList2 = new List<string>() { "1", "2", "3", "4", "5" };
            IList<string> strList3 = new List<string>() { "2", "1", "3", "4", "5" };
            Console.WriteLine(strList1.SequenceEqual(strList2));//true döner
            Console.WriteLine(strList1.SequenceEqual(strList3));//false döner
        }
        static void SequenceEqualsWithReferenceType()
        {
            DataContext dataContext = new DataContext();
            List<Student> studentList = dataContext.GetStudents();
            List<Student> studentList2 = dataContext.GetStudents();
            Console.WriteLine(studentList.SequenceEqual(studentList2));//false
            Console.WriteLine(studentList.SequenceEqual(studentList2, new StudentComparer()));//true
        }
    }
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID && x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
