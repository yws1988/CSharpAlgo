using System;
using System.Collections.Generic;
using Collection;

namespace Graph.ShortestPath
{
    public class Node:IComparable<Node>
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

    public class DijsktraShortestPath
    {
        public static int[,] Graph { get; set; }
        public static List<Node>[] GraphList { get; set; }
        public static int V { get; set; }
        public static bool[] Visited { get; set; }
        public static int[] Parents { get; set; }
        public static int[] Weights { get; set; }
        public static PriorityQueue<Node> NodeQueue { get; set; }

        public DijsktraShortestPath(int[,] graph)
        {
            Graph = graph;
            V = Graph.GetLength(0);
            GraphList = new List<Node>[V];
            Visited = new bool[V];
            Parents = new int[V];
            Weights = new int[V];
            NodeQueue = new PriorityQueue<Node>();
        }

        public static void Calculate(int src)
        {
            NodeQueue.Enqueue(new Node(src, 0));
            Parents[src] = src;

            while (NodeQueue.Count() > 0)
            {
                var node = NodeQueue.Dequeue();
                int s = node.Index;
                if (Visited[s]) continue;
                Visited[s] = true;

                for (int i = 0; i < V; i++)
                { 
                    if (Visited[i] == false && Graph[s, i] > 0)
                    {
                        if (Weights[i] > Weights[s] + Graph[s, i])
                        {
                            Weights[i] = Weights[s] + Graph[s, i];
                            Parents[i] = s;
                        }

                        NodeQueue.Enqueue(new Node(i, Weights[i]));
                    }
                }
            }
        }

        public static void CalculateGraphList(int src)
        {
            NodeQueue.Enqueue(new Node(src, 0));
            Parents[src] = src;

            while (NodeQueue.Count() > 0)
            {
                var nodeInfo = NodeQueue.Dequeue();
                int s = nodeInfo.Index;
                if (Visited[s]) continue;
                Visited[s] = true;

                for (int i = 0; i < GraphList[s].Count; i++)
                {
                    var e = GraphList[s][i];
                    if (!Visited[e.Index])
                    {
                        if (Weights[e.Index] > Weights[s] + e.Weight)
                        {
                            Weights[e.Index] = Weights[s] + e.Weight;
                            Parents[e.Index] = s;
                        }

                        NodeQueue.Enqueue(new Node(e.Index, Weights[s]));
                    }
                }
            }
        }

        public void CalculateShortestPath(int src)
        {
            for (int i = 0; i < V; i++)
            {
                if (i == src)
                {
                    Weights[i] = 0;
                }
                else
                {
                    Weights[i] = int.MaxValue;
                }
            }
            
            Calculate(src);

            PrintShortestPathForEveryNode(src);
        }

        private void PrintShortestPathForEveryNode(int src)
        {
            Stack<int> path = new Stack<int>();
            for (int i = 0; i < Weights.Length; i++)
            {
                Console.WriteLine($"Node {i}, shortest weight {Weights[i]}");
                int p = i;
                path.Push(p);
                do
                {
                    path.Push(Parents[p]);
                    p = Parents[p];
                } while (p != src);

                while (path.Count>0)
                {
                    Console.Write(path.Pop() + " => ");
                }
                Console.WriteLine();
            }
        }
    }
}
