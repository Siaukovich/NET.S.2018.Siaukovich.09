namespace Matrix.Tests
{
    using System;
    using System.Linq;
    using System.Runtime.ExceptionServices;

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
                () => MatrixSort.ByRowSumAscending(null), 
                $"{nameof(MatrixSort.ByRowSumAscending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByRowSumDescending(null), 
                $"{nameof(MatrixSort.ByRowSumDescending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMaxElementAscending(null), 
                $"{nameof(MatrixSort.ByMaxElementAscending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMaxElementDescending(null), 
                $"{nameof(MatrixSort.ByMaxElementDescending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMinElementAscending(null), 
                $"{nameof(MatrixSort.ByMinElementAscending)}not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMinElementDescending(null), 
                $"{nameof(MatrixSort.ByMinElementDescending)} not throwing ArgumentNullException.");
        }

        [Test]
        public void Sortings_NullRowInMatrix_ThrowsArgumentNullExc()
        {
            const int SIZE = 5;
            var matrix = new int[SIZE][];
            for (int i = 0; i < SIZE - 1; i++)
            {
                matrix[i] = new int[SIZE];
            }

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByRowSumAscending(matrix),
                $"{nameof(MatrixSort.ByRowSumAscending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByRowSumDescending(matrix),
                $"{nameof(MatrixSort.ByRowSumDescending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMaxElementAscending(matrix),
                $"{nameof(MatrixSort.ByMaxElementAscending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMaxElementDescending(matrix),
                $"{nameof(MatrixSort.ByMaxElementDescending)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMinElementAscending(matrix),
                $"{nameof(MatrixSort.ByMinElementAscending)}not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSort.ByMinElementDescending(matrix),
                $"{nameof(MatrixSort.ByMinElementDescending)} not throwing ArgumentNullException.");
        }

        [Test]
        public void Sortings_EmptyRowInMatrix_ThrowsArgumentNullExc()
        {
            const int SIZE = 5;
            var matrix = new int[SIZE][];
            for (int i = 0; i < SIZE - 1; i++)
            {
                matrix[i] = new int[SIZE];
            }

            matrix[SIZE - 1] = new int[0];

            Assert.Throws<ArgumentException>(
                () => MatrixSort.ByRowSumAscending(matrix),
                $"{nameof(MatrixSort.ByRowSumAscending)} not throwing ArgumentException.");

            Assert.Throws<ArgumentException>(
                () => MatrixSort.ByRowSumDescending(matrix),
                $"{nameof(MatrixSort.ByRowSumDescending)} not throwing ArgumentException.");

            Assert.Throws<ArgumentException>(
                () => MatrixSort.ByMaxElementAscending(matrix),
                $"{nameof(MatrixSort.ByMaxElementAscending)} not throwing ArgumentException.");

            Assert.Throws<ArgumentException>(
                () => MatrixSort.ByMaxElementDescending(matrix),
                $"{nameof(MatrixSort.ByMaxElementDescending)} not throwing ArgumentException.");

            Assert.Throws<ArgumentException>(
                () => MatrixSort.ByMinElementAscending(matrix),
                $"{nameof(MatrixSort.ByMinElementAscending)}not throwing ArgumentException.");

            Assert.Throws<ArgumentException>(
                () => MatrixSort.ByMinElementDescending(matrix),
                $"{nameof(MatrixSort.ByMinElementDescending)} not throwing ArgumentException.");
        }

        [Test]
        public void SortByRowSumAscending_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                MatrixSort.ByRowSumAscending(array);

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

                MatrixSort.ByRowSumDescending(array);

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

                MatrixSort.ByMaxElementAscending(array);

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

                MatrixSort.ByMaxElementDescending(array);

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

                MatrixSort.ByMinElementAscending(array);

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

                MatrixSort.ByMinElementDescending(array);

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
