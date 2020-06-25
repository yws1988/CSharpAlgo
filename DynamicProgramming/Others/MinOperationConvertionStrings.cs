/*
    Given two strings str1 and str2 and below operations that can performed on str1. 
    Find minimum number of edits (operations) required to convert ‘str1’ into ‘str2’.
    You can do the following operations:
    Insert
    Remove
    Replace
    All of the above operations are of equal cost.

    Examples:

    Input:   str1 = "geek", str2 = "gesek"
    Output:  1
    We can convert str1 into str2 by inserting a 's'.
 */

namespace DynamicProgramming.Other
{
    public class MinOperationConvertionStrings
    {
        public static int GetMinimumOperation(string str1, string str2)
        {
            var dp = new int[str1.Length, str2.Length];

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return GetMin(str1.Length - 1, str2.Length - 1, str1, str2, dp);
        }

        static int GetMin(int m, int n, string str1, string str2, int[,] dp)
        {
            if (n < 0) return m+1;
            if (m < 0) return n+1;

            if(dp[m, n] != -1)
            {
                return dp[m, n];
            }

            if(str1[m] == str2[n])
            {
                dp[m, n] = GetMin(m - 1, n - 1, str1, str2, dp);
            }else
            {
                dp[m, n] =1 + GetMinValue(GetMin(m, n-1, str1, str2, dp), GetMin(m-1, n-1, str1, str2, dp), GetMin(m-1, n, str1, str2, dp));
            }

            return dp[m, n];
        }

        static int GetMinValue(int n1, int n2, int n3)
        {
            return n1 > n2 ? (n2 > n3 ? n3 : n2) : (n1 > n3 ? n3 : n1);
        }
    }
}