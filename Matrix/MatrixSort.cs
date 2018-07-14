namespace Matrix
{
    using System;

    /// <summary>
    /// Class for sorting matrix's rows by different keys.
    /// </summary>
    public static class MatrixSort
    {
        /// <summary>
        /// Sorts matrix's rows by sum of each row in ascending order.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null or any of its rows is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if some of matrix's row are empty.
        /// </exception>
        public static void ByRowSumAscending(int[][] matrix)
        {
            ThrowForInvalidMatrix(matrix);

            var sums = new (long sum, int[] row)[matrix.Length];
            for (int i = 0; i < sums.Length; i++)
            {
                sums[i] = (matrix[i].Sum(), matrix[i]);
            }

            sums.BubbleSort();

            for (int i = 0; i < sums.Length; i++)
            {
                matrix[i] = sums[i].row;
            }
        }

        /// <summary>
        /// Sorts matrix's rows by sum of each row in descending order.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null or any of its rows is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if some of matrix's row are empty.
        /// </exception>
        public static void ByRowSumDescending(int[][] matrix)
        {
            ByRowSumAscending(matrix);

            matrix.ReverseRows();
        }

        /// <summary>
        /// Sorts matrix's rows by max element of each row in ascending order.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null or any of its rows is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if some of matrix's row are empty.
        /// </exception>
        public static void ByMaxElementAscending(int[][] matrix)
        {
            ThrowForInvalidMatrix(matrix);

            var maxes = new (long max, int[] row)[matrix.Length];
            for (int i = 0; i < maxes.Length; i++)
            {
                maxes[i] = (matrix[i].Max(), matrix[i]);
            }

            maxes.BubbleSort();

            for (int i = 0; i < maxes.Length; i++)
            {
                matrix[i] = maxes[i].row;
            }
        }

        /// <summary>
        /// Sorts matrix's rows by max element of each row in descending order.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null or any of its rows is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if some of matrix's row are empty.
        /// </exception>
        public static void ByMaxElementDescending(int[][] matrix)
        {
            ByMaxElementAscending(matrix);

            matrix.ReverseRows();
        }

        /// <summary>
        /// Sorts matrix's rows by min element of each row in ascending order.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null or any of its rows is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if some of matrix's row are empty.
        /// </exception>
        public static void ByMinElementAscending(int[][] matrix)
        {
            ThrowForInvalidMatrix(matrix);

            var mins = new (long max, int[] row)[matrix.Length];
            for (int i = 0; i < mins.Length; i++)
            {
                mins[i] = (matrix[i].Min(), matrix[i]);
            }

            mins.BubbleSort();

            for (int i = 0; i < mins.Length; i++)
            {
                matrix[i] = mins[i].row;
            }
        }

        /// <summary>
        /// Sorts matrix's rows by min element of each row in descending order.
        /// </summary>
        /// <param name="matrix">
        /// Matrix that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null or any of its rows is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if some of matrix's row are empty.
        /// </exception>
        public static void ByMinElementDescending(int[][] matrix)
        {
            ByMinElementAscending(matrix);

            matrix.ReverseRows();
        }

        /// <summary>
        /// Bubble sort which performs O(n) in best case.
        /// </summary>
        /// <param name="array">
        /// Array of tuples (key, value).
        /// </param>
        private static void BubbleSort(this (long key, int[] row)[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].key > array[j + 1].key)
                    {
                        Swap(ref array[j], ref array[j + 1]);
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
        /// Checks passed matrix.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if matrix is null or any of its rows is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if some of matrix's row are empty.
        /// </exception>
        private static void ThrowForInvalidMatrix(int[][] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (AnyRowIsNull())
            {
                throw new ArgumentNullException(nameof(matrix), "Not all rows are initialized.");
            }

            if (AnyRowIsEmpty())
            {
                throw new ArgumentException("Matrix's rows can not be empty.");
            }

            bool AnyRowIsNull()
            {
                foreach (int[] row in matrix)
                {
                    if (row == null)
                    {
                        return true;
                    }
                }

                return false;
            }

            bool AnyRowIsEmpty()
            {
                foreach (int[] row in matrix)
                {
                    if (row.Length == 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Sums all elements in given array.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// Sum of all elements in array.
        /// </returns>
        private static long Sum(this int[] array)
        {
            long sum = 0;
            foreach (int i in array)
            {
                sum += i;
            }

            return sum;
        }

        /// <summary>
        /// Returns max element of passed array.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// Max element of a passed array.
        /// </returns>
        private static long Max(this int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Returns min element of passed array.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// Min element of a passed array.
        /// </returns>
        private static long Min(this int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Reverses rows of a given jagged array.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        private static void ReverseRows(this int[][] array)
        {
            int lastIndex = array.Length - 1;
            for (int i = 0; i < array.Length / 2; i++)
            {
                Swap(ref array[i], ref array[lastIndex - i]);
            }
        }

        /// <summary>
        /// Swaps two given operands.
        /// </summary>
        /// <param name="a">
        /// First operand.
        /// </param>
        /// <param name="b">
        /// Second operand.
        /// </param>
        /// <typeparam name="T">
        /// Type of a swapped element.
        /// </typeparam>
        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
    }
}
