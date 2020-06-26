namespace CSharpAlgo.Geometry.Helper
{
    using DataStructure.Geometry;
    using System;
    using System.Linq;

    public class PolygonHelper
    {
        /// <summary>
        /// We can compute area of a polygon using Shoelace formula.
        /// Vertex axis x values, axis y values
        /// </summary>
        public static double GetPolygonArea(double[] xs, double[] ys, int n)
        {

            // Initialze area
            double area = 0.0;

            // Calculate value of shoelace formula
            int j = n-1;

            for (int i = 0; i < n; i++)
            {
                area += (xs[j] + xs[i]) * (ys[j] - ys[i]);

                // j is previous vertex to i
                j = i;
            }

            // Return absolute value
            return Math.Abs(area/2);
        }

        public static bool IsPointInsidePolygon(Point<double>[] vetexes, Point<double> p)
        {
            double maxX = vetexes.Select(v => v.X).Max()+1;
            int n = vetexes.Count();
            for (int i = 0; i < n; i++)
            {
                int next = i != n - 1 ? i + 1 : 0;
                if (LinePointHelper.IsPointInLine(vetexes[i], vetexes[next], p))
                {
                    return true;
                }
            }

            double y = p.Y;
            Point<double> newP = new Point<double>(maxX, y);

            for (int i = 0; i <= n; i++)
            {
                y += i;
                newP = new Point<double>(maxX, y);
                if (vetexes.Any(v => LinePointHelper.IsPointInLine(p, newP, v))){
                    continue;
                }
                break;
            }

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                int next = i != n - 1 ? i + 1 : 0;
                if (LineHelper.IsTwoLineIntersect(vetexes[i], vetexes[next], p, newP))
                {
                    count++;
                }
            }

            return count % 2 == 1 ? true : false;
        }
    }
}
