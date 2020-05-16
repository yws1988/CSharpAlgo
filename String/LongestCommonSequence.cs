namespace AlgorithmExcercise.DynamicProgramming
{
    using System.Collections.Generic;

    public class LongestCommonSequence
    {
        public static string GetLCS(string str1, string str2)
        {
            int xLength = str1.Length + 1;
            int yLength = str2.Length + 1;

            int[,] matrix = new int[yLength, xLength];
            for (int i = 1; i < yLength; i++)
            {
                for (int j = 1; j < xLength; j++)
                {
                    if(str1[j-1] == str2[i - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = System.Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            // The length of the longest sequence is matrix[yLength-1, xLength-1]
            List<char> chars = new List<char>();

            int m = yLength-1;
            int n = xLength-1;

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
                    chars.Add(str1[n-1]);
                    m--;
                    n--;
                }
            }

            return new string(chars.ToArray());
        }
    }
}
