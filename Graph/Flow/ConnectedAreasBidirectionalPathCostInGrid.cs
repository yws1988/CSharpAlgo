/*
    Give a char matrix,  in the char grid it contains the following characters:
    '.' represents a crossable cell
    '#' represents a wall cell, is not crossable
    '!' an door cell
    's' source crossable cell axis(0, 0)
    'd' destination crossable cell(n-1, n-1)

    once you've walked on such a door cell, it becomes impassable.
    Indicating the minimum number of door cells to cross in order to reach the destination and return back
    to source. If it is possible to reach destination but not come back then return -1. 
    If it is not possible to reach the source from destination, return -2.

    Input char grid like this:
    .....
    ##!!#
    #!!!#
    #!!##
    .....

    Output -1

    Input char grid:
    ....
    #!!#
    #!!#
    ....

    return 4
 */

namespace CSharpAlgo.Graph.Flow
{
    using System.Collections.Generic;
    using System.Linq;
    using input = System.Console;


    public class ConnectedAreasBidirectionalPathCostInGrid
    {
        static int n;
        static Dictionary<int, List<(int, int)>> nodesByArea;
        static Dictionary<int, char> type=new Dictionary<int, char>();
        static int[,] map;
        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = { 1, 0, -1, 0 };
        const int INF = int.MaxValue;

        public static int GetCost(string[] grid)
        {
            n = int.Parse(input.ReadLine());
            nodesByArea = new Dictionary<int, List<(int, int)>>();
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
                        if (grid[i][j] == '.')
                        {
                            nodesByArea[area] = dfs(i, j, area, grid);
                            type[area] = '.';
                            area++;
                        }else if(grid[i][j] == '!')
                        {
                            var list = new List<(int, int)>();
                            for (int k = 0; k < 4; k++)
                            {
                                int tx = i + dx[k];
                                int ty = j + dy[k];
                                if (tx >= 0 && tx < n && ty >= 0 && ty < n && grid[tx][ty]!='#')
                                {
                                    list.Add((tx, ty));
                                }
                            }

                            map[i, j] = area;
                            nodesByArea[area] = list;
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
                    foreach (var item in nodesByArea[i])
                    {
                        ng[twin[i]].Add(new Node(map[item.Item1, item.Item2], 0, INF));
                    }

                    ng[i].Add(new Node(twin[i], 1, 1));
                }
                else
                {
                    foreach (var item in nodesByArea[i])
                    {
                        ng[i].Add(new Node(map[item.Item1, item.Item2], 0, INF));
                    }
                }
            }

            var routeFromSourceToDestination1 = bellmanford(ng, 0, map[n - 1, n - 1]);

            if(grid[0][0]=='#' || routeFromSourceToDestination1.dis == INF)
            {
                return -2;
            }

            var path = routeFromSourceToDestination1.path.ToArray();

            int lp = path.Length;
            for (int i = 0; i < lp-1; i++)
            {
                var bn = path[i];
                var fn = path[i + 1];

                for (int j = 0; j < ng[bn].Count; j++)
                {
                    if (ng[bn][j].destination == fn)
                    {
                        ng[bn][j].times -= 1;
                        ng[fn].Add(new Node(bn, -ng[bn][j].cost, 1));
                        break;
                    }
                }
            }

            var routeFromSourceToDestination2 = bellmanford(ng, 0, map[n - 1, n - 1]);

            if (routeFromSourceToDestination2.dis == INF)
            {
                return -1;
            }

            return routeFromSourceToDestination2.dis + routeFromSourceToDestination2.dis;
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
                        if(e.times>0 && dis[j]!=INF && dis[j] + e.cost < dis[e.destination])
                        {
                            dis[e.destination] = dis[j] + e.cost;
                            ps[e.destination] = j;
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

        static List<(int, int)> dfs(int x, int y, int a, string[] grid)
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
                        if(map[tx, ty] == -1 && grid[tx][ty] == '.')
                        {
                            map[tx, ty] = a;
                            stack.Push((tx, ty));
                        }else if (grid[tx][ty] == '!')
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
        public int destination;
        public int cost;
        public int times;

        public Node(int d, int w, int t)
        {
            this.destination = d;
            this.cost = w;
            this.times = t;
        }
    }
}