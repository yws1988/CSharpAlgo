/*
    Give a char matrix n row*m column,  in the char grid it contains the following characters:
    '.' represents a crossable cell
    '#' represents a wall cell, is not crossable
    's' source crossable cell
    'd' destination crossable cell
    How many wall at least to break in order to connect source and destination?

    Input char grid like this:
    ##########
    s...#....#
    #####..###
    #......#.#
    ##########
    #..#..#..#
    #..#..####
    #..#.....#
    ########d#

   so the expected answer is 2.
 */

namespace CSharpAlgo.Graph.Connectivity
{
    using System;
    using CSharpAlgo.DataStructure.Heap;

    public class ConnectedAreasPathCostForSingleSourceInGrid
    {
        static int n, m;
        static int[] dx = { 1, 0, -1, 0 };
        static int[] dy = { 0, 1, 0, -1 };

        public static int GetShortestPath(string[] graph, int src, int des)
        {
            n = graph.Length;
            m = graph[0].Length;

            int v = n * m;
            var weights = new int[v];
            var parents = new int[v];

            for (int i = 0; i < v; i++)
            {
                if (i == src)
                {
                    weights[i] = 0;
                }
                else
                {
                    weights[i] = int.MaxValue;
                }
            }

            return Calculate(graph, src, des, v, weights, parents);
        }

        static int Calculate(string[] graph, int src, int des, int v, int[] weights, int[] parents)
        {
            var visited = new bool[v];
            var queue = new PriorityQueue<Node>();

            queue.Enqueue(new Node(src, 0));
            parents[src] = src;

            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                int s = node.Index;

                if (s == des)
                {
                    return weights[des];
                }

                if (visited[s]) continue;
                visited[s] = true;

                int x = s / m;
                int y = s % m;

                for (int i = 0; i < 4; i++)
                {
                    int tx = x + dx[i];
                    int ty = y + dy[i];
                    int d = tx * m + ty;

                    if (IsSafe(tx, ty) && !visited[d])
                    {
                        int newWeight = weights[s];

                        if (graph[tx][ty] == '#')
                        {
                            newWeight += 1;
                        }

                        if (weights[d] > newWeight)
                        {
                            weights[d] = newWeight;
                            parents[d] = s;
                        }

                        queue.Enqueue(new Node(d, weights[d]));
                    }
                }
            }

            return int.MaxValue;
        }

        static bool IsSafe(int tx, int ty)
        {
            return tx >= 0 && tx < n && ty >= 0 && ty < m;
        }

        class Node : IComparable<Node>
        {
            public int Weight { get; set; }

            public int Index { get; set; }

            public Node(int index, int weight)
            {
                Index = index;
                Weight = weight;
            }

            public int CompareTo(Node other)
            {
                return this.Weight.CompareTo(other.Weight);
            }
        }
    }
}