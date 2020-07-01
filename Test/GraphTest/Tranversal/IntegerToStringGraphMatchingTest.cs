namespace CSharpAlgo.GraphTest.Traversal
{
    using CSharpAlgo.Graph.Traversal.DFS;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using static Utils.Helper.DictionaryHelper;

    [TestFixture]
    public class IntegerToStringGraphMatchingTest
    {
        [Test]
        public void Returns_Number_To_String_Matching_With_OldGraph_And_NewGraph_Four_Vertexes()
        {
            // Arrange
            var edgesOfOldGraph = new List<(int, int)>{
                ( 0, 1), ( 0, 3), ( 0, 2),( 1, 3)
            };

            var oldGraph = Enumerable.Range(0, 14).Select(s => new HashSet<int>()).ToArray();
            foreach (var e in edgesOfOldGraph)
            {
                oldGraph[e.Item1].Add(e.Item2);
                oldGraph[e.Item2].Add(e.Item1);
            }

            var newGraph = new RDictionary<string, HashSet<string>>();
            var edgesOfNewGraph = new List<(string, string)>()
            {
                ("C","D"),
                ("D","A"),
                ("C","A"),
                ("B","C")
            };

            foreach (var edge in edgesOfNewGraph)
            {
                newGraph[edge.Item1].Add(edge.Item2);
                newGraph[edge.Item2].Add(edge.Item1);
            }

            // Act
            var matches = IntegerToStringGraphMatching.GetMatches(oldGraph, newGraph);

            // Assert
            Assert.AreEqual("C", matches[0]);
            Assert.AreEqual("D", matches[1]);
            Assert.AreEqual("B", matches[2]);
            Assert.AreEqual("A", matches[3]);
        }

        [Test]
        public void Returns_Number_To_String_Matching_With_OldGraph_And_NewGraph_Fourteen_Vertexes()
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
            var edgesOfNewGraph = new List<(string, string)>()
            {
                ("Earaindir","Rithralas"),
                ("Hilad","Fioldor"),
                ("Delanduil","Rithralas"),
                ("Urarion","Elrebrimir"),
                ("Elrebrimir","Fioldor"),
                ("Eowul","Fioldor"),
                ("Beladrieng","Anaramir"),
                ("Urarion","Eowul"),
                ("Earaindir","Sanakil"),
                ("Delanduil","Isilmalad"),
                ("Earylas","Isilmalad"),
                ("Rithralas","Sanakil"),
                ("Unithral","Elrebrimir"),
                ("Earylas","Eowul"),
                ("Beladrieng","Hilad"),
                ("Isilmalad","Sanakil"),
                ("Unithral","Earylas"),
                ("Earaindir","Anaramir"),
                ("Unithral","Beladrieng"),
                ("Hilad","Anaramir"),
                ("Delanduil","Urarion")
            };

            foreach (var edge in edgesOfNewGraph)
            {
                newGraph[edge.Item1].Add(edge.Item2);
                newGraph[edge.Item2].Add(edge.Item1);
            }

            // Act
            var matches = IntegerToStringGraphMatching.GetMatches(oldGraph, newGraph);

            // Assert
            Assert.AreEqual("Delanduil", matches[0]);
            Assert.AreEqual("Unithral", matches[1]);
            Assert.AreEqual("Beladrieng", matches[2]);
            Assert.AreEqual("Hilad", matches[3]);
            Assert.AreEqual("Earaindir", matches[4]);
            Assert.AreEqual("Urarion", matches[5]);
            Assert.AreEqual("Anaramir", matches[6]);
        }
    }
}
