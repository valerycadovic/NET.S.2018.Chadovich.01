﻿namespace SortingAlgos
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A set of sorting methods
    /// </summary>
    /// <typeparam name="T">Type of instances to be sorted</typeparam>
    public static class SortingAlgorithms<T>
    {
        /// <summary>
        /// Merge sorting method with O(n*log(n)) the worst difficulty
        /// </summary>
        /// <param name="array">array to be sorted</param>
        public static void MergeSort(T[] array)
        {
            MergeSort(array, Comparer<T>.Default, 0, array.Length);
        }

        /// <summary>
        /// Merge sorting method with O(n*log(n)) the worst difficulty
        /// </summary>
        /// <param name="array">array to be sorted</param>
        /// <param name="comparer">defines sorting condition</param>
        public static void MergeSort(T[] array, IComparer<T> comparer)
        {
            MergeSort(array, comparer, 0, array.Length);
        }

        /// <summary>
        /// Merge sorting method with O(n*log(n)) the worst difficulty
        /// </summary>
        /// <param name="array">array to be sorted</param>
        /// <param name="comparer">defines sorting condition</param>
        /// <param name="start">start index of sorting</param>
        /// <param name="end">end index of sorting</param>
        public static void MergeSort(T[] array, IComparer<T> comparer, int start, int end)
        {
            ValidateNull(array, nameof(array));
            ValidateNull(comparer, nameof(comparer));
            ValidateParams(array, start, end);

            void Sort(T[] a, int s, int e)
            {
                if (s + 1 >= e)
                {
                    return;
                }

                int mid = (s + e) / 2;
                Sort(a, s, mid);
                Sort(a, mid, e);
                Merge(array, comparer, s, mid, e);
            }

            Sort(array, start, end);
        }

        /// <summary>
        /// Quick sorting method with O(n*log(n)) average difficulty
        /// </summary>
        /// <param name="array">array to be sorted</param>
        public static void QuickSort(T[] array)
        {
            QuickSort(array, Comparer<T>.Default, 0, array.Length);
        }

        /// <summary>
        /// Quick sorting method with O(n*log(n)) average difficulty
        /// </summary>
        /// <param name="array">array to be sorted</param>
        /// <param name="start">start index of sorting</param>
        /// <param name="end">end index of sorting</param>
        public static void QuickSort(T[] array, int start, int end)
        {
            QuickSort(array, Comparer<T>.Default, start, end);
        }

        /// <summary>
        /// Quick sorting method with O(n*log(n)) average difficulty
        /// </summary>
        /// <param name="array">end index of sorting</param>
        /// <param name="comparer">defines sorting condition</param>
        public static void QuickSort(T[] array, IComparer<T> comparer)
        {
            QuickSort(array, comparer, 0, array.Length);
        }

        /// <summary>
        /// Quick sorting method with O(n*log(n)) average difficulty
        /// </summary>
        /// <param name="array">array to be sorted</param>
        /// <param name="comparer">defines sorting condition</param>
        /// <param name="start">start index of sorting</param>
        /// <param name="end">end index of sorting</param>
        public static void QuickSort(T[] array, IComparer<T> comparer, int start, int end)
        {
            ValidateNull(array, nameof(array));
            ValidateNull(comparer, nameof(comparer));
            ValidateParams(array, start, end);

            void Sort(T[] a, int s, int e)
            {
                if (s >= e)
                {
                    return;
                }

                int part = GetPartition(a, comparer, s, e);
                Sort(a, s, part);
                Sort(a, part + 1, e);
            }

            Sort(array, start, end - 1);
        }

        /// <summary>
        /// Constricts sorting area
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="comparer">defines sorting condition</param>
        /// <param name="start">start index of sorting</param>
        /// <param name="end">end index of sorting</param>
        /// <returns>the center index of constricted area</returns>
        private static int GetPartition(T[] array, IComparer<T> comparer, int start, int end)
        {
            T temp = array[(start + end) / 2];
            int i = start, j = end;

            while (i <= j)
            {
                while (comparer.Compare(array[i], temp) < 0)
                {
                    i++;
                }

                while (comparer.Compare(temp, array[j]) < 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                Swap(ref array[i++], ref array[j--]);
            }

            return j;
        }

        /// <summary>
        /// Swaps two elements
        /// </summary>
        /// <param name="a">element 1</param>
        /// <param name="b">element 2</param>
        private static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Merges two subarrays of preset array
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="comparer">defines sorting condition</param>
        /// <param name="start">start index of merging</param>
        /// <param name="mid">middle index</param>
        /// <param name="end">end index</param>
        private static void Merge(T[] array, IComparer<T> comparer, int start, int mid, int end)
        {
            uint l = 0, r = 0;

            T[] result = new T[end - start];

            while (start + l < mid && mid + r < end)
            {
                if (comparer.Compare(array[start + l], array[mid + r]) < 0)
                {
                    result[l + r] = array[start + l];
                    l++;
                }
                else
                {
                    result[l + r] = array[mid + r];
                    r++;
                }
            }

            while (start + l < mid)
            {
                result[l + r] = array[start + l];
                l++;
            }

            while (mid + r < end)
            {
                result[l + r] = array[mid + r];
                r++;
            }

            for (int i = 0; i < l + r; i++)
            {
                array[start + i] = result[i];
            }
        }

        /// <summary>
        /// Checks if object is null
        /// </summary>
        /// <param name="object">checking object</param>
        /// <param name="objectName">name of checking object</param>
        private static void ValidateNull(object @object, string objectName)
        {
            if (@object == null)
            {
                throw new ArgumentNullException($"{objectName} refers to null");
            }
        }

        /// <summary>
        /// Validates indexes of array
        /// </summary>
        /// <param name="array">sorting array</param>
        /// <param name="start">start index</param>
        /// <param name="end">end index</param>
        private static void ValidateParams(T[] array, int start, int end)
        {
            if (start < 0 || end < start || end < 0 || start > array.Length || end > array.Length)
            {
                throw new ArgumentOutOfRangeException("border params are out of range");
            }
        }
    }
}
