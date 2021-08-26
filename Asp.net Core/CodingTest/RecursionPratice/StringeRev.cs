using System;
using System.Collections.Generic;
using System.Text;

namespace RecursionPratice
{
    class StringeRev
    {    
        public static string str = "Code";
        public static void Main(string[] args)
        {
            int l = str.Length;
            StringReverse(l-1);
        }

        private static int StringReverse(int l)
        {
            if (l == 0)
            {
                Console.WriteLine(str[l]);
                return 0;
            }
            else
            {
                Console.WriteLine(str[l]);
                l--;
                return StringReverse(l);
            }
        }
    }
}
