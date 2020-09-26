using System;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class AmazingTest
    {
        public static int t;
        public static int n;
        public static int x;
        public static int[] nums;
        public static int[,] dp;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\AmazingTest.txt");
#endif
            t = int.Parse(input.ReadLine());
            for (int i = 0; i < t; i++)
            {
                nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                n = nums[0];
                x = nums[1];
                nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Solve();
            }

            Console.Read();
        }

        public static void Solve()
        {
            int s = nums.Sum();
            if (s <= x)
            {
                Console.WriteLine("YES");
                return;
            }

            if (s > 2*x)
            {
                Console.WriteLine("NO");
                return;
            }

            dp = new int[x + 1, n];
            for (int i = 1; i <= x; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int cc = nums[j];

                    if (j == 0)
                    {
                        if (i >= cc)
                        {
                            dp[i, j] = cc;
                        }
                    }
                    else
                    {
                        if (i >= cc)
                        {
                            dp[i, j] = Math.Max(dp[i-cc, j-1] + cc, dp[i, j-1]);
                        }
                    }
                }
            }

            if(s-dp[x, n - 1] <= x)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
