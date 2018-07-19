namespace Matrix
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for sorting matrix's rows by different Comparison delegates.
    /// </summary>
    public static class MatrixSortByDelegate
    {
        /// <summary>
        /// Sorts in ascending order using given strategy.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <param name="comparison">
        /// Rule for sorting matrix.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null.
        /// </exception>
        public static void SortBy(this int[][] matrix, Comparison<int[]> comparison)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            BubbleSort(matrix, Comparer<int[]>.Create(comparison));
        }

        /// <summary>
        /// Bubble sort which performs O(n) in best case.
        /// </summary>
        /// <param name="matrix">
        /// Array of tuples (key, value).
        /// </param>
        /// <param name="comparer">
        /// Comparer of two sz matrixes.
        /// </param>
        private static void BubbleSort(int[][] matrix, IComparer<int[]> comparer)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                bool swapped = false;
                for (int j = 0; j < matrix.Length - i - 1; j++)
                {
                    if (comparer.Compare(matrix[j], matrix[j + 1]) > 0)
                    {
                        Swap(ref matrix[j], ref matrix[j + 1]);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Swaps two given arrays.
        /// </summary>
        /// <param name="a">
        /// First array.
        /// </param>
        /// <param name="b">
        /// Second array.
        /// </param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            var t = a;
            a = b;
            b = t;
        }
    }
}