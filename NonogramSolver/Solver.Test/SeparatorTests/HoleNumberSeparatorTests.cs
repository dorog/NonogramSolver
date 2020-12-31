using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class HoleNumberSeparatorTests
    {
        private readonly HoleNumberSeparator holeNumberSeparator = new HoleNumberSeparator();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;
        private readonly FieldType white = FieldType.White;

        [TestMethod]
        public void OneNumberNoWhiteTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, unknown };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 5
                }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberNoWhiteTest()
        {
            List<int> numbers = new List<int> { 3, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, solid };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreNumberNoWhiteTest()
        {
            List<int> numbers = new List<int> { 3, 1, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, solid, unknown, solid };
            Range[] expected = new Range[]
            {
                null,
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneNumberOneWhiteStartTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { white, solid, solid, solid, unknown, unknown };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 1,
                    End = 5
                }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneNumberOneWhiteEndTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, white };
            Range[] expected = new Range[]
            {
                new Range()
                {
                    Start = 0,
                    End = 4
                }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void OneNumberOneWhiteMiddleTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, white, unknown };
            Range[] expected = new Range[]
            {
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberOneWhiteMiddleTest()
        {
            List<int> numbers = new List<int> { 3, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, white, unknown };
            Range[] expected = new Range[]
            {
                new Range() { Start = 0, End = 3 },
                new Range() { Start = 5, End = 5 }
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberOneWhiteEndTest()
        {
            List<int> numbers = new List<int> { 3, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, solid, unknown, white };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberOneWhiteStartTest()
        {
            List<int> numbers = new List<int> { 3, 1 };
            FieldType[] fields = new FieldType[] { white, solid, solid, solid, unknown, solid, unknown, unknown };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = holeNumberSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
