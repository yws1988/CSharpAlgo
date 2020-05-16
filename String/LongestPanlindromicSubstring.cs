using System;

namespace AlgorithmExcercise.BranchAndBounds.Simple
{
    public class LongestPanlindromicSubstring
    {
        public static int[,] dp;
        public static void Start(string str)
        {
            int n = str.Length;
            dp = new int[n, n];
            int x=0, y=0;
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = 1;
                if (i<n-1 && str[i + 1] == str[i])
                {
                    dp[i, i + 1] = 1;
                    x = i; y = i + 1;
                    
                }
            }
            for (int len = 3; len <= n; len++)
            {
                for (int i = 0; i+len-1 < n; i++)
                {
                    if(dp[i+1, i+len-2] == 1 && str[i]==str[i + len - 1])
                    {
                        dp[i, i + len - 1] = 1;
                        x = i;
                        y = i + len - 1;
                    }
                }
            }
            Console.WriteLine($"The longest panlindrone is : {str.Substring(x, y-x+1)}");
        }
    }
}
