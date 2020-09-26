using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class ManhattanCrepeCart
    {
        public static int T;
        public static int p;
        public static int q;
        public static int[][] lo;
        public static string[] pp;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\test.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                var nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                p = nums[0];
                q = nums[1];
                lo = new int[p][];
                pp = new string[p];
                for (int k = 0; k < p; k++)
                {
                    var nn = input.ReadLine().Split(' ').ToArray();
                    lo[k] = new int[2];
                    lo[k][0] = int.Parse(nn[0]);
                    lo[k][1] = int.Parse(nn[1]);
                    pp[k] = nn[2];
                }
                

                Solve(i+1);
            }

            Console.Read();
        }

        public static int Solve(bool isX)
        {
            Dictionary<int, Node> dic = new Dictionary<int, Node>();

            int et = 0;
            int wt = 0;
            int v = isX ? 0 : 1;

            for (int i = 0; i < p; i++)
            {
                if (pp[i] == (isX ? "E":"N"))
                {
                    et++;
                    if (dic.ContainsKey(lo[i][v]))
                    {
                        dic[lo[i][v]].e += 1;
                    }
                    else
                    {
                        dic[lo[i][v]] = new Node(1, 0);
                    }
                }
                else if (pp[i] == (isX ? "W":"S"))
                {
                    wt++;
                    if (dic.ContainsKey(lo[i][v]))
                    {
                        dic[lo[i][v]].w += 1;
                    }
                    else
                    {
                        dic[lo[i][v]] = new Node(0, 1);
                    }
                }
            }

            var cords = dic.Select(s => s.Key).OrderBy(s => s).ToArray();

            int x = 0;
            int xm = p - et;
            int ec = 0;
            int wc = 0;
            for (int i = 0; i < cords.Length; i++)
            {
                ec += dic[cords[i]].e;
                wc += dic[cords[i]].w;

                int tx = cords[i] + 1;
                int mc = 0;
                if (dic.ContainsKey(tx))
                {
                    mc = p - wc - (et - ec) - dic[tx].w;
                }
                else
                {
                    mc = p - wc - (et - ec);
                }

                if (mc > xm)
                {
                    x = tx;
                    xm = mc;
                }
            }

            return x;
        }

        public static void Solve(int t)
        {
            int x = Solve(true);
            int y = Solve(false);

            Output(t, x + " " + y);
        }

        public static void Output(int caseNum, string result)
        {
            Console.WriteLine("Case #" + caseNum + ": " + result);
        }
    }

    class Node
    {
        public int e = 0;
        public int w=0;
        
        public Node(int ee, int ww)
        {
            e = ee;
            w = ww;
        }
    }
}
