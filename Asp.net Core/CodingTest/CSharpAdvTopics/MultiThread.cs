//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;

//namespace CSharpAdvTopics
//{
//    class MultiThread
//    {
//        private static void Method2(object obj)
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Method2 {i} No Process is Executed");
//            }
//        }

//        private static void Method1(object obj)
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Method1 {i} No Process is Executed");
//                if (i == 5) Thread.Sleep(5000);

//            }
//        }

//        public static void Main()
//        {
//            var th1 = new Thread(Method1);
//            var th2 = new Thread(Method2);
//            th1.Start();
//            th2.Start();
//        }
//    }
//}
