namespace Maths.Geometric
{
    using System;
    using System.Linq;

    public class Polygon
    {
        public static Point[] Vs { get; set; }

        /// <summary>
        /// We can compute area of a polygon using Shoelace formula.
        /// </summary>
        public static double GetPolygonArea(double[] X, double[] Y, int n)
        {

            // Initialze area
            double area = 0.0;

            // Calculate value of shoelace formula
            int j = n-1;

            for (int i = 0; i < n; i++)
            {
                area += (X[j] + X[i]) * (Y[j] - Y[i]);

                // j is previous vertex to i
                j = i;
            }

            // Return absolute value
            return Math.Abs(area/2);
        }

        public static bool IsInsidePoint(Point p)
        {
            double maxX = Vs.Select(v => v.X).Max()+1;
            int n = Vs.Count();
            for (int i = 0; i < n; i++)
            {
                int next = i != n - 1 ? i + 1 : 0;
                if (LPI.IsPointInLine(Vs[i], Vs[next], p))
                {
                    return true;
                }
            }

            double y = p.Y;
            Point newP = new Point(maxX, y);

            for (int i = 0; i <= n; i++)
            {
                y += i;
                newP = new Point(maxX, y);
                if (Vs.Any(v => LPI.IsPointInLine(p, newP, v))){
                    continue;
                }
                break;
            }

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                int next = i != n - 1 ? i + 1 : 0;
                if (LPI.IsTwoLineIntersect(Vs[i], Vs[next], p, newP))
                {
                    count++;
                }
            }

            return count % 2 == 1 ? true : false;
        }
    }
}
