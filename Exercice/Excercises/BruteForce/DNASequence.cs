namespace BattleDev
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DNASequence
    {
        public static int N;
        public static string[] strs;
        public static Dictionary<char, char> dic;
        public static string result;
        public const string F = "Fi";
        
        public static void Start(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            strs = new string[N];
            for (int i = 0; i < N; i++)
            {
                strs[i] = Console.ReadLine();
            }
            dic = new Dictionary<char, char>()
            {
                { 'A', 'T' },
                { 'T', 'A' },
                { 'C', 'G' },
                { 'G', 'C' }
            };
            bool[] isV = new bool[N];
            Solve("", "", "", isV);
            Console.WriteLine(result);
        }

        public static string StrTr(string input)
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

        public static void Solve(string prefix, string sol1, string sol2, bool[] isV)
        {
            int pL = prefix.Length;
            bool isAll = true;

            for (int i = 0; i < N; i++)
            {
                if (!isV[i])
                {
                    isAll = false;
                    bool[] isVn = new bool[N];
                    isV.CopyTo(isVn, 0);
                    isVn[i] = true;
                    string str = strs[i];
                    int sL = str.Length;
                    string nSol1, nSol2, nPrefix;
                    if (pL == 0)
                    {
                        nSol1 = sol1+ " "+str;
                        nSol2 = sol2;
                        nPrefix = StrTr(str);
                    }else if(sL>=pL && str.StartsWith(prefix))
                    {
                        nSol1 = sol2 + " " + str;
                        nSol2 = sol1;
                        nPrefix = StrTr(str.Substring(pL));
                    }else if (sL < pL && prefix.StartsWith(str))
                    {
                        nSol1 = sol1;
                        nSol2 = sol2 + " " + str;
                        nPrefix = prefix.Substring(sL);
                    }
                    else
                    {
                        nSol1 = sol1 + " " + str;
                        nSol2 = sol2;
                        nPrefix = prefix + StrTr(str);
                    }

                    Solve(nPrefix, nSol1, nSol2, isVn);
                }
            }

            if (isAll && prefix.Length == 0)
            {
                result = sol1.Trim() + "#" + sol2.Trim();
            }
        }
    }
}