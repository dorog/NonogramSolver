using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Complex.Impl;
using System.Collections.Generic;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class TooSmallSpaceRuleTests
    {
        private readonly TooSmallSpaceRule tooSmallSpaceRule = new TooSmallSpaceRule();

        [TestMethod]
        public void NoTooSmallSpaceWithOneNumberTest()
        {
            List<int> numbers = new List<int> { 2 };
            int[] fields = new int[] { 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, 0 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoTooSmallSpaceWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 3, 2, 5 };
            int[] fields = new int[] { 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, 0 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithOneNumberStartTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { -1, -1, -1, 0, 0, 0, -1, 0, 0, 0, 0 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithOneNumberMiddleTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 0,  0, -1, 0, 0, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { 0, 0, 0, -1, -1, -1, -1, 0, 0, 0, 0 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithOneNumberEndTest()
        {
            List<int> numbers = new List<int> { 3 };
            int[] fields = new int[] { 0, 0, 0, -1, 0, 0, 0, 0 -1, 0, 0 };
            int[] expected = new int[] { 0, 0, 0, -1, 0, 0, 0, 0 - 1, -1, -1 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithMoreNumberStartTest()
        {
            List<int> numbers = new List<int> { 7, 6, 5, 4, 3 };
            int[] fields = new int[] { 0, 0, -1, 0, 0, 0, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { -1, -1, -1, 0, 0, 0, -1, 0, 0, 0, 0 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithMoreNumberMiddleTest()
        {
            List<int> numbers = new List<int> { 3, 4, 5, 6 };
            int[] fields = new int[] { 0, 0, 0, -1, 0, 0, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { 0, 0, 0, -1, -1, -1, -1, 0, 0, 0, 0 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithMoreNumberEndTest()
        {
            List<int> numbers = new List<int> { 5, 4, 3 };
            int[] fields = new int[] { 0, 0, 0, -1, 0, 0, 0, 0 - 1, 0, 0 };
            int[] expected = new int[] { 0, 0, 0, -1, 0, 0, 0, 0 - 1, -1, -1 };

            var results = tooSmallSpaceRule.Check(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
