using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Tests
{
    [TestClass()]
    public class MainWindowTests
    {        
        

        [TestMethod()]
        public void ConvertToListOfElementsTest()
        {
            string str = "x+2x^5";
            List<string> should = new List<string>() { "x" ,"2x^5"};
            List<string> real = ConvertToListOfElements(str+"+");
            CollectionAssert.AreEqual(should,real);

            str = "-x+sinx^5";
            should = new List<string>() { "","-x", "sinx^5" };
            real = ConvertToListOfElements(str + "+");
            CollectionAssert.AreEqual(should, real);

        }

        [TestMethod()]
        public void ConvertToVariablesTest()
        {
            string str = "1x+2y+3z";
            List<string> should = new List<string>() { "x", "y", "z" };
            List<string> real = ConvertToVariables(str);
            CollectionAssert.AreEqual(real, should);

            str = "-x+2y";
            should = new List<string>() { "x", "y" };
            real = ConvertToVariables(str + "+");
            CollectionAssert.AreEqual(should, real);
        }

        [TestMethod()]
        public void DeleteIJTest()
        {
            double[] line1 = new double[] { 1, 2, 3 };
            double[] line2 = new double[] { 4, 5, 6 };
            double[] line3 = new double[] { 7, 8, 9 };
            List<double[]> v = new List<double[]>() { line1, line2, line3 };
            double[] should1 = new double[] { 1, 2 };
            double[] should2 = new double[] { 4, 5 };
            List<double[]> real = new List<double[]>() { should1, should2 };
            List<double[]> should = DeleteIJ(v, 2, 2);

            CollectionAssert.AreEqual(real[0], should[0]);
            CollectionAssert.AreEqual(real[1], should[1]);


        }

        [TestMethod()]
        public void TaylorTest()
        {
            double real = Taylor(1.0,4);
            double should = 1.0 - 1.0 / 6 + 1.0 / 120 - 1.0 / 840;
            Assert.IsTrue(should-real<0.1);
        }

        [TestMethod()]
        public void XLimitTest()
        {
            double real = XLimit(4);
            Assert.IsTrue(real - 3 < 0.1);
        }

        [TestMethod()]
        public void MoshtaghTest()
        {
            Diagram func = new Diagram(-1, 1, -1, 1);
            func.fx = "x^2+3x^5";
            Assert.AreEqual(func.Moshtagh(), "2x^1+15x^4");
        }

        [TestMethod()]
        public void MoshtaghNTest()
        {
            Diagram func = new Diagram(-1, 1, -1, 1);
            func.fx = "x^2+3x^5";
            Assert.AreEqual(func.MoshtaghN(2), "2x^0+60x^3");
        }
        [TestMethod()]
        public void TaylorDelkhah()
        {
            Diagram func = new Diagram(-1, 1, -1, 1);
            func.fx = "x^2";
            Assert.AreEqual(TaylorD(func.fx, 2,1),3);
        }

        [TestMethod()]
        public void IntegralTest()
        {
            Diagram func = new Diagram(-1, 1, -1, 1);
            func.fx = "3x^2+6x^5";
            Assert.AreEqual(func.Integral(), "1x^3+1x^6");
        }

        [TestMethod()]
        public void ResultOfFunctionTest()
        {
            Diagram func = new Diagram(-1, 1, -1, 1);
            func.fx = "3x^2-2x^3";
            List<string> listOf = ConvertToListOfElements(func.fx+"+");
            Assert.AreEqual(func.ResultOfFunction(1, listOf), 1);

            Diagram func2 = new Diagram(-1, 1, -1, 1);
            func2.fx = "sinx^2+x";
            List<string> listOf2 = ConvertToListOfElements(func2.fx + "+");
            Assert.AreEqual(func2.ResultOfFunction(Math.PI/2, listOf2), 1+Math.PI/2);


        }
        public double TaylorD(string x, int n, double num)
        {
            double res = 0;
            Diagram func = new Diagram();
            func.fx = x;
            for (int i = 0; i < n; i++)
            {
                string moshtagh = func.MoshtaghN(i);
                func.fx = moshtagh;
                List<string> listOf = func.ConvertToListOfElements();
                double moshta = func.ResultOfFunction(num, listOf);
                res += moshta * Math.Pow(num, i) / Factorial(i);
            }
            return res;
        }

        #region Needed Methods
        public List<string> ConvertToListOfElements(string text)
        {
            List<string> result = new List<string>();
            string sub = "";
            for (int i = 0; i < text.Length; i++)
            {
                sub += text[i];
                if (text[i] == '+')
                {
                    result.Add(sub.Substring(0, sub.Length - 1));
                    sub = "";
                }
                if (text[i] == '-')
                {
                    result.Add(sub.Substring(0, sub.Length - 1));
                    sub = "-";
                }
            }
            return result;
        }
        public List<string> ConvertToVariables(string text)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                if (Convert.ToInt32(text[i]) > 96 && Convert.ToInt32(text[i]) < 123 && !result.Contains(text[i].ToString()))
                    result.Add(text[i].ToString());
            }
            result.Sort();
            return result;
        }
        public List<double[]> DeleteIJ(List<double[]> nums, int i, int j)
        {
            List<double[]> result = new List<double[]>();
            for (int column = 0; column < nums.Count; column++)
            {
                List<double> temp = new List<double>();
                for (int row = 0; row < nums[column].Length; row++)
                {
                    if (column != i && row != j)
                        temp.Add(nums[column][row]);
                }
                if (column != i)
                    result.Add(temp.ToArray());
            }
            return result;
        }
        public double Taylor(double x, int n)
        {
            double result = 0;
            for (int i = 1; i <= n * 2 - 1; i = i + 2)
            {
                result += (2 - i % 4) * Math.Pow(x, i) / Factorial(i);
            }
            return result;
        }
        public double Factorial(int i)
        {
            double result = 1;
            for (int j = 1; j <= i; j++)
                result *= j;
            return result;

        }
        public double XLimit(int n)
        {
            double result = 0.1;
            for (double i = 0.1; i <= 100; i = i + 0.1)
            {
                double t = Math.Abs(Taylor(result, n));
                if (Math.Abs(Taylor(result, n) - Math.Sin(result)) / Math.Sin(result) < 0.2)
                {
                    result = i;
                }

            }
            return result;

        }
        #endregion
    }
}