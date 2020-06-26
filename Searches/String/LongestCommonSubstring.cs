namespace CSharpAlgo.Searching.String
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubstring
    {
        public static string GetLCS(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            var dp = new int[len1, len2];
            int max = -1;
            int maxX = -1;
            int maxY = -1;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if(i == 0 || j == 0)
                    {
                        if (str1[i] == str2[j])
                        {
                            dp[i, j] = 1;
                        }
                        else
                        {
                            dp[i, j] = 0;
                        }
                    }
                    else
                    {
                        if(str1[i] == str2[j])
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            dp[i, j] = 0;
                        }
                    }

                    if(dp[i, j] > max)
                    {
                        max = dp[i, j];
                        maxX = i;
                        maxY = j;
                    }
                    

                }
            }

            var lcs = new Stack<char>();

            while (max > 0)
            {
                lcs.Push(str1[maxX]);
                maxX--;
                max--;
            }

            return new String(lcs.ToArray());
        }
    }
}
