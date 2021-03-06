﻿using System.Collections.Generic;
using System.Text;

namespace Utils.Helper
{
    public class StringHelper
    {
        /// <summary>
        /// Replace the string characters with specified mapped character array
        /// </summary>
        /// <param name="input">The origninal string</param>
        /// <param name="src">Searched characters</param>
        /// <param name="des">Replaced characters</param>
        /// <returns></returns>
        public static string StrReplace(string input, char[] src, char[] des)
        {
            Dictionary<char, char> dic = new Dictionary<char, char>();
            for (int i = 0; i < src.Length; i++)
            {
                dic.Add(src[i], des[i]);
            }

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (dic.ContainsKey(input[i]))
                {
                    str.Append(dic[input[i]]);
                }
                else
                {
                    str.Append(input[i]);
                }
            }

            return str.ToString();
        }

        public static string StrReplace(string input, Dictionary<char, char> dic)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (dic.ContainsKey(input[i]))
                {
                    str.Append(dic[input[i]]);
                }
                else
                {
                    str.Append(input[i]);
                }
            }

            return str.ToString();
        }

        /// <summary>
        /// Determine if string contains the sequence
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsSequenceInString(string sequence, string str)
        {
            int i = 0, j = 0;

            while (i < sequence.Length && j < str.Length)
            {
                if (sequence[i] == str[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }

            if (i == sequence.Length)
            {
                return true;
            }

            return false;
        }
    }
}
