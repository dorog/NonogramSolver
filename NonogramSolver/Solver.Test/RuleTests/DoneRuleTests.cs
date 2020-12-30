using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Complex.Impl;
using System.Collections.Generic;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class DoneRuleTests
    {
        private readonly DoneRule doneRule = new DoneRule();

        [TestMethod]
        public void OneAndNoEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            int[] fields = new int[] { 1, 1, 1, 1, 1 };
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneAndStartEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            int[] fields = new int[] { 0, 1, 1, 1, 1, 1 };
            int[] expected = new int[] { -1, 1, 1, 1, 1, 1 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneAndEndEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            int[] fields = new int[] { 1, 1, 1, 1, 1, 0 };
            int[] expected = new int[] { 1, 1, 1, 1, 1, -1 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneAndDoubleEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            int[] fields = new int[] { 0, 1, 1, 1, 1, 1, 0 };
            int[] expected = new int[] { -1, 1, 1, 1, 1, 1, -1 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreAndMiddleTest()
        {
            List<int> numbers = new List<int> { 2, 2 };
            int[] fields = new int[] { 1, 1, 0, 1, 1 };
            int[] expected = new int[] { 1, 1, -1, 1, 1 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreAndAllTest()
        {
            List<int> numbers = new List<int> { 2, 2 };
            int[] fields = new int[] { 0, 0, 1, 1, 0, 1, 1, 0 };
            int[] expected = new int[] { -1, -1, 1, 1, -1, 1, 1, -1 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotMatchStartTest()
        {
            List<int> numbers = new List<int> { 3, 2 };
            int[] fields = new int[] { 0, 0, 1, 1, 0, 1, 1, 0 };
            int[] expected = new int[] { 0, 0, 1, 1, 0, 1, 1, 0 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotMatchEndTest()
        {
            List<int> numbers = new List<int> { 2, 3 };
            int[] fields = new int[] { 0, 0, 1, 1, 0, 1, 1, 0 };
            int[] expected = new int[] { 0, 0, 1, 1, 0, 1, 1, 0 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotMatchMiddleTest()
        {
            List<int> numbers = new List<int> { 2, 1, 3 };
            int[] fields = new int[] { 0, 0, 1, 1, 0, 1, 0, 1, 1, 0 };
            int[] expected = new int[] { 0, 0, 1, 1, 0, 1, 0, 1, 1, 0 };

            var results = doneRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
