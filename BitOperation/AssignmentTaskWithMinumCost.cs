namespace BitOperation
{
    using BitOperation.Helper;
    using System;

    // There are N persons and N tasks, each task is to be alloted to a single person.
    // We are also given a matrix of size N* N, where cost[i, j] denotes the cost when person i is assigned to task j
    // Get the minumum cost if every person takes one task

    public class AssignmentTaskWithMinumCost
    {
        public static int GetMinimumCost(int[,] costs)
        {
            int n = costs.GetLength(0);
            int max = (int)Math.Pow(2, n);
            int[] dp = new int[max];
            for (int i = 0; i < max; i++)
            {
                dp[i] = int.MaxValue;
            }

            dp[0] = 0;

            for (int i = 0; i < max; i++)
            {
                int k = BitMaskingHelper.CountBit(i);
                for (int j = 0; j < n; j++)
                {
                    if((i & (1 << j)) == 0)
                    {
                        dp[i | (1 << j)] = Math.Min(dp[i | (1 << j)], dp[i]+costs[k, j]);
                    }
                }
            }
            
            return dp[max-1];
        }
    }
}
