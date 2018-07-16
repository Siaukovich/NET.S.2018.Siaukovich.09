namespace Matrix
{
    public class CompareByMinElement : ICustomComparer
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

            int leftMin = lhs.Min();
            int rightMin = rhs.Min();
            
            return leftMin == rightMin ? 0 : 
                   leftMin >  rightMin ? 1 : -1;
        }
    }
}