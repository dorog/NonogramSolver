using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Complex.Impl;
using System.Collections.Generic;

namespace Solver.Test
{
    [TestClass]
    public class SummRuleTests
    {
        private readonly SummRule summRule = new SummRule();

        [TestMethod]
        public void FullWithOneNumberTest()
        {
            List<uint> numbers = new List<uint>{ 5 };
            int[] fields = new int[5];
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullWithTwoNumberTest()
        {
            List<uint> numbers = new List<uint> { 2, 2 };
            int[] fields = new int[5];
            int[] expected = new int[] { 1, 1, -1, 1, 1 };

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullWithMoreNumberTest()
        {
            List<uint> numbers = new List<uint> { 1, 1, 1 };
            int[] fields = new int[5];
            int[] expected = new int[] { 1, -1, 1, -1, 1 };

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithOneNumberTest()
        {
            List<uint> numbers = new List<uint> { 4 };
            int[] fields = new int[5];
            int[] expected = new int[5];

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithTwoNumberTest()
        {
            List<uint> numbers = new List<uint> { 2, 1 };
            int[] fields = new int[5];
            int[] expected = new int[5];

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithMoreNumberTest()
        {
            List<uint> numbers = new List<uint> { 2, 1, 1 };
            int[] fields = new int[7];
            int[] expected = new int[7];

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
