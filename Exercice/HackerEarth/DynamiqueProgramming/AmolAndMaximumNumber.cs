using System;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class AmolAndMaximumNumber
    {
        public static int n;
        public static int k;
        public static int p;
        public static int[] ns;
        static long[,] dp;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\AmolAndMaximumNumber.txt");
#endif
            var temp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = temp[0];
            k = temp[1];
            p = temp[2];
            ns = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Solve();

            //Console.Read();
        }

        public static void Solve()
        {
            dp = new long[n, k + 1];

            for (int i = 0; i <=p; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j], ns[i]);
                    if (i>0)
                    {
                        if(j >= 2)
                        {
                            dp[i, j] = Math.Max(dp[i, j], ns[i] + ns[i - 1]);
                        }

                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
                    }
                }
            }

            for (int i = p + 1; i < n; i++)
            {
                long sum = ns[i] + ns[i - 1];
                for (int j = 1; j <= k; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - p - 1, j - 1] + ns[i]);
                    if (j >= 2)
                    {
                        dp[i, j] = Math.Max(dp[i, j], i==p+1 ? sum : dp[i - p - 2, j - 2] + sum);
                    }
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
                }
            }

            Console.WriteLine(dp[n-1, k]);
        }
    }
}
