//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace PracticeRandomProblem
//{
//    class SelectionSort
//    {
//        public static void Main()
//        {
//            int[] arr = { 43, 16, 11, 12, 15, 27 };
//            var sorted = SelectionSorting(arr);
//            foreach (var item in sorted)
//            {
//                Console.WriteLine(item);
//            }
//        }

//        private static int[] SelectionSorting(int[] arr)
//        {
//            int min_indx = 0; var temp = 0;
//            for (int i = 0; i < arr.Length; i++)
//            {
//                min_indx = i;
//                for (int j = i + 1; j < arr.Length; j++)
//                {
//                    if (arr[j] < arr[min_indx])
//                    {
//                        min_indx = j;
//                    }
//                }

//                temp = arr[min_indx];
//                arr[min_indx] = arr[i];
//                arr[i] = temp;
//            }
//            return arr;
//        }
//    }
//}
