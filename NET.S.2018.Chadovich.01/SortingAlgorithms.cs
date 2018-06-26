namespace SortingAlgos
{
    using System;
    using System.Collections.Generic;

    public static class SortingAlgorithms<T>
    {
        public static void MergeSort(T[] array)
        {
            MergeSort(array, Comparer<T>.Default, 0, array.Length);
        }

        public static void MergeSort(T[] array, IComparer<T> comparer)
        {
            MergeSort(array, comparer, 0, array.Length);
        }
        
        public static void MergeSort(T[] array, IComparer<T> comparer, int start, int end)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} refers to null");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} refers to null");
            }
            if (start < 0 || end < start || end < 0 || start > array.Length || end > array.Length)
            {
                throw new ArgumentOutOfRangeException("border params are out of range");
            }
            
            void Sort(T[] a, int s, int e)
            {
                if (s + 1 >= e) return;
                 
                int mid = (s + e) / 2;
                Sort(a, s, mid);
                Sort(a, mid, e);
                Merge(array, comparer, s, mid, e);
            }

            Sort(array, start, end);
        }

        public static void QuickSort(T[] array)
        {
            QuickSort(array, Comparer<T>.Default, 0, array.Length);
        }

        public static void QuickSort(T[] array, int start, int end)
        {
            QuickSort(array, Comparer<T>.Default, start, end);
        }

        public static void QuickSort(T[] array, IComparer<T> comparer)
        {
            QuickSort(array, comparer, 0, array.Length);
        }

        public static void QuickSort(T[] array, IComparer<T> comparer, int start, int end)
        {
            if (array == null) throw new ArgumentNullException($"{nameof(array)} refers to null");
            if (comparer == null) throw new ArgumentNullException($"{nameof(comparer)} refers to null");
            if (start < 0 || end < start || end < 0 || start > array.Length || end > array.Length)
                throw new ArgumentOutOfRangeException("border params are out of range");

            void Sort(T[] a, int s, int e)
            {
                if (s >= e) return;

                int part = GetPartition(a, comparer, s, e);
                Sort(a, s, part);
                Sort(a, part + 1, e);
            }

            Sort(array, start, end - 1);
        }

        private static int GetPartition(T[] array, IComparer<T> comparer, int start, int end)
        {
            T temp = array[(start + end) / 2];
            int i = start, j = end;

            while (i <= j)
            {
                while (comparer.Compare(array[i], temp) < 0) i++;
                while (comparer.Compare(temp, array[j]) < 0) j--;

                if (i >= j) break;
                Swap(ref array[i++], ref array[j--]);
            }
            return j;
        }

        private static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
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
    }
}
