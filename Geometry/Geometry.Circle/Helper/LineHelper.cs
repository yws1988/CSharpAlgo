namespace Geometry.Helper
{
    using DataStructure.Models.Geometry;

    public class LineHelper
    {
        public static Line GetLineFromTwoPoint(Point<double> p1, Point<double> p2)
        {
            double a = p2.Y - p1.Y;
            double b = p1.X - p2.X;
            double c = -a * (p1.X) - b * (p1.Y);
            return new Line(a, b, c);
        }

        public static bool IsTwoLineIntersect(Point<double> p1, Point<double> p2, Point<double> q1, Point<double> q2)
        {
            if ((OrientationTreePoint.Orientation(p1, p2, q1) != OTP.Orientation(p1, p2, q2)) && (OTP.Orientation(q1, q2, p1) != OTP.Orientation(q1, q2, p2)))
                return true;

            var rangeX1 = new Range<double>(p1.X, p2.X);
            var rangeX2 = new Range<double>(q1.X, q2.X);
            var rangeY1 = new Range<double>(p1.Y, p2.Y);
            var rangeY2 = new Range<double>(q1.Y, q2.Y);

            if (OTP.Orientation(p1, p2, q1) == 0 && OTP.Orientation(p1, p2, q2) == 0 && rangeX1.IsOverlapped(rangeX2) && rangeY1.IsOverlapped(rangeY2))
            {
                return true;
            }

            return false;
        }

        public static Point<double> GetIntersectPoint(Point<double> A, Point<double> B, Point<double> C, Point<double> D)
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
    }
}
