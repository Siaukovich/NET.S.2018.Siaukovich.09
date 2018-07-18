namespace Matrix.Tests
{
    public class CompareByRowSum : ICustomComparer
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == rhs)
            {
                return 0;
            }

            if (lhs == null && rhs != null)
            {
                return -1;
            }

            if (lhs != null && rhs == null)
            {
                return 1;
            }
            
            int leftSum = lhs.Sum();
            int rightSum = rhs.Sum();
            
            return leftSum == rightSum ? 0 : 
                   leftSum >  rightSum ? 1 : -1;
        }
    }
}