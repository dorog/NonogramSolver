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
            uint number = 5;
            int[] fields = new int[] { 0, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 1, 0, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteButEdgeStartTest()
        {
            uint number = 4;
            int[] fields = new int[] { 1, 0, 1, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteButEdgeEndTest()
        {
            uint number = 4;
            int[] fields = new int[] { 0, 1, 0, 1, 1 };
            int[] expected = new int[] { 0, 1, 1, 1, 1 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteButNoSolidTest()
        {
            uint number = 2;
            int[] fields = new int[] { 0, 0, -1, 0, 0, 0 };
            int[] expected = new int[] { 0, 0, -1, 0, 0, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidButNotNearTest()
        {
            uint number = 2;
            int[] fields = new int[] { 0, 0, -1, 0, 1, 0 };
            int[] expected = new int[] { 0, 0, -1, 0, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidRightSidePerfectTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 0, -1, 1, 0, 0 };
            int[] expected = new int[] { 0, 0, -1, 1, 1, 1 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidRightSideGreaterTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 0, -1, 1, 0, 1, 0 };
            int[] expected = new int[] { 0, 0, -1, 1, 1, 1, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidLeftSidePerfectTest()
        {
            uint number = 3;
            int[] fields = new int[] { 1, 0, 1, -1, 0, 0, 0 };
            int[] expected = new int[] { 1, 1, 1, -1, 0, 0, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidLeftSideGreaterTest()
        {
            uint number = 3;
            int[] fields = new int[] { 0, 1, 0, 1, -1, 0, 0, 0, 0 };
            int[] expected = new int[] { 0, 1, 1, 1, -1, 0, 0, 0, 0 };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
