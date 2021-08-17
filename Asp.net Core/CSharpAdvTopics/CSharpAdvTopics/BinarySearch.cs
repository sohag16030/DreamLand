using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvTopics
{
    public class BinarySearch
    {
        public static int binarySearch(int val,int[] arr,int l,int h)
        {
            while (h >= l)
            {
                int mid = (l + h) / 2;
                if (arr[mid] == val)
                    return val;
                else if (arr[mid] > val)
                    h = mid - 1;
                else
                    l = mid + 1;
            }
            return 0;
        }
        public static void Main()
        {
            int searchval = 5;
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            int l = 0, h = 5;
            binarySearch(searchval, arr,l,h);

        }
    }
}
