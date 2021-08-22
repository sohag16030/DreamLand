//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace PracticeRandomProblem
//{
//    class BubbleSort //complexity O(n)
//    {
//        public static void Main()
//        {
//            var arr = new List<int> { 4, 3, 2, 1 };
//            int cnt = 0;
//            for (int i = 0; i < arr.Count; i++)
//            {
//                var temp = 0;
//                for (int j = i; j < arr.Count; j++)
//                {
//                    if (arr[i] > arr[j])
//                    {
//                        temp = arr[j];
//                        arr[j] = arr[i];
//                        arr[i] = temp;
//                        cnt++;
//                    }
//                }
//            }
//            Console.WriteLine(cnt);
//        }
//    }
//}
