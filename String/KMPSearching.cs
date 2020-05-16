using System.Collections.Generic;

namespace PatternSearching
{
    public class KMPSearching
    {
        /// <summary>
        /// Given a text txt and a pattern string pattern, write a function 
        /// to get all occurrences of pattern in txt. 
        /// You may assume that n > m.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="text"></param>
        
        public static IList<int> SearchPattern(string pattern, string text)
        {
            int[] lpsArray;

            CalculateLps(pattern, out lpsArray);

            var result = new List<int>();
            int j = 0;
            for (int i = 0; i < text.Length;)
            {
                if(text[i] == pattern[j])
                {
                    i++;
                    j++;

                    if(j == lpsArray.Length)
                    {
                        result.Add(i - j);
                        j = lpsArray[j - 1];
                    }

                }else
                {
                    if (j > 0)
                    {
                        j = lpsArray[j - 1];
                    }else
                    {
                        i++;
                    }
                }
            }

            return result;
        }

        static void CalculateLps(string pattern, out int[] lps)
        {
            int len = 0;
            char[] chars = pattern.ToCharArray();
            lps = new int[chars.Length];

            for (int i = 1; i < chars.Length;)
            {
                if (chars[i] == chars[len])
                {
                    lps[i] = len + 1;
                    len++;
                    i++;
                }
                else if (chars[i] != chars[len] && len > 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
    }
}
