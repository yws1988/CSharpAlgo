namespace GraphTest.Tranversal
{
    using CSharpAlgo.Graph.Tranversal.DFS;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using static Utils.Helper.DictionaryHelper;

    [TestFixture]
    public class IntegerToStringGraphMatchingTest
    {
        public void Returns_Number_To_String_Matching_With_OldGraph_And_NewGraph()
        {
            // Arrange
            var edgesOfOldGraph = new List<(int, int)>{
                ( 0, 5), ( 0, 9), ( 0, 12),( 1, 10), ( 1, 2), ( 1, 7),
                ( 2, 3), ( 2, 6), ( 3, 6), ( 3, 11), ( 4, 12), ( 4, 6),
                ( 4, 13), ( 5, 8), ( 5, 10), ( 7, 8), ( 7, 9),
                ( 8, 11), ( 9, 13), ( 10, 11), ( 12, 13)
            };

            var oldGraph = Enumerable.Range(0, 14).Select(s => new HashSet<int>()).ToArray();
            foreach (var e in edgesOfOldGraph)
            {
                oldGraph[e.Item1].Add(e.Item2);
                oldGraph[e.Item2].Add(e.Item1);
            }

            var newGraph = new RDictionary<string, HashSet<string>>();
            var edgesOfOldGraph = new List<()>
            for (int i = 0; i < 21; i++)
            {
                newGraph[edge[0]].Add(edge[1]);
                newGraph[edge[1]].Add(edge[0]);
            }

            // Act
            var matches = IntegerToStringGraphMatching.GetMatches(oldGraph, newGraph);
        }
    }
}
