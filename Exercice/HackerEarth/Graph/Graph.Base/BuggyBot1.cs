//using System;
//using System.Collections.Generic;
//using System.Linq;
//using input = System.Console;

//namespace HackerEarth.Graph.Base
//{
//    public class BuggyBot
//    {
//        public static int n, m, k;
//        public static int[] ia, ib, ee, pos;
//        public static List<int>[] G;
//        public static HashSet<int> r = new HashSet<int>();

//        public static void Start()
//        {
//#if true
//            System.IO.StreamReader input = new System.IO.StreamReader(@"test\BuggyBot.txt");
//#endif
//            var nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            n = nums[0];
//            m = nums[1];
//            k = nums[2];

//            G = new List<int>[n + 1];

//            for (int i = 0; i < n + 1; i++)
//            {
//                G[i] = new List<int>();
//            }

//            for (int i = 0; i < m; i++)
//            {
//                var e = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
//                G[e[0]].Add(e[1]);
//            }

//            int K = k + 1;
//            ia = new int[K];
//            ib = new int[K];
//            pos = new int[K];
//            pos[0] = 1;
//            int cp = 1;

//            for (int i = 0; i < k; i++)
//            {
//                var ins = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
//                ia[i] = ins[0];
//                ib[i] = ins[1];

//                if (cp == ia[i])
//                {
//                    cp = ib[i];
//                }

//                pos[i + 1] = cp;
//            }
//            r.Add(pos[k]);

//            for (int i = 0; i < pos.Length; i++)
//            {
//                Console.WriteLine(i+"=>"+pos[i]);
//            }

//            /*
//                0=>1
//                1=>1
//                2=>1
//                3=>5
//                4=>5
//             */

//            ee = new int[n + 1];
//            HashSet<int>[] temp = new HashSet<int>[n + 1];
//            for (int i = 1; i <= n; i++)
//            {
//                ee[i] = i;
//                temp[i] = new HashSet<int>();
//            }

//            for (int i = k; i >= 0; i--)
//            {
//                foreach (int j in G[pos[i]])
//                {
//                    r.Add(ee[j]);

//                    temp[j].Add(pos[i]);
//                }

//                G[pos[i]].Clear();

//                if (i > 0)
//                {
//                    ee[ia[i - 1]] = ee[ib[i - 1]];

//                    foreach (int j in temp[ia[i-1]])
//                    {
//                        G[j].Add(ia[i - 1]);
//                    }
//                }
//            }
//        }
//    }
//}