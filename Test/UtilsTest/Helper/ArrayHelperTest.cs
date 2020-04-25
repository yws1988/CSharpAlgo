namespace UtilsTest.Helper
{
    using NUnit.Framework;
    using Utils.Helper;

    [TestFixture]
    public class ArrayHelperTest
    {
        [Test]
        public void Copy_Returns_New_Two_Dimension_Array()
        {
            var array = new int[2][] { new int[]{ 1, 2 }, new int[]{ 3, 4, 5 } };

            var result = ArrayHelper.Clone(array);

            CollectionAssert.AreEqual(array, result);
        }
    }
}
