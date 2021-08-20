//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;

//namespace CSharpAdvTopics
//{
//    class ForeGroundThreadExample
//    {
//        public static void Main()
//        {
//            Thread thr = new Thread(MyThread);
//            thr.Start();
//            Console.WriteLine("Main Thread is complete");

//        }
//        private static void MyThread()
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                Console.WriteLine("MyThread is running");
//                Thread.Sleep(1000);
//            }
//            Console.WriteLine("MyThread is completed");
//        }
//    }
//}
