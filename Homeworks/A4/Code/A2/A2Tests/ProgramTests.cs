using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AssignPiTest()
        {
            double pi = Math.PI;
            Program.AssignPi(out double res);
            Assert.AreEqual(res, pi);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int a = 5;
            Program.Square(ref a);
            Assert.AreEqual(a, 25);
        }

        [TestMethod()]
        public void SwapTest()
        {
            int num1 = 5;
            int num2 = 10;
            Program.Swap(ref num1, ref num2);
            Assert.AreEqual(true, (num1 == 10 && num2 == 5));
        }

        [TestMethod()]
        public void SumTest()
        {
            int s = 0;
            int num1 = 1;
            int num2 = 2;
            int num3 = 10;
            Program.Sum(out s, num1, num2, num3);
            Assert.AreEqual(s, 13);
        }

        [TestMethod()]
        public void AppendTest()
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            int c = 10;
            int[] res = new int[6] { 1, 2, 3, 4, 5, 10 };
            Program.Append(arr, c);
            CollectionAssert.Equals(res, arr);
        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int[] arr = new int[5] { 1, -2, -3, 4, -5 };
            int[] res = new int[5] { 1, 2, 3, 4, 5 };
            Program.AbsArray(arr);
            CollectionAssert.AreEqual(res, arr);
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            int[] bar = new int[5] { 6, 7, 8, 9, 10 };
            Program.ArraySwap(ref arr, ref bar);
            int[] c = new int[5] { 6, 7, 8, 9, 10 };
            int[] d = new int[5] { 1, 2, 3, 4, 5 };
            bool x = arr == c && bar == d;
            CollectionAssert.AreEqual(bar, d);
            CollectionAssert.AreEqual(arr, c);


        }

        [TestMethod()]
        public void ArraySwapTest1()
        {
            long[] arr = new long[5] { 1, 2, 3, 4, 5 };
            long[] bar = new long[5] { 6, 7, 8, 9, 10 };
            Program.ArraySwap(ref arr, ref bar);
            long[] c = new long[5] { 6, 7, 8, 9, 10 };
            long[] d = new long[5] { 1, 2, 3, 4, 5 };
            bool x = arr == c && bar == d;
            CollectionAssert.AreEqual(bar, d);
            CollectionAssert.AreEqual(arr, c);
        }
    }
}