namespace Matrix
{
    public static class ArraySorting
    {
        public static void ByRowSum(int[][] array)
        {
            var sums = new (long sum, int[] row)[array.Length];
            for (int i = 0; i < sums.Length; i++)
            {
                sums[i] = (array[i].Sum(), array[i]);
            }

            sums.BubbleSort();
        }

        public static void ByMaxElementAscending(int[][] array)
        {
            var maxes = new (long max, int[] row)[array.Length];
            for (int i = 0; i < maxes.Length; i++)
            {
                maxes[i] = (array[i].Max(), array[i]);
            }

            maxes.BubbleSort();
        }

        public static void ByMaxElementDescending(int[][] array)
        {
            ByMaxElementAscending(array);

            array.ReverseRows();
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
                        Swap(ref array[j], ref array[i]);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        private static long Sum(this int[] array)
        {
            long sum = 0;
            foreach (int i in array)
            {
                sum += i;
            }

            return sum;
        }

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

        private static void ReverseRows(this int[][] array)
        {
            int len = array.Length;
            for (int i = 0; i < array.Length / 2; i++)
            {
                Swap(ref array[i], ref array[len - i]);
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
    }
}
