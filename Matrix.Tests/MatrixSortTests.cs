namespace Matrix.Tests
{
    using System;
    using System.Collections.Generic;
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
                () => MatrixSortByComparer.SortBy(null, new CompareByRowSumAscending()), 
                $"{nameof(MatrixSortByComparer.SortBy)} not throwing ArgumentNullException.");

            Assert.Throws<ArgumentNullException>(
                () => MatrixSortByDelegate.SortBy(null, (a, b) => 0),
                $"{nameof(MatrixSortByDelegate.SortBy)} not throwing ArgumentNullException.");
        }

        [Test]
        public void SortingsComparer_NullComparer_ThrowsArgumentNullExc()
        {
            const int SIZE = 5;
            var matrix = new int[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                matrix[i] = new int[SIZE];
            }

            Assert.Throws<ArgumentNullException>(
                () => matrix.SortBy((IComparer<int[]>)null),
                $"{nameof(MatrixSortByComparer.SortBy)} not throwing ArgumentNullException.");
        }

        [Test]
        public void SortingsDelegate_NullDelegate_ThrowsArgumentNullExc()
        {
            const int SIZE = 5;
            var matrix = new int[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                matrix[i] = new int[SIZE];
            }

            Assert.Throws<ArgumentNullException>(
                () => matrix.SortBy((Comparison<int[]>)null),
                $"{nameof(MatrixSortByDelegate.SortBy)} not throwing ArgumentNullException.");
        }


        [Test]
        public void SortByRowSumAscendingComparer_Random100ValidTests()
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
        public void SortByRowSumAscendingDelegate_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(Comparison);

                if (!IsSortedByKeyAscending(array, key: Enumerable.Sum))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }

            int Comparison(int[] a, int[] b) => a == b ? 0 :
                                                a == null ? -1 :
                                                b == null ? 1 :
                                                a.Sum() - b.Sum();
        }

        [Test]
        public void SortByRowSumDescendindComparer_Random100ValidTests()
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
        public void SortByRowSumDescendindDelegate_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(Comparison);

                if (!IsSortedByKeyDescending(array, key: Enumerable.Sum))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }

            int Comparison(int[] a, int[] b) => a == b ? 0 :
                                                a == null ? 1 :
                                                b == null ? -1 :
                                                b.Sum() - a.Sum();
        }

        [Test]
        public void SortByMaxElementAscendingComparer_Random100ValidTests()
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
        public void SortByMaxElementAscendingDelegate_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(Comparison);

                if (!IsSortedByKeyAscending(array, key: Enumerable.Max))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }

            int Comparison(int[] a, int[] b) => a == b ? 0 :
                                                a == null ? -1 :
                                                b == null ? 1 :
                                                a.Max() - b.Max();
        }

        [Test]
        public void SortByMaxElementDescendingComparer_Random100ValidTests()
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
        public void SortByMaxElementDescendingDelegate_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(Comparison);

                if (!IsSortedByKeyDescending(array, key: Enumerable.Max))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }

            int Comparison(int[] a, int[] b) => a == b ? 0 :
                                                a == null ? 1 :
                                                b == null ? -1 :
                                                b.Max() - a.Max();
        }

        [Test]
        public void SortByMinElementAscendingComparer_Random100ValidTests()
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
        public void SortByMinElementAscendingDelegate_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(Comparison);

                if (!IsSortedByKeyAscending(array, key: Enumerable.Min))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }

            int Comparison(int[] a, int[] b) => a == b ? 0 :
                                                a == null ? -1 :
                                                b == null ? 1 :
                                                a.Min() - b.Min();
        }

        [Test]
        public void SortByMinElementDescendingComparer_Random100ValidTests()
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

        [Test]
        public void SortByMinElementDescendingDelegate_Random100ValidTests()
        {
            var rng = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = this.GetRandomArray(SIZE, rng);

                array.SortBy(Comparison);

                if (!IsSortedByKeyDescending(array, Enumerable.Min))
                {
                    Assert.Fail($"Test #{i} not working.");
                }
            }

            int Comparison(int[] a, int[] b) => a == b ? 0 :
                                                a == null ? 1 :
                                                b == null ? -1 :
                                                b.Min() - a.Min();
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
