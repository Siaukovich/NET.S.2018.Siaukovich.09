﻿namespace Matrix
{
    using System;

    /// <summary>
    /// Class for sorting matrix's rows by different keys.
    /// </summary>
    public static class MatrixSort
    {
        /// <summary>
        /// Sorts in ascending order using given strategy.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <param name="comparer">
        /// Rule for sorting matrix.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null.
        /// </exception>
        public static void AscendingSortBy(this int[][] matrix, ICustomComparer comparer)
        {
            ThrowForNullMatrix(matrix);
            
            BubbleSort(matrix, comparer);
        }

        /// <summary>
        /// Sorts in descending order using given strategy.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <param name="comparer">
        /// Rule for sorting matrix.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null.
        /// </exception>
        public static void DescendingSortBy(this int[][] matrix, ICustomComparer comparer)
        {
            ThrowForNullMatrix(matrix);

            BubbleSort(matrix, comparer);
            
            Array.Reverse(matrix);
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
        private static void BubbleSort(int[][] matrix, ICustomComparer comparer)
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

        /// <summary>
        /// Checks passed matrix for null.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null.
        /// </exception>
        private static void ThrowForNullMatrix(int[][] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }
    }
}
