using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S1
{
    public class Program
    {
        static void Main(string[] args)
        {            
        }

        public static int FileSize(string s)
        {
            string[] arr= File.ReadAllLines(s);
            int tedad = 0;
            foreach (string xxx in arr)
                tedad += xxx.Length;
            return tedad;
        }

        public static string[] ListFiles(string s)
        {
            string[] arr = Directory.GetFiles(s);
            return arr;
        }

        public static int FileLineCount(string s)
        {
            string[] array = File.ReadAllLines(s);
            return array.Length;
        }

        public static int LineCount(string s)
        {
            int l = 0;
            foreach (char a in s)
                if (a=='\n')
                    l++;
            return l+1;
        }

        public static int LetterCount(string s)
        {
            int l = 0;
            foreach (char a in s)
                if (char.IsLetter(a))
                    l++;
            return l;
        }

        public static int CalculateLength(string s)
        {
            int l = 0;
            foreach (char a in s)
                l++;
            return l;
        }
    }
}
