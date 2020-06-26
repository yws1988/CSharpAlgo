namespace CSharpAlgo.BitOperationTest
{
    using BitOperation;
    using NUnit.Framework;

    [TestFixture]
    public class AssignmentTaskWithMinumCostTest
    {
        [Test]
        public void GetMinimumCost_Returns_Minimum_Cost()
        {
            int[,] costs = new int[,]
            {
                {1, 3, 2 },
                {7, 5, 2 },
                {4, 3, 8 }
            };

            var cost = AssignmentTaskWithMinumCost.GetMinimumCost(costs);

            Assert.AreEqual(6, cost);
        }
    }
}
