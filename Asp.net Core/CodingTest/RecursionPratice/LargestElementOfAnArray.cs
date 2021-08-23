//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RecursionPratice
//{
//    class LargestElementOfAnArray
//    {
//        public static int[] arr = { 5, 3, 2, 6, 7 };
//        public static int max = -99999;
//        public static void Main(string[] args)
//        {
//            var n = 0;
//            Console.WriteLine(LargestElementOfAnArrayFindingsFun(n));
//        }

//        private static int LargestElementOfAnArrayFindingsFun(int n)
//        {
//            if (n < arr.Length)
//            {
//                if (arr[n] > max)
//                {
//                    max = arr[n];
//                    n++;
//                    LargestElementOfAnArrayFindingsFun(n);
//                }
//                else
//                {
//                    n++;
//                    LargestElementOfAnArrayFindingsFun(n);
//                }

//            }
           
//            return  max;
//        }
//    }
//}
