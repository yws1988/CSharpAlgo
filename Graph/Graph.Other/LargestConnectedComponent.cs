using System;
using System.Collections.Generic;

namespace graph.Other
{
    public class LargestConnectedComponentInGrid
    {
        public static int GetLargestConnectedComponent(int[,] graph)
        {
            int m = graph.GetLength(0);
            int n = graph.GetLength(1);
            var vs = new bool[m, n];

            var area = new int[m, n];
            int areaNum = 1;
            int max = 0;
            int maxAreaNum = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!vs[i, j])
                    {
                        int val = graph[i, j];
                        int num = Search(graph, vs, i, j, val, areaNum, m, n, area);
                        if (num > max)
                        {
                            max = num;
                            maxAreaNum = areaNum;
                        }
                        areaNum++;
                    }
                }
            }

            return max;
        }

        public static int Search(int[,] graph, bool[,] vs, int i, int j, int val, int counter, int m, int n, int[,] area)
        {
            if (i < 0 || i >= m || j < 0 || j >= n) return 0;

            if (!vs[i, j] && graph[i, j] == val)
            {
                vs[i, j] = true;
                area[i, j] = counter;
                int[] xMove = { 1, -1, 0, 0 };
                int[] yMove = { 0, 0, 1, -1 };

                int c = 1;
                for (int u = 0; u < 4; u++)
                {
                    c += Search(graph, vs, i + xMove[u], j + yMove[u], val, counter, m, n, area);
                }
                return c;
            }

            return 0;
        }

        public static List<(int, int)> GetArea(int[,] area, int areaNum)
        {
            var list = new List<(int, int)>();
            int m = area.GetLength(0);
            int n = area.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (area[i, j] == areaNum)
                    {
                        list.Add((i, j));
                    }
                }
            }

            return list;
        }
    }
}

