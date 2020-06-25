/*
 * Given to integers a and b. Your task is to print the sum of all the digits appearing in the integers between a and b.
 * For example if a = 5 and b = 11, then answer is 38 (5 + 6 + 7 + 8 + 9 + 1 + 0 + 1 + 1)
 */

namespace AlgorithmExcercise.DynamicProgramming
{
    using System.Collections.Generic;

    public class DigitSum
    {
        public static long GetDigitSumOfAllRangeNumbers(int start, int end)
        {
            // long 64-bit signed integer contains maximum 19 digits
            // tight value 0 or 1
            // maximum sum of all the 19 digits 19*9 = 171

            var dp = new long[19, 2, 171];

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 171; k++)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }

            var maxValueByIndex = new List<int>();
            CalculateIndexValues(end, maxValueByIndex);
            long resultEnd = GetDigitSumUntil(maxValueByIndex.Count - 1, 1, 0, dp, maxValueByIndex);

            CalculateIndexValues(start - 1, maxValueByIndex);
            long resultStart = GetDigitSumUntil(maxValueByIndex.Count - 1, 1, 0, dp, maxValueByIndex);

            return resultEnd - resultStart;
        }

        public static int GetDigitsSumOfNumber(long number)
        {
            int sum = 0;
            do
            {
                sum += (int)number % 10;
                number /= 10;
            } while (number > 0);

            return sum;
        }

        static long GetDigitSumUntil(int index, int tight, int sum, long[,,] dp, List<int> maxValueByIndex)
        {
            if (index <= -1) return sum;
            if (dp[index, tight, sum] != -1) return dp[index, tight, sum];
            long result = 0;

            int upperLimit = tight == 0 ? 9 : maxValueByIndex[index];

            for (int i = 0; i <= upperLimit; i++)
            {
                int newTight = (tight == 1 && i == upperLimit) ? 1 : 0;
                result += GetDigitSumUntil(index - 1, newTight, sum + i, dp, maxValueByIndex);
            }

            return dp[index, tight, sum] = result;
        }

        static void CalculateIndexValues(long value, List<int> maxValueByIndex)
        {
            maxValueByIndex.Clear();
            do
            {
                maxValueByIndex.Add((int)value % 10);
                value /= 10;
            } while (value > 0);
        }
    }
}