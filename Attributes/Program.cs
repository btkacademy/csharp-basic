using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.OldProp = "eski özellik";
            user.NewProp = "yeni özellik";
        }
    }

    [MyTable("Users")]
    public class User
    {
        [Prop("Lref")]
        public int Id { get; set; }

        [Prop("OldProp")]
        [Obsolete("Eski alan yeni alan olarak NewProp kullan")]
        public string OldProp { get; set; }

        [Prop("OldProp")]
        [Prop("NewProp")]
        public string NewProp { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    public class PropAttribute : Attribute
    {
        string _columnName;
        public PropAttribute(string columnName)
        {
            _columnName = columnName;
        }
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false)]
    public class MyTableAttribute : Attribute
    {
        string _tableName;
        public MyTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }

}
