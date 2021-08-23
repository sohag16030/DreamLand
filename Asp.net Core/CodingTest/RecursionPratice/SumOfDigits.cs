//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RecursionPratice
//{
//    class SumOfDigits
//    {
//        public static int sum;
//        public static void Main(string[] args)
//        {
//            var n = 123;
//            Console.WriteLine(SumOfDigitsfun(n));
//        }

//        private static int SumOfDigitsfun(int n)
//        {
//            if (n != 0)
//            {
//                sum += n % 10;
//                return SumOfDigitsfun(n / 10);
//            }
//            return sum;
//        }
//    }
//}
