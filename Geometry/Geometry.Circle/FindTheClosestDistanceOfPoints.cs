namespace Geometric
{
    using Maths.Geometric;
    using System;
    using System.Linq;

    class FindTheClosestDistanceOfPoints
    {
        public static double GetClosestPoints(Point[] ps)
        {
            var orderedPs = ps.OrderBy(p => p.X).ToArray(); //nlogn
            return GetClosestDistance(orderedPs);
        }

        public static double GetClosestDistance(Point[] ps)
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
                        mD = Math.Min(mD, GetTwoPointsDistance(strip[i], strip[j]));
                    }
                }

                return mD;
            }
            else
            {
                return GetMinPointsDistance(ps);
            }
        }

        public static double GetMinPointsDistance(Point[] ps)
        {
            double min = double.MaxValue;

            for (int i = 0; i < ps.Length; i++)
            {
                for (int j = i + 1; j < ps.Length; j++)
                {
                    min=Math.Min(min, GetTwoPointsDistance(ps[i], ps[j]));
                }
            }

            return min;
        }

        public static double GetTwoPointsDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }
    }
}
