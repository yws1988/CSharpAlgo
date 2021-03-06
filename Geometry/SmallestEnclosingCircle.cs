﻿namespace CSharpAlgo.Geometry
{
    using System;
    using System.Collections.Generic;

    public sealed class SmallestEnclosingCircle
    {
        /* 
	    * Returns the smallest circle that encloses all the given points. Runs in expected O(n) time, randomized.
	    * Note: If 0 points are given, a circle of radius -1 is returned. If 1 point is given, a circle of radius 0 is returned.
	    */
        // Initially: No boundary points known
        public static Circle GetCircle(IList<Point> points)
        {
            // Clone list to preserve the caller's data, do Durstenfeld shuffle
            List<Point> shuffled = new List<Point>(points);
            Random rand = new Random();
            for (int i = shuffled.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                Point temp = shuffled[i];
                shuffled[i] = shuffled[j];
                shuffled[j] = temp;
            }

            // Progressively add points to circle or recompute circle
            Circle c = Circle.INVALID;
            for (int i = 0; i < shuffled.Count; i++)
            {
                Point p = shuffled[i];
                if (c.radius < 0 || !c.Contains(p))
                    c = MakeCircleOnePoint(shuffled.GetRange(0, i + 1), p);
            }
            return c;
        }


        // One boundary point known
        private static Circle MakeCircleOnePoint(List<Point> points, Point p)
        {
            Circle c = new Circle(p, 0);
            for (int i = 0; i < points.Count; i++)
            {
                Point q = points[i];
                if (!c.Contains(q))
                {
                    if (c.radius == 0)
                        c = MakeDiameter(p, q);
                    else
                        c = MakeCircleTwoPoints(points.GetRange(0, i + 1), p, q);
                }
            }
            return c;
        }


        // Two boundary points known
        private static Circle MakeCircleTwoPoints(List<Point> points, Point p, Point q)
        {
            Circle circ = MakeDiameter(p, q);
            Circle left = Circle.INVALID;
            Circle right = Circle.INVALID;

            // For each point not in the two-point circle
            Point pq = q.Subtract(p);
            foreach (Point r in points)
            {
                if (circ.Contains(r))
                    continue;

                // Form a circumcircle and classify it on left or right side
                double cross = pq.Cross(r.Subtract(p));
                Circle c = MakeCircumcircle(p, q, r);
                if (c.radius < 0)
                    continue;
                else if (cross > 0 && (left.radius < 0 || pq.Cross(c.center.Subtract(p)) > pq.Cross(left.center.Subtract(p))))
                    left = c;
                else if (cross < 0 && (right.radius < 0 || pq.Cross(c.center.Subtract(p)) < pq.Cross(right.center.Subtract(p))))
                    right = c;
            }

            // Select which circle to return
            if (left.radius < 0 && right.radius < 0)
                return circ;
            else if (left.radius < 0)
                return right;
            else if (right.radius < 0)
                return left;
            else
                return left.radius <= right.radius ? left : right;
        }


        private static Circle MakeDiameter(Point a, Point b)
        {
            Point c = new Point((a.x + b.x) / 2, (a.y + b.y) / 2);
            return new Circle(c, Math.Max(c.Distance(a), c.Distance(b)));
        }


        private static Circle MakeCircumcircle(Point a, Point b, Point c)
        {
            // Mathematical algorithm from Wikipedia: Circumscribed circle
            double ox = (Math.Min(Math.Min(a.x, b.x), c.x) + Math.Max(Math.Min(a.x, b.x), c.x)) / 2;
            double oy = (Math.Min(Math.Min(a.y, b.y), c.y) + Math.Max(Math.Min(a.y, b.y), c.y)) / 2;
            double ax = a.x - ox, ay = a.y - oy;
            double bx = b.x - ox, by = b.y - oy;
            double cx = c.x - ox, cy = c.y - oy;
            double d = (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by)) * 2;
            if (d == 0)
                return Circle.INVALID;
            double x = ((ax * ax + ay * ay) * (by - cy) + (bx * bx + by * by) * (cy - ay) + (cx * cx + cy * cy) * (ay - by)) / d;
            double y = ((ax * ax + ay * ay) * (cx - bx) + (bx * bx + by * by) * (ax - cx) + (cx * cx + cy * cy) * (bx - ax)) / d;
            Point p = new Point(ox + x, oy + y);
            double r = Math.Max(Math.Max(p.Distance(a), p.Distance(b)), p.Distance(c));
            return new Circle(p, r);
        }
    }

    public struct Circle
    {
        public static readonly Circle INVALID = new Circle(new Point(0, 0), -1);
        private const double MULTIPLICATIVE_EPSILON = 1 + 1e-14;

        public Point center;   // Center
        public double radius;  // Radius

        public Circle(Point c, double r)
        {
            this.center = c;
            this.radius = r;
        }

        public bool Contains(Point p)
        {
            return center.Distance(p) <= radius * MULTIPLICATIVE_EPSILON;
        }

        public bool Contains(ICollection<Point> ps)
        {
            foreach (Point p in ps)
            {
                if (!Contains(p))
                    return false;
            }
            return true;
        }
    }

    public struct Point
    {

        public double x;
        public double y;


        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        public Point Subtract(Point p)
        {
            return new Point(x - p.x, y - p.y);
        }


        public double Distance(Point p)
        {
            double dx = x - p.x;
            double dy = y - p.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }


        // Signed area / determinant thing
        public double Cross(Point p)
        {
            return x * p.y - y * p.x;
        }
    }
}