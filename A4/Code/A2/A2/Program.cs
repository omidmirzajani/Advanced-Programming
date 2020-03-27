using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public static void AssignPi(out double number)
        {
            number = Math.PI;
        }
        public static void Square(ref int number)        
        {
            number = number * number;
        }
        public static void Swap(ref int number1, ref int number2)
        {
            int tmp = number1;
            number1 = number2;
            number2 = tmp;
        }
        public static void Sum(out int number, params int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum = sum + array[i];
            number = sum;
        }
        public static void Append(int[] array, int number)
        {
            int[] array2 = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
                array2[i] = array[i];
            array2[array.Length] = number;
            array = array2;
        }
        public static void AbsArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    array[i] = (-1) * array[i];
            }            
        }
        public static void ArraySwap(ref int[] array1,ref int[] array2)
        {
            int[] tmp = new int[array1.Length];
            tmp = array1;
            array1 = array2;
            array2 = tmp;
        }
        public static void ArraySwap(ref long[] array1, ref long[] array2)
        {
            long[] c = new long[array1.Length];
            c = array1;
            array1 = array2;
            array2 = c;
        }
    }
}
