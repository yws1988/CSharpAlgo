using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class RobotProgramming
    {
        static int T;
        static int n;
        static char[][] strs;
        const int len= 500;
        static Dictionary<char, char> dic = new Dictionary<char, char>();

        public static void Start()
        {
#if false
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\test.txt");
#endif
            dic.Add('R', 'P');
            dic.Add('P', 'S');
            dic.Add('S', 'R');
            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                n = int.Parse(input.ReadLine());
                strs = new char[n][];
                for (int j = 0; j < n; j++)
                {
                    var css = input.ReadLine().ToCharArray();
                    int ll = css.Length;
                    strs[j] = new char[len];
                    for (int h = 0; h < len; h++)
                    {
                        strs[j][h] = css[h % ll];
                    }
                }

                Solve(i + 1);
            }

            //Console.Read();
        }

        public static void Solve(int t)
        {
            List<char> cr = new List<char>();
            bool[] vs = new bool[n];
            for (int i = 0; i < len; i++)
            {
                List<char> cc = new List<char>();

                Dictionary<char, List<int>> cidx = new Dictionary<char, List<int>>();
                cidx['S'] = new List<int>();
                cidx['R'] = new List<int>();
                cidx['P'] = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    if (!vs[j])
                    {
                        cc.Add(strs[j][i]);
                        cidx[strs[j][i]].Add(j);
                    }
                }

                cc = cc.Distinct().ToList();
                if (cc.Count() == 3)
                {
                    Output(t, "IMPOSSIBLE");
                    break;
                }else if (cc.Count() == 1)
                {
                    cr.Add(dic[cc[0]]);
                    Output(t, new string(cr.ToArray()));
                    break;
                }
                else if(cc.Count() == 2)
                {
                    char nc;
                    if (dic[cc[0]] == cc[1])
                    {
                        nc = cc[1];
                    }
                    else
                    {
                        nc = cc[0];
                    }

                    if (cr.Count == len-1)
                    {
                        Output(t, "IMPOSSIBLE");
                        break;
                    }
                    else
                    {
                        cr.Add(nc);
                    }

                    foreach(int k in cidx[dic[dic[nc]]])
                    {
                        vs[k] = true;
                    }
                }
                else
                {
                    Output(t, new string(cr.ToArray()));
                    break;
                }
            }
        }

        public static void Output(int caseNum, string result)
        {
            Console.WriteLine("Case #" + caseNum + ": " + result);
        }
    }
}
