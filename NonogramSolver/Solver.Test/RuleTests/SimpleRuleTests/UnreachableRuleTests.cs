using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests.SimpleRuleTests
{
    [TestClass]
    public class UnreachableRuleTests
    {
        private readonly UnreachableRule unreachableRule = new UnreachableRule();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void NoUnreachableMiddleTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, solid, solid, solid, unknown };

            var results = unreachableRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoChangesFullTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[] { solid, solid, solid, solid, solid };
            FieldType[] expected = new FieldType[] { solid, solid, solid, solid, solid };

            var results = unreachableRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoUnreachableEndTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, solid, solid };
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, solid, solid };

            var results = unreachableRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoUnreachableStartTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[] { solid, solid, solid, unknown, unknown };
            FieldType[] expected = new FieldType[] { solid, solid, solid, unknown ,unknown  };

            var results = unreachableRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableEndTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, solid, solid, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, solid, solid, unknown, white, white };

            var results = unreachableRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableStartTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { white, white, unknown, solid, solid, unknown };

            var results = unreachableRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void UnreachableStartAndEndTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, solid, unknown, unknown };
            FieldType[] expected = new FieldType[] { white, unknown, solid, solid, unknown, white };

            var results = unreachableRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
