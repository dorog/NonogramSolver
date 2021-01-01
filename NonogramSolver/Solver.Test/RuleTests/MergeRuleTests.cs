using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Simple.Impl;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class MergeRuleTests
    {
        private readonly MergeRule mergeRule = new MergeRule();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;

        [TestMethod]
        public void NothingTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[5];
            FieldType[] expected = new FieldType[5];

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void FullTest()
        {
            int number = 5;
            FieldType[] fields = new FieldType[] { solid, unknown, unknown, unknown, solid };
            FieldType[] expected = new FieldType[] { solid, solid, solid, solid, solid };

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactMiddleTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, solid, solid, solid, unknown };

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactEndTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, unknown, solid };
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, solid, solid };

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void ExactStartTest()
        {
            int number = 3;
            FieldType[] fields = new FieldType[] { solid, unknown, solid, unknown, unknown };
            FieldType[] expected = new FieldType[] { solid, solid, solid, unknown, unknown };

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessMiddleTest()
        {
            int number = 4;
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, solid, solid, solid, unknown };

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessEndTest()
        {
            int number = 4;
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, unknown, solid };
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, solid, solid };

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void LessStartTest()
        {
            int number = 4;
            FieldType[] fields = new FieldType[] { solid, unknown, solid, unknown, unknown };
            FieldType[] expected = new FieldType[] { solid, solid, solid, unknown, unknown };

            var results = mergeRule.Apply(number, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
