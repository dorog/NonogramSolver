using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver.Engine.Data;
using Solver.Engine.Separators.Impl;
using System.Collections.Generic;

namespace Solver.Test.SeparatorTests
{
    [TestClass]
    public class TwoNumberDistanceSeparatorTests
    {
        private readonly TwoNumberDistanceSeparator twoNumberDistanceSeparator = new TwoNumberDistanceSeparator();

        private readonly FieldType solid = FieldType.Solid;
        private readonly FieldType unknown = FieldType.Unknown;

        [TestMethod]
        public void OneNumberRangeTest()
        {
            List<int> numbers = new List<int> { 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, solid, solid, unknown, unknown };
            Range[] expected = new Range[]
            {
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void MoreThanTwoNumberRangeTest()
        {
            List<int> numbers = new List<int> { 1, 1, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, unknown, solid };
            Range[] expected = new Range[]
            {
                null,
                null,
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberTwoSolidButTooCloseRangeTest()
        {
            List<int> numbers = new List<int> { 1, 2 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, unknown, unknown };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberMoreSolidButTooCloseRangeTest()
        {
            List<int> numbers = new List<int> { 1, 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, solid, unknown, solid };
            Range[] expected = new Range[]
            {
                null,
                null
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberTwoSolidAndEnoughSpaceRangeTest()
        {
            List<int> numbers = new List<int> { 1, 1 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, unknown, solid, unknown };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                new Range(){ Start = 3, End = 5 }
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TwoNumberMoreSolidAndEnoughSpaceRangeTest()
        {
            List<int> numbers = new List<int> { 1, 3 };
            FieldType[] fields = new FieldType[] { unknown, solid, unknown, unknown, unknown, solid, unknown, solid };
            Range[] expected = new Range[]
            {
                new Range(){ Start = 0, End = 2 },
                new Range(){ Start = 3, End = 7 },
            };

            var results = twoNumberDistanceSeparator.Separate(numbers, fields);

            CollectionAssert.AreEqual(expected, results);
        }
    }
}
