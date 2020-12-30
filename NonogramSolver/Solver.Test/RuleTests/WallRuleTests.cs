using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class WallRuleTests
    {
        private readonly WallRule wallRule = new WallRule();

        [TestMethod]
        public void NoWhiteOrEdgeTest()
        {
            int number = 5;
            int[] fields = new int[] { 0, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 1, 0, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteButEdgeStartTest()
        {
            int number = 4;
            int[] fields = new int[] { 1, 0, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteButEdgeEndTest()
        {
            int number = 4;
            int[] fields = new int[] { 0, 1, 0, 1, 1 };
            int[] expected = new int[] { 0, 1, 1, 1, 1 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteButNoSolidTest()
        {
            int number = 2;
            int[] fields = new int[] { 0, 0, -1, 0, 0, 0 };
            int[] expected = new int[] { 0, 0, -1, 0, 0, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidButNotNearTest()
        {
            int number = 2;
            int[] fields = new int[] { 0, 0, -1, 0, 1, 0 };
            int[] expected = new int[] { 0, 0, -1, 0, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidRightSidePerfectTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 0, -1, 1, 0, 0 };
            int[] expected = new int[] { 0, 0, -1, 1, 1, 1 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidRightSideGreaterTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 0, -1, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 0, -1, 1, 1, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidLeftSidePerfectTest()
        {
            int number = 3;
            int[] fields = new int[] { 1, 0, 1, -1, 0, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, -1, 0, 0, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidLeftSideGreaterTest()
        {
            int number = 3;
            int[] fields = new int[] { 0, 1, 0, 1, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, -1, 0, 0, 0, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
