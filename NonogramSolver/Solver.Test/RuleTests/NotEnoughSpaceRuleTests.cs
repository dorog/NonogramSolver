using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class NotEnoughSpaceRuleTests
    {
        private readonly NotEnoughSpaceRule notEnoughSpaceRule = new NotEnoughSpaceRule();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void NoLittlePlaceTest()
        {
            int number = 1;
            FieldType[] fields = new FieldType[] { unknown, white, unknown, unknown, white, unknown };
            FieldType[] expected = new FieldType[] { unknown, white, unknown, unknown, white, unknown };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void StartLittlePlaceTest()
        {
            int number = 2;
            FieldType[] fields = new FieldType[] { unknown, white, unknown, unknown, white, unknown, unknown };
            FieldType[] expected = new FieldType[] { white, white, unknown, unknown, white, unknown, unknown };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void EndLittlePlaceTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, unknown, unknown, white, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, unknown, unknown, white, white, white };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MiddleLittlePlaceTest()
        {
            int number = 2;
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, white, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, white, white, white, unknown, unknown };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void AllLittlePlaceTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, white, solid, solid, solid, solid, solid, white, unknown, unknown };
            FieldType[] expected = new FieldType[] { white, white, white, white, white, white, solid, solid, solid, solid, solid, white, white, white };

            var results = notEnoughSpaceRule.Check(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
