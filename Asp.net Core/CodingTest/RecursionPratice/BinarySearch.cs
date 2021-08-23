//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RecursionPratice
//{
//    class BinarySearch
//    {
//        public static void Main()
//        {
//            var arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
//            int l = 0, h = 6, search = 6;
//            Console.WriteLine(binarySerach(arr, l, h, search));
//        }

//        private static int binarySerach(List<int> arr, int l, int h, int search)
//        {
//            var mid = (l + h) / 2;
//            if (arr[mid] == search)
//                return arr[mid];
//            else if (arr[mid] > search)
//                return binarySerach(arr, l, mid - 1, search);
//            else
//                return binarySerach(arr, mid + 1, h, search);
//        }
//    }
//}
