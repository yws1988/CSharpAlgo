namespace UtilsTest
{
    using Collection.Helper;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class CollectionHelperTest
    {
        [Test]
        public void GetPermutations_Returns_Expected_Permutations()
        {
            var list = new List<int> { 1, 2, 3 };

            var result = CollectionHelper.GetPermutations(list, 3);

            // {1,2,3} {1,3,2} {2,1,3} {2,3,1} {3,1,2} {3,2,1}
            Assert.AreEqual(6, result.Count());
        }

        [Test]
        public void GetCombinations_Returns_Expected_Combinations()
        {
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 4, 5 };
            var list3 = new List<int> { 6, 7 };

            var result = CollectionHelper.GetCombinations(new List<List<int>> { list1, list2, list3});

            // {1,4,6} {1,4,7} {2,4,6}...
            Assert.AreEqual(12, result.Count());
        }
    }
}
