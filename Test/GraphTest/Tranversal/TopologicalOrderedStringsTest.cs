namespace IsogradTest
{
    using CSharpAlgo.Graph.Tranversal.DFS;
    using NUnit.Framework;
    using System;
    using System.IO;
    using Utils;

    [TestFixture]
    public class TopologicalOrderedStringsTest
    {
        [Test]
        public void TopologicalOrderedStrings_Returns_One_Possible_Topological_Sorting_Strings()
        {
            // Arrange
            IO.Reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/IOFiles/TopologicalOrderedStringsInput1.txt");
            var ns = IO.ReadIntArray();
            int n = ns[0];
            int m = ns[1];
            var strs = IO.ReadStringMatrix(m);

            // Act
            var result = TopologicalOrderedStrings.GetTopologicalOrder(strs, n);

            // Assert
            Assert.AreEqual("fraise mojito club-mate pamplemousse grenadine", result);
        }

        [Test]
        public void TopologicalOrderedStrings_Returns_KO()
        {
            // Arrange
            IO.Reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/IOFiles/TopologicalOrderedStringsInput2.txt");
            var ns = IO.ReadIntArray();
            int n = ns[0];
            int m = ns[1];
            var strs = IO.ReadStringMatrix(m);

            // Act
            var result = TopologicalOrderedStrings.GetTopologicalOrder(strs, n);

            // Assert
            Assert.AreEqual("KO", result);
        }
    }
}
