using Graph.Cycle;
using NUnit.Framework;
using Utils.Graph.Helper;

namespace GraphTest
{
    [TestFixture]
    public class CycleDirectedGraphTest
    {
        [Test]
        public void CycleDirectedGraph_Returns_True()
        {
            // Arrange
            var graph = GraphBuilderHelper.CreateListArray(6);

            graph[0].Add(1);
            graph[0].Add(2);
            graph[1].Add(2);
            graph[2].Add(0);
            graph[2].Add(3);

            //  Act
            bool result = CycleDirectedGraph.DoesGraphContainsCycle(graph);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CycleDirectedGraph_Returns_False()
        {
            // Arrange
            var graph = GraphBuilderHelper.CreateListArray(5);

            graph[0].Add(1);
            graph[0].Add(2);
            graph[3].Add(0);
            graph[4].Add(0);

            //  Act
            bool result = CycleDirectedGraph.DoesGraphContainsCycle(graph);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
