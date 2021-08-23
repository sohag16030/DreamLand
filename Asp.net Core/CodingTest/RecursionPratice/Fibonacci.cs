using System;
using System.Collections.Generic;
using System.Text;

namespace RecursionPratice
{
    class Fibonacci
    {
        public static void Main()
        {
            var n = 6;
            Console.WriteLine(Fib(n));
        }

        public static int Fib(int n)
        {
            if (n==0 || n == 1) return 1;
            else
                return Fib(n - 1) + Fib(n - 2);
        }
    }
}
