using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALib
{
    public class QuickSort
    {
        public int Partition(int[] array, int start, int end)
        {
            int i = start;
            int j = end;
            int pivot = end;
            while (i < j)
            {
                while (array[i] < array[pivot])
                    i++;
                while (array[j] > array[pivot])
                    j--;
                if (i < j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }

            }
            int temp2 = array[j];
            array[j] = array[pivot];
            array[pivot] = temp2;

            return j;
        }

        public void QuickSortArray(int[] array,int start,int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                QuickSortArray(array,start,pivot-1);
                QuickSortArray(array,pivot+1,end);
            }
        }
    }
}
