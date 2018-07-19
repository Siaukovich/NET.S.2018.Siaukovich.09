namespace Matrix.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    /// <summary>
    /// Class for testing MatrixSort class.
    /// </summary>
    [TestFixture]
    public class MatrixSortTests
    {
        [Test]
        public void Sortings_NullMatrix_ThrowsArgumentNullExc()
        {
            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.SortBy(null, new CompareByRowSumAscending()), 
                $"{nameof(MatrixSort.SortBy)} not throwing ArgumentNullException.");
        }

        [Test]
        public void Sortings_NullComparer_ThrowsArgumentNullExc()
        {
            const int SIZE = 5;
            var matrix = new int[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                matrix[i] = new int[SIZE];
            }

            Assert.Throws<ArgumentNullException>(
                () => matrix.SortBy(null),
                $"{nameof(MatrixSort.SortBy)} not throwing ArgumentNullException.");
        }


        [Test]
        public void SortByRowSumAscending_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(new CompareByRowSumAscending());

                if (!IsSortedByKeyAscending(array, key: Enumerable.Sum))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }
        }

        [Test]
        public void SortByRowSumDescendind_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(new CompareByRowSumDescending());

                if (!IsSortedByKeyDescending(array, key: Enumerable.Sum))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }
        }

        [Test]
        public void SortByMaxElementAscending_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(new CompareByMaxElementAscending());

                if (!IsSortedByKeyAscending(array, key: Enumerable.Max))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }
        }

        [Test]
        public void SortByMaxElementDescending_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(new CompareByMaxElementDescending());

                if (!IsSortedByKeyDescending(array, key: Enumerable.Max))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }
        }

        [Test]
        public void SortByMinElementAscending_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(new CompareByMinElementAscending());

                if (!IsSortedByKeyAscending(array, key: Enumerable.Min))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }
        }

        [Test]
        public void SortByMinElementDescending_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(new CompareByMinElementDescending());

                if (!IsSortedByKeyDescending(array, Enumerable.Min))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }
        }

        private int[][] GetRandomArray(int size, Random rng)
        {
            var array = new int[size][];
            for (int j = 0; j < size; j++)
            {
                array[j] = new int[rng.Next(1, size)];
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rng.Next(-size, size);
                }
            }

            return array;
        }

        private static bool IsSortedByKeyAscending(int[][] array, Func<int[], int> key)
        {
            int[] sums = array.Select(key).ToArray();
            for (int i = 0; i < sums.Length - 1; i++)
            {
                if (sums[i] > sums[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsSortedByKeyDescending(int[][] array, Func<int[], int> key)
        {
            int[] sums = array.Select(key).ToArray();
            for (int i = 0; i < sums.Length - 1; i++)
            {
                if (sums[i] < sums[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
