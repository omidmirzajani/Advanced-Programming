using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IndexOutOfRangeException a = new IndexOutOfRangeException();
            Console.WriteLine(a.StackTrace+" dsd");
        }
    }
}
