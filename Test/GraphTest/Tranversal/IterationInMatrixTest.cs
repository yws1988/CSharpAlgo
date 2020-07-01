namespace CSharpAlgo.GraphTest.Traversal
{
    using CSharpAlgo.Graph.Traversal;
    using NUnit.Framework;

    [TestFixture]
    public class IterationInMatrixTest
    {
        [Test]
        public void FromTopToBottom_Returns_Path()
        {
            // Arrange
            int[,] matrix = new int[3, 3]
            {
                {1, 2, 3 },
                {6, 5, 4 },
                {7, 8, 9 }
            };

            // Act
            var result = IterationInMatrix.FromTopToBottom(matrix);

            // Assert
            Assert.AreEqual(">>v<<v>>", result.Item1);
        }

        [Test]
        public void FromBottomToTop_Returns_Path()
        {
            // Arrange
            int[,] matrix = new int[3, 3]
            {
                {1, 2, 3 },
                {6, 5, 4 },
                {7, 8, 9 }
            };

            // Act
            var result = IterationInMatrix.FromBottomToTop(matrix, -1);

            // Assert
            Assert.AreEqual("<<^>>^<<", result.Item1);
        }
    }
}
