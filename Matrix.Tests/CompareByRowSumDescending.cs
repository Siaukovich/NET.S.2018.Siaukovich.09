namespace Matrix.Tests
{
    using System.Collections.Generic;

    class CompareByRowSumDescending : IComparer<int[]>
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == rhs)
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            int leftSum = lhs.Sum();
            int rightSum = rhs.Sum();

            return leftSum == rightSum ? 0 :
                   leftSum >  rightSum ? -1 : 1;
        }
    }
}
