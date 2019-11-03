using System;
using System.Linq;
using Graph.Base;

namespace Algorithmne
{
    public class KCore
    {
        public AdjacencyList AdjList { get; set; }

        public KCore(AdjacencyList adjList)
        {
            AdjList = adjList;
        }

        public bool DFSUtil(int start, int[] degrees, int k)
        {
            AdjList.Visited[start] = true;

            foreach (int i in AdjList.G[start])
            {
                if (degrees[start] < k)
                {
                    degrees[i]--;
                }

                if (!AdjList.Visited[i] && DFSUtil(i, degrees, k))
                {
                    degrees[start]--;
                }
            }

            return degrees[start] < k ? true : false;
        }

        public void Print(int k)
        {
            int v = AdjList.V;
            int startPoint = 0;
            bool hasKeyCore = false;
            int[] degrees = new int[v];

            int min = Int32.MaxValue;
            for (int i = 0; i < v; i++)
            {
                degrees[i] = AdjList.G[i].Count;
                if (degrees[i] < min)
                {
                    min = degrees[i];
                    startPoint = i;
                }
            }


            if (degrees[startPoint] < k)
            {
                DFSUtil(startPoint, degrees, k);
            }
            
            for (int i = 0; i < AdjList.G.Length; i++)
            {
                if (AdjList.Visited[i] == false)
                {
                    DFSUtil(i, degrees, k);
                }  
            }

            hasKeyCore = degrees.Any(s => s >= k);

            if (hasKeyCore)
            {
                for (int i = 0; i < v; i++)
                {
                    if (degrees[i] >= k)
                    {
                        Console.Write(i + " => ");
                        foreach (int m in AdjList.G[i])
                        {
                            if(degrees[m] >= k)
                            Console.Write(m + " => ");
                        }
                        Console.WriteLine();
                    }
                }
               
            }
            else
            {
                Console.WriteLine("Doesn't have "+ k + "Core Graph");
            }
        }
    }
}
