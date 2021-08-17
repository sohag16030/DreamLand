//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CSharpAdvTopics
//{
//    class LamdaExpression
//    {
//        public delegate int Multiplication(int a, int b);
//        public static void Main()
//        {
//            Func<int, int> Square = num => num * num;
//            Console.WriteLine(Square(5));

//            Multiplication s = (o, p) => o * p;
//            int result = s(5, 2);
//            Console.WriteLine(result);

//            //Func<int, int> res = (a, b) => a * b;
//            Func<int, int, int> add = (a, b) => a + b;

//            Console.WriteLine( add(1, 3));

//        }
//    }
//}
