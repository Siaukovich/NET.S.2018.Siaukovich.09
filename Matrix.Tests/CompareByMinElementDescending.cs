namespace Matrix.Tests
{
    using System.Collections.Generic;

    class CompareByMinElementDescending : IComparer<int[]>
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

            int leftMin = lhs.Min();
            int rightMin = rhs.Min();

            return leftMin == rightMin ? 0 :
                   leftMin >  rightMin ? -1 : 1;
        }
    }
}
