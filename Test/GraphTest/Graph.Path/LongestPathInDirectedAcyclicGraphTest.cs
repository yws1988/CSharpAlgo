using Algorithmne.Graph.Graph.Path.LongestPath;
using DataStructure.Models;
using NUnit.Framework;
using System.Linq;
using Utils.Graph.Helper;

namespace GraphTest
{
    [TestFixture]
    public class LongestPathInDirectedAcyclicGraphTest
    {
        [Test]
        public void GetLongestPath_Returns_LongestPath_With_ListGraph_And_Source_Vertix()
        {
            // Arrange
            var graph = GraphBuilderHelper.CreateListArray<EdgeNode>(6);

            graph[0].Add(new EdgeNode(1, 3));
            graph[1].Add(new EdgeNode(2, 4));
            graph[1].Add(new EdgeNode(5, 2));
            graph[5].Add(new EdgeNode(3, 6));
            graph[5].Add(new EdgeNode(4, 5));

            //  Act
            int[] parents;
            int longestPath = LongestPathInDirectedAcyclicGraph.GetLongestPath(graph, 0, out parents).Max();

            // Assert
            
            Assert.AreEqual(11, longestPath);
            CollectionAssert.AreEqual(new int[]{ -1, 0, 1, 5, 5, 1 }, parents);
        }
    }
}
