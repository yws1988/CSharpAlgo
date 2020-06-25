namespace Graph.Path.ShortestPath
{
    using DataStructure.Heap;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DijsktraShortestPath
    {
        public static int GetShortestPath(int[,] graph, int src, int des)
        {
            int v = graph.GetLength(0);
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
        
        static int Calculate(int[,] graph, int src, int des, int v, int[] weights, int[] parents)
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

                for (int i = 0; i < v; i++)
                {
                    if (!visited[i] && graph[s, i] > 0)
                    {
                        if (weights[i] > weights[s] + graph[s, i])
                        {
                            weights[i] = weights[s] + graph[s, i];
                            parents[i] = s;
                        }

                        queue.Enqueue(new Node(i, weights[i]));
                    }
                }
            }

            return int.MaxValue;
        }


        public static int[] GetShortestPath(int[,] graph, int src)
        {
            int v = graph.GetLength(0);
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

            Calculate(graph, src, v, weights, parents);

            //var path = GetShortestPathForEveryNode(src, des, parents);
            return weights;
        }

        static void Calculate(int[,] graph, int src, int v, int[] weights, int[] parents)
        {
            var visited = new bool[v];
            var queue = new PriorityQueue<Node>();

            queue.Enqueue(new Node(src, 0));
            parents[src] = src;

            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                int s = node.Index;

                if (visited[s]) continue;
                visited[s] = true;
                
                for (int i = 0; i < v; i++)
                {
                    if (!visited[i] && graph[s, i] > 0)
                    {
                        if (weights[i] > weights[s] + graph[s, i])
                        {
                            weights[i] = weights[s] + graph[s, i];
                            parents[i] = s;
                        }

                        queue.Enqueue(new Node(i, weights[i]));
                    }
                }
            }
        }

        static void Calculate(List<Node>[] graph, int src, int v, int[] weights, int[] parents)
        {
            var visited = new bool[v];
            var queue = new Queue<Node>();

            queue.Enqueue(new Node(src, 0));
            parents[src] = src;

            while (queue.Count() > 0)
            {
                var nodeInfo = queue.Dequeue();
                int s = nodeInfo.Index;
                if (visited[s]) continue;
                visited[s] = true;

                for (int i = 0; i < graph[s].Count; i++)
                {
                    var e = graph[s][i];
                    if (!visited[e.Index])
                    {
                        if (weights[e.Index] > weights[s] + e.Weight)
                        {
                            weights[e.Index] = weights[s] + e.Weight;
                            parents[e.Index] = s;
                        }

                        queue.Enqueue(new Node(e.Index, weights[s]));
                    }
                }
            }
        }

        public List<int> GetShortestPathForEveryNode(int src, int des, int[] parents)
        {
            Stack<int> path = new Stack<int>();

            int p = des;
            path.Push(p);
            do
            {
                path.Push(parents[p]);
                p = parents[p];
            } while (p != src);

            return path.ToList();
        }

        public class Node : IComparable<Node>
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
