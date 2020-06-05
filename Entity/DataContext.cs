using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DataContext
    {
        public List<Student> GetStudents() => new List<Student>()
        {
            new Student() { StudentID = 1, StudentName = "Ayşe", Age = 13, CityRef=28} ,
            new Student() { StudentID = 2, StudentName = "Ahmet",  Age = 21 , CityRef=28} ,
            new Student() { StudentID = 3, StudentName = "Rabia",  Age = 18, CityRef=55 } ,
            new Student() { StudentID = 4, StudentName = "Yasin" , Age = 20, CityRef=52} ,
            new Student() { StudentID = 5, StudentName = "Cem" , Age = 15 , CityRef=52},
            new Student() { StudentID = 6, StudentName = "Ayşe", Age = 15, CityRef=28} ,
            new Student() { StudentID = 7, StudentName = "Aygün" , Age = 23, CityRef=52} ,
        };
        public List<City> GetCities() => new List<City>
        {
            new City(){ CityID=28,CityName="Giresun"},
            new City(){ CityID=52,CityName="Ordu"},
            new City(){ CityID=55,CityName="Samsun"},
            new City(){ CityID=34,CityName="İstanbul"},
        };
    }
}
