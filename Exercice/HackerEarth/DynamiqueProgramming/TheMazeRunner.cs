using System;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class TheMazeRunner
    {
        public static int n;
        public static int h;
        public static int[][] ns;
        public static double[,] dp;

        public static void MainF()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\TheMazeRunner.txt");
#endif
            n = int.Parse(input.ReadLine());
            ns = new int[n+1][];

            for (int i = 0; i <= n; i++)
            {
                ns[i] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            h = int.Parse(input.ReadLine());
            Solve();
            //Console.Read();
        }

        public static void Solve()
        {
            dp = new double[n + 1, 2];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dp[i, j] = double.MaxValue;
                }
            }

            for (int i = 0; i <= n; i++)
            {
                for (int m = 0; m < 2; m++)
                {
                    for (int j = i+1; j <= n; j++)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            int x = ns[i][0];
                            int y = ns[i][1] + (m == 0 ? 0 : h);
                            int xr = ns[j][0];
                            int yr = ns[j][1] + (k == 0 ? 0 : h);
                            if (Valid(i+1, j-1, x, y, xr, yr))
                            {
                                dp[j, k] = Math.Min(dp[j,k], dp[i, m]+Dis(x,y, xr, yr));
                            }
                        }
                    }
                }
            }

            double dis = Math.Min(dp[n, 0], dp[n, 1]);
            for (int i = 0; i < n; i++)
            {
                int xn = ns[n][0];
                int x = ns[i][0];
                int y = ns[i][1];
                int dd = xn - x;
                if (CheckHLine(i, y))
                {
                    dis = Math.Min(dis, dp[i, 0] + dd);
                }

                if (CheckHLine(i, y+h))
                {
                    dis = Math.Min(dis, dp[i, 1] + dd);
                }
            }

            Console.WriteLine(dis.ToString("F12"));
        }

        public static int Orientation(int x1, int y1, int x2, int y2, int x, int y)
        {
            double val = (y2 - y1) * (x - x2) - (x2 - x1) * (y - y2);

            if (val == 0) return 0;  // colinear

            // clock or counterclock wise
            return (val > 0) ? 1 : -1;
        }

        static bool Valid(int l, int r, int x, int y, int xr, int yr)
        {
            for (int i = l; i <= r; i++)
            {
                int res = Orientation(x, y, xr, yr, ns[i][0], ns[i][1]) * Orientation(x, y, xr, yr, ns[i][0], ns[i][1] + h);
                if (res > 0) return false;
            }

            return true;
        }

        static bool CheckHLine(int l, int y)
        {
            for (int i = l; i <= n; i++)
            {
                if (y>ns[i][1]+h || y < ns[i][1])
                {
                    return false;
                }
            }
            return true;
        }

        static double Dis(int x, int y, int xr, int yr)
        {
            return Math.Sqrt(Math.Pow(x - xr, 2) + Math.Pow(y - yr, 2));
        }

    }
}
