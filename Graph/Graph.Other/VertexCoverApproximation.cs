namespace Graph.Other
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Graph.Base;

    public class VertexCoverApproximation
    {
        public AdjacencyList AdjList;
        public int V;
        public List<int> Result = new List<int>();

        public VertexCoverApproximation(AdjacencyList adjList)
        {
            AdjList = adjList;
            V = AdjList.V;
        }

        public int GetMin()
        {
            for (int i = 0; i < V; i++)
            {
                if (AdjList[i].Count > 0)
                {
                    Result.Add(i);
                    int j = AdjList[i][0];
                    Result.Add(j);
                    foreach (int des in AdjList[i])
                    {
                        AdjList[des].Remove(i);
                    }
                    AdjList[i].Clear();

                    foreach (int des in AdjList[j])
                    {
                        AdjList[des].Remove(j);
                    }
                    AdjList[j].Clear();
                }
            }

            Result = Result.Take(Result.Count - 1).ToList();
            this.Print();

            return Result.Count;
        }


        public void Print()
        {
            Console.WriteLine(string.Join(",", this.Result.ToArray()));
        }
    }
}
