using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A1S2
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        static public long information(string filename)
        {
            string[] folders = Directory.GetDirectories(filename);
            string[] files = Directory.GetFiles(filename);
            long s = 0;
            foreach (var aaa in files)
            {
                FileInfo hajomid = new FileInfo(aaa);
                s += hajomid.Length;
            }
            foreach (var x in folders)
                 s= s + information(x);
            return s;
        }
    }
}
