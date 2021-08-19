using System;
using System.Collections.Generic;
using System.Text;

namespace RecursionPratice
{
    class Fibonacci
    {
        public static void Main()
        {
            var n = 3;
            Console.WriteLine( Fib(n));
        }

        public  static int Fib(int n)
        {
            if (n == 1 || n == 0) return 1;
            else 
                return Fib(n - 1) + Fib(n - 2);
        }
    }
}
