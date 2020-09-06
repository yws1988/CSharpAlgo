/*
    You are given a bag of size W kg and you are provided costs of packets different weights of oranges 
    in array cost[] where cost[i] is basically cost of ‘i’ kg packet of oranges. 
    Where cost[i] = -1 means that ‘i’ kg packet of orange is unavailable

    Find the minimum total cost to buy exactly W kg oranges and if it is not possible to buy exactly W kg 
    oranges then print -1. It may be assumed that there is infinite supply of all available packet types.

    Note : array starts from index 1.
    Examples:

    Input  : W = 5, cost[] = {20, 10, 4, 50, 100}
    Output : 14
    We can choose two oranges to minimize cost. First 
    orange of 2Kg and cost 10. Second orange of 3Kg
    and cost 4. 

    Input  : W = 5, cost[] = {1, 10, 4, 50, 100}
    Output : 5
    We can choose five oranges of weight 1 kg.

    Input  : W = 5, cost[] = {-1, -1, 4, 5, -1}
    Output : -1
    Packets of size 1, 2 and 5 kg are unavailable
    because they have cost -1. Cost of 3 kg packet 
    is 4 Rs and of 4 kg is 5 Rs. Here we have only 
    weights 3 and 4 so by using these two we can  
    not make exactly W kg weight, therefore answer 
    is -1.
*/
namespace CSharpAlgo.DynamicProgramming.Other
{
    using System;

    public class MinimumCostOfKnapsack
    {
        public static int GetMinCostValue((int, int)[] arr, int capacity)
        {
            int n = arr.Length;

            var dp = new int[capacity + 1];
            for (int i = 0; i < capacity + 1; i++)
            {
                dp[i] = int.MaxValue;
            }

            dp[0] = 0;

            foreach (var (weight, cost) in arr)
            {
                for (int i = 0; i <= capacity-weight; i++)
                {
                    if (dp[i] != int.MaxValue)
                    {
                        dp[i + weight] = Math.Min(dp[i + weight], dp[i] + cost);
                    }
                }
            }

            return dp[capacity] < int.MaxValue ? dp[capacity] : -1;
        }
    }
}
