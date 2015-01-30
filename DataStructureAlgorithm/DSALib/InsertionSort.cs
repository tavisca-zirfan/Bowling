using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALib
{
    public class InsertionSort
    {
        public void sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i-1;
                for (; j >= 0 && array[j] > temp; j--)
                {
                    array[j + 1] = array[j];
                }
                array[j+1] = temp;
            }
        }
    }
}
