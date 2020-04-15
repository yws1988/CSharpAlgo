namespace BitOperation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BitMaskingCaps
    {
        const int cN = 100;
        static List<int>[] capList = new List<int>[cN+1];
        public static int[][] ps;
        static int[,] dp = new int[1025, cN+1];
        static int allmask;

        static int countWaysUtil(int mask, int i)
        {
            if (dp[mask, i] != -1) return dp[mask, i];

            if (i == 0 && mask != 0) return dp[mask, i] = 0;

            if (mask == 0) return dp[mask, i] = 1;

            var ps = capList[i];
            int total = 0;
            foreach (var p in ps)
            {
                if((mask>>p & 1) == 1)
                {
                    total+=countWaysUtil(mask & (~(1 << p)), i - 1);
                }
            }

            return dp[mask, i]=countWaysUtil(mask, i - 1) + total;
        }

        // Reads n lines from standard input for current test case
        static void countWays(int n)
        {
            //  ----------- READ INPUT --------------------------
            ps = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ps[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                //   while there are words in the split[]
                for (int j = 0; j < ps[i].Length; j++)
                {
                    capList[ps[i][j]].Add(i);
                }
            }

            //  ----------------------------------------------------
            //   All mask is used to check of all persons
            //   are included or not, set all n bits as 1
            allmask = ((1 << n) - 1);

            //   Initialize all entries in dp as -1
            for (int i = 0; i < 1025; i++)
            {
                for (int j = 0; j <= cN; j++)
                {
                    dp[i, j] = -1;
                }
            }

            //   Call recursive function count ways
            Console.WriteLine(countWaysUtil(allmask, cN));
        }

        public static void Test()
        {
            int n;

            for (int i = 0; i < capList.Length; i++)
            {
                capList[i] = new List<int>();
            }

            n = int.Parse(Console.ReadLine());
            countWays(n);
        }
    }
}
