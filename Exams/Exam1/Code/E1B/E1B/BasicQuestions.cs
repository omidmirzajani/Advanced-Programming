using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    public class Human:IHasAge
    {
        public int Age;
        public string Name;
        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int GetAge()
        {
            return this.Age;
        }
    }
    public interface IHasAge
    {
        int GetAge();
    }
    public class BasicQuestions
    {

        public static int OddSum(int[] nums)
        {
            int sum = 0;
            foreach (int s in nums)
                if (s % 2 == 1)
                    sum += s;
            return sum;
        }

        public static void Swap<_Type>(ref _Type a, ref _Type b)
        {
            _Type c = a;
            a = b;
            b = c;
        }
        class Human
        {
            int Age;
            string Name;
            public Human(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }
    }
}
