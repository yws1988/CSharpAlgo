/// Given two integer arrays val[0..n-1] and wt[0..n-1] that represent values and weights associated with n items
/// respectively. Find out the maximum value subset of val[] such that sum of the weights of this subset is smaller than or equal
/// to Knapsack capacity cap.

namespace CSharpAlgo.DynamicProgramming.Other
{
        using System;

        public class MaximumValueToReachAtMostWeight
        {
            public static int GetMaxValue((int, int)[] arr, int capacity, out int[,] dp)
            {
                int n = arr.Length;

                dp = new int[capacity + 1, n];

                for (int i = 1; i <= capacity; i++)
                {
                    if (i >= arr[0].Item1)
                    {
                        dp[i, 0] = arr[0].Item2;
                    }
                }

                for (int i = 1; i <= capacity; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (arr[j].Item1 <= i)
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[i - arr[j].Item1, j - 1] + arr[j].Item2);
                        }

                        dp[i, j] = Math.Max(dp[i, j], dp[i, j - 1]);
                    }
                }

                return dp[capacity, n - 1];
            }
        }
}
