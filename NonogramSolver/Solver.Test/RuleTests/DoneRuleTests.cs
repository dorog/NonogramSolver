using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Complex.Impl;
using System.Collections.Generic;

namespace Solver.Test.RuleTests
{
    [TestClass]
    public class DoneRuleTests
    {
        private readonly DoneRule doneRule = new DoneRule();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void OneAndNoEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            FieldType[] fields = new FieldType[] { solid, solid, solid, solid, solid };
            FieldType[] expected = new FieldType[] { solid, solid, solid, solid, solid };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneAndStartEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            FieldType[] fields = new FieldType[] { white, solid, solid, solid, solid, solid };
            FieldType[] expected = new FieldType[] { white, solid, solid, solid, solid, solid };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneAndEndEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            FieldType[] fields = new FieldType[] { solid, solid, solid, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { solid, solid, solid, solid, solid, white };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneAndDoubleEdgeTest()
        {
            List<int> numbers = new List<int> { 5 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { white, solid, solid, solid, solid, solid, white };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreAndMiddleTest()
        {
            List<int> numbers = new List<int> { 2, 2 };
            FieldType[] fields = new FieldType[] { solid, solid, unknown, solid, solid };
            FieldType[] expected = new FieldType[] { solid, solid, white, solid, solid };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreAndAllTest()
        {
            List<int> numbers = new List<int> { 2, 2 };
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, solid, unknown, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { white, white, solid, solid, white, solid, solid, white };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotMatchStartTest()
        {
            List<int> numbers = new List<int> { 3, 2 };
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, solid, unknown, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, solid, unknown, solid, solid, unknown };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotMatchEndTest()
        {
            List<int> numbers = new List<int> { 2, 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, solid, unknown, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, solid, unknown, solid, solid, unknown };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NotMatchMiddleTest()
        {
            List<int> numbers = new List<int> { 2, 1, 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, solid, solid, unknown, solid, unknown, solid, solid, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, solid, solid, unknown, solid, unknown, solid, solid, unknown };

            var results = doneRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
