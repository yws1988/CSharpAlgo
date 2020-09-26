/*
 Given a string matrix, The goal is to determine the minimum number of moves you have to make to reach the bottom of the matrix.
 You can choose any starting point on the top of the matrix and arrive at any point at the bottom of the track. 
 In the matrix 'X' means a wall, '.' means it is crossable

 Exemples with following matrix 13*7:
    X..X...
    X.X..XX
    X.X....
    .XXX.X.
    X..X...
    XXXX...
    X.X..X.
    X.X.XXX
    .XX..XX
    X.X....
    X..X..X
    X.X..X.
    X.X..XX

    Output
    14
 */

namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;

    public class FromTopToBottonInGraphMatrix
    {
        public static int GetMinimunSteps(string[] graph)
        {
            int n = graph.Length;
            int m = graph[0].Length;
            var distance = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && graph[i][j] == '.')
                    {
                        distance[i, j] = 0;
                    }
                    else
                    {
                        distance[i, j] = int.MaxValue;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (distance[0, i] == 0)
                {
                    BFS(i, graph, distance);
                }
            }

            int res = int.MaxValue;
            for (int i = 0; i < m; i++)
            {
                res = Math.Min(res, distance[n - 1, i]);
            }

            return res == int.MaxValue ? -1 : res;
        }

        static void BFS(int idx, string[] graph, int[,] distance)
        {
            int n = graph.Length;
            int m = graph[0].Length;
            var queue = new Queue<(int, int, int)>();
            queue.Enqueue((0, idx, 0));

            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                int x = c.Item1;
                int y = c.Item2;
                int d = c.Item3;

                int[] dx = new[] { 0, 1, 0 };
                int[] dy = new[] { -1, 0, 1 };

                for (int i = 0; i < 3; i++)
                {
                    int tx = x + dx[i];
                    int ty = y + dy[i];

                    if (ty >= 0 && ty < m && tx < n && graph[tx][ty] == '.' && distance[tx, ty] > 1 + d)
                    {
                        distance[tx, ty] = 1 + d;
                        queue.Enqueue((tx, ty, 1 + d));
                    }
                }
            }
        }
    }

}
