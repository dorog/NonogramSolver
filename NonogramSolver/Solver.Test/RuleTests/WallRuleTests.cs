using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class WallRuleTests
    {
        private readonly WallRule wallRule = new WallRule();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void NoWhiteOrEdgeTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, solid, unknown, solid, unknown };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteButEdgeStartTest()
        {
            int number = 4;
            FieldType[] fields = new FieldType[] { solid, unknown, solid, unknown, unknown };
            FieldType[] expected = new FieldType[] { solid, solid, solid, solid, unknown };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoWhiteButEdgeEndTest()
        {
            int number = 4;
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, solid };
            FieldType[] expected = new FieldType[] { unknown, solid, solid, solid, solid };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteButNoSolidTest()
        {
            int number = 2;
            FieldType[] fields = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidButNotNearTest()
        {
            int number = 2;
            FieldType[] fields = new FieldType[] { unknown, unknown, white, unknown, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, white, unknown, solid, unknown };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidRightSidePerfectTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, unknown, white, solid, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, white, solid, solid, solid };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidRightSideGreaterTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, unknown, white, solid, unknown, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, white, solid, solid, solid, unknown };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidLeftSidePerfectTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { solid, unknown, solid, white, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { solid, solid, solid, white, unknown, unknown, unknown };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void WhiteAndSolidLeftSideGreaterTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, white, unknown, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, solid, solid, solid, white, unknown, unknown, unknown, unknown };

            var results = wallRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
