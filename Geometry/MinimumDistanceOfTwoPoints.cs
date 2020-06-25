namespace Geometry
{
    using DataStructure.Geometry;
    using Geometry.Helper;
    using System;
    using System.Linq;

    /// <summary>
    /// Given an array of n points in the panel, and the problem is to find out the 
    // closest pair of points in the array with divde and conquer method.
    /// </summary>

    class MinimumDistanceOfTwoPoints
    {
        public static double GetMinimumDistanceOfTwoPoints(Point<double>[] ps)
        {
            var orderedPs = ps.OrderBy(p => p.X).ToArray(); //nlogn
            return GetClosestDistance(orderedPs);
        }

        static double GetClosestDistance(Point<double>[] ps)
        {
            int n = ps.Count();
            if (n > 3)
            {
                var psLeft = ps.Take((n + 1) / 2).ToArray();
                var psRight = ps.Skip((n + 1) / 2).ToArray();
                double mD = Math.Min(GetClosestDistance(psLeft), GetClosestDistance(psRight));
                var mP = ps[(n + 1) / 2];
                var strip = ps.Where(p => Math.Abs(p.X - mP.X) < mD).ToArray(); //nlogn
                int nS = strip.Length;
                
                for (int i = 0; i < nS; i++) //n
                {
                    for (int j = i+1; j < nS && Math.Abs(strip[i].Y-strip[j].Y)<mD; j++)
                    {
                        mD = Math.Min(mD, PointHelper.GetTwoPointsDistance(strip[i], strip[j]));
                    }
                }

                return mD;
            }
            else
            {
                return GetMinPointsDistance(ps);
            }
        }

        static double GetMinPointsDistance(Point<double>[] ps)
        {
            double min = double.MaxValue;

            for (int i = 0; i < ps.Length; i++)
            {
                for (int j = i + 1; j < ps.Length; j++)
                {
                    min=Math.Min(min, PointHelper.GetTwoPointsDistance(ps[i], ps[j]));
                }
            }

            return min;
        }
    }
}
