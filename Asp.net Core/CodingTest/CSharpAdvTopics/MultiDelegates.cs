using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvTopics
{
    public delegate int AreaCalculation(int l, int h);
    public class MultiDelegates
    {
        public int BoxArea(int a, int b)
        {
            return a * b;
        }
        public int BoxPeremeter(int x,int y)
        {
            return x * y;
        }
        public static void Main()
        {
            var obj = new MultiDelegates();
            AreaCalculation del = new AreaCalculation(obj.BoxArea);
            del += obj.BoxPeremeter;

            Console.WriteLine(del(1, 2));
            Console.WriteLine(del.Invoke(2, 3));

        }
    }
}
