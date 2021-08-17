using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvTopics
{
    public class Testing 
    {
        public delegate void Mydelegate();
        public Mydelegate testDelegate;
        public void Start()
        {
            testDelegate = TestMethod;
            testDelegate();
        }
        public static void TestMethod()
        {
            Console.WriteLine("DelegateDone");
        }
    }
}
