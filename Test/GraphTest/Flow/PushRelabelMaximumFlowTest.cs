using CSharpAlgo.Graph.Flow;
using NUnit.Framework;

namespace GraphTest.Flow
{
    [TestFixture]
    public class PushRelabelMaximumFlowTest
    {
        [Test]
        public void GetMaximunFlow_When_Give_Cost_Graph()
        {
            // Arrange
            int source = 0;
            int destination = 5;

            int[,] matrix = new int[6, 6]{{0, 16, 13, 0, 0, 0},
                                          {0, 0, 10, 12, 0, 0},
                                          {0, 4, 0, 0, 14, 0},
                                          {0, 0, 9, 0, 0, 20},
                                          {0, 0, 0, 7, 0, 4},
                                          {0, 0, 0, 0, 0, 0}};

            // Act
            var maxFlow = PushRelabelToFrontMaximumFlow.GetMaximunFlow(matrix, source, destination);

            // Assert
            Assert.AreEqual(23, maxFlow);
        }
    }
}
