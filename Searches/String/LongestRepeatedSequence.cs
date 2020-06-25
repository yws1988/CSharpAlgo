// longest repeating subsequence
// str = "aadsdkeke"
// output = "adke"

namespace Searching.String
{
    using System;
    using System.Collections.Generic;

    public class LongestRepeatedSequence
    {
        public static string GetLRS(string str)
        {
            int length = str.Length + 1;

            int[,] matrix = new int[length, length];
            for (int i = 1; i < length; i++)
            {
                for (int j = 1; j < length; j++)
                {
                    if(i != j && str[i - 1] == str[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            var chars = new Stack<char>();

            int m = length-1;
            int n = m;

            while (m > 0 && n > 0)
            {
                if (matrix[m, n] == 0) break;

                if (matrix[m, n] == matrix[m - 1, n])
                {
                    m--;
                }
                else if (matrix[m, n] == matrix[m, n - 1])
                {
                    n--;
                }
                else
                {
                    chars.Push(str[m - 1]);
                    m--;
                    n--;
                }
            }

            return new string(chars.ToArray());
        }
    }
}
