/*
 * Give a graph, every time delete the vetex with maximum degrees,
 * how many vetexes should be deleted so that the graph has no edges.
 */ 
namespace CSharpAlgo.Excercise.Excercises.Graph.SegmentTree
{
    using System.Collections.Generic;
    using System.Linq;
    using CSharpAlgo.Graph.Tree;

    public class NumOfVetexToBeDeletedGraphNoConnections
    {
        public static int GetNumOfVetexToBeDeleted(HashSet<int>[] graph)
        {
            var arr = graph.Select(s => s.Count).ToArray();

            var segmentTree = new SegmentTreeCompare(arr, (node1, node2) => {
                if (node1 == null) return node2;
                if (node2 == null) return node1;
                return node1.CompareTo(node2) > 0 ? node1 : node2;
            });

            int numOfVetex = 0;

            while (segmentTree.Tree[0].Value > 0)
            {
                numOfVetex++;
                var node = segmentTree.Tree[0];

                int u = node.Index;
                var neighbours = graph[u];

                foreach (int v in neighbours)
                {
                    graph[v].Remove(u);
                    segmentTree.Update(v, graph[v].Count);
                }

                graph[u].Clear();
                segmentTree.Update(u, 0);
            }

            return numOfVetex;
        }
     }
}
