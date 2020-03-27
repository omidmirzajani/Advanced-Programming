using System;
using System.Collections.Generic;

namespace E2.Tests
{
    public class MyString
    {
        public string Name { get; set; }
        public MyString(string name)
        {
            Name = name;
        }
        public static explicit operator MyString(string roleName)
        {
            return new MyString(roleName) { Name = roleName };
        }
        public override bool Equals(object obj)
        {
            return this.Name == obj.ToString();
        }
        public override string ToString()
        {
            return this.Name;
        }
        public static bool operator ==(MyString my, string roleName) => my.Name==roleName;
        public static bool operator !=(MyString my, string roleName) => my.Name!=roleName;

        public static explicit operator string(MyString v)
        {
            return v.ToString();
        }
        public static MyString operator ++(MyString my) => (MyString)my.ToString().ToUpper();
        public static MyString operator --(MyString my) => (MyString)my.ToString().ToLower();
    }
}