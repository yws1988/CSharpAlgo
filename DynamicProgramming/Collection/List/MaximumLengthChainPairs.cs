/*
 Given n pairs of numbers. In every pair, the first number is always smaller than the second number. 
 A pair (c, d) can follow another pair (a, b) if b < c. Chain of pairs can be formed in this fashion. 
 Find the longest chain which can be formed from a given set of pairs. Source:

 For example, if the given pairs are {{5, 24}, {39, 60}, {15, 28}, {27, 40}, {50, 90} }, 
 then the longest chain that can be formed is of length 3, and the chain is {{5, 24}, {27, 40}, {50, 90}}
 */
namespace CSharpAlgo.DynamicProgramming.Collection.List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumLengthChainPairs
    {
        public static int GetMaximumLength(List<Tuple<int, int>> pairs)
        {
            int len = pairs.Count;
            var dp = new int[len];

            pairs = pairs.OrderBy(s => s.Item1).ToList();

            return GetMaxLength(len - 1, pairs[len - 1].Item1, dp, pairs);
        }

        public static int GetMaxLength(int index, int limit, int[] dp, List<Tuple<int, int>> pairs)
        {
            dp[0] = 1;
            for (int i = 1; i < pairs.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if(pairs[i].Item1 > pairs[j].Item2)
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                    }

                    if (dp[i] == 0) dp[i] = 1;
                }
            }

            return dp.Max();
        }
    }
}
