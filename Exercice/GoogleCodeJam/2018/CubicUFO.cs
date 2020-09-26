using System;
using System.Globalization;

namespace GoogleCodeJam
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public bool UsePrecision { get; set; }
        public int Precision { get; set; }

        public Point3D(double x, double y, double z, int precision = 6, bool usePrecision = false)
        {
            X = usePrecision ? Math.Round(x, precision, MidpointRounding.AwayFromZero) : x;
            Y = usePrecision ? Math.Round(y, precision, MidpointRounding.AwayFromZero) : y;
            Z = usePrecision ? Math.Round(z, precision, MidpointRounding.AwayFromZero) : z;
        }

        /// <summary>
        /// 3D rotation matrix
        /// </summary>
        /// <param name="pointToRotate"></param>
        /// <param name="centerPoint"></param>
        /// <param name="dir">The ratation direction, 0 is Z axis, 1 is x axis, 2 is y axis </param>
        /// <param name="angleInDegrees"></param>
        /// <returns>3D point after rotation</returns>
        public static Point3D RotatePoint3D(Point3D pointToRotate, Point3D centerPoint, int dir, double angleInDegrees, bool isAngle = false)
        {
            double angleInRadians = isAngle ? angleInDegrees * (Math.PI / 180) : angleInDegrees;
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            double x = pointToRotate.X - centerPoint.X;
            double y = pointToRotate.Y - centerPoint.Y;
            double z = pointToRotate.Z - centerPoint.Z;
            double x1, y1, z1;

            if (dir == 0)
            {
                x1 = cosTheta * x - sinTheta * y + centerPoint.X;
                y1 = sinTheta * x + cosTheta * y + centerPoint.Y;
                z1 = pointToRotate.Z + centerPoint.Z;
            }
            else if (dir == 1)
            {
                y1 = cosTheta * y - sinTheta * z + centerPoint.Y;
                z1 = sinTheta * y + cosTheta * z + centerPoint.Z;
                x1 = pointToRotate.X + centerPoint.X;
            }
            else
            {
                z1 = cosTheta * z - sinTheta * x + centerPoint.Z;
                x1 = sinTheta * z + cosTheta * x + centerPoint.X;
                y1 = pointToRotate.Z + centerPoint.Z;
            }

            return new Point3D(x1, y1, z1);
        }

        public override string ToString()
        {
            return this.X + " " + this.Y + " " + this.Z;
        }
    }


    public class CubicUFO
    {
        public static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            double[] Area = new double[t];

            for (int i = 0; i < t; i++)
            {
                Area[i] = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            var A = new Point3D(0.5, -0.5, 0.5);
            var B = new Point3D(-0.5, -0.5, -0.5);
            var C = new Point3D(-0.5, 0.5, 0.5);
            var centerP = new Point3D(0, 0, 0);
            double aZrotationMax = Math.Sqrt(2);
            Point3D[] result;

            for (int i = 0; i < t; i++)
            {
                double ar = Area[i];
                Point3D A1, B1, C1;

                if (ar <= aZrotationMax)
                {
                    double degree = Math.PI / 4 - Math.Acos(ar / Math.Sqrt(2));

                    A1 = Point3D.RotatePoint3D(A, centerP, 0, degree);
                    B1 = Point3D.RotatePoint3D(B, centerP, 0, degree);
                    C1 = Point3D.RotatePoint3D(C, centerP, 0, degree);

                    result = new Point3D[] {
                         GetMidPoint(A1,B1),
                         GetMidPoint(A1,C1),
                         GetMidPoint(B1,C1),
                    };
                }
                else
                {
                    double degreeZ = Math.PI / 4;

                    A1 = Point3D.RotatePoint3D(A, centerP, 0, degreeZ);
                    B1 = Point3D.RotatePoint3D(B, centerP, 0, degreeZ);
                    C1 = Point3D.RotatePoint3D(C, centerP, 0, degreeZ);

                    double degreeX = 0;
                    double dMin = 0;
                    double dMax = Math.Asin(1/Math.Sqrt(3));
                    double caX = GetPolygonAreaRotationByAngle(centerP, A1, B1, C1, dMin);
                    double caXMax = GetPolygonAreaRotationByAngle(centerP, A1, B1, C1, dMax);
                    if(caXMax == ar)
                    {
                        degreeX = dMax;
                    }
                    else
                    {
                        while (ar != caX)
                        {
                            degreeX = (dMin + dMax) / 2;
                            caX = GetPolygonAreaRotationByAngle(centerP, A1, B1, C1, degreeX);
                            if (caX < ar)
                            {
                                dMin = degreeX;
                            }
                            else
                            {
                                dMax = degreeX;
                            }
                        }
                    }

                    Point3D A2, B2, C2;
                    A2 = Point3D.RotatePoint3D(A1, centerP, 1, degreeX);
                    B2 = Point3D.RotatePoint3D(B1, centerP, 1, degreeX);
                    C2 = Point3D.RotatePoint3D(C1, centerP, 1, degreeX);
                    result = new Point3D[] {
                         GetMidPoint(A2,B2),
                         GetMidPoint(A2,C2),
                         GetMidPoint(B2,C2),
                    };
                }

                Output(i + 1, result);
            }
            //Console.Read();
        }

        private static Point3D GetMidPoint(Point3D A, Point3D B)
        {
            return new Point3D((A.X+B.X)/2, (A.Y+B.Y)/2, (A.Z+B.Z)/2, 8, true);
        }

        private static double GetPolygonAreaRotationByAngle(Point3D centerP, Point3D A1, Point3D B1, Point3D C1, double degree)
        {
            Point3D A2, B2, C2;

            A2 = Point3D.RotatePoint3D(A1, centerP, 1, degree);
            B2 = Point3D.RotatePoint3D(B1, centerP, 1, degree);
            C2 = Point3D.RotatePoint3D(C1, centerP, 1, degree);

            double[] ax = new double[] { A2.X, B2.X, C2.X };
            double[] az = new double[] { A2.Z, B2.Z, C2.Z };
            double area = Math.Round(2 * GetPolygonArea(ax, az, 3), 8, MidpointRounding.AwayFromZero);
            return area;
        }

        public static void Output(int caseNum, Point3D[] ps)
        {
            Console.WriteLine("Case #" + caseNum + ": ");
            foreach (var p in ps)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static double GetPolygonArea(double[] X, double[] Y, int n)
        {

            // Initialze area
            double area = 0.0;

            // Calculate value of shoelace formula
            int j = n - 1;

            for (int i = 0; i < n; i++)
            {
                area += (X[j] + X[i]) * (Y[j] - Y[i]);

                // j is previous vertex to i
                j = i;
            }

            // Return absolute value
            return Math.Abs(area / 2);
        }
    }
}
