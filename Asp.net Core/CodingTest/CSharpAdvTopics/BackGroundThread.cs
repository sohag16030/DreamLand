//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;

//namespace CSharpAdvTopics
//{
//    class BackGroundThread
//    {
//        public static void Main()
//        {
//            var thr = new Thread(mythread);
//            thr.Start();
//            thr.IsBackground = true;
//            Console.WriteLine("Main Thread is completed");
//        }

//        private static void mythread(object obj)
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                Console.WriteLine("MyThread is running");
//                Thread.Sleep(1000);
//            }
//            Console.WriteLine("My Thread is completed");
//        }
//    }
//}
