using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1B
{
    public class Program
    {
        public static int OddSum(params int[] a)
        {
            int sum = 0;
            foreach (int s in a)
                if (s % 2 == 1)
                    sum += s;
            return sum;
        }
        public static void Main(string[] args)
        {
        }
    }
}
