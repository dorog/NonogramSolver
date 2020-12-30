using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class UnreachableRuleTests
    {
        private readonly UnreachableRule unreachableRule = new UnreachableRule();

        [TestMethod]
        public void NoUnreachableMiddleTest()
        {
            int number = 5;
            int[] fields = new int[] { 0, 1, 1, 1, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, 0 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoChangesFullTest()
        {
            int number = 5;
            int[] fields = new int[] { 1, 1, 1, 1, 1 };
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoUnreachableEndTest()
        {
            int number = 5;
            int[] fields = new int[] { 0, 0, 1, 1, 1 };
            int[] expected = new int[] { 0, 0, 1, 1, 1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoUnreachableStartTest()
        {
            int number = 5;
            int[] fields = new int[] { 1, 1, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 0 ,0  };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableEndTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 1, 1, 0, 0, 0 };
            int[] expected = new int[] { 0, 1, 1, 0, -1, -1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableStartTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 0, 0, 1, 1, 0 };
            int[] expected = new int[] { -1, -1, 0, 1, 1, 0 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableStartAndEndTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 0, 1, 1, 0, 0 };
            int[] expected = new int[] { -1, 0, 1, 1, 0, -1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
