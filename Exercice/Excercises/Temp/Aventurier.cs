namespace BattleDev
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using input = System.Console;


    public class Aventurier
    {
        public static int n;
        public static char[][] s;
        static Dictionary<int, List<(int, int)>> g;
        static Dictionary<int, char> type=new Dictionary<int, char>();
        static int[,] map;
        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = { 1, 0, -1, 0 };
        const int INF = int.MaxValue;

        public static void Start(string[] args)
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\test.txt");
#endif
            n = int.Parse(input.ReadLine());
            g = new Dictionary<int, List<(int, int)>>();
            s = new char[n][];

            for (int i = 0; i < n; i++)
            {
                s[i] = input.ReadLine().ToCharArray();
            }
            
            map = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = -1;
                }
            }

            int area = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(map[i, j] == -1)
                    {
                        if (s[i][j] == '.')
                        {
                            g[area] = dfs(i, j, area);
                            type[area] = '.';
                            area++;
                        }else if(s[i][j] == '!')
                        {
                            var list = new List<(int, int)>();
                            for (int k = 0; k < 4; k++)
                            {
                                int tx = i + dx[k];
                                int ty = j + dy[k];
                                if (tx >= 0 && tx < n && ty >= 0 && ty < n && s[tx][ty]!='#')
                                {
                                    list.Add((tx, ty));
                                }
                            }

                            map[i, j] = area;
                            g[area] = list;
                            type[area] = '!';
                            area++;
                        }
                    }
                }
            }

            int[] twin = new int[area];
            int t = area;
            for (int i = 0; i < area; i++)
            {
                if (type[i] == '!')
                {
                    twin[i] = t;
                    t++;
                }
                else
                {
                    twin[i] = -1;
                }
            }

            List<Node>[] ng = Enumerable.Range(0, t+1).Select(s=>new List<Node>()).ToArray();

            for (int i = 0; i < area; i++)
            {
                if (type[i] == '!')
                {
                    foreach (var item in g[i])
                    {
                        ng[twin[i]].Add(new Node(map[item.Item1, item.Item2], 0, INF));
                    }

                    ng[i].Add(new Node(twin[i], 1, 1));
                }
                else
                {
                    foreach (var item in g[i])
                    {
                        ng[i].Add(new Node(map[item.Item1, item.Item2], 0, INF));
                    }
                }
            }

            //for (int i = 0; i < ng.GetLength(0); i++)
            //{
            //    for (int j = 0; j < ng[i].Count; j++)
            //    {
            //        Console.WriteLine(i + "=>" + ng[i][j].d + "  (w:" + ng[i][j].w + " t:" + ng[i][j].t + ")");
            //    }
            //}

            //Console.WriteLine("-------------------------------------");

            var r = bellmanford(ng, 0, map[n - 1, n - 1]);

            if(s[0][0]=='#' || r.dis == INF)
            {
                Console.WriteLine("-2");
                return;
            }

            var path = r.path.ToArray();

           
            //Console.WriteLine(string.Join("=>", path));
            //Console.WriteLine("-------------------------------------");

            int lp = path.Length;
            for (int i = 0; i < lp-1; i++)
            {
                var bn = path[i];
                var fn = path[i + 1];

                for (int j = 0; j < ng[bn].Count; j++)
                {
                    if (ng[bn][j].d == fn)
                    {
                        ng[bn][j].t -= 1;
                        ng[fn].Add(new Node(bn, -ng[bn][j].w, 1));
                        break;
                    }
                }
            }

            var r1 = bellmanford(ng, 0, map[n - 1, n - 1]);

            //for (int i = 0; i < ng.GetLength(0); i++)
            //{
            //    for (int j = 0; j < ng[i].Count; j++)
            //    {
            //        Console.WriteLine(i + "=>" + ng[i][j].d + "  (w:"+ ng[i][j].w +" t:"+ ng[i][j].t+")");
            //    }
            //}

            if (r1.dis == INF)
            {
                Console.WriteLine("-1");
                return;
            }

            Console.WriteLine(r1.dis+r.dis);

            Console.ReadKey();
        }

        static (Stack<int> path, int dis) bellmanford(List<Node>[] ng, int s, int d)
        {
            int len=ng.Count();
            int[] dis = new int[len];
            int[] ps = new int[len];

            for (int i = 0; i < len; i++)
            {
                dis[i] = INF;
                ps[i] = -1;
            }

            dis[s] = 0;

            for (int i = 0; i < len-1; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    foreach (var e in ng[j])
                    {
                        if(e.t>0 && dis[j]!=INF && dis[j] + e.w < dis[e.d])
                        {
                            dis[e.d] = dis[j] + e.w;
                            ps[e.d] = j;
                        }
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            path.Push(d);
            int t = ps[d];
            while (t != -1)
            {
                path.Push(t);
                t = ps[t];
            }

            return (path, dis[d]);
        }

        static List<(int, int)> dfs(int x, int y, int a)
        {
            List<(int, int)> list = new List<(int, int)>();
            Stack<(int, int)> stack = new Stack<(int, int)>();
            map[x, y] = a;
            stack.Push((x, y));

            while (stack.Count > 0)
            {
                var next = stack.Pop();
                for (int i = 0; i < 4; i++)
                {
                    int tx = next.Item1 + dx[i];
                    int ty = next.Item2 + dy[i];
                    if (tx >= 0 && tx < n && ty >= 0 && ty < n)
                    {
                        if(map[tx, ty] == -1 && s[tx][ty] == '.')
                        {
                            map[tx, ty] = a;
                            stack.Push((tx, ty));
                        }else if (s[tx][ty] == '!')
                        {
                            list.Add((tx, ty));
                        }
                    }
                }
            }

            return list;
        }
    }

    class Node
    {
        public int d;
        public int w;
        public int t;

        public Node(int d, int w, int t)
        {
            this.d = d;
            this.w = w;
            this.t = t;
        }
    }
}