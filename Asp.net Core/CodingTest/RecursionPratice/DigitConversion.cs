//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RecursionPratice
//{
//    class DigitConversion
//    {
//        public static int cnt = 0;
//        public static void Main(string[] args)
//        {
//            int n = 450;
//            Console.WriteLine(FrequencyConversion(n));
//        }

//        private static int FrequencyConversion(int n)
//        {
//            if (n!= 0)
//            {
//                //Console.WriteLine(n % 10);
//                cnt++;
//                n = n / 10;
//                return FrequencyConversion(n);
//            }
//            return cnt;
//        }
//    }
//}
