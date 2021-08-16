using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvTopics
{
    public class Generic
    {
        public static T Test<T>(T a)
        {
            return a;
        }
        static void Main(string[] args)
        {
           Console.WriteLine(Test<int>(5));
           Console.WriteLine(Test<string>("hello"));
        }
    }
}
