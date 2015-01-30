using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALib
{
    public class MergeSort
    {
        public void MergeSortArray(int[] array, int start, int end)
        {
            if (end > start)
            {
                MergeSortArray(array, start, (start + end) / 2);
                MergeSortArray(array, ((start + end) / 2) + 1, end);
                Merge(array, start, end);
            }
        }

        public void Merge(int[] array, int start, int end)
        {
            int midpoint = (end + start) / 2;
            int totalElement = end - start + 1;
            int[] tempArray = new int[totalElement];
            int i = start;
            int j = midpoint+1;
            int k = 0;
            while (i <= midpoint && j <= end)
            {
                if (array[i] <= array[j])
                {
                    tempArray[k] = array[i];
                    i++;
                    k++;
                }
                else
                {
                    tempArray[k] = array[j];
                    j++;
                    k++;
                }
            }
            while (i<=midpoint)
            {
                tempArray[k] = array[i];
                i++;
                k++;
            }
            while (j<=end)
            {
                tempArray[k] = array[j];
                j++;
                k++;
            }
            for (int num = 0; num < tempArray.Length; num++)
            {
                array[start + num] = tempArray[num];
            }
        }
    }
}
