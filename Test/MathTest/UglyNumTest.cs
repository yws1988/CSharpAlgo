namespace MathTest
{
    using CSharpAlgo.Maths;
    using NUnit.Framework;

    [TestFixture]
    public class UglyNumTest
    {
        [Test]
        public void Nth_UglyNum()
        {
            int n = 6;

            var result = UglyNum.Get(n);

            Assert.AreEqual(6, result);
        }
    }
}
