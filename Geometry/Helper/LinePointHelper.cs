namespace Geometry.Helper
{
    using DataStructure.Geometry;
    using System;

    public class LinePointHelper
    {
        public static bool IsPointInLine(Point<double> l1, Point<double> l2, Point<double> p)
        {
            if (PointHelper.OrientationOfThreePoints(l1, l2, p) == 0 && p.X >= Math.Min(l1.X, l2.X) && p.X <= Math.Max(l1.X, l2.X) && p.Y>= Math.Min(l1.Y, l2.Y) && p.Y<=Math.Max(l1.Y, l2.Y))
            {
                return true;
            }

            return false;
        }

        public static Point<double> GetIntersectPoint(Line abLine, Line cdLine)
        {
            // Line AB represented as a1x + b1y = c1
            double a1 = abLine.A;
            double b1 = abLine.B;
            double c1 = -abLine.C;

            // Line CD represented as a2x + b2y = c2
            double a2 = cdLine.A;
            double b2 = cdLine.B;
            double c2 = -cdLine.C;

            double determinant = a1 * b2 - a2 * b1;

            if (determinant == 0)
            {
                return null;
            }
            else
            {
                double x = (b2 * c1 - b1 * c2) / determinant;
                double y = (a1 * c2 - a2 * c1) / determinant;
                return new Point<double>(x, y);
            }
        }

        public static double GetPointToLineDistance(Line line, Point<double> P)
        {
            // line ax+by+c=0
            double slop = 0;
            double a, b, c;
            if (line.A == 0)
            {
                a = 1;
                b = 0;
                c = P.X;
            }
            else
            {
                slop = line.B / line.A;
                a = slop;
                b = -1;
                c = -(a * P.X + b * P.Y);
            }

            var verticalLine = new Line(a, b, c);
            var intersectPoint = GetIntersectPoint(line, verticalLine);
            var result = Math.Pow(intersectPoint.Y - P.Y, 2) + Math.Pow(intersectPoint.X - P.X, 2);
            return Math.Sqrt(result);
        }

        public static Line GetBestApproximateLine(Point<double>[] ps)
        {
            int n = ps.Length;
            double m, c, sum_x = 0, sum_y = 0,
                         sum_xy = 0, sum_x2 = 0;

            for (int i = 0; i < n; i++)
            {
                sum_x += ps[i].X;
                sum_y += ps[i].Y;
                sum_xy += ps[i].X * ps[i].Y;
                sum_x2 += Math.Pow(ps[i].X, 2);
            }

            m = (n * sum_xy - sum_x * sum_y) / (n * sum_x2 - Math.Pow(sum_x, 2));

            c = (sum_y - m * sum_x) / n;

            return new Line(m,-1,c);
        }
    }
}
