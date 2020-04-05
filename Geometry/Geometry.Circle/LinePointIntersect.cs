namespace Maths.Geometric
{
    using System;
    using System.Linq;

    public class LPI
    {
        public static bool IsTwoLineIntersect(Point p1, Point p2, Point q1, Point q2)
        {
            if ((OTP.Orientation(p1, p2, q1) != OTP.Orientation(p1, p2, q2)) && (OTP.Orientation(q1, q2, p1) != OTP.Orientation(q1, q2, p2)))
                return true;

            var rangeX1 = new Range<double>(p1.X, p2.X);
            var rangeX2 = new Range<double>(q1.X, q2.X);
            var rangeY1 = new Range<double>(p1.Y, p2.Y);
            var rangeY2 = new Range<double>(q1.Y, q2.Y);

            if (OTP.Orientation(p1, p2, q1)==0 && OTP.Orientation(p1, p2, q2)==0 && rangeX1.IsOverlapped(rangeX2) && rangeY1.IsOverlapped(rangeY2))
            {
                return true;
            }

            return false;
        }

        public static bool IsPointInLine(Point l1, Point l2, Point p)
        {
            if (OTP.Orientation(l1, l2, p) == 0 && p.X >= Math.Min(l1.X, l2.X) && p.X <= Math.Max(l1.X, l2.X) && p.Y>= Math.Min(l1.Y, l2.Y) && p.Y<=Math.Max(l1.Y, l2.Y))
            {
                return true;
            }

            return false;
        }

        public static Point GetIntersectPoint(Point A, Point B, Point C, Point D)
        {
            // Line AB represented as a1x + b1y = c1
            Line abLine = Line.GetLineFromTwoPoint(A, B);
            double a1 = abLine.A;
            double b1 = abLine.B;
            double c1 = -abLine.C;

            // Line CD represented as a2x + b2y = c2
            Line cdLine = Line.GetLineFromTwoPoint(C, D);
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
                return new Point(x, y);
            }
        }

        public static Point GetIntersectPoint(Line abLine, Line cdLine)
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
                return new Point(x, y);
            }
        }

        public static double GetPointToLineDistance(Line line, Point P)
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

        public static Line GetBestApproximateLine(Point[] ps)
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

        public static Point GetMininumDistancesToPointInLineMethodDerive(Point[] ps, Line line)
        {
            double x, y;
            int n = ps.Length;
            double a, b;
            if (line.B != 0)
            {
                a = -line.A / line.B;
                b = -line.C / line.B;

                double sumX = ps.Select(p => p.X).Sum();
                double sumY = ps.Select(p => p.Y).Sum();
                x = (sumY*a+sumX - n *a* b) / (n * (a * a + 1));
                y = a * x + b;
                return new Point(x, y);
            }

            if(line.B == 0)
            {
                x = -line.C / line.A;
                y = ps.Select(p => p.Y).Average();
                return new Point(x, y);
            }

            return null;
        }

    }
}
