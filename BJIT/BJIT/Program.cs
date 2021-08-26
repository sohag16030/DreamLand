using System;
using System.Collections.Generic;

namespace BJIT
{
    class Program
    {
        static void allLexicographicRecur(String str, char[] data,
                                     int last, int index)
        {
            int length = str.Length;

            for (int i = 0; i < length; i++)
            {
                data[index] = str[i];

                if (index == last)
                    Console.WriteLine(new String(data));
                else
                    allLexicographicRecur(str, data, last,
                                               index + 1);
            }
        }

        static void allLexicographic(String str)
        {
            int length = str.Length;

            char[] data = new char[length + 1];
            char[] temp = str.ToCharArray();
            Array.Sort(temp);
            str = new String(temp);

            allLexicographicRecur(str, data, length - 1, 0);
        }
        public static void Main(String[] args)
        {
            String str = "0123456789";
            Console.Write("All permutations with " +
                       "repetition of {0} are: \n", str);
            allLexicographic(str);
        }
    }
}

