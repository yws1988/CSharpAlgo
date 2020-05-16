using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExcercise.BranchAndBounds
{
    public class LongestRepeatedSequence
    {
        public static void GetLRS(string str1)
        {
            char[] xChars = str1.ToCharArray();
            char[] yChars = xChars;

            int xLength = xChars.Length + 1;

            int[,] matrix = new int[xLength, xLength];
            for (int i = 1; i < xLength; i++)
            {
                for (int j = 1; j < xLength; j++)
                {
                    if(i!=j && xChars[i-1] == yChars[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            Console.WriteLine("The longest length of repeated sequence is : " + matrix[xLength-1, xLength - 1]);

            Console.WriteLine("The matrix is like this : ");
            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < xLength; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            List<char> chars = new List<char>();

            int m = xLength-1;
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
                    chars.Add(xChars[m - 1]);
                    m--;
                    n--;
                }
            }

            chars.Reverse();

            Console.WriteLine("The result of the string is : "+ new string(chars.ToArray()));
        }
    }
}
