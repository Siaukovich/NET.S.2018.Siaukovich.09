namespace Matrix.Tests
{
    public static class ArrayHelper
    {
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
        public static int Sum(this int[] array)
        {
            int sum = 0;
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
        public static int Max(this int[] array)
        {
            int max = array[0];
            for (int i = 1; i<array.Length; i++)
            {
                if (max<array[i])
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
        public static int Min(this int[] array)
        {
            int min = array[0];
            for (int i = 1; i<array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
}