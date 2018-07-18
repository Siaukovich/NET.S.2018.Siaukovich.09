namespace Matrix.Tests
{
    class CompareByMaxElementDescending : ICustomComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == rhs)
            {
                return 0;
            }

            if (lhs == null && rhs != null)
            {
                return 1;
            }

            if (lhs != null && rhs == null)
            {
                return -1;
            }

            int leftMax = lhs.Max();
            int rightMax = rhs.Max();

            return leftMax == rightMax ? 0 :
                   leftMax >  rightMax ? -1 : 1;
        }
    }
}
