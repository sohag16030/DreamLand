using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeRandomProblem
{
    class ReverseArray
    {
        public static void Main()
        {
            int[] arr = { 10, 12, 13, 1, 4, 11 };
            Reverse(arr.Length-1,arr);
        }

        private static int Reverse(int n,int[] arr)
        {
            if (n == 0)
            {
                Console.WriteLine(arr[n]);
                return arr[n];
            }
            else
            {
                Console.WriteLine(arr[n]);
                n -= 1;
                return Reverse(n,arr);
            }

        }
    }
}
