using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeRandomProblem
{
    class MergeTwoSortedArray
    {
        public static void Main()
        {
            int[] arr1 = { 1, 5, 7, 12, 13 };
            int[] arr2 = { 2, 3, 6, 7, 8 };
            // output: 1,2,35,6,7,8,12,13
            int[] arr3 = new int[10];
            var n = arr1.Length; var m = arr2.Length;
            int a = 0, b = 0, c = 0;
            for (int i = 0; i < n+m; i++)
            {
                if( a == n-1 || b == m-1)  break;

                if (arr1[a] <= arr2[b])
                {
                    arr3[c] = arr1[a];
                    a++; c++;
                }
                else if(arr2[b]<arr1[a])
                {
                    arr3[c] = arr2[b];
                    b++; c++;
                }
                
            }
            if (a < n)
            {
                for (int j = a; j < n; j++)
                {
                    arr3[c] = arr1[j];
                    j++; c++;

                }

            }
            else if (b < m)
            {
                for (int k = a; k < m; k++)
                {
                    arr3[c] = arr2[k];
                    k++; c++;

                }

            }
            for (int i = 0; i < arr3.Length; i++)
                Console.WriteLine(arr3[i]);


        }
    }
}
