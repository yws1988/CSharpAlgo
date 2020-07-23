/*
 Give a symmetric cost matrix, get the maximum sum of the matrix sub elements, every two of the sub elements matrix[a, b], matrix[c, d]
 should satisfy one of the following condition:
 1. a < b < c < d 
 2. c < d < a < b
 3. a < c < d < b

 Example matrix:
   0 2 6 1
   2 0 8 9
   6 8 0 3
   1 9 3 0

 The maximum sum should be 9 elements(0, 3), (1, 2) or element (1, 3)

 */

namespace CSharpAlgo.DynamicProgramming.Graph
{
    using System;

    public class MaximumSumOfNonIntersectionElementsInMatrix
    {
        public static int GetMaximumSum(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[,] dp = new int[n, n];

            for (int i = 1; i < n; i++)
            {
                for (int j = 0, k = j + i; k < n; j++, k++)
                {
                    if (i == 1)
                    {
                        dp[j, k] = matrix[j, k];
                    }
                    else
                    {
                        for (int m = j + 1; m < k; m++)
                        {
                            dp[j, k] = Math.Max(Math.Max(dp[j, k], matrix[m, k] + dp[j, m - 1] + dp[m + 1, k - 1]), dp[j, k - 1]);
                        }

                        dp[j, k] = Math.Max(dp[j, k], matrix[j, k] + dp[j + 1, k - 1]);
                    }
                }
            }

            return dp[0, n - 1];
        }
    }
}
