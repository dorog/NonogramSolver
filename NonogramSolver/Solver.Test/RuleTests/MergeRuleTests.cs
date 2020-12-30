using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Simple.Impl;
using System.Collections.Generic;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class MergeRuleTests
    {
        private readonly MergeRule mergeRule = new MergeRule();

        [TestMethod]
        public void NothingTest()
        {
            int number = 5;
            int[] fields = new int[5];
            int[] expected = new int[5];

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullTest()
        {
            int number = 5;
            int[] fields = new int[] { 1, 0, 0, 0, 1 };
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactMiddleTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactEndTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 0, 1, 0, 1 };
            int[] expected = new int[] { 0, 0, 1, 1, 1 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactStartTest()
        {
            int number = 3;
            int[] fields = new int[] { 1, 0, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 0, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessMiddleTest()
        {
            int number = 4;
            int[] fields = new int[] { 0, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessEndTest()
        {
            int number = 4;
            int[] fields = new int[] { 0, 0, 1, 0, 1 };
            int[] expected = new int[] { 0, 0, 1, 1, 1 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessStartTest()
        {
            int number = 4;
            int[] fields = new int[] { 1, 0, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 0, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
