using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Rules.Complex.Impl;
using System.Collections.Generic;

namespace Solver.Test.RuleTests.ComplexRuleTests
{
    [TestClass]
    public class TooSmallSpaceRuleTests
    {
        private readonly TooSmallSpaceRule tooSmallSpaceRule = new TooSmallSpaceRule();

        private readonly FieldType unknown = FieldType.Unknown;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void NoTooSmallSpaceWithOneNumberTest()
        {
            List<int> numbers = new List<int> { 2 };
            FieldType[] fields = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void NoTooSmallSpaceWithMoreNumberTest()
        {
            List<int> numbers = new List<int> { 3, 2, 5 };
            FieldType[] fields = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithOneNumberStartTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { white, white, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithOneNumberMiddleTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown,  unknown, white, unknown, unknown, white, unknown, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, white, white, white, white, unknown, unknown, unknown, unknown };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithOneNumberEndTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, unknown, white, white, white };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithMoreNumberStartTest()
        {
            List<int> numbers = new List<int> { 7, 6, 5, 4, 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { white, white, white, unknown, unknown, unknown, white, unknown, unknown, unknown, unknown };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithMoreNumberMiddleTest()
        {
            List<int> numbers = new List<int> { 3, 4, 5, 6 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, white, unknown, unknown, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, white, white, white, white, unknown, unknown, unknown, unknown };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TooSmallSpaceWithMoreNumberEndTest()
        {
            List<int> numbers = new List<int> { 5, 4, 3 };
            FieldType[] fields = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, unknown, white, unknown, unknown };
            FieldType[] expected = new FieldType[] { unknown, unknown, unknown, white, unknown, unknown, unknown, white, white, white };

            var results = tooSmallSpaceRule.Apply(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
