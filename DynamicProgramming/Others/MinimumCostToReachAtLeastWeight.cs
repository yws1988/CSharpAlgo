﻿/*
 * Give two array weights and costs, for each element i, weights[i] is the weight of the ith stone,
 * costs[i] is the corresponding stone price, calculate the minimum costs to collect stones which the weight
 * is at least mWeight.
 * 
 * For example, input:
 * 10 6 7
 * 20 8 10
 * 
 * Output:
 * 18
 */

namespace CSharpAlgo.DynamicProgramming.Other
{
    using System;

    public class MinimumCostToReachAtLeastWeight
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="costs"></param>
        /// <param name="minimumWeight"></param>
        /// <returns>-1 means can't reach minimumWeight with the current stones</returns>
        public static int GetMinimumCosts(int[] weights, int[] costs, int minimumWeight)
        {
            int n = weights.Length;
            var dp = new int[n, minimumWeight + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= minimumWeight; j++)
                {
                    dp[i, j] = int.MaxValue;

                    if (i == 0)
                    {
                        dp[0, weights[0] >= minimumWeight ? minimumWeight : weights[0]] = costs[0];
                    }
                }
            }

            for (int i = 1; i < n; i++)
            {
                int weight = weights[i];
                for (int j = 0; j <= minimumWeight + weight; j++)
                {
                    int idx = j > minimumWeight ? minimumWeight : j;

                    dp[i, idx] = Math.Min(dp[i, idx], dp[i - 1, idx]);

                    if (j >= weight && dp[i - 1, j - weight] != int.MaxValue)
                    {
                        dp[i, idx] = Math.Min(dp[i, idx], dp[i - 1, j - weight] + costs[i]);
                    }
                }
            }

            return dp[n - 1, minimumWeight] == int.MaxValue ? -1 : dp[n - 1, minimumWeight];
        }
    }
}