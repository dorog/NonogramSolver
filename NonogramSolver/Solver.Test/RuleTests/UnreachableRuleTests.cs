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
            uint number = 5;
            int[] fields = new int[] { 0, 1, 1, 1, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, 0 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoChangesFullTest()
        {
            uint number = 5;
            int[] fields = new int[] { 1, 1, 1, 1, 1 };
            int[] expected = new int[] { 1, 1, 1, 1, 1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoUnreachableEndTest()
        {
            uint number = 5;
            int[] fields = new int[] { 0, 0, 1, 1, 1 };
            int[] expected = new int[] { 0, 0, 1, 1, 1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoUnreachableStartTest()
        {
            uint number = 5;
            int[] fields = new int[] { 1, 1, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 0 ,0  };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableEndTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 1, 1, 0, 0, 0 };
            int[] expected = new int[] { 0, 1, 1, 0, -1, -1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableStartTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 0, 0, 1, 1, 0 };
            int[] expected = new int[] { -1, -1, 0, 1, 1, 0 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableStartAndEndTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 0, 1, 1, 0, 0 };
            int[] expected = new int[] { -1, 0, 1, 1, 0, -1 };

            var results = unreachableRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
