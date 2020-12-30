using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Complex.Impl;
using System.Collections.Generic;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class SummRuleTests
    {
        private readonly SummRule summRule = new SummRule();

        [TestMethod]
        public void FullWithOneNumberTest()
        {
            List<int> numbers = new List<int>{ 5 };
            int[] fields = new int[5];
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullWithTwoNumberTest()
        {
            List<int> numbers = new List<int> { 2, 2 };
            int[] fields = new int[5];
            int[] expected = new int[] { 1, 1, -1, 1, 1 };

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 1, 1, 1 };
            int[] fields = new int[5];
            int[] expected = new int[] { 1, -1, 1, -1, 1 };

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithOneNumberTest()
        {
            List<int> numbers = new List<int> { 4 };
            int[] fields = new int[5];
            int[] expected = new int[5];

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithTwoNumberTest()
        {
            List<int> numbers = new List<int> { 2, 1 };
            int[] fields = new int[5];
            int[] expected = new int[5];

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotFullWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 2, 1, 1 };
            int[] fields = new int[7];
            int[] expected = new int[7];

            var results = summRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
