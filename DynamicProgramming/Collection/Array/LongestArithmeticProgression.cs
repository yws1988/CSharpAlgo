/*
 * Given a set of numbers, find the Length of the Longest Arithmetic Progression(LLAP) in it(increasing array with the same interval)
 * set[] = {1, 7, 10, 15, 27, 29}
 * output = 3
 * The longest arithmetic progression is {1, 15, 29}
 */

namespace CSharpAlgo.DynamicProgramming.Collection.Array
{
    using System.Collections.Generic;
    using System.Linq;

    public class LongestArithmeticProgression
    {
        public static int GetMaxLength(int[] arr)
        {
            int len = arr.Length;
            var dic = new Dictionary<(int, int), int>();
            for (int i = 1; i < len; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    int margin = arr[i] - arr[j];
                    if (margin > 0)
                    {
                        dic[(i, margin)] = dic.ContainsKey((j, margin)) ? dic[(j, margin)] + 1 : 2;
                    }
                }
            }

            return dic.Select(d => d.Value).Max();
        }
    }
}