namespace DynamicProgrammingTest.Others
{
    using CSharpAlgo.DynamicProgramming.Other;
    using NUnit.Framework;


    public class NumOfSolutionsLimitedCoinChangeTest
    {
        [Test]
        public void GetNumOfSolutions_Returns_Expected_Num_Of_Solutions()
        {
            //Arrange
            int[] nums = { 3, 2, 1 };
            int[] values = { 1, 2, 3 };

            //Act
            var result = NumOfSolutionsLimitedCoinChange.GetNumOfSolutions(4, nums, values);

            //Assert
            Assert.AreEqual(3, result);
        }
    }
}
