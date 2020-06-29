namespace MathTest
{
    using CSharpAlgo.Maths;
    using NUnit.Framework;
    using Utils.Helper.Math;

    [TestFixture]
    public class HungarianMatchingTest
    {
        [Test]
        public void Returns_The_Lowest_Costs_With_Positive_Costs_Matrix()
        {
            var costMatrix = new int[,]
            {
                {5, 2, 3, 9 },
                {6, 4, 5, 2 },
                {3, 7, 2, 6 },
                {10, 1, 4, 5}
            };

            var result = HungarianMatching.GetAssignmentsWithMinimunCost(costMatrix);

            CollectionAssert.AreEqual(new int[] { 2, 3, 0, 1 }, result);
        }

        [Test]
        public void Returns_The_Lowest_Costs_With_Negative_Costs_Matrix1()
        {
            var costMatrix = new int[,]
            {
                {5, 2, 3, 9 },
                {6, 4, 5, 2 },
                {3, 7, 2, 6 },
                {10, 1, 4, 5}
            };

            var maxCostMatrix = MatrixHelper.GetMaxMatrixForHungarianMatching(costMatrix, 10);

            var result = HungarianMatching.GetAssignmentsWithMinimunCost(maxCostMatrix);

            CollectionAssert.AreEqual(new int[] { 3, 2, 1, 0 }, result);
        }

        [Test]
        public void Returns_The_Lowest_Costs_With_Negative_Costs_Matrix2()
        {
            var costMatrix = new int[,]
            {
                {1, 0, 0 },
                {0, 0, 0 },
                {0, 1, 0 }
            };

            var maxCostMatrix = MatrixHelper.GetMaxMatrixForHungarianMatching(costMatrix, 1);

            var result = HungarianMatching.GetAssignmentsWithMinimunCost(maxCostMatrix);

            CollectionAssert.AreEqual(new int[] { 0, 2, 1 }, result);
        }
    }
}
