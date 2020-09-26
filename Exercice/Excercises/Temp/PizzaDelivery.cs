namespace BattleDev
{
    using System;
    using System.Linq;

    public class PizzaDelivery
    {
        public static int n;
        public static int[][] a;
        public static double[,] dp; // Vector
        public static double[,] dis;

        public static void Start(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            a = new int[n][];
            dp = new double[n, n];
            dis = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                a[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            a = a.OrderBy(a => a[1]).ToArray();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    dis[i, j] = Distance(a[i], a[j]);
                }
            }

            dp[0, 1] = dis[0, 1];
            
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i+2; j < n; j++)
                {
                    dp[i, j] = dp[i, j-1] + dis[j-1, j];
                }

                for (int j = i + 2; j < n; j++)
                {
                    double q = dp[i, j - 1] + dis[i, j];

                    if(i==0 || q < dp[j-1, j])
                    {
                        dp[j - 1, j] = q;
                    }
                }
            }

            dp[n - 1, n - 1] = dp[n - 2, n - 1] + dis[n-2, n-1];

            Console.WriteLine((int)dp[n - 1, n - 1]);
        }

        static double Distance(int[] x, int[] y)
        {
            return Math.Sqrt(Math.Pow(x[0] - y[0], 2) + Math.Pow(x[1] - y[1], 2) + Math.Pow(x[2] - y[2], 2));
        }
    }
}