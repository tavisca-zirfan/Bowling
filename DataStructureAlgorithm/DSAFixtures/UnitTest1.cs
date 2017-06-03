using System;
using DSALib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSAFixtures
{
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        public void ShouldMergeSortArray()
        {
            var arr = new int[10] {5,7,4,8,1,9,6,4,3,4};
            MergeSort sorter = new MergeSort();
            sorter.MergeSortArray(arr,0,arr.Length-1);
            CollectionAssert.AreEqual(arr, new int[10] { 1,3,4,4,4,5,6,7,8,9 });
        }

        [TestMethod]
        public void ShouldQuickSortArray()
        {
            var arr = new int[10] { 5, 7, 4, 8, 1, 9, 6, 4, 3, 4 };
            QuickSort sorter = new QuickSort();
            sorter.QuickSortArray(arr, 0, arr.Length - 1);
            CollectionAssert.AreEqual(arr, new int[10] { 1, 3, 4, 4, 4, 5, 6, 7, 8, 9 });
        }

        [TestMethod]
        public void ShouldInsertionSortArray()
        {
            var arr = new int[10] { 5, 7, 4, 8, 1, 9, 6, 4, 3, 4 };
            InsertionSort sorter = new InsertionSort();
            sorter.sort(arr);
            CollectionAssert.AreEqual(arr, new int[10] { 1, 3, 4, 4, 4, 5, 6, 7, 8, 9 });
        }
    }
}
