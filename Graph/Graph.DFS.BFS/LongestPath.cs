

using System.Linq;

namespace Algorithmne
{
    //Given a Weighted Directed Acyclic Graph(DAG) and a source vertex s in it, find the longest distances from s to all other vertices in the given graph.

    using System;
    using System.Collections.Generic;

    public class Node
    {
        public int Num { get; set; }
        public int Weight { get; set; }
    }

    public class LongestPath
    {
        public int V;
        public LinkedList<Node>[] adjListArray;
        bool[] visited;
        Stack<int> stack;
        public const int INFI = int.MinValue;
        public int WeightMax = int.MinValue;

        public LongestPath(int v)
        {
            V = v;
            adjListArray = new LinkedList<Node>[V];

            for (var i = 0; i < adjListArray.Length; i++)
            {
                adjListArray[i] = new LinkedList<Node>();
            }

            visited = new bool[V];
            stack = new Stack<int>();
        }

        public void AddEdge(int src, int des, int weight)
        {
            adjListArray[src].AddLast(new Node { Num = des, Weight = weight});
        }

        public void TopologicalSortingUtil(int i)
        {
            if (visited[i] == false)
            {
                visited[i] = true;

                foreach (Node s in adjListArray[i])
                {
                    TopologicalSortingUtil(s.Num);
                }

                stack.Push(i);
            }
        }

        public void StartTopologicalSorting()
        {
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    TopologicalSortingUtil(i);
                }
            }
        }

        //Solution 1
        public void CalculateLongestPathWithTopologicalOrder(int s)
        {
            StartTopologicalSorting();
            int[] weights = new int[V];
            Stack<int> copieStack = new Stack<int>(stack);
            List<int> longestPath = new List<int>();
            
            for (var i = 0; i < weights.Length; i++)
            {
                weights[i] = INFI;
            }
            weights[s] = 0;

            do
            {
                int numVertix = stack.Pop();
                if (weights[numVertix] != INFI)
                {
                    foreach (Node node in adjListArray[numVertix])
                    {
                        if (weights[numVertix] + node.Weight > weights[node.Num])
                        {
                            weights[node.Num] = weights[numVertix] + node.Weight;           
                        }
                    }
                }
            } while (stack.Count > 0);

            foreach (int i in copieStack.Reverse())
            {
                Console.Write(weights[i] + " ");
            }

            for (int i = 1; i < weights.Length; i++)
            {
                if (weights[i] != INFI && weights[i]>weights[i-1])
                {
                    longestPath.Add(i);
                } 
            }

            Console.WriteLine();
            Console.WriteLine("The longest path is : ");
            foreach (int i in longestPath)
            {
                Console.Write(weights[i] + " ");
            }
        }

        //Solution 2
        public void CalculateLongestPathWithRecursiveWay(int s)
        {
            int[] weights = new int[V];

            for (var i = 0; i < weights.Length; i++)
            {
                weights[i] = INFI;
            }
            
            weights[s] = 0;
            int src = s;
            List<int>[] paths = new List<int>[adjListArray[src].Count];
            FindLongestPath(src, weights, paths);

            Console.WriteLine(WeightMax);
        }

        public void FindLongestPath(int src, int[] weights, List<int>[] paths)
        {
            int index = 0;
            foreach (Node node in adjListArray[src])
            {
                paths[index].Add(src);
                int sourceNum = 0;
                if (weights[src] + node.Weight > weights[node.Num])
                {
                    weights[node.Num] = weights[src] + node.Weight;
                    if (WeightMax < weights[node.Num])
                        WeightMax = weights[node.Num];
                }

                sourceNum = node.Num;
                FindLongestPath(sourceNum, weights, paths);
                index++;
            }           
        }
    }
}
