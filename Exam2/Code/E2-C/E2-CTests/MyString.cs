using System;

namespace E2.Tests
{
    public class MyString
    {
        public string Name { get; set; }
        public MyString(string s)
        {
            Name = s;
        }

        public static explicit operator MyString(string v)
        {
            MyString my = new MyString(v);
            return my;
        }
        public static bool operator ==(MyString m, string s) => m.Name == s;
        
        public static bool operator !=(MyString m, string s)=>m.Name != s;

        public override bool Equals(object obj)
        {
            var tmp = obj as string;
            return tmp == this.Name;
        }

        public static explicit operator string(MyString my)=>my.Name;

        public static MyString operator ++(MyString m) => (MyString)(m.Name.ToUpper());
        
        public static MyString operator --(MyString m) => (MyString)(m.Name.ToLower());

    }
}