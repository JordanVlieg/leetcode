using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    static class MergeSort
    {
        public static void Merge(int[] array, int l, int m, int r)
        {
            int i = l;
            int j = m + 1;
            int k = 0;
            int[] temp = new int[r - l + 1];
            while(i <= m && j <= r)
            {
                if (array[i] < array[j])
                    temp[k++] = array[i++];
                else
                    temp[k++] = array[j++];
            }
            while (i <= m)
            {
                temp[k++] = array[i++];
            }
            while (j <= r)
            {
                temp[k++] = array[j++];
            }
            int y = 0;
            for(int x = l; x <= r; x++)
            {
                array[x] = temp[y++];
            }
        }

        public static void _Sort(int[] array, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                _Sort(array, l, m);
                _Sort(array, m + 1, r);
                Merge(array, l, m, r);
            }
        }

        public static void Sort(int[] array)
        {
            _Sort(array, 0, array.Length - 1);
        }
    }
}
