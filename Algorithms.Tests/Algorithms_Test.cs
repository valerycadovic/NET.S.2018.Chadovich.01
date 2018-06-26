using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgos;

namespace Algorithms.Tests
{
    [TestClass]
    public class Algorithms_Test
    {
        [TestMethod]
        public void Can_MergeSort()
        {
            int[] expect = { 4, 5, 2, 3, 3, 6, 7, -1, 0, -1 };
            int[] sorted = { -1, -1, 0, 2, 3, 3, 4, 5, 6, 7 };

            SortingAlgorithms<int>.MergeSort(expect, Comparer<int>.Default, 0, expect.Length);

            CollectionAssert.AreEqual(sorted, expect);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_Throws_ArgumentNullException()
        {
            SortingAlgorithms<int>.MergeSort(null, null, 0, 10);
        }
        
        [TestMethod]
        public void Can_QuickSort()
        {
            int[] expect = { 4, 5, 2, 3, 3, 6, 7, -1, 0, -1 };
            int[] sorted = { -1, -1, 0, 2, 3, 3, 4, 5, 6, 7 };

            SortingAlgorithms<int>.QuickSort(expect, Comparer<int>.Default, 0, expect.Length);

            CollectionAssert.AreEqual(sorted, expect);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_Throws_ArgumentNullException()
        {
            SortingAlgorithms<int>.QuickSort(null, null, 0, 10);
        }

    }
}
