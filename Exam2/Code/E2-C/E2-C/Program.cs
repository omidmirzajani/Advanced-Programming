using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    public class MyString
    {
        public string Name { get; set; }
        public static implicit operator MyString(string roleName)
        {
            return new MyString() { Name = roleName };
        }
        public override bool Equals(object obj)
        {
            var tmp = obj as MyString;
            return this.Name == tmp.Name;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            MyString s1 = (MyString)"I love you";
            
        }
    }
}
