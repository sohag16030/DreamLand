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
            // output: 1,2,3,5,6,7,8,12,13
            var n = arr1.Length; var m = arr2.Length;
            int[] arr3 = new int[n+m];

            int a = 0, b = 0, c = 0;
            while(a<n && b<m)
            {

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
                while (a < n)
                {
                    arr3[c] = arr1[a];
                    a++;c++;
                }

            }
            else if (b < m)
            {
                while (b < m)
                {
                    arr3[c] = arr2[b];
                    b++; c++;
                }

            }
            for (int i = 0; i < arr3.Length; i++)
                Console.WriteLine(arr3[i]);


        }
    }
}
