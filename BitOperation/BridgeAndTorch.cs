/*
 * There are n persons who want to cross a bridge in night, every person need x minutes to cross the bridge
 * There is only one torch with them and the bridge cannot be crossed without the torch.
 * There cannot be more than two persons on the bridge at any time,
 * and when two people cross the bridge together, they must move at the slower person’s pace.
 */
namespace CSharpAlgo.BitOperation
{
    using System;

    public class BridgeAndTorch
    {
        static int[,] dp;

        public static int GetMinimunTime(int[] times)
        {
            int n = times.Length;
            int len = 1 << n;

            // represent the left mask and right mask
            dp = new int[len, 2];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            int fullMask = len - 1;

            // 0 go cross river, 1 go back to river
            dp[0, 0] = 0;
            dp[0, 1] = 0;

            return GetMinTime(times, fullMask, 0, n);
        }

        static int GetMinTime(int[] times, int leftMask, int turn, int n)
        {
            if (dp[leftMask, turn] != int.MaxValue)
            {
                return dp[leftMask, turn];
            }

            if (turn == 0)
            {
                for (int m = 0; m < n; m++)
                {
                    for (int h = m + 1; h < n; h++)
                    {
                        if ((leftMask & (1 << m)) > 0 && (leftMask & (1 << h)) > 0)
                        {
                            dp[leftMask, 0] = Math.Min(dp[leftMask, 0], Math.Max(times[m], times[h]) + GetMinTime(times, leftMask ^ (1 << m) ^ (1 << h), 1, n));
                        }
                    }
                }
            }
            else if (turn == 1)
            {
                int minIndex = GetMinIndex(times, ((1 << n) - 1) ^ leftMask, n);
                dp[leftMask, 1] = Math.Min(dp[leftMask, 1], times[minIndex] + GetMinTime(times, leftMask | 1 << minIndex, 0, n));
            }

            return dp[leftMask, turn];
        }

        static int GetMinIndex(int[] arr, int mask, int n)
        {
            int min = int.MaxValue;
            int index = -1;
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) > 0)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                        index = i;
                    }
                }
            }

            return index;
        }
    }
}