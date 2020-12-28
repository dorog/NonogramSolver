using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Simple.Impl;
using System.Collections.Generic;

namespace Solver.Test
{
    [TestClass]
    public class MergeRuleTests
    {
        private readonly MergeRule mergeRule = new MergeRule();

        [TestMethod]
        public void NothingTest()
        {
            uint number = 5;
            int[] fields = new int[5];
            int[] expected = new int[5];

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullTest()
        {
            uint number = 5;
            int[] fields = new int[] { 1, 0, 0, 0, 1 };
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactMiddleTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactEndTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 0, 1, 0, 1 };
            int[] expected = new int[] { 0, 0, 1, 1, 1 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactStartTest()
        {
            uint number = 3;
            int[] fields = new int[] { 1, 0, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 0, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessMiddleTest()
        {
            uint number = 4;
            int[] fields = new int[] { 0, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessEndTest()
        {
            uint number = 4;
            int[] fields = new int[] { 0, 0, 1, 0, 1 };
            int[] expected = new int[] { 0, 0, 1, 1, 1 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessStartTest()
        {
            uint number = 4;
            int[] fields = new int[] { 1, 0, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 0, 0 };

            var results = mergeRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
