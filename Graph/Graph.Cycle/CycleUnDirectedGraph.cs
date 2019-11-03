﻿namespace Graph.Cycle
{
    using System;
    using Graph.Base;

    public class CycleUnDirectedGraph
    {
        public static AdjacencyList AdjList { get; set; }

        public static void DetectCycle(AdjacencyList adjList)
        {
            AdjList = adjList;

            if (HasCycle())
            {
                Console.WriteLine("There is a cyle");
            }
            else
            {
                Console.WriteLine("No cycle");
            }
            
        }

        static bool HasCycle()
        {
            int v = AdjList.V;
            bool[] vs = new bool[v];

            for (int i = 0; i < v; i++)
            {
                if (!vs[i] && DFSUtil(i, i, vs))
                {
                    return true;
                }
            }
            return false;
        }

        static bool DFSUtil(int i, int parent, bool[] vs)
        {
            vs[i] = true;

            foreach (int child in AdjList[i])
            {
                if (child!=parent && vs[child])
                {
                    return true;
                }

                if (!vs[child] && DFSUtil(child, i, vs))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
