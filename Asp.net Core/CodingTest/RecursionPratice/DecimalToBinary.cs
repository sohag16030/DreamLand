//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RecursionPratice
//{
//    class DecimalToBinary
//    {
//        public static void Main()
//        {
//            int n = 11;
//            Console.WriteLine(binaryConversion(n));
//        }  
//        public static int factor = 1, bin = 0, r;
//        private static int binaryConversion(int n)
//        {
//            if (n != 0)
//            {
//                //Console.WriteLine(n % 2);
//                r = n % 2;
//                bin += r * factor;
//                factor = factor * 10;
//                n = n / 2;
//                return binaryConversion(n);
//            }
//            else
//                return bin;
//        }
//    }
//}
