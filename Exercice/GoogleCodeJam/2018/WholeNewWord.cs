using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace GoogleCodeJam
{
    public class WholeNewWord
    {
        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\WholeNewWord.txt");
#endif
            int t = Convert.ToInt32(input.ReadLine());

            int[][] NL = new int[t][];
            string[][] Ws = new string[t][];

            for (int i = 0; i < t; i++)
            {
                NL[i] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Ws[i] = new string[NL[i][0]];
                for (int j = 0; j < NL[i][0]; j++)
                {
                    string str = input.ReadLine();
                    Ws[i][j] = str;
                }
            }

            
            for (int i = 0; i < t; i++)
            {
                string[] words = Ws[i];
                HashSet<string> hash=new HashSet<string>(words.Distinct());
                int L = NL[i][1];
                List<char>[] chars = new List<char>[L];
                for (int h = 0; h < L; h++)
                {
                    chars[h]=words.Select(s => s[h]).Distinct().ToList();
                }

                IEnumerable<string> lstRes = new List<string> { null };
                foreach (var list in chars)
                {
                    lstRes = lstRes.SelectMany(o => list.Select(s => o + s));
                }

                string result = "";
                bool isPossible = false;

                //IEnumerable avoid ocuppying too much memory, it is much faster,
                //it will be evaluated in compiler, 
                //Don't use ToList
                foreach (string item in lstRes)
                {
                    if (!hash.Contains(item))
                    {
                        isPossible = true;
                        result = item;
                        break;
                    }
                }

                Output(i + 1, result, isPossible);
            }

            Console.Read();
        }

        public static void Output(int caseNum, string result, bool isPos)
        {
            if (isPos)
            {
                input.Write("Case #" + caseNum + ": " + result);
            }
            else
            {
                input.Write("Case #" + caseNum + ": -");
            }
            

            input.WriteLine();
        }
    }
}
