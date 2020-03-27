using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override bool Equals(object obj)
        {
            FullName f = obj as FullName;
            return ((f.FirstName == this.FirstName) && (f.LastName == this.LastName));
        }
    }

    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            char[] under10 = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string[] array = expression.Split('+');
            int sum = 0;
            foreach (string num in array)
            {
                Console.WriteLine(num);
                if (num == "")
                    throw new InvalidDataException();
                if (!under10.Contains(num[0]))
                    throw new FormatException();
                sum += Convert.ToInt32(num);
            }
            return sum;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            char[] under10 = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string[] array = expression.Split('+');
            int sum = 0;
            foreach (string num in array)
            {
                Console.WriteLine(num);
                if (num == "")
                {
                    value = 0;
                    return false;
                }
                if (!under10.Contains(num[0]))
                {
                    value = 0;
                    return false;
                }
                sum += Convert.ToInt32(num);
            }
            value = sum;
            return true;

        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            int i = 10372344;
            var t = Math.Round(Math.PI, 7);
            while (true)
            {
                if (Math.Round(PiMethod(i), 7) == t)
                {
                    return i;
                }               
                i++;
            }
        }

        public static double PiMethod(int n)
        {
            double d = 0;
            double s = 0;
            for (int i = 0; i < n; i++)
            {
                s = Convert.ToDouble(1.0 / (2 * i + 1));
                if (i % 2 == 0)
                    d = d + s;
                else
                    d = d - s;
            }
            return d * 4;
        }
        
        public static int Fibonacci(this int n)
        {
            int a = 1;
            int b = 2;
            int tmp = 0;
            for(int i=0;i<n-2;i++)
            {
                tmp = a + b;
                a = b;
                b = tmp;
            }
            return tmp;
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            foreach (var item in list)
                if (item is FullName && lookup is FullName)
                {
                    FullName f1 = item as FullName;
                    FullName f2 = lookup as FullName;
                    if (f1.FirstName == f2.FirstName && f1.LastName == f2.LastName)
                        return true;
                }
            return false;
        }
    }
}