namespace Geometry
{
    using DataStructure.Models.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximunPointsInOneLine
    {
        public const double INF = double.MaxValue;

        public static int GetMax(Point<double>[] ps)
        {
            Dictionary<double, HashSet<int>> dicP = new Dictionary<double, HashSet<int>>();

            HashSet<int> vPs = new HashSet<int>();

            int num = ps.Length;
            for (int i = 0; i < num; i++)
            {
                for (int j = i+1; j < num; j++)
                {
                    if(ps[j].X - ps[i].X == 0){
                        if (!vPs.Contains(i)) vPs.Add(i);
                        if (!vPs.Contains(j)) vPs.Add(j);
                    }
                    else{
                        double slop = (ps[j].Y - ps[i].Y) / (ps[j].X - ps[i].X);
                        if (dicP.ContainsKey(slop))
                        {
                            if (!dicP[slop].Contains(i)) dicP[slop].Add(i);
                            if (!dicP[slop].Contains(j)) dicP[slop].Add(j);
                        }
                        else
                        {
                            dicP.Add(slop, new HashSet<int>{i, j});
                        }
                       
                    }
                }
            }

            return Math.Max(dicP.Max(d => d.Value.Count), vPs.Count);
        }

        //use greatest common divisor for avoid double precision error
        public static int GetMax(IntPoint[] points)
        {
            if (points.Count() == 0)
            {
                return 0;
            }

            var dic = new Dictionary<(int, int), int>();
            for (int i = 0; i < points.Length; i++)
            {
                var key = (points[i].x, points[i].y);
                if (dic.ContainsKey(key))
                {
                    dic[key]++;
                }
                else
                {
                    dic[key] = 1;
                }
            }

            var ps = dic.Select(d => d.Key).ToArray();
            int n = ps.Count();
            if (n == 1)
            {
                return dic[ps[0]];
            }

            Dictionary<(int, int), int> dicp = new Dictionary<(int, int), int>();
            

            int max = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    int x = ps[i].Item1 - ps[j].Item1;
                    int y = ps[i].Item2 - ps[j].Item2;

                    
                    if (x == 0)
                    {
                        y = 1;
                    }else if (y == 0)
                    {
                        x = 1;
                    }
                    else
                    {
                        int gcd = GreatestCommonDivisor(Math.Abs(x), Math.Abs(y));
                        x /= gcd;
                        y /= gcd;
                        y = x * y < 0 ? -Math.Abs(y) : Math.Abs(y);
                        x = Math.Abs(x);
                    }

                    if (dicp.ContainsKey((x, y)))
                    {
                        dicp[(x, y)] += dic[(ps[j].Item1, ps[j].Item2)];
                    }
                    else
                    {
                        dicp[(x, y)] = dic[(ps[j].Item1, ps[j].Item2)] +dic[(ps[i].Item1, ps[i].Item2)];
                    }

                    max = Math.Max(max, dicp[(x, y)]);
                }
                dicp.Clear();
            }

            return max;
        }

        public static int GreatestCommonDivisor(int m, int n)
        {
            while (n > 0)
            {
                int t = n;
                n = m % n;
                m = t;
            }

            return m;
        }
    }

    public class IntPoint
    {
        public int x;
        public int y;

        public IntPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
