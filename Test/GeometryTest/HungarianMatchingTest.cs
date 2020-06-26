namespace CSharpAlgo.GeometryTest
{
    using Maths;
    using NUnit.Framework;

    public class HungarianMatchingTest
    {
        [Test]
        public void GetAssignmentsWithMinimunCost_Get_JobAssignment_Array_To_Get_MinimumCost()
        {
            var costMartrix = new int[,]
            {
                {9, 2, 7, 8},
                {6, 4, 3, 7},
                {5, 8, 1, 8},
                {7, 6, 9, 4}
            };

            var jobAssignments = HungarianMatching.GetAssignmentsWithMinimunCost(costMartrix);

            CollectionAssert.AreEqual(new int[]{1, 0, 2, 3}, jobAssignments);
        }
    }
}
