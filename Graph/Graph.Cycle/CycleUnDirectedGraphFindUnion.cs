using System;
using Graph.Base;

namespace Graph.Cycle
{
    public class CycleUnDirectedGraphFindUnion
    {
        public GraphVertexEdge GraphVertexEdge { get; set; }

        public CycleUnDirectedGraphFindUnion(GraphVertexEdge graphVertexEdge)
        {
            GraphVertexEdge = graphVertexEdge;
        }

        public int Find(int i, int[] parents)
        {
            if (parents[i] == -1)
                return i;

            return Find(parents[i], parents);
        }

        public void Union(int src, int des, int[] parents)
        {
            parents[src] = des;
        }

        public void DetectCycle()
        {
            if (HasCycle())
            {
                Console.WriteLine("There is a cyle");
            }
            else
            {
                Console.WriteLine("No cycle");
            }
        }

        public bool HasCycle()
        {
            int[] parents = new int[GraphVertexEdge.V];
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = -1;
            }

            foreach (Edge edge in GraphVertexEdge.edges)
            {
                int parentX = Find(edge.Src, parents);
                int parentY = Find(edge.Des, parents);

                if (parentX == parentY)
                    return true;

                Union(parentX, parentY, parents);
            }

            return false;
        }
    }
}
