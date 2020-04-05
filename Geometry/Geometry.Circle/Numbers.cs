namespace Maths.Geometric
{
    using System.Collections.Generic;

    public class Numbers
    {
        public static int GreatestCommonDivisor(int m, int n)
        {
            while (n>0)
            {
                int t = n;
                n = m % n;
                m = t;
            }

            return m;
        }

        public static IList<int> GetDigits(int source)
        {
            List<int> res = new List<int>();
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                res.Add(digit);
            }
            return res;
        }
    }
}
