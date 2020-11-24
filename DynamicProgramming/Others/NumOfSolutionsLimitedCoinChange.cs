/*
 * Given a value N, if we want to make change for N cents, and we have limited supply {N1, N2, .. , Nm} of each 
 * of S = { S1, S2, .. , Sm} valued coins, how many ways can we make the change? 
 * The order of coins doesn’t matter.
 * For example, for N = 4 and N = {3,2,1} S = {1,2,3}, there are three solutions: 
 * {1,1,2},{2,2},{1,3}
 * So output should be 3. 
 */

using System.Linq;

namespace CSharpAlgo.DynamicProgramming.Other
{
    public class NumOfSolutionsLimitedCoinChange
    {

        public static int[,] dp;

        public static int GetNumOfSolutions(int sum, int[] nums, int[] coins)
        {
            int totalNum = nums.Sum();
            int[] values = new int[totalNum];
            int idx = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i]; j++)
                {
                    values[idx] = coins[i];
                    idx++;
                }
            }

            dp = new int[sum+1, totalNum+1];

            for (int i = 0; i <= totalNum; i++)
            {
                dp[0, i] = 1;
            }
            
            for(int i = 1; i < sum; i++)
            {
                for (int j = 0; j <= totalNum; j++)
                {
                    if (j >= 1)
                    {
                        dp[i, j] += dp[i, j - 1];
                    }

                    if(i >= values[j])
                    {
                        dp[i, j] += dp[i-values[j], j];
                    }
                }
            }

            return dp[sum, totalNum];
        }
    }
}
